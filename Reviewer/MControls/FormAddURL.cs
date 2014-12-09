using System;
using System.Windows.Forms;

namespace MControls
{
    public partial class FormAddURL : Form
    {

        public FormAddURL()
        {
            InitializeComponent();
        }

        public string url;
       
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            url = urlPath.Text;
        }

    }
}
