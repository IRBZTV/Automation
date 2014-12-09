using MediaInfoNET;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace FileIngest
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string _ServiceBaseAddress = "";

        string _VideoFile = "";
        public Form1()
        {
            InitializeComponent();
            _ServiceBaseAddress = System.Configuration.ConfigurationSettings.AppSettings["DbService"].Trim();
        }
        protected void Programs_Kind_Select()
        {
            string Json = "";
            WebRequest request = WebRequest.Create(_ServiceBaseAddress + "/Programs_Kind/List");
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                
                Json = reader.ReadToEnd();
                reader.Close();
                responseStream.Close();
                
                List<BO.Programs_Kind> ProgKinds = JsonConvert.DeserializeObject<List<BO.Programs_Kind>>(Json);
                
                foreach (BO.Programs_Kind item in ProgKinds)
                {
                    cmbProgramKinds.Items.Add(new BO.MyListItem(item.Programs_Kind_Title, item));
                }

                if (cmbProgramKinds.Items.Count > 0)
                {
                    cmbProgramKinds.SelectedIndex = 0;
                }
            }

            response.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Programs_Kind_Select();
            tmrCheckReviewRejected_Tick(null, null);
        }

        private void cmbProgramKinds_SelectedIndexChanged(object sender, EventArgs e)
        {
            BO.Programs_Kind ProgKind = (BO.Programs_Kind)((BO.MyListItem)cmbProgramKinds.SelectedItem).value;

            string Json = "";
            WebRequest request = WebRequest.Create(_ServiceBaseAddress + "/Programs/Kind/" + ProgKind.Programs_Kind_Id);
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                Json = reader.ReadToEnd();
                reader.Close();
                responseStream.Close();
                List<BO.Programs> ProgKinds = JsonConvert.DeserializeObject<List<BO.Programs>>(Json);
                cmbPrograms.Items.Clear();
                foreach (BO.Programs item in ProgKinds)
                {
                    cmbPrograms.Items.Add(new BO.MyListItem(item.Programs_Title, item));
                }
                if (cmbPrograms.Items.Count > 0)
                {
                    cmbPrograms.SelectedIndex = 0;
                }
            }
            response.Close();
        }

        private void btnChooseFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ofdImportFile.ShowDialog();
        }

        private void ofdImportFile_FileOk(object sender, CancelEventArgs e)
        {
            MediaFile VideoFile = new MediaFile(ofdImportFile.FileName);
            lblVideoFileDuration.Text = TimeSpan.FromMilliseconds(VideoFile.Video[0].DurationMillis).ToString();
            _VideoFile = ofdImportFile.FileName;
            lblFileVideoPath.Text = _VideoFile;
        }

        private void btnPlayVideoFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_VideoFile.Length > 0)
            {
                VideoPlayer VplForm = new VideoPlayer(_VideoFile);
                VplForm.TopMost = true;
                VplForm.Show();
            }
            else
            {
                MessageBox.Show("Please Import file");
            }
        }

        private void btnSendFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_VideoFile.Length > 0)
            {
                WebRequest request = WebRequest.Create(_ServiceBaseAddress + "Media/insert");

                request.Method = "POST";

                BO.Programs SelectedProg = (BO.Programs)((BO.MyListItem)cmbPrograms.SelectedItem).value;

                MediaFile VideoFile = new MediaFile(ofdImportFile.FileName);


                string postData = "Media_Title=" + txtTitle.Text.Trim() + "&Media_Description=" + txtDescProg.Text.Trim()
                    + "&Media_Description_Adver=" + txtDescAdver.Text.Trim() + "&Media_Programs_Id=" + SelectedProg.Programs_Id
                    + "&Media_Session_Number=" + txtSessionNumber.Text.Trim() + "&Media_Duration=" + VideoFile.Video[0].DurationMillis
                    + "&Media_User_Id=" + 0;

                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                request.ContentType = "application/x-www-form-urlencoded";

                request.ContentLength = byteArray.Length;

                Stream dataStream = request.GetRequestStream();

                dataStream.Write(byteArray, 0, byteArray.Length);

                dataStream.Close();

                WebResponse response = request.GetResponse();
                if (((HttpWebResponse)response).StatusDescription == "OK")
                {
                    dataStream = response.GetResponseStream();

                    StreamReader reader = new StreamReader(dataStream);

                    string responseFromServer = reader.ReadToEnd();
                    BO.Media NewMedia = JsonConvert.DeserializeObject<BO.Media>(responseFromServer);
                    reader.Close();

                    //Call Convert Method Here:
                    VideoSender VsndForm = new VideoSender(_VideoFile, @"c:\files\tmp\Automation\" + NewMedia.Media_Datetime_Insert.ToString("yyyy-MM-dd") + @"\" + NewMedia.Media_Id + ".mp4", NewMedia);
                    VsndForm.TopMost = true;
                    VsndForm.Show();

                }

                dataStream.Close();
                response.Close();
            }
            else
            {
                btnChooseFile_ItemClick(null, null);
            }
        }

        public static void ItemSucceed()
        {
            MessageBox.Show("Item Uploaded");            
        }

        private void btnClearForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _VideoFile = "";
            txtDescAdver.Text = "";
            txtDescProg.Text = "";
            txtSessionNumber.Text = "0";
            txtTitle.Text = "";
            lblFileVideoPath.Text = "No Video File";
            lblVideoFileDuration.Text = "00:00:00";
        }

        private void tmrCheckReviewRejected_Tick(object sender, EventArgs e)
        {
            string Json = "";
            WebRequest request = WebRequest.Create(_ServiceBaseAddress + "/Review/List/Rejected/2");
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                Json = reader.ReadToEnd();
                reader.Close();
                responseStream.Close();
                List<BO.Review> RvLst = JsonConvert.DeserializeObject<List<BO.Review>>(Json);
               
                btnListReviewRejected.Caption=RvLst.Count.ToString();



            }
            response.Close();
        }

        private void btnListReviewRejected_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Rejected Rj = new Rejected();
          //  Rj.TopMost = true;
            Rj.Show();
        }

    }
}
