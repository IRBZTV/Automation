using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Imaging;
using MPLATFORMLib;


namespace MControls
{
    public partial class MPlaylistTimeline : Label
    {
        IMPlaylist m_pPlaylist;

        MImageStore imgFiles = new MImageStore();

        // The displayed time window
        double m_dblTimeWindowSec = 0;

        //Font Font = new Font("Segoe UI Semibold", 8.25f);

        public MPlaylistTimeline()
        {
            InitializeComponent();
            MFramesStore.Root.OnFrameReady += new EventHandler(MFramesStore_OnFrameReady);
        }

        Color blockColorHi = MHelpers.ColorLightBlue;
        public Color BlockColorHi
        {
            get { return blockColorHi; }
            set { blockColorHi = value; }
        }

        Color blockColorLo = MHelpers.ColorDarkBlue;
        public Color BlockColorLo
        {
            get { return blockColorLo; }
            set { blockColorLo = value; }
        }

        Color breakColorHi = Color.Red;
        public Color BreakColorHi
        {
            get { return breakColorHi; }
            set { breakColorHi = value; }
        }

        Color breakColorLo = Color.Maroon;
        public Color BreakColorLo
        {
            get { return breakColorLo; }
            set { breakColorLo = value; }
        }

        Color cmdColorHi = Color.LightGray;
        public Color CmdColorHi
        {
            get { return cmdColorHi; }
            set { cmdColorHi = value; }
        }

        Color cmdColorLo = Color.Gray;
        public Color CmdColorLo
        {
            get { return cmdColorLo; }
            set { cmdColorLo = value; }
        }

        Color backColorHi = Color.FromArgb(222, 232, 254);
        public Color BackColorHi
        {
            get { return backColorHi; }
            set { backColorHi = value; }
        }

        float fNowPos = 0.33f;
        public float NowPos
        {
            get { return fNowPos; }
            set { fNowPos = value; }
        }

        bool bShowFrames = true;
        public bool ShowFrames
        {
            get { return bShowFrames; }
            set { bShowFrames = value; }
        }

        double m_dblScale = 0;

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pPlaylist;
            try
            {
                m_pPlaylist = (IMPlaylist)pObject;

                this.Invalidate();
            }
            catch (System.Exception) { }

            return pOld;
        }

        public void ItemChanged( MItem pItem )
        {
            if (pItem != null)
            {
                imgFiles.ImageSet(pItem, null);
            }
            else
            {
                imgFiles.ImageRemoveAll();
            }
        }

        void MFramesStore_OnFrameReady(object sender, EventArgs e)
        {
            MFramesStore_EventArgs pArg = (MFramesStore_EventArgs)e;

            // Update file image (only if have)
            // TODO: Updated breaks
            if( imgFiles.ImageGet( pArg.pItem ) != null )
                GetFileImage(pArg.pItem, true);
        }

