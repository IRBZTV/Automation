using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace FileIngest
{
    public partial class Rejected : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string _ServiceBaseAddress = "";
        public Rejected()
        {
            InitializeComponent();

        }
        protected void LoadTasks()
        {
            string Status = "2";

            //get list of reviews
            string Json = "";
            WebRequest request = WebRequest.Create(_ServiceBaseAddress + "Review/List/" + Status);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            Json = reader.ReadToEnd();
            reader.Close();
            responseStream.Close();
            response.Close();
            List<BO.ReviewClient> RvLst = JsonConvert.DeserializeObject<List<BO.ReviewClient>>(Json);
            dgvList.Rows.Clear();
            foreach (BO.ReviewClient item in RvLst)
            {
                DateTime DtUpload = DateTime.Parse(item.Media_Datetime_Insert);
                DateTime DtRevInsert = DateTime.Parse(item.Review_Datetime_Insert);

                dgvList.Rows.Add(item.Programs_Kind_Title,
                    item.Programs_Title,
                    item.Media_Title,
                    item.Media_Session_Number,
                    Msec2TC(item.Media_Duration),
                    DtRevInsert.ToString("HH:mm:ss") + " " + DateConversion.GD2JD(DtRevInsert),
                    DtUpload.ToString("HH:mm:ss") + " " + DateConversion.GD2JD(DtUpload),
                    item.Review_Id,
                    item.FilePath,
                    item.Media_Id);
            }
            if (dgvList.Rows.Count > 0)
            {
                dgvList.Rows[0].Selected = true;
                LoadComments();

            }

            // dgvList.DataSource = RvLst;
        }
        public static string Msec2TC(double _dblPos)
        {
            _dblPos = (_dblPos * 1000) / 40;
            double H = Math.Floor(Convert.ToDouble(_dblPos / (3600 * 25)));
            double M = Math.Floor(Convert.ToDouble((_dblPos - (H * 3600 * 25)) / (60 * 25)));
            double S = Math.Floor(Convert.ToDouble((_dblPos - (H * 3600 * 25) - (M * 60 * 25)) / 25));
            double F = Math.Floor(Convert.ToDouble(_dblPos - (H * 3600 * 25) - (M * 60 * 25) - (S * 25)));

            return string.Format("{0:d2}:{1:d2}:{2:d2}.{3:d2}", Convert.ToInt32(H), Convert.ToInt32(M),
                Convert.ToInt32(S), Convert.ToInt32(F));
        }

        private void Rejected_Load(object sender, EventArgs e)
        {
            _ServiceBaseAddress = System.Configuration.ConfigurationSettings.AppSettings["DbService"].Trim();
            LoadTasks();

        }

        private void dgvList_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count == 1)
            {
                LoadComments();
            }
        }
        public void LoadComments()
        {
            string Json = "";
            WebRequest request = WebRequest.Create(_ServiceBaseAddress + "Review/Comment/List/" + dgvList.SelectedRows[0].Cells["Review_Id"].Value.ToString());
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            Json = reader.ReadToEnd();
            reader.Close();
            responseStream.Close();
            response.Close();
            List<BO.Review_Comments> RvLst = JsonConvert.DeserializeObject<List<BO.Review_Comments>>(Json);
            dgvComments.Rows.Clear();
            foreach (BO.Review_Comments item in RvLst)
            {
                DateTime dtInsert = DateTime.Parse(item.Review_Comments_Datetime);

                dgvComments.Rows.Add(item.Review_Comments_Text,
                    Msec2TC(item.Review_Comments_TimeCode),
                   "",
                    dtInsert.ToString("HH:mm:ss") + " " + DateConversion.GD2JD(dtInsert),
                    item.Review_Comments_TimeCode,
                    item.Review_Comments_Reply,
                    item.Review_Comments_Reply_Datetime,
                    item.Review_Comments_Reply_UserId, item.Review_Comments_Id);

            }
        }

        private void btnReplyComment_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create(_ServiceBaseAddress + "Review/Comment/update");

            request.Method = "POST";

            string postData = "Review_Comments_Id=" + dgvComments.SelectedRows[0].Cells["Id"].Value.ToString()
                                + "&&Review_Comments_Reply=" + txtComment.Text.Trim()
                                + "&&Review_Comments_Reply_UserId=" + 0;

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            request.ContentType = "application/x-www-form-urlencoded";

            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();

            WebResponse response = request.GetResponse();

            dataStream.Close();
            response.Close();

            LoadComments();
        }

        private void btnSendReviewer_Click(object sender, EventArgs e)
        {
            updateStatus(0);
            LoadTasks();
        }
        protected void updateStatus(int status)
        {
            WebRequest request = WebRequest.Create(_ServiceBaseAddress + "Review/update/status/" + status + "/" + dgvList.SelectedRows[0].Cells["Review_Id"].Value.ToString());
            WebResponse response = request.GetResponse();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfDialog = new SaveFileDialog();
            sfDialog.FileName = dgvList.SelectedRows[0].Cells["Media_Id"].Value.ToString() + ".mp4";
            sfDialog.ShowDialog();

            System.IO.File.Copy(dgvList.SelectedRows[0].Cells["FilePath"].Value.ToString(), sfDialog.FileName);
            MessageBox.Show("File saved to  your system.");
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            VideoPlayer VplForm = new VideoPlayer(dgvList.SelectedRows[0].Cells["FilePath"].Value.ToString());
            VplForm.TopMost = true;
            VplForm.Show();
        }

        private void btnReplaceVideo_Click(object sender, EventArgs e)
        {
            //Get new video file:
            string VideoFile = "";
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.ShowDialog();
            VideoFile = ofDialog.FileName;


            if (VideoFile.Length > 2)
            {
                //get all old media fields from server
                WebRequest requestGet = WebRequest.Create(_ServiceBaseAddress + "media/" + dgvList.SelectedRows[0].Cells["Media_Id"].Value.ToString());
                string Json = "";
                BO.Media Md = new BO.Media();
                WebResponse response = requestGet.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    Json = reader.ReadToEnd();
                    reader.Close();
                    responseStream.Close();
                    Md = JsonConvert.DeserializeObject<BO.Media>(Json);
                }

                //Insert New Media to DB:
                WebRequest request = WebRequest.Create(_ServiceBaseAddress + "Media/insert");

                request.Method = "POST";



                string postData = "Media_Title=" + Md.Media_Title + "&Media_Description=" + Md.Media_Description
                    + "&Media_Description_Adver=" + Md.Media_Description_Adver + "&Media_Programs_Id=" + Md.Media_Programs_Id
                    + "&Media_Session_Number=" + Md.Media_Session_Number + "&Media_Duration=" + Md.Media_Duration
                    + "&Media_User_Id=" + 0;

                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                request.ContentType = "application/x-www-form-urlencoded";

                request.ContentLength = byteArray.Length;

                Stream dataStream = request.GetRequestStream();

                dataStream.Write(byteArray, 0, byteArray.Length);

                dataStream.Close();

                WebResponse response2 = request.GetResponse();
                if (((HttpWebResponse)response2).StatusDescription == "OK")
                {
                    dataStream = response2.GetResponseStream();

                    StreamReader reader = new StreamReader(dataStream);

                    string responseFromServer = reader.ReadToEnd();
                    BO.Media NewMedia = JsonConvert.DeserializeObject<BO.Media>(responseFromServer);
                    reader.Close();

                    //Copy All Source Comments to New Uploaded media
                    WebRequest reqComments = WebRequest.Create(_ServiceBaseAddress + "Review/Comment/copy/" + dgvList.SelectedRows[0].Cells["Media_Id"].Value.ToString() + "/" + NewMedia.Media_Id);
                    WebResponse responseComments = reqComments.GetResponse();
                    
                    //Call Convert and Upload Method Here:
                    VideoSender VsndForm = new VideoSender(VideoFile, @"c:\files\tmp\Automation\" + NewMedia.Media_Datetime_Insert.ToString("yyyy-MM-dd") + @"\" + NewMedia.Media_Id + ".mp4", NewMedia);
                    VsndForm.TopMost = true;
                    VsndForm.Show();

                }

                dataStream.Close();
                response.Close();

                //Update status of media to replaced video file:(we have to delete Kind 4 after some days( TODO ))
                updateStatus(4);
                LoadTasks();
            }
        }
    }
}
