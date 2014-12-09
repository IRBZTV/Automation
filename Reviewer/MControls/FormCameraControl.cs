using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MControls
{
    public partial class FormCameraControl : Form
    {
        public FormCameraControl()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.Manual;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            BackColor = Color.Ivory;
            TransparencyKey = Color.Ivory;
            Opacity = 0.7f;
        }
    }
}