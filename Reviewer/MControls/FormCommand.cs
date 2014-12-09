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
    public partial class FormCommand : Form
    {
        public IMItem m_pPlaylistItem;

        public FormCommand()
        {
            InitializeComponent();
        }

        private void FormCommand_Load(object sender, EventArgs e)
        {
            string strCommand;
            string strProps;
            Object pTarget;
            m_pPlaylistItem.ItemCommandGet(out strCommand, out strProps, out pTarget);
            textBoxCommand.Text = strCommand;

            mPropsControl1.SetControlledObject(m_pPlaylistItem);
        }

        
    }
}