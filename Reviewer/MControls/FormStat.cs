using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MControls
{
    public partial class FormStat : Form
    {
        public FormStat()
        {
            InitializeComponent();
        }

        private IMProps properties;
       
        public Object SetControlledObject(List<object> pObject)
        {
            Object pOld = (Object)properties;
            labels = new List<Label>();
            if (pObject.Count == 0) this.Close();
            
            try
            {
                int counter = 0;
                int width = 10;
                int lastWidth = 0;
                foreach (object tmpObj in pObject)
                {
                    string objectName;
                    ((IMObject)tmpObj).ObjectNameGet(out objectName);
                    properties = (IMProps)tmpObj;
                    string props = GetStat();
                    Label myLabel = new Label();
                    myLabel.AutoSize = true;
                    myLabel.Tag = properties;
                    myLabel.Text = objectName+" : " + Environment.NewLine + props;
                    myLabel.Location = new Point(150*counter+10, 10);
                    myLabel.Visible = true;
                    myLabel.ContextMenuStrip = contextMenuStrip1;
                    Controls.Add(myLabel);
                    labels.Add(myLabel);
                    lastWidth = myLabel.Size.Width;
                    counter++;
                }
                width += counter*150+10;
                this.Size = new Size(width, 200);
                timer1.Enabled = true;
                
            }
            catch (System.Exception) { }

            return pOld;
        }
        private List<Label> labels;
        //private void clearLabels()
        //{
        //    this.Controls.Remove Controls.Remove(lastLabel);
        //    throw new Exception("The method or operation is not implemented.");
        //}

        private string GetStat()
        {
            int count;
            string result = "";
            try
            {
                properties.PropsGetCount("stat", out count);
                //string result = "";
                for (int i = 0; i < count; i++)
                {
                    string name;
                    string value;
                    int isNode;
                    properties.PropsGetByIndex("stat", i, out name, out value, out isNode);
                    result += name + "    " + value + Environment.NewLine;
                }
            }
            catch
            {}
            try
            {
                properties.PropsGetCount("object::stat", out count);
                //string result = "";
                for (int i = 0; i < count; i++)
                {
                    string name;
                    string value;
                    int isNode;
                    properties.PropsGetByIndex("object::stat", i, out name, out value, out isNode);
                    result += name + "    " + value + Environment.NewLine;
                }
            }
            catch { }
            return result;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Label l in labels)
            {
                properties = (IMProps)l.Tag;
                string stat = GetStat();

                l.Text = l.Text.Remove(l.Text.IndexOf(" : ") + 3);
                l.Text += Environment.NewLine + stat;
            }
        }

        private void FormStat_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(contextMenuStrip1.SourceControl.Text);
        }
    }
}