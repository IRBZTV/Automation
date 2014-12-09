using System;
using System.Collections.Generic;
using System.Text;
using MPLATFORMLib;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MControls
{
    public class MHelpers
    {
        public static Color ColorActive
        {
            get
            {
                return Color.Red;// Color.FromArgb(255, 72, 0);
            }
        }

        public static Color ColorReady
        {
            get
            {
                return Color.Green;// FromArgb(122, 192, 36);
            }
        }

        public static Color ColorDarkBlue
        {
            get
            {
                return Color.FromArgb(0, 92, 144);
            }
        }

        public static Color ColorLightBlue
        {
            get
            {
                return Color.FromArgb(52, 152, 212);
            }
        }

        public static Color ColorBGBlue
        {
            get
            {
                return Color.FromArgb(222, 232, 254);
            }
        }

        public static string ToString(M_VID_PROPS vidProps)
        {
            return vidProps.nWidth.ToString() + "x" + vidProps.nHeight + "@" + vidProps.dblRate.ToString("00.00") + " " +
                vidProps.nAspectX.ToString() + ":" + vidProps.nAspectY.ToString() + " " +
                vidProps.eInterlace.ToString();
        }

        public static string ToString(M_AUD_PROPS audProps)
        {
            return ((double)audProps.nSamplesPerSec / 1000).ToString("0.00") + "KHz " + audProps.nChannels.ToString() + "Ch " + audProps.nBitsPerSample.ToString() + "Bits";
        }

        public static string ToString(M_DATETIME mTime)
        {
            string strRes = "";
            if (mTime.nYear > 0)
            {
                strRes = string.Format("{0,0:00}.{1,0:00}.{2,0:0000} {3,0:00}:{4,0:00}:{5,0:00}", mTime.nDay, mTime.nMonth, mTime.nYear, mTime.nHour, mTime.nMinute, mTime.nSecond);
            }
            else
            {
                strRes = string.Format("{0,0:00}:{1,0:00}:{2,0:00}", mTime.nHour, mTime.nMinute, mTime.nSecond);
            }         
            return strRes;
            //return mTime.nHour.ToString("00") + ":" + mTime.nMinute.ToString("00") + ":" + mTime.nSecond.ToString("00");
        }

        public static string ToString(M_DATETIME mTime, bool _bMSec)
        {
            return mTime.nHour.ToString("00") + ":" + mTime.nMinute.ToString("00") + ":" + mTime.nSecond.ToString("00") + "." +
                mTime.nMilliseconds.ToString("000");
        }

        public static string PosToString(double _dblPos)
        {
            return PosToString(_dblPos, -1);
        }

        // _nUseMsec = 0 -> No msec
        // _nUseMsec = 1 -> Use msec
        // _nUseMsec = -1 -> Auto
        public static string PosToString(double _dblPos, int _nUseMsec)
        {
            bool bReverse = _dblPos >= 0 ? false : true;
            if (bReverse)
                _dblPos *= -1;

            int nHour = (int)_dblPos / 3600;
            int nMinutes = ((int)_dblPos % 3600) / 60;
            int nSec = ((int)_dblPos % 60);
            _dblPos -= (int)_dblPos;
            int nMsec = (int)(_dblPos * 1000 + 0.01); // For rounding
            nMsec = nMsec >= 1000 ? 999 : nMsec;

            if (_nUseMsec < 0)
                _nUseMsec = nMsec > 0 ? 1 : 0;

            string strRes = (bReverse ? "-" : "") + nHour.ToString("00") + ":" + nMinutes.ToString("00") + ":" + nSec.ToString("00")
                + (_nUseMsec > 0 ? "." + nMsec.ToString("000") : "");

            return strRes;
        }

        public static M_DATETIME ParseTime(string _strTime)
        {
            return ParseTime(_strTime, 25.0);
        }

        public static M_DATETIME ParseTime(string _strTime, double _dblRate)
        {
            return ParseTime(_strTime, _dblRate, false );
        }

        public static M_DATETIME ParseDateTime(string _strDateTime)
        {
            M_DATETIME m_dtRes = new M_DATETIME();
            DateTime dtParse;
            bool valid = DateTime.TryParse(_strDateTime, null, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dtParse);
            if (valid)
            {
                m_dtRes.nYear = dtParse.Year >= 1 ? dtParse.Year : 0;
                m_dtRes.nMonth = dtParse.Month >= 1 ? dtParse.Month : 0;
                m_dtRes.nDay = dtParse.Day >= 1 ? dtParse.Day : 0;
                m_dtRes.nHour = dtParse.Hour;
                m_dtRes.nMinute = dtParse.Minute;
                m_dtRes.nSecond = dtParse.Second;
            }
            return m_dtRes;

        }

        public static M_DATETIME ParseTime(string _strTime, double _dblRate, bool _bForceSec )
        {
            M_DATETIME mTime = new M_DATETIME();
            // Check for negative time
            _strTime = _strTime.Trim();
            bool bNegative = false;
            if(_strTime.Length > 0 && _strTime[0] == '-')
            {
                // Remove -1
                bNegative = true;
                _strTime = _strTime.Substring(1);
            }

            // Get milliseconds
            int nMsecPos = _strTime.LastIndexOf(".");
            if (nMsecPos >= 0)
            {
                double dblMsec = 0;
                double.TryParse(_strTime.Substring(nMsecPos), out dblMsec);
                mTime.nMilliseconds = (int)(dblMsec * 1000);
                _strTime = _strTime.Substring(0, nMsecPos);
            }

            // Parse other type
            string [] arrParts = _strTime.Split(':');
            if (arrParts.Length == 1)
            {
                // e.g. 10 or 10.100
                Int32.TryParse(arrParts[0], out mTime.nSecond);
            }
            else if (arrParts.Length == 2)
            {
                if (nMsecPos >= 0 || _bForceSec)
                {
                    // e.g. 12:10.100 -> 12 min 10 sec 100 msec
                    Int32.TryParse(arrParts[0], out mTime.nMinute);
                    Int32.TryParse(arrParts[1], out mTime.nSecond);
                }
                else 
                {
                    // e.g. 12:10 -> 12h 10 min
                    Int32.TryParse(arrParts[0], out mTime.nHour);
                    Int32.TryParse(arrParts[1], out mTime.nMinute);
                }
            }
            else if (arrParts.Length >= 3)
            {
                // e.g. 12:10:05 -> 12h 10 min 5 sec
                Int32.TryParse(arrParts[0], out mTime.nHour);
                Int32.TryParse(arrParts[1], out mTime.nMinute);
                Int32.TryParse(arrParts[2], out mTime.nSecond);

                if (arrParts.Length >= 4)
                {
                    // 12:10:05:10  -> timecode (ignore .xxx if have e.g. 12:10:05:10.100 -> 12:10:05:10)
                    Int32.TryParse(arrParts[3], out mTime.nMilliseconds);

                    // Update milliseconds according to rate
                    _dblRate = _dblRate > 0 ? _dblRate : 25.0;
                    mTime.nMilliseconds = (int)(mTime.nMilliseconds * 1000 / _dblRate);
                }
            }

            if (bNegative)
            {
                mTime.nHour *= -1;
                mTime.nMinute *= -1;
                mTime.nSecond *= -1;
                mTime.nMilliseconds *= -1;
            }

            return mTime;
        }

        public static double ParsePos(string _strTime)
        {
            M_DATETIME mTime = ParseTime(_strTime, 25.0, true );
            return mTime.nHour * 3600 + mTime.nMinute * 60 + mTime.nSecond + (double)mTime.nMilliseconds / 1000.0;
        }

        // Conversion
        public static DateTime MTime2DateTime(M_DATETIME _mTime)
        {
            DateTime dtTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                _mTime.nHour, _mTime.nMinute, _mTime.nSecond, _mTime.nMilliseconds);

            return dtTime;
        }

        public static double MTime2Sec(M_DATETIME mTime)
        {
            return mTime.nHour * 3600 + mTime.nMinute * 60 + mTime.nSecond + (double)mTime.nMilliseconds / 1000.0;
        }

        public static long MTime2FileTime(M_DATETIME mTime)
        {
            if (mTime.nDay > 0)
            {
                DateTime dtTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                    mTime.nHour, mTime.nMinute, mTime.nSecond, mTime.nMilliseconds);

                return dtTime.ToFileTime();
            }

            return ((mTime.nHour * 3600 + mTime.nMinute * 60 + mTime.nSecond) * 1000 + mTime.nMilliseconds) * 10000L;
        }

        // Construct Image from MFrame 
        // WARNING !!! This bitmap valid till valid MFrame
        static public Bitmap FrameGetBitmap(MFrame pFrame)
        {
            // Get image bytes
            int nSize = 0;
            long pImage32 = 0;
            pFrame.FrameVideoGetBytes(out nSize, out pImage32);

            // Get A/V props (for image size)
            M_AV_PROPS avProps;
            pFrame.FrameAVPropsGet(out avProps);

            // The RGB images is bottom-top if height is positive
            if (avProps.vidProps.nHeight > 0)
            {
                pImage32 += (avProps.vidProps.nHeight - 1) * avProps.vidProps.nRowBytes;
                avProps.vidProps.nRowBytes *= -1;
            }
            else
            {
                avProps.vidProps.nHeight *= -1;
            }

            // Note - this bitmap contain reference to MFrame data
            Bitmap bmpFrame = new Bitmap(avProps.vidProps.nWidth, avProps.vidProps.nHeight, avProps.vidProps.nRowBytes,
                System.Drawing.Imaging.PixelFormat.Format32bppPArgb, new IntPtr(pImage32));

            return bmpFrame;
        }

        static public bool PictureBoxSetImage(PictureBox picBox, Image img)
        {
            if (img != null && picBox.Tag != img)
            {
                picBox.Image = img;
                picBox.Tag = img;

                return true;
            }

            return false;
        }
        // Graphics basics
        static public void DrawRoundImage(Graphics g, Image img, RectangleF rect, float radius)
        {
            if (img != null)
            {
                TextureBrush brImage = new TextureBrush(img);
                brImage.ScaleTransform(rect.Width / img.Width, rect.Height / img.Height);
                brImage.TranslateTransform(rect.Left, rect.Top, MatrixOrder.Append);
                FillRoundRect(g, brImage, rect, radius);
            }
        }

        static public void DrawRoundRect(Graphics g, Pen p, RectangleF rect, float radius)
        {
            GraphicsPath gp = GetRoundRectPath( rect.X, rect.Y, rect.Width, rect.Height, radius );
            g.DrawPath(p, gp);
            gp.Dispose();
        }

        static public void FillRoundRect(Graphics g, Brush br, RectangleF rect, float radius)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath gp = GetRoundRectPath( rect.X, rect.Y, rect.Width, rect.Height, radius);
            g.FillPath(br, gp);
            gp.Dispose();
        }

        static public GraphicsPath GetRoundRectPath(float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line
            if (radius > 0)
                gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner
            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2)); // Line
            if (radius > 0)
                gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner
            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line
            if (radius > 0)
                gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner
            gp.AddLine(x, y + height - (radius * 2), x, y + radius); // Line
            if (radius > 0)
                gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner
            gp.CloseFigure();

            return gp;
        }

        public static string[] strDefAttributes = new string[] { "show", "alpha", "x", "y", "z", "w", "h", "d", "rv", "rh", "r", "pos", "maintain_ar", "sx", "sy", "sw", "sh", "spos", "audio_gain" };
        public static string[] strDefNodes = new string[] { "on_hide", "on_show", "on_select", "add", "vary" };
        public static string[] strDefOptions = new string[] {"Invoke", "Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker", "Remove" };
		public static string[] strDefaultElements = new string[] { "video", "text", "block", "group", "img", "crawl", "roll", "matrix", "cloud", "cube", "polygon", "star", "ticker" };

        public static List<MElemementDescriptor> MMixerElementDescriptors = new List<MElemementDescriptor>(new MElemementDescriptor[] {
        new MElemementDescriptor("foreground", new List<string>(), new List<string>(), new List<string>(new string[] {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image","Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker"}), "", ""),
        new MElemementDescriptor("view", new List<string>(), new List<string>(), new List<string>(new string[] {"Add View", "Invoke", "Remove"}), "", ""),
        new MElemementDescriptor("video", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(strDefOptions),
            @"<video stream_idx='0' h='0.5' w='0.5' show='1'/>",
            @"<video stream_idx='0' h='0.5' w='0.5' show='1'/>"),
        new MElemementDescriptor("block", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(strDefOptions),
            @"<block show='1' h='0.5' w='0.5'>
            </block>",
            @"<block show='1' h='0.5' w='0.5'>
            </block>")
        });


        public static List<MElemementDescriptor> MComposerElementDescriptors = new List<MElemementDescriptor>(new MElemementDescriptor[] {
        new MElemementDescriptor("background", new List<string>(), new List<string>(), new List<string>(new string[] {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image","Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker"}), "", ""),
        new MElemementDescriptor("scene_3d", new List<string>(), new List<string>(), new List<string>(new string[] {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image","Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker"}), "", ""),
        new MElemementDescriptor("foreground", new List<string>(), new List<string>(), new List<string>(new string[] {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image","Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker"}), "", ""),
        new MElemementDescriptor("viewroot", new List<string>(), new List<string>(), new List<string>(new string[] {"Add View"}), "", ""),
        new MElemementDescriptor("view", new List<string>(), new List<string>(), new List<string>(new string[] {"Add View","Invoke", "Remove"}), "", ""),
        new MElemementDescriptor("timeline", new List<string>(), new List<string>(), new List<string>(), "", ""),
        new MElemementDescriptor("effects", new List<string>(), new List<string>(), new List<string>(), "", ""),
        new MElemementDescriptor("light", new List<string>(), new List<string>(), new List<string>(), "", ""),
        new MElemementDescriptor("camera", new List<string>(), new List<string>(new string[] {"add", "vary"}), new List<string>(), "", ""),
        new MElemementDescriptor("ticker_item", new List<string>(strDefAttributes), new List<string>(strDefNodes), new List<string>(new string[] {"Remove"}), 
            @"<ticker_item></ticker_item>", "<ticker_item></ticker_item>"),
        new MElemementDescriptor("on_ticker_next", new List<string>(strDefAttributes), new List<string>(new string[] {"add", "vary"}), new List<string>(new string[] {"Remove"}), 
            @"<on_ticker_next></on_ticker_next>", "<on_ticker_next></on_ticker_next>"),
        new MElemementDescriptor("rear_side", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(strDefOptions),
              @"<rear_side> </rear_side>",            
@"<rear_side>
		<text show='true' w='0.8'>Rear side</text>
</rear_side>"),
        new MElemementDescriptor("cell", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image","Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker", "Remove"}), 
                @"<cell>
</cell>",            
@"<cell>
	<block show='1' shape='rrect-r05' border='0.01' color='green(200)' d='0.02' h='0.9' w='0.9'>	
		<text show='true' w='0.8'>Content</text>
	</block>
</cell>"),
        new MElemementDescriptor("face", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image","Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker", "Remove"}), 
                @"<face></face>",            
@"<face>
	<block show='1' shape='rrect-r05' border='0' color='red(100)' d='0' h='0.9' w='0.9'>
		<text show='true' w='0.8'>Content</text>
	</block>
</face>"),
		new MElemementDescriptor("top", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image","Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker", "Remove"}), 
                @"<top></top>",@"<top></top>"),
		new MElemementDescriptor("bottom", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image","Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker", "Remove"}), 
                @"<bottom></bottom>",@"<bottom></bottom>"),
		new MElemementDescriptor("left", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image","Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker", "Remove"}), 
                @"<left></left>",@"<left></left>"),
		new MElemementDescriptor("right", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image","Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker", "Remove"}), 
                @"<right></right>",@"<right></right>"),
		new MElemementDescriptor("front", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image","Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker", "Remove"}), 
                @"<front></front>",@"<front></front>"),
		new MElemementDescriptor("back", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image","Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker", "Remove"}), 
                @"<back></back>",@"<back></back>"),

        new MElemementDescriptor("video", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>( new string[] {"Invoke", "Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker", "Remove", "Move Up", "Move Down" }),
            @"<video/>",
            @"<video stream_idx='0' border='0.03' shape='trect' d='0.1' h='0.6' x='-0.1' rh='40'/>"),
        new MElemementDescriptor("text", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Invoke", "Remove", "Move Up", "Move Down"}),
            @"<text>Put text here...</text>",
@"<text bg_color='black(80)' indent='0.03' bg_shape='rrect-r03' size='1.0' show='true'>
	<font bg_color='RED'>M</font>Composer support 
	<br/>
    <font bg_shape='rrect-r100' bg_color='red'> Rich </font><font size=1.5 color='yellow' face='Consolas'>text <i>formatting</i></font>
	<br/>
	<up>UPPerCase</up> and <lo>LOweRcase</lo>
	<br/>
	<font depth='1.0' size=3.0 color='silver' bold=true>3D text</font>
	<br/>
	<tab/>Tabbed lines.
	<br/>
	Images could be added into text:<br/>
	<img size=3.0 shape='rrect' src='C:\Users\Public\Pictures\Sample Pictures\Koala.jpg'/>
	<br>
	And even videos:<br/>
	<video shape='trect' stream_idx='0' size=4.0/>
</text>"),
        new MElemementDescriptor("block", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Invoke", "Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker", "Add Rear Side", "Remove", "Move Up", "Move Down" }),
@"<block>
	<rear_side/>
</block>",
@"<block show='true' d='0.1' h='0.8' w='0.8' color='white' bg_color='black(80)' shape='box-lr-o' border='0.1'>
	<text w='1.0'>Front side</text>
	<rear_side>
		<text w='1.0'>Back side</text>
	</rear_side>
</block>"),
        new MElemementDescriptor("group", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Invoke", "Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker", "Add Rear Side", "Remove", "Move Up", "Move Down" }),
            @"<group/>",
            @"<group h='1.0' w='1.0' d='1.0'/>"),
        new MElemementDescriptor("img", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Invoke", "Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker", "Add Rear Side", "Remove", "Move Up", "Move Down" }),
            @"<img src='' />",
            @"<img shape='rrect-r05' frame='true' border='0.05' color='silver' src='' h='0.8' x='0.1' rh='-40' d='0.1'/>"),
        new MElemementDescriptor("crawl", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Invoke", "Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker", "Add Rear Side", "Remove", "Move Up", "Move Down" }),
        @"<crawl h='0.1' src=''>Crawl content</crawl>",
@"<crawl h='0.1' w='1.2' bg_color='blue(80)' bg_shape='rrect-r100' indent='0.05, 0.0' z=0.6 rh='30.0' rv='10.0' r='10.0' speed='1.0'>
	<text color='Red'>Crawl </text>
	<b>with </b>
	<text bg_color='RED' bg_shape='trect'> colored </text>
	<text> text</text>
	<pause time=1.0/>
	<i> &lt;1 second pause&gt; </i>
	<text src=''>...Loaded content...</text>
</crawl>"),
        new MElemementDescriptor("roll", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Invoke", "Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", "Add Ticker", "Add Rear Side", "Remove", "Move Up", "Move Down" }),
        @"<roll src=''>Roll content</roll>",
@"<roll bg_color='blue(80)' bg_shape='rrect-r05' indent='0.1' show='true' h='1.2' w='0.4' z=0.5 y=0.2 rv=-55 speed='2.0'>
	<font color=yellow align='center' size='2.0'>A long time ago in a<br/>galaxy far, far away....</font>
	<br/>
	<br/>
	<pause time=1.0/>
	<i> &lt;1 second pause&gt; </i>
	<br/>
	<text word_wrap='true' align='justify'>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</text>
	<br>
	<text src=''>...Loaded content...</text>
	<br>
	<br>
</roll>"),
        new MElemementDescriptor("matrix", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Invoke", "Add Cell", "Remove", "Move Up", "Move Down"}),
@"<matrix items='9'>
	<cell>
	</cell>
</matrix>",
@"<matrix items='9' show='true' h='0.8' w='0.8' d='1' rh=-40 z=0.1 x=-0.1>
    <cell>
        <block show='1' shape='rrect-r05' border='0.0' color='grey(100)' d='0.0' h='0.9' w='0.9'>
            <text show='true' w='0.8'>Default cell</text>
        </block>
    </cell>
    <cell.0.0>
        <video stream_idx='0' shape='rrect-r05' border='0.02' d='0.02' h='0.9' w='0.9'/>
    </cell.0.0>
    <cell.2.1>
        <block show='1' shape='rrect-r05' border='0.0' color='red(200)' d='0.0' h='0.9' w='0.9'>
            <text align='center' show='true' w='0.8'>Selected cell<br>(cell.2.1)</text>
        </block>
    </cell.2.1>
</matrix>"),
        
        new MElemementDescriptor("cloud", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Invoke", "Add Cell", "Remove", "Move Up", "Move Down"}),
@"<cloud items='12' show='1' h='0.5' w='0.5' d='1' src=''>
	<cell>
	</cell>
</cloud>",
@"<cloud items='12' show='true' h='0.5' w='0.5' d='1' src='C:\Users\Public\Pictures\Sample Pictures\*.*'  rv='-20'>
     <cell>
	           <loaded_item show='true' frame=true shape='rrect-r05' border='0.02' d='0.02' h='0.9'/>
	 </cell>
	 <cell>
	           <loaded_item show='true' frame=true color='red' shape='rrect-r05' border='0.02' d='0.02' h='0.9'/>
	 </cell>
</cloud>"),
        new MElemementDescriptor("cube", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Invoke", "Add Face", "Remove", "Move Up", "Move Down"}),
@"<cube show='true' h='0.5'>
    <face>
    </face>
</cube>",
@"<cube  show='1' h='0.5' rh=-45 >
	<face>
		<block show='1' d='0.0'color='maroon'>
			<text show='true' w='0.9'>Default face</text>
		</block>
	</face>
	<right>
		<block z='0.1' show='1' color='white'>
			<text size=2.0 color='maroon' show='true' pos=top w='0.9' h=0.2 y=0.1>Right face</text>
			<video show='true' shape='rrect-r05' border=0.1 pos=bottom w='0.9' h='0.6' y='0.05'/>
		</block>
	</right>
	<add rh='10'/>
	<vary rv=10 time=20/>
</cube>"),

        new MElemementDescriptor("polygon", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Invoke", "Add Face", "Remove", "Move Up", "Move Down"}),
@"<polygon faces='3' show='1' h='0.5' w='0.5' d='0.5'>
    <face>
    </face>
</polygon>",
@"<polygon faces='3' show='true' h='0.5' w='0.5' d='0.5'>
    <face>
        <block show='1' shape='box-lr' border='0.1' bg_color='red(100)' d='0.1' h='0.9' w='0.9' z='0.2'>
            <text show='true' w='0.8'>Default face</text>
        </block>
    </face>
    <face.0>
            <video stream_idx='0' frame=true border=0.05 shape='rrect-r10' d=0.1 w='0.9' h='0.9' z='0.2'/>
    </face.0>
    <add rh='10'/>
</polygon>"),

        new MElemementDescriptor("star", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Invoke", "Remove", "Move Up", "Move Down"}),
@"<star faces='6' show='1' h='0.3' w='0.3' d='0.3'>
    <face>
    </face>
</star>",
@"<star faces='6' show='true' h='0.3' w='0.3' d='0.3' rv='16.666667'>
<face>
	<video id='video_000' x='-0.2' back_side='true' frame='true' shape='box-lr-i' border='0.05' d='0.1'/>
</face>
    <face.1>
        <video id='video_001' x='-0.2' img_filter='blue' back_side='true' frame='true' shape='box-lr-i' border='0.05' d='0.1' color='orange'>
			<text bg_color=black(100)> Selected Face </text>
		</video>
    </face.1>
    <add rh='10'/>
</star>"),

			// TODO: Add ticker
            new MElemementDescriptor("ticker", new List<string>(strDefAttributes), new List<string>(strDefNodes),new List<string>(new string[] {"Invoke", "Remove", "Move Up", "Move Down"}), 
			@"<ticker src=''></ticker>", 
			@"<ticker src=''>
			</ticker>"),

        });


        
        
    }

    public class MElemementDescriptor
    {
        public MElemementDescriptor(string _strName, List<string> _strAttributesToShowAlways, List<string> _strNodesToShowAlways, List<string> _strAvailableOptions, string _strDefaultXML, string _strDemoXML)
        {
            strName = _strName;
            strAttributesToShowAlways = _strAttributesToShowAlways;
            strNodesToShowAlways = _strNodesToShowAlways;
            strAvailableOptions = _strAvailableOptions;
            strDefaultXML = _strDefaultXML;
            strDemoXML = _strDemoXML;
        }
        public string strName;
        public List<string> strAttributesToShowAlways;
        public List<string> strNodesToShowAlways;
        public List<string> strAvailableOptions;
        public string strDefaultXML;
        public string strDemoXML;
    }
}
