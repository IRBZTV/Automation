using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Text;
using System.Drawing;

using MPLATFORMLib;

namespace MControls
{
   

    class MImageStore
    {
        // Resulting frames
        private HybridDictionary mapFrames = new HybridDictionary();

        public Image ImageGet(object key)
        {
            lock (mapFrames.SyncRoot)
            {
                if (mapFrames.Contains(key))
                    return (Image)mapFrames[key];

                return null;
            }
        }

        public Image ImageSet(object key, Image pImage)
        {
            lock (mapFrames.SyncRoot)
            {
                Image pPrev = null;
                if (mapFrames.Contains(key))
                {
                    pPrev = (Image)mapFrames[key];
                    if (pImage != null)
                        mapFrames[key] = pImage;
                    else
                        mapFrames.Remove(key);
                }
                else if (pImage != null)
                {
                    mapFrames.Add(key, pImage);
                }

                return pPrev;
            }
        }

        public void ImageRemoveAll()
        {
            lock (mapFrames.SyncRoot)
            {
                mapFrames.Clear();
            }
        }

        public void ImageRemove(object key)
        {
            lock (mapFrames.SyncRoot)
            {
                mapFrames.Remove(key);
            }
        }
    };

    public class MFramesStore_EventArgs : EventArgs
    {
        public string sKey;
        public MItem pItem;
        public double dblPos;
        public Image img;

        public MFramesStore_EventArgs(MItem _pItem, double _dblPos, Image _img)
        {
            pItem = _pItem;
            dblPos = _dblPos;
            img = _img;
        }
    };

    class MFramesStore : MImageStore
    {
        public static MFramesStore Root = new MFramesStore();

        // Called if user change playlist selection
        public event EventHandler OnFrameReady;

        // The maximum size
        private Size szImageMax;

        // Special map for out frame (used in play-while-rec), keep last out pount
        // Used for return previous pic if new not updated and for remove last out after updated
        // map: file_name -> out_point (last valid)
        private HybridDictionary mapOutPoints = new HybridDictionary();

        public MFramesStore()
        {
            deqReqest = new Queue<Request>();
            hHaveRequest = new EventWaitHandle(false, EventResetMode.AutoReset);
          
            // Maximum image size
            szImageMax = new Size(256, 256);
        }

        //////////////////////////////////////////////////////////////////////////
        // Public methods

        public Size FrameSizeMax
        {
            get { return szImageMax; }
            set { szImageMax = value; }
        }

        public Image FileFrameGetIn(MItem pItem)
        {
            double dblIn = 0, dblOut = 0, dblFileLen = 0;
            pItem.FileInOutGet(out dblIn, out dblOut, out dblFileLen);

            return FileFrameGet(pItem, dblIn);
        }

		public Image FileFrameGetOut(MItem pItem)
		{
			double dblIn = 0, dblOut = 0, dblFileLen = 0;
			pItem.FileInOutGet(out dblIn, out dblOut, out dblFileLen);
			dblOut = dblOut > dblIn ? dblOut : dblFileLen;

			return FileFrameGet(pItem, dblOut);
		}

        public Image FileFrameGetOut_Update(MItem pItem)
        {
            double dblIn = 0, dblOut = 0, dblFileLen = 0;
            pItem.FileInOutGet(out dblIn, out dblOut, out dblFileLen);
            dblOut = dblOut > dblIn ? dblOut : dblFileLen;
            

            string sKeyOut;
            pItem.FileNameGet(out sKeyOut);

            Image imgRes = FileFrameGet(pItem, dblOut);
            
                // Check for previous out point
            double dblLastOut = -1;
            lock (mapOutPoints.SyncRoot)
            {
                if (mapOutPoints.Contains(sKeyOut))
                {
                    // Have previous out 
                    dblLastOut = (double)mapOutPoints[sKeyOut];

                    // Remove if update succesfull
                    if (imgRes != null)
                        mapOutPoints[sKeyOut] = dblOut;
                }
                else if (imgRes != null)
                {
                    // Add if update succesfull
                    mapOutPoints.Add(sKeyOut, dblOut);
                }
            }


            if (dblLastOut >= 0)
            {
                if (imgRes != null)
                    ImageRemove(StringKey(pItem, dblLastOut)); // Remove prev out point image
                else
                    imgRes = FileFrameGet(pItem, dblLastOut); // Return prev out point image
            }

            return imgRes;
            
        }

