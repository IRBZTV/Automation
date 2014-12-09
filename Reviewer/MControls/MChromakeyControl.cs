using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MCHROMAKEYLib;

namespace MControls
{
	public partial class MChromaKeyControl : UserControl
	{
		MCHROMAKEYLib.MChromaKey m_pChromaKey;
		MKey m_pKey;
		IMFrame m_pFrame;

		public MChromaKeyControl()
		{
			InitializeComponent();
		}


		~MChromaKeyControl()
		{
			if (m_pFrame != null)
			{
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_pFrame);
				m_pFrame = null;
			}
		}

		public Object SetControlledObject(Object pObject)
		{
			Object pOld = (Object)m_pChromaKey;
			try
			{
				m_pChromaKey = (MCHROMAKEYLib.MChromaKey)pObject;
				m_pChromaKey.KeyGet(null, out m_pKey, "");
				UpdateKey();

				mImageBoxPreview.ZoomToFit(); //Zoom to fit picturebox and set minimum zoom
				comboBoxDetectType.SelectedIndex = 0;
				comboScale.SelectedIndex = 0;
				mCollapsibleGroupBox1.IsCollapsed = true;
			}
			catch (System.Exception ex) 
			{
			}

			return pOld;
		}

		private void buttonApply_Click(object sender, EventArgs e)
		{
			if (m_pKey != null && m_pChromaKey != null)
			{
				m_pChromaKey.KeySet(m_pKey);
				UpdateKey();
			}
		}

		private void buttonDetect_Click(object sender, EventArgs e)
		{
			if (m_pKey != null)
			{
				object pFrame;
				string strConfig = "type='" + comboBoxDetectType.Text + "' max_keys='" + numericKeys.Value.ToString() + "'" +
					" show_blocks=" + (checkBoxShowBlocks.Checked ? "true" : "false");

				m_pKey.KeyDetect(strConfig, out pFrame);

				UpdatePicture(pFrame);
				UpdateKey();
			}
		}