        Image GetFileImage(MItem pItem, bool _bUpdate)
        {
            if (pItem == null)
                return null;

            if (!_bUpdate)
            {
                // Try find in map
                Image img = imgFiles.ImageGet(pItem);
                if (img != null && img.Tag != null && (double)img.Tag == m_dblScale )
                {
                    return img;
                }
            }

            Image imgFile = null;
            StringFormat strFormat = new StringFormat();
            strFormat.Trimming = StringTrimming.None;
            strFormat.FormatFlags = StringFormatFlags.NoWrap;

            try
            {
                double dblPlayTime;
                pItem.ItemPlayTimeGet(out dblPlayTime);

                string strName;
                pItem.FileNameGet(out strName);

                int nWidth = (int)( Time2Pixels(dblPlayTime) + 1.5 );
                int nHeight = this.Height - Font.Height * 2 - 4;

                imgFile = new Bitmap(nWidth, nHeight, PixelFormat.Format32bppArgb);

                Graphics g = Graphics.FromImage(imgFile);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;

                strName = ": " + strName.Substring(strName.LastIndexOf('\\') + 1); ;

                
                // Draw block FG
                RectangleF rcItem = new RectangleF(0, Font.Height + 2, nWidth, nHeight - Font.Height * 2.2f);

                Brush bgBlock = new LinearGradientBrush(rcItem, blockColorLo, blockColorHi, LinearGradientMode.Horizontal);
                Brush brText = new SolidBrush(ForeColor);
                Pen penText = new Pen(brText);
                g.FillRectangle(bgBlock, rcItem.Left, rcItem.Top, rcItem.Width, rcItem.Height);


                // Calc image size
                int nIndent = (int)(rcItem.Height / 10);
                RectangleF rcImage = new RectangleF();
                rcImage.Y = rcItem.Y + nIndent;
                rcImage.Height = rcItem.Height - nIndent * 2;
                rcImage.Width = rcImage.Height * 16 / 9;


                // Draw breaks
                float fLastBreak = rcItem.Left;
                float fFirstBreak = rcItem.Right;
                {
                    IMBreaks pBreaks = (IMBreaks)pItem;
                    int nBreaks; double dblBreaks;
                    pBreaks.BreaksGetCount(out nBreaks, out dblBreaks);

                    for (int b = 0; b < nBreaks; b++)
                    {
                        double dblBreakTime;
                        string strBreakName;
                        MItem pBreakItem;
                        pBreaks.BreaksGetByIndex(b, out dblBreakTime, out strBreakName, out pBreakItem);
                        strBreakName = ": " + strBreakName.Substring(strBreakName.LastIndexOf('\\') + 1);

                        eMStartType eBStartType;
                        M_DATETIME mBStart, mBStop;
                        pBreakItem.ItemTimesGet(out mBStart, out mBStop, out eBStartType);
                        double dblBreakStart = MHelpers.MTime2Sec(mBStart);
                        double dblBreakStop = MHelpers.MTime2Sec(mBStop);

                        // For not put text over previous break
                        float fTextLimit = rcItem.Right;
                        if (b + 1 < nBreaks)
                        {
                            double dblNextTime;
                            string strTemp;
                            MItem pNextBreakItem;
                            pBreaks.BreaksGetByIndex(b + 1, out dblNextTime, out strTemp, out pNextBreakItem);

                            M_DATETIME mBStart2, mBStop2;
                            pNextBreakItem.ItemTimesGet(out mBStart2, out mBStop2, out eBStartType);
                            double dblBreakStart2 = MHelpers.MTime2Sec(mBStart2);

                            fTextLimit = Time2Pixels(dblBreakStart2);

                            Marshal.ReleaseComObject(pNextBreakItem);
                            GC.Collect();
                        }
                        

                        float fBreakWidth = Time2Pixels( dblBreakStop - dblBreakStart );
                        float fBreakStart = Time2Pixels( dblBreakStart);

                        RectangleF rcBreak = new RectangleF(rcItem.Left + fBreakStart, rcItem.Top, fBreakWidth, rcItem.Height);

                        if (rcBreak.Width < 1.0)
                        {
                            Pen penBreak = new Pen(BreakColorLo);

                            g.DrawLine(penBreak, rcBreak.Left, rcBreak.Top - Font.Height / 2, rcBreak.Left, rcBreak.Bottom );
                            g.DrawLine(penBreak, rcBreak.Left, rcBreak.Top - Font.Height / 2, rcBreak.Left + Font.Height / 4, rcBreak.Top - Font.Height / 2);

                            RectangleF rcBString = rcBreak;
                            rcBString.X += Font.Height / 4;
                            rcBString.Y -= Font.Height;
                            rcBString.Width = fTextLimit - rcBString.Left;
                            g.DrawString(MHelpers.ToString(mBStart) + strBreakName, Font, new SolidBrush(BreakColorLo), rcBString, strFormat);
                        }
                        else
                        {
                            // Draw block FG
                            
                            Brush bgBreak;
                            Pen penBreak;


                            // Draw break info
                            eMItemType eBreakType;
                            pBreakItem.ItemTypeGet(out eBreakType);
                            if (eBreakType != eMItemType.eMPIT_Command)
                            {
                                //bgBreak1 = new LinearGradientBrush(rcBreak, BreakColorHi, BreakColorLo, LinearGradientMode.Vertical);
                                bgBreak = new LinearGradientBrush(rcBreak, BreakColorLo, BreakColorHi, LinearGradientMode.Horizontal);

                                penBreak = new Pen(BreakColorLo);

                            }
                            else
                            {
                                //bgBreak1 = new LinearGradientBrush(rcBreak, CmdColorHi, CmdColorLo, LinearGradientMode.Vertical);
                                bgBreak = new LinearGradientBrush(rcBreak, CmdColorLo, CmdColorHi, LinearGradientMode.Horizontal);

                                penBreak = new Pen(CmdColorLo);
                            }

                            g.FillRectangle(bgBreak, rcBreak.Left, rcBreak.Top, rcBreak.Width, rcBreak.Height);

                            g.DrawLine(penBreak, rcBreak.Left, rcBreak.Top - Font.Height / 2, rcBreak.Left, rcBreak.Top);
                            g.DrawLine(penBreak, rcBreak.Left, rcBreak.Top - Font.Height / 2, rcBreak.Left + Font.Height / 4, rcBreak.Top - Font.Height / 2);

                          
                            RectangleF rcBString = rcBreak;
                            rcBString.X += Font.Height / 4;
                            rcBString.Y -= Font.Height;
                            rcBString.Width = fTextLimit - rcBString.Left;
                            g.DrawString(MHelpers.ToString(mBStart) + strBreakName, Font, bgBreak, rcBString, strFormat);

                            // For out point
                            if (b == 0)
                                fFirstBreak = rcBreak.Left;

                            // Check for place for image
                            if (bShowFrames && fBreakStart - fLastBreak > rcImage.Width + nIndent * 2)
                            {
                                // Check for image for break
                                if (b == 0 && fBreakStart > rcImage.Width * 2 + nIndent * 3)
                                {
                                    rcImage.X = fBreakStart - rcImage.Width - nIndent;
                                    MHelpers.DrawRoundImage(g, MFramesStore.Root.FileFrameGet(pItem, dblBreakTime), rcImage, rcImage.Height / 6.0f);
                                }
                                else if (b > 0)
                                {
                                    rcImage.X = fBreakStart - rcImage.Width - nIndent;
                                    MHelpers.DrawRoundImage(g, MFramesStore.Root.FileFrameGet(pItem, dblBreakTime), rcImage, rcImage.Height / 6.0f);
                                }
                            }

                            // Image for break
                            if (bShowFrames && rcBreak.Width > rcImage.Width + nIndent * 2)
                            {
                                rcImage.X = rcBreak.Left + nIndent;
                                MHelpers.DrawRoundImage(g, MFramesStore.Root.FileFrameGetIn(pBreakItem), rcImage, rcImage.Height / 6.0f);

                                if (rcImage.Right + rcImage.Width + nIndent * 2 < rcBreak.Right)
                                {
                                    rcImage.X = rcBreak.Right - nIndent - rcImage.Width;
                                    MHelpers.DrawRoundImage(g, MFramesStore.Root.FileFrameGetOut(pBreakItem), rcImage, rcImage.Height / 6.0f);
                                }
                            }

                            fLastBreak = rcBreak.Right;
                        }

                        Marshal.ReleaseComObject(pBreakItem);
                        GC.Collect();
                    }
                }


                if (bShowFrames)
                {
                    // Draw in point
                    if (fFirstBreak - rcItem.Left > rcImage.Width + nIndent * 2 )
                    {
                        rcImage.X = rcItem.Left + nIndent;
                        MHelpers.DrawRoundImage(g, MFramesStore.Root.FileFrameGetIn(pItem), rcImage, rcImage.Height / 8.0f);
                        // For out point
                        fLastBreak = rcImage.Right > fLastBreak ? rcImage.Right : fLastBreak;
                    }

                    // Draw out point
                    if (rcItem.Right - fLastBreak > rcImage.Width + nIndent * 2)
                    {
                        rcImage.X = rcItem.Right - nIndent - rcImage.Width;
                        MHelpers.DrawRoundImage(g, MFramesStore.Root.FileFrameGetOut(pItem), rcImage, rcImage.Height / 6.0f);
                    }

                    // Draw extra images
                    if (rcImage.X - fLastBreak > rcImage.Width * 8)
                    {
                        rcImage.X = (fLastBreak + rcImage.X) / 2.0f - rcImage.Width / 2.0f;

                        double dblImgPos = Pixels2Time(rcImage.X + rcImage.Width / 2.0f - rcItem.Left);

                        MHelpers.DrawRoundImage(g, MFramesStore.Root.FileFrameGet(pItem, dblImgPos), rcImage, rcImage.Height / 6.0f);
                    }
                }

                // Get start time (for string)
                eMStartType eStartType;
                M_DATETIME mStart, mStop;
                pItem.ItemTimesGet(out mStart, out mStop, out eStartType);

                // Draw file name
                Pen penBlock = new Pen(blockColorLo);
                g.DrawLine(penBlock, rcItem.Left + 1, rcItem.Bottom, rcItem.Left + 1, rcItem.Bottom + Font.Height / 2);
                g.DrawLine(penBlock, rcItem.Left + 1, rcItem.Bottom + Font.Height / 2, rcItem.Left + Font.Height / 4, rcItem.Bottom + Font.Height / 2);

                RectangleF rcString = rcItem;
                rcString.X += Font.Height / 4;
                rcString.Y = rcItem.Bottom;
                g.DrawString(MHelpers.ToString(mStart) + strName, Font, brText, rcString, strFormat);
                g.Dispose();

                imgFile.Tag = m_dblScale;
                imgFiles.ImageSet(pItem, imgFile);
            }
            catch (System.Exception ex)
            {
            }

            return imgFile;
        }

