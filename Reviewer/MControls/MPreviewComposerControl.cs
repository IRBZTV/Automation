using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
//using System.Windows.;
using MPLATFORMLib;

namespace MControls
{
    public partial class MPreviewComposerControl : MPreviewControl
    {

        public FormCameraControl m_frmControl;
        private MElement m_CameraElement;
        private MElement m_SceneElement;
		private MElement m_Element;
        Point? m_StartPosition;

		double m_StartAngle = 0.0;
		double m_dblStartCX;
		double m_dblStartCY;
		double m_dblStartHorz;
		double m_dblStartVert;
		double m_dblStartRotate;

		double m_dblStartX;
		double m_dblStartY;
		double m_dblStartRH;
		double m_dblStartRV;
		double m_dblStartR;


        double m_dblXYModifier = 1.0;
        double m_dblSpinModifier = 5.0;
        double m_dblDistanceModifier = 0.05;
        double m_dblRotateModifier = 10;


        public MPreviewComposerControl()
        {
            InitializeComponent();
            this.panelPreview.MouseWheel += new MouseEventHandler(panelPreview_MouseWheel);
            m_dblStartCX = -1;
            m_dblStartCY = -1;
        }

        void panelPreview_MouseWheel(object sender, MouseEventArgs e)
        {
            int bHave;
            string strValue;

			if (m_Element == null)
			{
				if (m_CameraElement != null && e.Button != MouseButtons.Left && e.Button != MouseButtons.Right)
				{
					double dblIncrement = e.Delta >= 0 ? -m_dblDistanceModifier : m_dblDistanceModifier;
					double dblDistance = 0;
					m_CameraElement.AttributesHave("distance", out bHave, out strValue);
					if (bHave == 1) m_CameraElement.AttributesDoubleGet("distance", out dblDistance);
					dblDistance += dblIncrement;
					m_CameraElement.AttributesDoubleSet("distance", dblDistance);
				}
			}
			else
			{
				if (m_Element != null && e.Button != MouseButtons.Left && e.Button != MouseButtons.Right)
				{
					double dblIncrement = e.Delta >= 0 ? -m_dblDistanceModifier : m_dblDistanceModifier;
					double dblz = 0;
					m_Element.AttributesHave("z", out bHave, out strValue);
					if (bHave == 1) m_Element.AttributesDoubleGet("z", out dblz);
					dblz +=  dblIncrement;
					m_Element.AttributesDoubleSet("z", dblz);
				}
			}
        }

        public override Object SetControlledObject(Object pObject)
        {
            object obj = base.SetControlledObject(pObject);
            IMElements pElementsRoot = (IMElements)pObject;
			SetEditScene(pElementsRoot);
			return obj;
        }

		public void SetEditScene(IMElements _target)
		{
			if (_target != null)
			{
				_target.ElementsGetByID("scene_3d", out m_SceneElement);
				_target.ElementsGetByID("scene_3d::camera", out m_CameraElement);
			}
		}

		public void SetEditElement(MElement _target)
		{
			m_Element = _target;

			if (_target == null)
			{
				labelVisualEditElement.Text = "    Visual edit: Camera";
			}
			string strType, strXML;
			m_Element.ElementGet(out strType, out strXML);
			foreach (string strDefElement in MHelpers.strDefaultElements)
			{
				if (strType.Contains(strDefElement))
				{
					labelVisualEditElement.Text = "    Visual edit: " + strType;
					break;
				}
			}
		}

        double CalcAngle(int nX, int nY )
        {
            double X = (double)(nX - panelPreview.Width / 2) / panelPreview.Width * 2;
            double Y = -1 * (double)(nY - panelPreview.Height / 2) / panelPreview.Height * 2;
            double dblAngle = 360 * Math.Atan2(Y, X) / (2 * Math.PI);
            return dblAngle;
        }

		double CalcAngle2(int nX, int nY)
		{
			double X = (double)(nX - panelPreview.Width / 2) / panelPreview.Width * 2;
			double Y = -1 * (double)(nY - panelPreview.Height / 2) / panelPreview.Height * 2;
			double dblAngle = 360 * Math.Atan2(Y, X) / (2 * Math.PI);
			return dblAngle;
		}