        public Image FileFrameGet(MItem pItem, double dblPos)
        {
            Image img = ImageGet(StringKey(pItem, dblPos));
            if( img != null )
                return img;

            if (reqThread == null || !reqThread.IsAlive)
            {
                reqThread = new Thread(new ThreadStart(Request_Thread));
                reqThread.Start();
            }
            

            Request_Add(pItem, dblPos);
            return null;
        }

        

        public Image FileFrameGet_Direct(MItem pItem, double dblPos)
        {
            try
            {
                // The exception may occurs (e.g. for MLive)
                MFrame mFrame;
                pItem.FileFrameGet(dblPos, 0, out mFrame);
                Image imgFrame = MHelpers.FrameGetBitmap(mFrame);

                // Update size and use copy as imgFrame valid only till MFrame alive
                double dblScaleX = (double)szImageMax.Width / imgFrame.Size.Width;
                double dblScaleY = (double)szImageMax.Height / imgFrame.Size.Height;
                Size szImage = new Size((int)(imgFrame.Size.Width * Math.Max(dblScaleX, dblScaleY)),
                    (int)(imgFrame.Size.Height * Math.Max(dblScaleX, dblScaleY)));
                Bitmap img = new Bitmap(imgFrame, szImage);

                if (img != null && img.Width > 0)
                {
                    ImageSet( StringKey(pItem, dblPos), img);

                    return img;
                }
            }
            catch (System.Exception) { }

            return null;
        }

        //////////////////////////////////////////////////////////////////////////
        // Private methods
        private class Request
        {
            public MItem pItem;
            public double dblPos;

            public Request(MItem _pItem, double _dblPos)
            {
                pItem = _pItem;
                dblPos = _dblPos;
            }

			public bool IsSame(Request pCompare)
			{
				if (pItem.Equals(pCompare.pItem) && dblPos == pCompare.dblPos)
					return true;

				return false;
			}
        };

        // For frames request
        private Thread reqThread;
        private EventWaitHandle hHaveRequest;
        private Queue<Request> deqReqest;
        private bool bThreadStop = false;

        ~MFramesStore()
        {
            if (reqThread != null)
            {
                bThreadStop = true;
                hHaveRequest.Set();
            }
        }

        private string StringKey(MItem pItem, double dblPos)
        {
            string sKey;
            pItem.FileNameGet(out sKey);
            sKey += "|" + dblPos.ToString("0.00");
            return sKey;
        }

        private void Request_Thread()
        {
            while (!bThreadStop)
            {
                // Wait one second -> if no new requests -> end thread
                bool bWaitOk = hHaveRequest.WaitOne(1000);
                
                Request req;
                lock( deqReqest )
                {
					if (deqReqest.Count > 0)
						req = deqReqest.Peek();
					else
					{
						if (bWaitOk)
							continue;
						else
							break;
					}

                    
                }

                // Check current map
				string strKey = StringKey(req.pItem, req.dblPos);
				if (ImageGet( strKey ) == null)
				{
					Image img = FileFrameGet_Direct(req.pItem, req.dblPos);

					// Notify about new image
					if (img != null && this.OnFrameReady != null)
						this.OnFrameReady(this, new MFramesStore_EventArgs(req.pItem, req.dblPos, img));
				}

				lock (deqReqest)
				{
					deqReqest.Dequeue();

					if (deqReqest.Count > 0)
						hHaveRequest.Set();
				}
            }
        }

        private bool Request_Add(MItem pItem, double dblPos)
        {
            Request req = new Request(pItem, dblPos);

            lock (deqReqest)
            {
				// Check for same request
				foreach (Request checkReq in deqReqest)
				{
					if( checkReq.IsSame( req ) )
						return false;
				}
        
				deqReqest.Enqueue(req);
            }
            hHaveRequest.Set();
			return true;
        }
    }

    
}