        Bitmap imgTimeBG;
        long lTimeBG_End = 0;
        long lTimeBG_Start = 0;
        void PrepareTimeBG(long lMin, long lMax, double dblScale)
        {
            // Create image
            imgTimeBG = new Bitmap(this.Bounds.Width * 8, this.Bounds.Height);

            Graphics g = Graphics.FromImage(imgTimeBG);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            int nRisks = 16;
            double dblStepSec = (lMax - lMin) / 10000000.0 / nRisks;

            // Convert to round value e.g. 1 sec, 2 sec, 5 sec, 10 sec, 15 sec, 30 sec, 1 min, 2 min, 5 min 10 min 15 min 30 min 1 hour
			long lStep = 7200;
            long[] arrSeconds = new long[] { 1, 2, 5, 10, 15, 30, 60, 120, 300, 600, 900, 1800, 3600, 7200 };
            for (int i = 0; i < arrSeconds.Length - 1; i++)
            {
                if (arrSeconds[i] < dblStepSec && dblStepSec <= arrSeconds[i + 1])
                {
                    lStep = arrSeconds[i + 1]; // Convert to file time
                    break;
                }
            }

            RectangleF rcBrush = new RectangleF(0, 0, (float)(lStep * dblScale), imgTimeBG.Height);
            Brush brBG = new SolidBrush(this.BackColorHi);
            Brush brBGSel = new LinearGradientBrush(rcBrush, this.BackColor, this.BackColorHi, LinearGradientMode.Vertical);
            Brush brText = new SolidBrush(this.ForeColor);
            Pen penText = new Pen(brText);
            Point ptPos = new Point();

            lTimeBG_Start = ((long)lMin / (lStep * 10000000)) * (lStep * 10000000);
            int nIndex = 0;
            while( true )
            {
                // Draw risks
                float fPosX = (float)((nIndex * lStep) * dblScale);
                float fWidth = (float)(lStep * dblScale);

                    // Draw sel
                g.FillRectangle( nIndex % 2 == 0 ? brBGSel : brBG, fPosX, 0, fWidth, imgTimeBG.Height);
                
              //  g.DrawLine(penText, fPosX, 0.0f, fPosX, Font.Height);

                // Draw text
                long lPos = lTimeBG_Start + lStep * nIndex * 10000000;
                g.DrawString(DateTime.FromFileTime(lPos).ToString("HH:mm:ss"), Font, brText, fPosX, 0.0f );

                if (fPosX + fWidth >= imgTimeBG.Width)
                    break;

                nIndex++;
            }

            g.Dispose();

            lTimeBG_End = lTimeBG_Start + lStep * nIndex * 10000000;
        }