        private void panelPreview_MouseMove(object sender, MouseEventArgs e)
        {
            int bHave;
            string strValue;
			if (m_Element == null)
			{
				if (e.Button == MouseButtons.Right && m_StartPosition != null && m_CameraElement != null)
				{
					double dblDeltaX = ((double)(e.X - m_StartPosition.Value.X) / panelPreview.Width) * -m_dblXYModifier;
					double dblDeltaY = ((double)(e.Y - m_StartPosition.Value.Y) / panelPreview.Height) * m_dblXYModifier;

					double dblCX = m_dblStartCX + dblDeltaX;
					double dblCY = m_dblStartCY + dblDeltaY;

					m_CameraElement.AttributesDoubleSet("cx", dblCX);
					m_CameraElement.AttributesDoubleSet("cy", dblCY);
				}

				if (e.Button == MouseButtons.Left && m_StartPosition != null && m_CameraElement != null && m_SceneElement != null)
				{
					double dblDeltaX = (double)(e.X - m_StartPosition.Value.X) / panelPreview.Width;
					double dblDeltaY = (double)(e.Y - m_StartPosition.Value.Y) / panelPreview.Height;

					if (Control.ModifierKeys != Keys.Control)
					{
						double dblDistance = 0.0;
						double dblViewAngle = 0;
						//m_CameraElement.AttributesHave("view_angle", out bHave, out strValue);
						//if (bHave == 1) 
						m_SceneElement.AttributesDoubleGet("view_angle", out dblViewAngle);

						double dblZOffset = 1.0 / Math.Tan(Math.Max(dblViewAngle, 0.01) / 360 * Math.PI);
						dblDistance += dblZOffset - 1.0;

						dblDistance = Math.Max(dblDistance, 1.0);

						double dblHorzDeltaAngle = (Math.Atan(dblDeltaX / dblDistance)) * 180 / Math.PI * -m_dblSpinModifier;
						double dblVertDeltaAngle = (Math.Atan(dblDeltaY / dblDistance)) * 180 / Math.PI * m_dblSpinModifier;

						double dblHorz = m_dblStartHorz + dblHorzDeltaAngle;
						double dblVert = m_dblStartVert + dblVertDeltaAngle;
						m_CameraElement.AttributesDoubleSet("horz", dblHorz);
						m_CameraElement.AttributesDoubleSet("vert", dblVert);
					}
					else
					{
						double dblAngle = CalcAngle2(e.X, e.Y);
						double dblDelta = m_StartAngle - dblAngle;
						m_CameraElement.AttributesDoubleSet("rotate", m_dblStartRotate - dblDelta);
					}
				}
			}
			else
			{
				if (e.Button == MouseButtons.Right && m_StartPosition != null && m_Element != null)
				{
					double dblDeltaX = ((double)(e.X - m_StartPosition.Value.X) / panelPreview.Width) * m_dblXYModifier;
					double dblDeltaY = ((double)(e.Y - m_StartPosition.Value.Y) / panelPreview.Height) * -m_dblXYModifier;

					double dblX = m_dblStartX + dblDeltaX;
					double dblY = m_dblStartY + dblDeltaY;

					m_Element.AttributesDoubleSet("x", dblX);
					m_Element.AttributesDoubleSet("y", dblY);
				}

				if (e.Button == MouseButtons.Left && m_StartPosition != null && m_Element != null)
				{
					double dblDeltaX = (double)(e.X - m_StartPosition.Value.X) / panelPreview.Width;
					double dblDeltaY = (double)(e.Y - m_StartPosition.Value.Y) / panelPreview.Height;

					if (Control.ModifierKeys != Keys.Control)
					{
						double dblDistance = 0;
						double dblViewAngle = 0;
						//m_CameraElement.AttributesHave("view_angle", out bHave, out strValue);
						//if (bHave == 1) 
						m_SceneElement.AttributesDoubleGet("view_angle", out dblViewAngle);

						double dblZOffset = 1.0 / Math.Tan(Math.Max(dblViewAngle, 0.01) / 360 * Math.PI);
						dblDistance += dblZOffset - 1.0;

						dblDistance = Math.Max(dblDistance, 1.0);

						double dblHorzDeltaAngle = (Math.Atan(dblDeltaX / dblDistance)) * 180 / Math.PI * m_dblSpinModifier;
						double dblVertDeltaAngle = (Math.Atan(dblDeltaY / dblDistance)) * 180 / Math.PI * m_dblSpinModifier;

						double dblHorz = m_dblStartRH + dblHorzDeltaAngle;
						double dblVert = m_dblStartRV + dblVertDeltaAngle;
						m_Element.AttributesDoubleSet("rh", dblHorz);
						m_Element.AttributesDoubleSet("rv", dblVert);
					}
					else
					{
						double dblAngle = CalcAngle(e.X, e.Y);
						
						double dblDelta = m_StartAngle - dblAngle;
						m_Element.AttributesDoubleSet("r", m_dblStartR - dblDelta);
						//Debug.WriteLine(string.Format("Angle={0}, StartAngle={1}, Val={2}", dblAngle, m_StartAngle, m_dblStartR - dblDelta ));
					}
				}
			}


            
        }

