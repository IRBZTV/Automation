using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MControls
{
	public partial class FormChromaKey : Form
	{
		MCHROMAKEYLib.MChromaKey m_pChromaKey;

		public FormChromaKey()
		{
			InitializeComponent();
		}

		public FormChromaKey(object pChromaKey)
		{
			InitializeComponent();
			m_pChromaKey = (MCHROMAKEYLib.MChromaKey)pChromaKey;
			this.DoubleBuffered = true;
		}

		private void FormChromaKey_Load(object sender, EventArgs e)
		{
			mChromaKey1.SetControlledObject(m_pChromaKey);
		}


	}
}