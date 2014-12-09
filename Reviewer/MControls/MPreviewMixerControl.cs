using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using MPLATFORMLib;


namespace MControls
{
    public partial class MPreviewControlMixer : MPreviewControl
    {
        public event EventHandler OnElementClick;

        // Edit element 
        MElement m_pEditElement;

        // Original block rectangle
        RectangleF m_rcOriginal; 
        // Mouse original pos
        PointF     m_ptMouseOriginal;
        // Resizing type
        bool m_bResizingHor;
        bool m_bResizingVert;
        bool m_bTopBound;
        bool m_bLeftBound;
        bool m_bMoving;

        private double m_dblResizeBorderWidth = 0.015;
        public double ResizeBorderWidth
        {
            get { return m_dblResizeBorderWidth; }
            set { m_dblResizeBorderWidth = value; }
        }

        public MPreviewControlMixer()
        {
            InitializeComponent();
        }

        private void MPreviewControlMixer_OnPreviewMouseDown(object sender, EventArgs e)
        {
            MPreviewControl.MPreview_EventArgs arg = (MPreviewControl.MPreview_EventArgs)e;
            double XMouse = arg.ptRelative.X;
            double YMouse = arg.ptRelative.Y;
            if (checkBoxAR.Checked)
                GetNewXY(ref XMouse, ref YMouse);
            
            // Select element in element tree
            MElement pElement = null;
            ((IMScenes)m_pPreview).ScenesElementGetByPos(XMouse, YMouse, 0, out pElement);
            if (pElement != null)
            {
                // Events (TODO: Make special events erg 
                if (this.OnElementClick != null)
                    this.OnElementClick(pElement, EventArgs.Empty );
 
                if (checkBoxVisualEdit.Checked)
                {
                    m_pEditElement = pElement;
                    try
                    {
                        // Could be exception - if scene not rendred yet
                        double x, y, w, h;
                        m_pEditElement.ElementAbsolutePosGet(out x, out y, out w, out h);
                        m_rcOriginal.X = (float)x;
                        m_rcOriginal.Y = (float)y;
                        m_rcOriginal.Width = (float)w;
                        m_rcOriginal.Height = (float)h;
                        Debug.WriteLine("Size get");
                        m_ptMouseOriginal = arg.ptRelative;

                        // TODO: Resize via corners

                        if (Math.Abs(XMouse - x) < m_dblResizeBorderWidth)
                        {
                            m_pPreview.PreviewSetCursor("", eMCursorType.eMCT_SIZEWE);
                            m_bResizingHor = true;
                            m_bLeftBound = true;
                        }
                        else if( Math.Abs(XMouse - x - w) < m_dblResizeBorderWidth)
                        {
                            m_pPreview.PreviewSetCursor("", eMCursorType.eMCT_SIZEWE);
                            m_bResizingHor = true;
                        }
                        else if ( Math.Abs(YMouse - y) < m_dblResizeBorderWidth)
                        {
                            m_pPreview.PreviewSetCursor("", eMCursorType.eMCT_SIZENS);
                            m_bResizingVert = true;
                            m_bTopBound = true;
                        }
                        else if (Math.Abs(YMouse - y - h) < m_dblResizeBorderWidth)
                        {
                            m_pPreview.PreviewSetCursor("", eMCursorType.eMCT_SIZENS);
                            m_bResizingVert = true;
                        }
                        else
                        {
                            m_pPreview.PreviewSetCursor("", eMCursorType.eMCT_SIZEALL);
                            m_bMoving = true;
                        }
                        // Make element topmost
                        m_pEditElement.ElementReorder(10000);
                    }
                    catch (System.Exception){}
                }
            }

           
        }

