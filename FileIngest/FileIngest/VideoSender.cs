using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FileIngest
{
    public partial class VideoSender : Form
    {
        string _VideoFile = "";
        string _NewVideoFile = "";
        string _ServiceBaseAddress = "";
        BO.Media _NewMedia;
        public VideoSender(string SourceFileName, string DestinationNewFileName, BO.Media NMedia)
        {
            InitializeComponent();
            _VideoFile = SourceFileName;
            _NewVideoFile = DestinationNewFileName;
            _ServiceBaseAddress = System.Configuration.ConfigurationSettings.AppSettings["DbService"].Trim();
            _NewMedia = NMedia;
        }
        protected void Convert()
        {
            lblSourceFile.Text = _VideoFile;
            lblDestinationFile.Text = _NewVideoFile;

            if (!Directory.Exists(Path.GetDirectoryName(_NewVideoFile)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_NewVideoFile));
            }


            Process proc = new Process();
            if (Environment.Is64BitOperatingSystem)
            {
                proc.StartInfo.FileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\ffmpeg64";
            }
            else
            {
                proc.StartInfo.FileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\ffmpeg32";
            }



            proc.StartInfo.Arguments = String.Format("-i \"{0}\"  -r 25 -b 14000k  -ar 48000 -ab 192k -async 1    -y  \"{1}\"", _VideoFile, _NewVideoFile);
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.EnableRaisingEvents = true;
            // proc.Exited += new EventHandler(myProcess_Exited);
            if (!proc.Start())
            {
                MessageBox.Show("Error Coverting File, Check FileName ,No Persian And Special Character");
                return;
            }

            proc.PriorityClass = ProcessPriorityClass.RealTime;
            StreamReader reader = proc.StandardError;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (richTextBox1.Lines.Length > 3)
                {
                    richTextBox1.Text = "";
                }
                FindDuration(line, "1");
                richTextBox1.Text += (line) + " \n";
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
                Application.DoEvents();
            }
            proc.Close();

            InsertReview();






        }
        protected void FindDuration(string Str, string ProgressControl)
        {
            try
            {

                string TimeCode = "";
                if (Str.Contains("Duration:"))
                {
                    TimeCode = Str.Substring(Str.IndexOf("Duration: "), 21).Replace("Duration: ", "").Trim();
                    string[] Times = TimeCode.Split('.')[0].Split(':');
                    double Frames = double.Parse(Times[0].ToString()) * (3600) * (25) +
                        double.Parse(Times[1].ToString()) * (60) * (25) +
                        double.Parse(Times[2].ToString()) * (25);
                    if (ProgressControl == "1")
                    {
                        progressBar1.Maximum = int.Parse(Frames.ToString());
                    }
                    else
                    {

                    }
                }
                if (Str.Contains("time="))
                {
                    try
                    {
                        string CurTime = "";
                        CurTime = Str.Substring(Str.IndexOf("time="), 16).Replace("time=", "").Trim();
                        string[] CTimes = CurTime.Split('.')[0].Split(':');
                        double CurFrame = double.Parse(CTimes[0].ToString()) * (3600) * (25) +
                            double.Parse(CTimes[1].ToString()) * (60) * (25) +
                            double.Parse(CTimes[2].ToString()) * (25);

                        if (ProgressControl == "1")
                        {
                            progressBar1.Value = int.Parse(CurFrame.ToString());

                            lblConvertPercent.Text = ((progressBar1.Value * 100) / progressBar1.Maximum).ToString() + "%";
                        }
                        else
                        {

                        }
                        Application.DoEvents();
                    }
                    catch
                    {


                    }

                }
                if (Str.Contains("fps="))
                {

                    string Speed = "";

                    Speed = Str.Substring(Str.IndexOf("fps="), 8).Replace("fps=", "").Trim();

                    lblConvertSpeed.Text = (float.Parse(Speed) / 25).ToString() + " X ";
                    Application.DoEvents();


                }
            }
            catch
            {

            }




        }
        private void VideoSender_Load(object sender, EventArgs e)
        {

        }
        private void VideoSender_Shown(object sender, EventArgs e)
        {
            Convert();
        }
        protected void InsertReview()
        {

            WebRequest request = WebRequest.Create(_ServiceBaseAddress + "Review/insert");

            request.Method = "POST";

            string postData = "Review_Media_Id=" + _NewMedia.Media_Id;

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            request.ContentType = "application/x-www-form-urlencoded";

            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();

            WebResponse response = request.GetResponse();

            this.Close();

            Form1.ItemSucceed();

          

            dataStream.Close();
            response.Close();
        }
    }
}
