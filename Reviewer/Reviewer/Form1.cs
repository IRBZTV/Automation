using MediaInfoNET;
using MLCHARGENLib;
using MPLATFORMLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Reviewer
{
    public partial class Form1 : Form
    {
        string _ServiceBaseAddress = "";
        //   MPlaylistClass _PlayList = new MPlaylistClass();
        MFileClass _File = new MFileClass();
        MRendererClass _Renderer = new MRendererClass();
        CoMLCharGenClass Cg = new CoMLCharGenClass();
        int _VideoStatus = 0;

        string _FileName = "";

        public Form1(string FileName)
        {

            //MPlatformLic.IntializeProtection();
            //DecoderlibLic.IntializeProtection();
            _FileName = FileName;
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _ServiceBaseAddress = System.Configuration.ConfigurationSettings.AppSettings["DbService"].Trim();

            MPlatformLic.IntializeProtection();
            DecoderlibLic.IntializeProtection();

            string myName = "Logo";
            Cg.AddNewItem(Path.GetDirectoryName(Application.ExecutablePath) + "\\Area.png", 0, 0, 0, 0, ref myName);
            MLCHARGENLib.CG_ITEM_PROPS itemProps;
            string fileName;
            Cg.GetItemBaseProps(myName, out fileName, out itemProps);
            itemProps.eScale = eCG_Scale.eCGS_ExactFit;
            Cg.SetItemBaseProps(myName, ref itemProps, 0);


            _File.PreviewWindowSet("", PnlPreview.Handle.ToInt32());
            _File.PreviewEnable("", 1, 1);


            //    MItem pItem;
            //   _File.colo(null, "Transparent", "", out pItem);

            //if (pItem != null)
            //{
            //    System.Runtime.InteropServices.Marshal.ReleaseComObject(pItem);
            //    GC.Collect();
            //}

            MPLATFORMLib.M_VID_PROPS newProps = new MPLATFORMLib.M_VID_PROPS();
            newProps.fccType = MPLATFORMLib.eMFCC.eMFCC_ARGB32;
            newProps.eInterlace = MPLATFORMLib.eMInterlace.eMI_Field2First;
            newProps.eVideoFormat = MPLATFORMLib.eMVideoFormat.eMVF_PAL;
            newProps.eScaleType = MPLATFORMLib.eMScaleType.eMST_None;
            newProps.nHeight = 576;
            newProps.nWidth = 720;
            //newProps.nAspectY = 3;
            //newProps.nAspectX = 4;
            _File.FormatVideoSet(eMFormatType.eMFT_Convert, ref newProps);


            mFileSeeking1.SetControlledObject(_File);
            mAudioMeter1.SetControlledObject(_File);
            //mAudioChannel1.InitializeLifetimeService();

            // ((IMProps)pFile).PropsSet("pause_out", "true");




            //  _PlayList.FilePlayPause(0);



            _File.PluginsAdd(Cg, 0);


            int nDevices;
            _Renderer.DeviceGetCount(0, "renderer", out nDevices);
            if (nDevices > 0)
            {
                CmbDevice.Enabled = true;
                for (int i = 0; i < nDevices; i++)
                {
                    string strName;
                    string strXML;
                    _Renderer.DeviceGetByIndex(0, "renderer", i, out strName, out strXML);
                    CmbDevice.Items.Add(strName);
                }
                CmbDevice.SelectedIndex = 0;
                CmbDevice_SelectedIndexChanged(new object(), new EventArgs());
            }
            else
            {
                CmbDevice.Enabled = false;
            }


            _File.OnEvent += _PlayList_OnEvent;


            cmbStatus.SelectedIndex = 0;
            cmbStatus_SelectedIndexChanged(null, null);

        }       

        protected void PlayVideo()
        {
            //MPlatformLic.IntializeProtection();
            //DecoderlibLic.IntializeProtection();
            try
            {
                _File.ObjectClose();
                //_PlayList.PlaylistRemoveByIndex(0, 1);
                //_PlayList.ObjectClose();             
                _VideoStatus = 0;
            }
            catch { }


            //  MItem pFile = null;
            Cursor prev = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            int nIndex = -1;
            // _PlayList.PlaylistAdd(null, _FileName, "", ref nIndex, out pFile);
            //  pFile.FileNameSet(_FileName, "");
            _File.FileNameSet(_FileName, "");
            ((IMProps)_File).PropsSet("object::mdelay.enabled", "true");
            ((IMProps)_File).PropsSet("pause_out", "true");
            //((IMProps)_File).PropsSet("file.buffer_min", "10.00");
            //((IMProps)_File).PropsSet("object::mdelay.time","0.0");
            this.Cursor = prev;
            _File.ObjectStart(new object());

            PbPlayPause_Click(null, null);
            mFileSeeking1.SetControlledObject(_File);
            mAudioMeter1.SetControlledObject(_File);
            ChkTimeCode_CheckedChanged(null, null);
            ChkArea_CheckedChanged(null, null);
        }

        private void _PlayList_OnEvent(string bsChannelID, string bsEventName, string bsEventParam, object pEventObject)
        {
            switch (bsEventName)
            {
                case "EOF":
                    if (_VideoStatus == 1)
                    {
                        PbPlayPause_Click(null, null);
                    }
                    break;

                default:
                    break;
            }
        }

        private void PbPlayPause_Click(object sender, EventArgs e)
        {
            switch (_VideoStatus)
            {
                case 0:
                    _File.FilePlayStart();
                    PbPlayPause.Image = Reviewer.Properties.Resources.pause_icon;
                    _VideoStatus = 1;
                    break;


                case 1:
                    _File.FilePlayPause(0);
                    PbPlayPause.Image = Reviewer.Properties.Resources.play;
                    _VideoStatus = 2;
                    break;

                case 2:
                    _File.FilePlayStart();
                    PbPlayPause.Image = Reviewer.Properties.Resources.pause_icon;
                    _VideoStatus = 1;
                    break;
                default:
                    break;
            }

        }

        private void TimerUi_Tick(object sender, EventArgs e)
        {
            try
            {
                double dblIn, dblOut, dblLen;
                _File.FileInOutGet(out dblIn, out dblOut, out dblLen);
                dblOut = dblOut > dblIn ? dblOut : dblLen;

                double dblPos;
                _File.FilePosGet(out dblPos);

                dblLen = dblLen > 0 ? dblLen : 0.001;
                dblPos = dblPos > 0 ? dblPos : 0;
                dblPos = dblPos < dblLen ? dblPos : dblLen;
                LblCurrentTime.Text = Msec2TC(dblPos);
                LblDurationTime.Text = Msec2TC(dblLen);
                LblCurrentRemainTime.Text = Msec2TC(dblLen - dblPos);




                if (ChkTimeCode.Checked)
                {
                    CG_TEXT_PROPS Txt = new CG_TEXT_PROPS();
                    Cg.TextGetProps("titleline1", out Txt);
                    Txt.bsTextString = Msec2TC(dblPos);
                    Cg.TextSetProps("titleline1", Txt, 0, 0);
                }

            }
            catch (System.Exception) { }
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

        private void CmbDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Renderer.DeviceSet("renderer", CmbDevice.SelectedItem.ToString(), "");
            _Renderer.ObjectStart(_File);
        }

        private void ChkTimeCode_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTimeCode.Checked)
            {
                string TitleLine1Id = "titleline1";
                string TitleLine1Xml =
              @"<cg-item>
	                    <text type='text' bold='1' font='Arial' font-size='40' color='white' word-break='no' outline='3.0' outline-color='Black' format='LTR '>" + "00:00:00:00" + @"</text>
	                    <cg-props scale='no-scale'  align='right' edges-smooth='0' pos-x='0' pos-y='0' show='yes' move-type='accel-both' alpha='255' bg-color='black(0)' pixel-ar='0.' play-mode='loop' interlace='auto' pause='no'>
		                    <indent left='0' right='0' top='0' bottom='0' use-for-bg='no'/>
		                    <group-indent left='0' right='0' top='0' bottom='0'/>
	                    </cg-props>
	                    <table/>
	                    <anchor item='auto' screen='top-right'/>
                      </cg-item>";
                try
                {
                    Cg.AddNewItem(TitleLine1Xml, 210, 0, 0, 0, ref TitleLine1Id);
                    Cg.ShowItemWithDelay("titleline1", 1, 0, 0);
                }
                catch
                {
                    //Cg.RemoveItem(TitleLine1Id, 0);
                    //Cg.AddNewItem(TitleLine1Xml, 0, 100, 0, 0, ref TitleLine1Id);
                }
            }
            else
            {

                try
                {
                    Cg.RemoveItemWithDelay("titleline1", 0, 500);
                }
                catch
                {

                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                _File.FileRateSet(2);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                _File.FileRateSet(4);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                _File.FileRateSet(0.2);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                _File.FileRateSet(1);
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                _File.FileRateSet(8);
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                _File.FileRateSet(16);
            }
        }

        private void ChkArea_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkArea.Checked)
                {

                    Cg.ShowItemWithDelay("Logo", 1, 500, 500);
                }
                else
                {
                    Cg.ShowItemWithDelay("Logo", 0, 500, 500);
                }
            }
            catch
            {

            }

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                _File.FileRateSet(-2.0);
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                _File.FileRateSet(-4.0);
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked)
            {
                _File.FileRateSet(-8.0);
            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked)
            {
                _File.FileRateSet(-16.0);
            }
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            double dblPos = (double)trackBarVolume.Value / trackBarVolume.Maximum;
            _File.PreviewAudioVolumeSet("", -1, -30 * (1 - dblPos));
        }

        protected void JogController()
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                PbPlayPause_Click(null, null);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadTasks();
        }

        protected void LoadTasks()
        {
            string Status = "1";
            switch (cmbStatus.SelectedIndex)
            {
                case 0:
                    Status = "0";
                    break;
                case 1:
                    Status = "1";
                    break;
                case 2:
                    Status = "2";
                    break;
            }

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

            // dgvList.DataSource = RvLst;
        }

        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            _FileName = dgvList.SelectedRows[0].Cells["FilePath"].Value.ToString();
            PlayVideo();
        }

        protected void InsertReviewComment()
        {

            WebRequest request = WebRequest.Create(_ServiceBaseAddress + "Review/Comment/insert");

            request.Method = "POST";

            double dblPos = 0;
            int position = 0;
            try
            {
                _File.FilePosGet(out dblPos);
                position = int.Parse(Math.Floor(dblPos).ToString());
                
            }
            catch
            {
            }


            string postData = "Review_Comments_Review_Id=" + dgvList.SelectedRows[0].Cells["Review_Id"].Value.ToString()
                                + "&&Review_Comments_Text=" + txtComment.Text.Trim()
                                + "&&Review_Comments_User_Id=" + 0
                                + "&&Review_Comments_TimeCode=" + position;

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            request.ContentType = "application/x-www-form-urlencoded";

            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();

            WebResponse response = request.GetResponse();

            dataStream.Close();
            response.Close();
        }

        private void btnInsertComment_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count == 1)
            {
                InsertReviewComment();
                LoadComments();
            }
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
                    item.Review_Comments_Reply_UserId);

            }
        }

        private void dgvComments_DoubleClick(object sender, EventArgs e)
        {
            _File.FilePosSet(double.Parse(dgvComments.SelectedRows[0].Cells["TimeCode"].Value.ToString()),0);
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTasks();
        }

        protected void updateStatus(int status)
        {
            WebRequest request = WebRequest.Create(_ServiceBaseAddress + "Review/update/status/"+status+"/" + dgvList.SelectedRows[0].Cells["Review_Id"].Value.ToString());
            WebResponse response = request.GetResponse();
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            updateStatus(1);
            LoadTasks();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            updateStatus(2);
            LoadTasks();
        }
    }
}