        private void MPreviewControlMixer_OnPreviewMouseMove(object sender, EventArgs e)
        {
            if (checkBoxVisualEdit.Checked)
            {
                MPreviewControl.MPreview_EventArgs arg = (MPreviewControl.MPreview_EventArgs)e;
                double XMouse = arg.ptRelative.X;
                double YMouse = arg.ptRelative.Y;


                if (m_pEditElement != null)
                {
                    int xOffset = (int)(panelPreview.Width * 0.1);
                    int yOffset = (int)(panelPreview.Height * 0.1);
                    if( ((MouseEventArgs)e).Button == MouseButtons.Left && 
                        ( (arg.X>=0 && arg.X<=xOffset) ||
                          (arg.X>=panelPreview.Width-xOffset  && arg.X<=panelPreview.Width) || 
                          (arg.Y>=0 && arg.Y<=yOffset) ||
                          (arg.Y >= panelPreview.Height - yOffset && arg.Y <= panelPreview.Height)))
                    {
                        MPreviewControlMixer_OnPreviewMouseUp(this, e);
                        m_pEditElement = null;
                        m_bMoving = false;
                        return;
                    }

                    RectangleF rcNew = m_rcOriginal;
                    if (m_bMoving)
                    {
                        m_pPreview.PreviewSetCursor("", eMCursorType.eMCT_SIZEALL);
                        rcNew.X += arg.ptRelative.X - m_ptMouseOriginal.X;
                        rcNew.Y += arg.ptRelative.Y - m_ptMouseOriginal.Y;
                    }
                    else
                    {
                        // For AR correction
                        double x, y, w, h;
                        m_pEditElement.ElementAbsolutePosGet(out x, out y, out w, out h);

                        if (m_bResizingHor)
                        {
                            m_pPreview.PreviewSetCursor("", eMCursorType.eMCT_SIZEWE);

                            if (m_bLeftBound)
                            {
                                rcNew.X += arg.ptRelative.X - m_ptMouseOriginal.X;
                                rcNew.Width -= arg.ptRelative.X - m_ptMouseOriginal.X;
                            }
                            else
                                rcNew.Width += arg.ptRelative.X - m_ptMouseOriginal.X;

                            Debug.WriteLine(m_ptMouseOriginal.X);

                            rcNew.Y = (float)y;
                            rcNew.Height = (float)h;
                            w = rcNew.Width;
                        }
                        if (m_bResizingVert)
                        {
                            m_pPreview.PreviewSetCursor("", eMCursorType.eMCT_SIZENS);
                            if (m_bTopBound)
                            {
                                rcNew.Y += arg.ptRelative.Y - m_ptMouseOriginal.Y;
                                rcNew.Height -= arg.ptRelative.Y - m_ptMouseOriginal.Y;
                            }
                            else
                                rcNew.Height += arg.ptRelative.Y - m_ptMouseOriginal.Y;

                            rcNew.X = (float)x;
                            rcNew.Width = (float)w;
                        }
                    }

                    m_pEditElement.ElementAbsolutePosSet(rcNew.X, rcNew.Y, rcNew.Width, rcNew.Height);
                }
                else
                {
                    // For change mouse cursor
                    if (checkBoxAR.Checked)
                        GetNewXY(ref XMouse, ref YMouse);

                    // Select element in element tree
                    MElement pElement = null;
                    ((IMScenes)m_pPreview).ScenesElementGetByPos(XMouse, YMouse, 0, out pElement);
                    if (pElement != null)
                    {
                        try
                        {
                            // Could be exception - if scene not rendred yet
                            double x, y, w, h;
                            pElement.ElementAbsolutePosGet(out x, out y, out w, out h);

                            if (Math.Abs(XMouse - x) < m_dblResizeBorderWidth || Math.Abs(XMouse - x - w) < m_dblResizeBorderWidth)
                            {
                                m_pPreview.PreviewSetCursor("", eMCursorType.eMCT_SIZEWE);
                            }
                            else if (Math.Abs(YMouse - y) < m_dblResizeBorderWidth || Math.Abs(YMouse - y - h) < m_dblResizeBorderWidth)
                            {
                                m_pPreview.PreviewSetCursor("", eMCursorType.eMCT_SIZENS);
                            }
                            else
                            {
                                m_pPreview.PreviewSetCursor("", eMCursorType.eMCT_SIZEALL);
                            }
                        }
                        catch (System.Exception) { }
                    }
                    else
                    {
                        m_pPreview.PreviewSetCursor("", eMCursorType.eMCT_ARROW);
                    }
                }
            }
        }

        private void MPreviewControlMixer_OnPreviewMouseUp(object sender, EventArgs e)
        {
            if (checkBoxVisualEdit.Checked)
            {
                // End element move/resize
                m_pPreview.PreviewSetCursor("", eMCursorType.eMCT_ARROW);
                //m_objMixer.ScenesOnMouseMove(0, 0, eMMoveOption.eMMO_Done);

                //Debug.WriteLine("mPreviewControl1_OnPreviewMouseUp");
                m_pEditElement = null;

                m_bMoving = false;
                m_bResizingHor = false;
                m_bResizingVert = false;
                m_bLeftBound = false;
                m_bTopBound = false;
            }
        }
        private void GetNewXY(ref double x, ref double y)
        {
            IMFormat pFormat = (IMFormat)m_pPreview;
            M_VID_PROPS vProps;
            int nIndex;
            string strNmae;
            pFormat.FormatVideoGet(eMFormatType.eMFT_Output, out vProps, out nIndex, out strNmae);
            double videoAspectRatio = (double)vProps.nAspectX / (double)vProps.nAspectY;
            if (vProps.nAspectX == 0 && vProps.nAspectY == 0)
            {
                videoAspectRatio = (double)vProps.nWidth / (double)vProps.nHeight;
            }

            Debug.WriteLine("AR" + videoAspectRatio.ToString() );
            
            double previewAspectRatio = (double)panelPreview.Width / (double)panelPreview.Height;
            double kX = 0;
            double kY = 0;

            if (videoAspectRatio < previewAspectRatio)
            {
                kX = (videoAspectRatio * (double)panelPreview.Height) / (double)panelPreview.Width;
                x = (x - 0.5) / kX + 0.5;
            }
            else
            {
                kY = (double)panelPreview.Width / (videoAspectRatio * (double)panelPreview.Height);
                y = (y - 0.5) / kY + 0.5;
            }        
        }

        private void MPreviewControlMixer_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