        private void panelPreview_MouseHover(object sender, EventArgs e)
        {
            this.panelPreview.Focus();
        }

        private void panelPreview_MouseDown(object sender, MouseEventArgs e)
        {
            this.panelPreview.Focus();
			int bHave;
			string strValue;
            if (m_CameraElement != null)
            {
				m_CameraElement.AttributesHave("cx", out bHave, out strValue);
				if (bHave == 1) m_CameraElement.AttributesDoubleGet("cx", out m_dblStartCX);
				else m_dblStartCX = 0;

				m_CameraElement.AttributesHave("cy", out bHave, out strValue);
				if (bHave == 1) m_CameraElement.AttributesDoubleGet("cy", out m_dblStartCY);
				else m_dblStartCY = 0;

				m_CameraElement.AttributesHave("horz", out bHave, out strValue);
				if (bHave == 1) m_CameraElement.AttributesDoubleGet("horz", out m_dblStartHorz);
				else m_dblStartHorz = 0;

				m_CameraElement.AttributesHave("vert", out bHave, out strValue);
				if (bHave == 1) m_CameraElement.AttributesDoubleGet("vert", out m_dblStartVert);
				else m_dblStartVert = 0;

				m_CameraElement.AttributesHave("rotate", out bHave, out strValue);
				if (bHave == 1) m_CameraElement.AttributesDoubleGet("rotate", out m_dblStartRotate);
				else m_dblStartRotate = 0;
            }

			if (m_Element != null)
			{
				m_Element.AttributesHave("x", out bHave, out strValue);
				if (bHave == 1) m_Element.AttributesDoubleGet("x", out m_dblStartX);
				else m_dblStartX = 0;

				m_Element.AttributesHave("y", out bHave, out strValue);
				if (bHave == 1) m_Element.AttributesDoubleGet("y", out m_dblStartY);
				else m_dblStartY = 0;

				m_Element.AttributesHave("rh", out bHave, out strValue);
				if (bHave == 1) m_Element.AttributesDoubleGet("rh", out m_dblStartRH);
				else m_dblStartRH = 0;

				m_Element.AttributesHave("rv", out bHave, out strValue);
				if (bHave == 1) m_Element.AttributesDoubleGet("rv", out m_dblStartRV);
				else m_dblStartRV = 0;

				m_Element.AttributesHave("r", out bHave, out strValue);
				if (bHave == 1) m_Element.AttributesDoubleGet("r", out m_dblStartR);
				else m_dblStartR = 0;
			}

			m_StartPosition = e.Location;
			m_StartAngle = CalcAngle(e.X, e.Y);
        }

        private void panelPreview_MouseUp(object sender, MouseEventArgs e)
        {
            m_StartPosition = null;
        }
    }
}
