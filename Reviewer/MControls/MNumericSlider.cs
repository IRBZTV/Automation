using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MControls
{
	public partial class MNumericSlider : UserControl
	{
		private double m_dblValue;
		public double dblValue
		{
			get 
			{
				return m_dblValue;
			}
			set
			{

				if (value >= m_dblMinimumValue && value <= m_dblMaximumValue)
				{
					m_dblValue = value;

					numericUpDown.ValueChanged -= new EventHandler(numericUpDown_ValueChanged);
					numericUpDown.Value = (decimal)value;
					numericUpDown.ValueChanged += new EventHandler(numericUpDown_ValueChanged);


					double relativeValue = (m_dblValue - m_dblMinimumValue) / (m_dblMaximumValue - m_dblMinimumValue); // 0..1
					trackBar.ValueChanged -= new EventHandler(trackBar_ValueChanged);
					trackBar.Value = (int)(relativeValue * (double)trackBar.Maximum);
					trackBar.ValueChanged += new EventHandler(trackBar_ValueChanged);

					if (DblValueChanged != null)
						DblValueChanged(this, new EventArgs());
				}
			}
		}

		public event EventHandler DblValueChanged;

		private string m_strCaption;
		public string strCaption
		{
			get 
			{
				return m_strCaption; 
			}
			set 
			{
				m_strCaption = value;
				LabelCaption.Text = value;
			}
		}

		private double m_dblMinimumValue;
		public double dblMinimumValue
		{
			get
			{
				return m_dblMinimumValue;
			}
			set
			{
				m_dblMinimumValue = value;
				numericUpDown.Minimum = (decimal)value;
			}
		}

		private double m_dblMaximumValue;
		public double dblMaximumValue
		{
			get
			{
				return m_dblMaximumValue;
			}
			set
			{
				m_dblMaximumValue = value;
				numericUpDown.Maximum = (decimal)value;
			}
		}

		private double m_dblIncrement;
		public double dblIncrement
		{
			get
			{
				return m_dblIncrement;
			}
			set
			{
				m_dblIncrement = value;
				this.numericUpDown.Increment = (decimal)value;
			}
		}

		public MNumericSlider(string caption, double value, double minimum, double maximum, double increment)
		{
			strCaption = caption;
			dblMinimumValue = minimum;
			dblMaximumValue = maximum;
			dblIncrement = increment;
			dblValue = value;
		}

		public MNumericSlider()
		{
			InitializeComponent();
		}

		private void numericUpDown_ValueChanged(object sender, EventArgs e)
		{
			dblValue = (double)numericUpDown.Value;
		}

		private void trackBar_ValueChanged(object sender, EventArgs e)
		{
			double relativeTBValue = (double)trackBar.Value / (double)trackBar.Maximum; //0..1
			dblValue = ((m_dblMaximumValue - m_dblMinimumValue) * relativeTBValue) + m_dblMinimumValue;
		}
	}
}