        private void UpdateScale( double _dblWindowSec )
        {
            // 1024 pix -> _dblWindowSec
            long lWindow = (long)(_dblWindowSec);
            double dblScale = 1024.0 / lWindow;

            if( dblScale != m_dblScale )
                imgTimeBG = null;

            m_dblScale = dblScale;
        }

        private float Time2Pixels(double dblPos)
        {
            return (float)(dblPos * m_dblScale);
        }
        private double Pixels2Time(float fPixels)
        {
            return m_dblScale > 0 ? (double)fPixels / m_dblScale : 0.0;
        }

        private void MPlaylistTimeline_Paint(object sender, PaintEventArgs e)
        {
            if (m_dblTimeWindowSec == 0)
            {
                if (m_pPlaylist == null)
                {
                    UpdateScale(600.0);
                }
                else
                {
                    // Get average file duration
                    int nFiles = 0;
                    double dblDuration = 0;
                    m_pPlaylist.PlaylistGetCount(out nFiles, out dblDuration);
                    if( nFiles > 0 )
                    {
                        double dblAvgLen = dblDuration / nFiles * 2.0;
                        // Set windows max for show two average bit not less than 30 sec
                        UpdateScale(Math.Max(dblAvgLen, 30.0));
                    }
                    else
                    {
                        UpdateScale(600.0);
                    }
                }
            }
            else
            {
                UpdateScale(m_dblTimeWindowSec);
            }

            float fNowOffset = this.Bounds.Width * fNowPos;

            // Draw background
            DateTime dtNow = DateTime.Now; // -> fNowOffset
            long lMin = dtNow.AddSeconds(-1 * Pixels2Time(fNowOffset)).ToFileTime();
            long lMax = dtNow.AddSeconds(Pixels2Time(this.Bounds.Width - fNowOffset) ).ToFileTime();

            {
                if (lTimeBG_Start > lMin || lTimeBG_End < lMax || imgTimeBG == null || imgTimeBG.Height != this.Height)
                    PrepareTimeBG(lMin, lMax, m_dblScale);

                float fOffset = Time2Pixels( (lTimeBG_Start - lMin) / 10000000.0);
                e.Graphics.DrawImage(imgTimeBG, fOffset, 0.0f);
            }

            

            // Draw playlist images
            // TODO: Shceduled items
            if (m_pPlaylist != null)
            {

                // This position should be at fNowOffset
                double dblPlayPos = 0;
                ((IMFile)m_pPlaylist).FilePosGet(out dblPlayPos);

                int nFiles = 0;
                double dblDuration = 0;
                m_pPlaylist.PlaylistGetCount(out nFiles, out dblDuration);

                for (int i = 0; i < nFiles; i++)
                {
                    double dblFileStart;
                    string strFileName;
                    MItem pFileItem;
                    m_pPlaylist.PlaylistGetByIndex(i, out dblFileStart, out strFileName, out pFileItem );

                    eMItemType eType;
                    pFileItem.ItemTypeGet(out eType);
                    if (eType != eMItemType.eMPIT_Command)
                    {
                        double dblFilePlayTime;
                        pFileItem.ItemPlayTimeGet(out dblFilePlayTime);

                        float fStartPix = Time2Pixels(dblFileStart - dblPlayPos) + fNowOffset;
                        float fEndPix = Time2Pixels(dblFileStart + dblFilePlayTime - dblPlayPos) + fNowOffset;

                        if (fEndPix > 0 && fStartPix < this.Width)
                        {
                            // Draw file image
                            Image imgFile = GetFileImage(pFileItem, false);

                            e.Graphics.DrawImage(imgFile, fStartPix, Font.Height + 1.0f);
                        }
                    }
                    Marshal.ReleaseComObject(pFileItem);
                    GC.Collect();
                }
                
            }


            //    return;

            //             int nRisks = 10; 
            //             double dblStepSec = m_dblTimeWindowSec / nRisks;
            // 
            // 
            //             // Convert to round value e.g. 1 sec, 2 sec, 5 sec, 10 sec, 15 sec, 30 sec, 1 min, 2 min, 5 min 10 min 15 min 30 min 1 hour
            //             long lStep = 0;
            //             long [] arrSeconds = new long[] { 1, 2, 5, 10, 15, 30, 60, 120, 300, 600, 900, 1800, 3600, 7200 };
            //             for( int i = 0; i < arrSeconds.Length - 1; i++ )
            //             {
            //                 if( arrSeconds[i] < dblStepSec && dblStepSec <= arrSeconds[i+1] )
            //                 {
            //                     lStep = arrSeconds[i+1] * 10000000; // Convert to file time
            //                     break;
            //                 }
            //             }
            // 
            //             //e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            // 
            //             if( lStep == 0 )
            //                 lStep = arrSeconds[ arrSeconds.Length - 1] * 10000000;
            // 
            //             Brush brBlack = new SolidBrush(Color.Black);
            //             Pen penBlack = new Pen(brBlack);
            // 
            //             Brush brText = new SolidBrush(this.ForeColor);
            //             Pen penText = new Pen(brText);
            //             Point ptPos = new Point();
            //             // Draw risks
            //             long lPos = ((long)lMin / lStep + 1) * lStep;
            //             while( lPos < lMax )
            //             {
            //                 // Draw risks
            //                 float fPosX = (float)((lPos - lMin) * dblScale);
            //                 e.Graphics.DrawLine(penText, fPosX, 0.0f, fPosX, Font.Height);
            // 
            //                 // Draw text
            //                 e.Graphics.DrawString(DateTime.FromFileTime(lPos).ToString("HH:mm:ss"), Font, brText, fPosX + 2.0f, 0);
            // 
            //                 lPos += lStep;
            //             }

            // Draw playlist pos
            //  DrawPlaylist(lMin, lMax, e);

            // Draw current pos
            {
                float fPosX = Time2Pixels((dtNow.ToFileTime() - lMin) /10000000.0);
                e.Graphics.DrawLine(Pens.Red, fPosX, 0.0f, fPosX, (float)(this.Bounds.Height));

                // Draw text
                e.Graphics.DrawString(dtNow.ToString("HH:mm:ss.fff"), Font, Brushes.Red, fPosX + 2.0f, this.Bounds.Height - Font.Height);
            }
        }

