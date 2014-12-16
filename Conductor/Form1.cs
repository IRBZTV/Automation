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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conductor
{
    public partial class Form1 : Form
    {
        string _ServiceBaseAddress = "";

        string _VideoFile = "";
        public Form1()
        {
            InitializeComponent();
            _ServiceBaseAddress = System.Configuration.ConfigurationSettings.AppSettings["DbService"].Trim();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Programs_Kind_Select();
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
                    cmbProgKind.Items.Add(new BO.MyListItem(item.Programs_Kind_Title, item));
                }

                if (cmbProgKind.Items.Count > 0)
                {
                    cmbProgKind.SelectedIndex = 0;
                }
            }

            response.Close();
        }

        private void cmbProgKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            BO.Programs_Kind ProgKind = (BO.Programs_Kind)((BO.MyListItem)cmbProgKind.SelectedItem).value;

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
                cmbProg.Items.Clear();
                foreach (BO.Programs item in ProgKinds)
                {
                    cmbProg.Items.Add(new BO.MyListItem(item.Programs_Title, item));
                }
                if (cmbProg.Items.Count > 0)
                {
                    cmbProg.SelectedIndex = 0;
                }
            }
            response.Close();
        }

       
    }
}