		void UpdatePicture(object pMFrameObj)
		{
			try
			{
				IMFrame pFrame = (IMFrame)pMFrameObj;

				M_AV_PROPS avProps;
				pFrame.FrameAVPropsGet(out avProps);

				int cbPicture;
				long pbPicture;
				pFrame.FrameVideoGetBytes(out cbPicture, out pbPicture);
				int nRowBytes = avProps.vidProps.nRowBytes;
				if (avProps.vidProps.nHeight > 0)		// RGB Bottom-top image
				{
					pbPicture += nRowBytes * (avProps.vidProps.nHeight - 1);
					nRowBytes *= -1;
				}

				Bitmap bmpPicture = new Bitmap(avProps.vidProps.nWidth, Math.Abs(avProps.vidProps.nHeight), nRowBytes,
					System.Drawing.Imaging.PixelFormat.Format32bppRgb,
					new IntPtr(pbPicture));

				mImageBoxPreview.Image = bmpPicture;

				// Release prev frame
				if (m_pFrame != null)
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_pFrame);

				m_pFrame = pFrame; // !!! Keep reference to frame 

				GC.Collect();

				if (checkBoxInstatntApply.Checked)
				{
					m_pChromaKey.KeySet(m_pKey);
				}
			}
			catch (System.Exception ex) { }
		}

		void UpdateSliderControls(Control parent)
		{
			double dblValue = 0;
			foreach (Control ctrl in parent.Controls)
			{
				if (ctrl is MNumericSliderAdjust)
				{
					MNumericSliderAdjust currSlider = ctrl as MNumericSliderAdjust;
					m_pKey.KeyAdjustGet(currSlider.AdjustType, out dblValue);
					currSlider.dblValue = dblValue;
				}

				if (ctrl.HasChildren)
				{
					UpdateSliderControls(ctrl);
				}
			}
		}

		void UpdateKey()
		{
			UpdateSliderControls(this);

			object pFrameRes, pFrameBG;
			m_pKey.KeyFrameGet(out pFrameRes, out pFrameBG);
			if (pFrameBG != null)
			{
				System.Runtime.InteropServices.Marshal.ReleaseComObject(pFrameBG);
			}
			if (pFrameRes != null)
			{
				UpdatePicture(pFrameRes);
			}
		}

		private void pictureBoxPreview_MouseEnter(object sender, EventArgs e)
		{
			mImageBoxPreview.Focus();
		}

		private void pictureBoxPreview_MouseClick(object sender, MouseEventArgs e)
		{

		}

		private void mImageBoxPreview_MouseUp(object sender, MouseEventArgs e)
		{
			if (m_pKey != null && e.Button == MouseButtons.Left)
			{
				M_AV_PROPS props = new M_AV_PROPS();
				m_pFrame.FrameAVPropsGet(out props);
				int nOrigPictureWidth = props.vidProps.nWidth;
				int nOrigPictureHeigth = Math.Abs(props.vidProps.nHeight);

				int nScaledImageX = e.X + mImageBoxPreview.HorizontalScroll.Value;
				int nScaledImageY = e.Y + mImageBoxPreview.VerticalScroll.Value;

				double dblScaleFactor = (double)nOrigPictureWidth / (double)mImageBoxPreview.ScaledImageWidth;

				int nOriginalImageX = (int)(nScaledImageX * dblScaleFactor);
				int nOriginalImageY = (int)(nScaledImageY * dblScaleFactor);

				object pFrame;
				string strConfig = "type='" + comboBoxDetectType.Text + "' max_keys='" + numericKeys.Value.ToString() + "'" ;

				if (checkBoxExcludePts.Checked)
				{
					m_pKey.KeyExcludePoint(nOriginalImageX, nOriginalImageY, strConfig, out pFrame);
				}
				else
				{
					m_pKey.KeyAddPoint(nOriginalImageX, nOriginalImageY, strConfig, out pFrame);
				}

				UpdatePicture(pFrame);
			}
		}

		private void mCollapsibleGroupBox1_SizeChanged(object sender, EventArgs e)
		{
			buttonApply.Location = new Point(buttonApply.Location.X, mCollapsibleGroupBox1.Location.Y + mCollapsibleGroupBox1.Height + 6);
			buttonReset.Location = new Point(buttonReset.Location.X, mCollapsibleGroupBox1.Location.Y + mCollapsibleGroupBox1.Height + 6);
			checkBoxInstatntApply.Location = new Point(checkBoxInstatntApply.Location.X, mCollapsibleGroupBox1.Location.Y + mCollapsibleGroupBox1.Height + 12);
		}

		private void buttonReset_Click(object sender, EventArgs e)
		{
			try
			{
				object pFrame;
				m_pKey.KeyReset(out pFrame);
				UpdatePicture(pFrame);
				UpdateKey();
			}
			catch (System.Exception ex) { }
		}

		private void SliderControl_DblValueChanged(object sender, EventArgs e)
		{
			object pFrame;
			MNumericSliderAdjust SliderControl = sender as MNumericSliderAdjust;

			m_pKey.KeyAdjustSet(SliderControl.AdjustType, SliderControl.dblValue, out pFrame);

			UpdatePicture(pFrame);
		}

		private void mImageBoxPreview_Scroll(object sender, ScrollEventArgs e)
		{

		}

		private void timerInfo_Tick(object sender, EventArgs e)
		{
		}

		private void comboScale_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (comboScale.SelectedIndex)
			{
				case 0:
					mImageBoxPreview.Zoom = MImageBox.MinZoom;
					break;
				case 1:
					mImageBoxPreview.Zoom = (int)(MImageBox.MinZoom * 1.5);
					break;
				case 2:
					mImageBoxPreview.Zoom = (int)(MImageBox.MinZoom * 2); ;
					break;
				case 3:
					mImageBoxPreview.Zoom = (int)(MImageBox.MinZoom * 2.5); ;
					break;
				case 4:
					mImageBoxPreview.Zoom = (int)(MImageBox.MinZoom * 3); ;
					break;
				case 5:
					mImageBoxPreview.Zoom = (int)(MImageBox.MinZoom * 3.5); ;
					break;
				case 6:
					mImageBoxPreview.Zoom = (int)(MImageBox.MinZoom * 4); ;
					break;
				case 7:
					mImageBoxPreview.Zoom = (int)(MImageBox.MinZoom * 4.5); ;
					break;
				case 8:
					mImageBoxPreview.Zoom = (int)(MImageBox.MinZoom * 5); ;
					break;
				default:
					break;
			}
		}

		private void mImageBoxPreview_MouseEnter(object sender, EventArgs e)
		{
			mImageBoxPreview.Focus();
		}

		private void checkBoxIncludePts_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxIncludePts.Checked)
				checkBoxExcludePts.Checked = false;
			else
				checkBoxExcludePts.Checked = true;
		}

		private void checkBoxExcludePts_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxExcludePts.Checked)
				checkBoxIncludePts.Checked = false;
			else
				checkBoxIncludePts.Checked = true;
		}

		private void buttonUndo_Click(object sender, EventArgs e)
		{
			try
			{
				object pFrame;
				m_pKey.KeyStepBack(1, out pFrame);
				UpdatePicture(pFrame);
				UpdateKey();
			}
			catch (System.Exception ex) { }
		}

		private void buttonRedo_Click(object sender, EventArgs e)
		{
			try
			{
				object pFrame;
				m_pKey.KeyStepFwd(1, out pFrame);
				UpdatePicture(pFrame);
				UpdateKey();
			}
			catch (System.Exception ex) { }
		}
	}

	public class MNumericSliderAdjust : MNumericSlider
	{
		private eCK_Adjust m_AdjustType;

		public eCK_Adjust AdjustType
		{
			get { return m_AdjustType; }
			set { m_AdjustType = value; }
		}
	}

}