        private void MPlaylistTimeline_MouseClick(object sender, MouseEventArgs e)
        {
            // Convert mouse pos to playlist pos
            
            // Draw playlist images
            // TODO: Shceduled items
            if (m_pPlaylist != null)
            {
                float fNowOffset = this.Bounds.Width * fNowPos;

                // This position should be at fNowOffset
                double dblPlayPos = 0;
                ((IMFile)m_pPlaylist).FilePosGet(out dblPlayPos);

                double dblClickPos = Pixels2Time(e.Location.X - fNowOffset);
                dblPlayPos += dblClickPos;

                if (dblPlayPos > 0 )
                    ((IMFile)m_pPlaylist).FilePosSet(dblPlayPos,0.5);
            }
        }

//         private void DrawPlaylist(long lMin, long lMax, PaintEventArgs e)
//         {
//             double dblScale = (double)this.Bounds.Width / (lMax - lMin);
// 
//             if (m_pPlaylist != null)
//             {
//                 try
//                 {
//                     int nFiles = 0;
//                     double dblDuration = 0;
//                     m_pPlaylist.PlaylistGetCount(out nFiles, out dblDuration);
//                     for (int i = 0; i < nFiles; i++)
//                     {
//                         double dblPos;
//                         string strPath;
//                         MItem pFileObj;
//                         m_pPlaylist.PlaylistGetByIndex(i, out dblPos, out strPath, out pFileObj);
// 
//                         e.Graphics.DrawImage(GetFileBlock(pFileObj, dblScale, m_bUpdateImages), 0, Font.Height + 1);
// 
//                         break;
//                     }
// 
//                     return;


//                     int nIndex, nNextIndex;
//                     double dblPos, dblListPos;
//                     m_pPlaylist.PlaylistPosGet(out nIndex, out nNextIndex, out dblPos, out dblListPos);
// 
//                     MItem pCurrent = null;
//                     double dblFileStart;
//                     string sPath;
//                     m_pPlaylist.PlaylistGetByIndex(nIndex, out dblFileStart, out sPath, out pCurrent);
// 
//                     // Only current playing item have valid times 
//                     M_DATETIME mStart, mStop;
//                     eMStartType eStartType;
//                     pCurrent.ItemTimesGet(out mStart, out mStop, out eStartType);
// 
//                     long lStart = MHelpers.MTime2FileTime(mStart);
//                     long lStop = MHelpers.MTime2FileTime(mStop);
// 
// 
//                     DrawBlock(lMin, lMax, lStart, lStop, e, pCurrent, MHelpers.ColorLightBlue );

//                     int nFiles = 0;
//                     double dblDuration = 0;
//                     m_pPlaylist.PlaylistGetCount(out nFiles, out dblDuration);
//                     for (int i = 0; i < nFiles; i++)
//                     {
//                         double dblPos;
//                         string strPath;
//                         MItem pFileObj;
//                         m_pPlaylist.PlaylistGetByIndex(i, out dblPos, out strPath, out pFileObj);
// 
//                         DrawItem(lMin, lMax, e, pFileObj);
//                     }
//                 }
//                 catch (System.Exception ex)
//                 {
//                 }
//             }
//         }

//         private int DrawItem( long lMin, long lMax, PaintEventArgs e, MItem pItem )
//         {
//             M_DATETIME mStart, mStop;
//             eMStartType eStartType;
//             pItem.ItemTimesGet(out mStart, out mStop, out eStartType);
// 
//             long lStart = MHelpers.MTime2DateTime(mStart).ToFileTime();
//             long lStop = MHelpers.MTime2DateTime(mStop).ToFileTime();
// 
//             // Draw item rect
//             if (lStop <= lMin )
//                 return -1;
//             if (lStart >= lMax)
//                 return 1;
// 
//             {
//                 double dblScale = (double)this.Bounds.Width / (lMax - lMin);
// 
//                 Brush brBlue = new SolidBrush(MHelpers.ColorDarkBlue);
//                 Brush brLightBlue = new SolidBrush(MHelpers.ColorLightBlue);
//                 Pen penBlue = new Pen(brBlue);
// 
//                 float fPosX = (float)((lStart - lMin) * dblScale);
//                 float fWidth = (float)((lStop - lStart) * dblScale);
// 
//                 // Draw rect
// 
//                 RectangleF rcItem = new RectangleF(fPosX, this.Bounds.Height / 5.0f, fWidth, this.Bounds.Height / 2.0f );
//                 e.Graphics.FillRectangle(brLightBlue, rcItem.Left, rcItem.Top, rcItem.Width, rcItem.Height);
//                 e.Graphics.DrawRectangle(penBlue, rcItem.Left, rcItem.Top, rcItem.Width, rcItem.Height);
// 
//                 // Draw breaks
//                 try
//                 {
//                     IMBreaks pBreaks = (IMBreaks)pItem;
//                     int nBreaks; double dblBreaks;
//                     pBreaks.BreaksGetCount(out nBreaks, out dblBreaks);
// 
//                     for (int i = 0; i < nBreaks; i++)
//                     {
//                         double dblTime;
//                         string strPath;
//                         MItem pBreakItem;
//                         pBreaks.BreaksGetByIndex(i, out dblTime, out strPath, out pBreakItem);
//                     }
//                 }
//                 catch (System.Exception ex)
//                 {
//                 	
//                 }
//                 
// 
//                 
// 
//                 // Draw frames
// 
// 
//                 // Draw time risk
//                 float fPosTime = (float)this.Bounds.Height / 5 + (float)this.Bounds.Height / 2;
//                 e.Graphics.DrawLine(penBlue, rcItem.X, rcItem.Bottom, 
//                     rcItem.X, rcItem.Bottom + Font.Height + 2 );
// 
//                 // Draw text
//                 e.Graphics.DrawString(DateTime.FromFileTime(lStart).ToString("HH:mm:ss"), Font, brBlue, rcItem.X + 2.0f, rcItem.Bottom);
//             }
// 
//             return 0;
//         }

//         private int DrawBlock(long lMin, long lMax, long lStart, long lStop, PaintEventArgs e, MItem pItem, Color fill)
//         {
//            
// 
//             // Draw item rect
//             if (lStop <= lMin)
//                 return -1;
//             if (lStart >= lMax)
//                 return 1;
// 
//             {
//                 eMItemType eType;
//                 pItem.ItemTypeGet(out eType);
//                 string strName = "", S1, S2;
//                 if (eType == eMItemType.eMPIT_File)
//                 {
//                     pItem.FileNameGet(out strName);;
//                     strName = ": " + strName.Substring(strName.LastIndexOf('\\') + 1);;
//                 }
// 
// 
//                 double dblScale = (double)this.Bounds.Width / (lMax - lMin);
// 
//                 float fPosX = (float)((lStart - lMin) * dblScale);
//                 float fWidth = (float)((lStop - lStart) * dblScale);
// 
//                 int nIndent = 3;
// 
//                 // Draw rect
// 
//                 RectangleF rcItem = new RectangleF(fPosX, Font.Height * 2 + nIndent * 2, fWidth, this.Bounds.Height  - Font.Height * 4 - nIndent * 4 );
// 
//                 Brush bgGradient = new LinearGradientBrush(rcItem, MHelpers.ColorDarkBlue, MHelpers.ColorLightBlue, LinearGradientMode.Vertical);
//                 Brush brBlue = new SolidBrush(MHelpers.ColorDarkBlue);
//                 Brush brFill = new SolidBrush(fill);
//                 Pen penBlue = new Pen(brBlue);
// 
//                 e.Graphics.FillRectangle(bgGradient, rcItem.Left, rcItem.Top, rcItem.Width, rcItem.Height);
//                 //e.Graphics.DrawRectangle(penBlue, rcItem.Left, rcItem.Top, rcItem.Width, rcItem.Height);
// 
//                 
//                 // Draw frames (In)
//                 
//                 RectangleF rcImageIn = rcItem;
//                 rcImageIn.Height -= nIndent * 2;
//                 rcImageIn.Y += nIndent;
//                 rcImageIn.X += nIndent;
//                 rcImageIn.Width = rcImageIn.Height * 16.0f / 9.0f;
//                 if (rcItem.Right > rcImageIn.Right + nIndent )
//                 {
//                     e.Graphics.DrawImage( MHelpers.FileFrameGetIn(pItem), rcImageIn );
//                 }
// 
//                 RectangleF rcImageOut = rcImageIn;
//                 rcImageOut.X = rcItem.Right - nIndent - rcImageOut.Width;
//                 if (rcImageOut.Left > rcImageIn.Right + nIndent)
//                 {
//                     e.Graphics.DrawImage(MHelpers.FileFrameGetOut(pItem), rcImageOut);
//                 }
// 
//                 // Draw breaks
//                 try
//                 {
//                     IMBreaks pBreaks = (IMBreaks)pItem;
//                     int nBreaks; double dblBreaks;
//                     pBreaks.BreaksGetCount(out nBreaks, out dblBreaks);
// 
//                     long lBreaksDuration = 0;
//                     for (int i = 0; i < nBreaks; i++)
//                     {
//                         double dblTime;
//                         string strPath;
//                         MItem pBreakItem;
//                         pBreaks.BreaksGetByIndex(i, out dblTime, out strPath, out pBreakItem);
// 
//                         M_DATETIME mStart, mStop;
//                         eMStartType eStartType;
//                         pBreakItem.ItemTimesGet(out mStart, out mStop, out eStartType);
// 
//                         long lBreakStart = (long)(MHelpers.MTime2Sec(mStart) * 10000000);
//                         long lBreakStop = (long)(MHelpers.MTime2Sec(mStop) * 10000000);
//                         
//                         
//                         DrawBlock(lMin, lMax, lStart + lBreakStart, lStart + lBreakStop, e, pBreakItem, Color.Red );
//                     }
//                 }
//                 catch (System.Exception ex)
//                 {
//                 	
//                 }
// 
//                 // Draw time risk
//                 float fPosTime = (float)this.Bounds.Height / 5 + (float)this.Bounds.Height / 2;
//                 e.Graphics.DrawLine(penBlue, rcItem.X, rcItem.Bottom,
//                     rcItem.X, rcItem.Bottom + Font.Height + 2.0f);
// 
//                 // Draw text
//                 RectangleF rcString = rcItem;
//                 rcString.X += 2.0f;
//                 rcString.Width -= 4.0f;
//                 rcString.Y = rcItem.Bottom;
//                 rcString.Height = Font.Height;
//                 e.Graphics.DrawString(DateTime.FromFileTime(lStart).ToString("HH:mm:ss") + strName, Font, brBlue, 
//                     rcString);
//             }
// 
//             return 0;
//         }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

       
    }
}
