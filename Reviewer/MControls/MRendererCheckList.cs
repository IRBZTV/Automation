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
    public partial class MRendererCheckList : ListViewEx
    {
        private Object m_pSrcObject;

        public class MRenderer_EventArgs : EventArgs
        {
            public MRendererClass pRenderer;
            public bool bStart;
            public bool bHaveStarted;

            public MRenderer_EventArgs(MRendererClass _pRenderer, bool _bStart, bool _bHaveStarted)
            {
                pRenderer = _pRenderer;
                bStart = _bStart;
                bHaveStarted = _bHaveStarted;
            }
        }

        public event EventHandler OnRenderingChange;
        
        public MRendererCheckList()
        {
            InitializeComponent();

            Columns[1].Tag = new ComboBox();
            Columns[2].Tag = new ComboBox();
            Columns[3].Tag = new ComboBox();
        }

        public Object SetSourceObject(Object pObject)
        {
            Object pOld = (Object)m_pSrcObject;
            try
            {
                ClearRenderers();

                m_pSrcObject = (Object)pObject;

                if (m_pSrcObject != null )
                    FillRenderers();
            }
            catch (System.Exception) { }

            return pOld;
        }

        private void FillRenderers()
        {
            ClearRenderers();

            try
            {
                MRendererClass pRender = new MRendererClass();
                int nDevices = 0;
                pRender.DeviceGetCount(0, "renderer", out nDevices);
                for (int i = 0; i < nDevices; i++)
                {
                    string strName;
                    string strXML;
                    pRender.DeviceGetByIndex(0, "renderer", i, out strName, out strXML);

                    MRendererClass pDevice = new MRendererClass();
                    pDevice.DeviceSet("renderer", strName, "");

                    // TODO: Make common method

                    // Add lines
                    ListViewItem lvItem = AddNewItem(strName, 0);
                    lvItem.Tag = pDevice;

                    ComboBox pComboLineOut = (ComboBox)lvItem.SubItems[1].Tag;
                    int nLines = 0;
                    pDevice.DeviceGetCount( 0, "renderer::line-out", out nLines );
                    for (int k = 0; k < nLines; k++)
                    {
                        pRender.DeviceGetByIndex(0, "renderer::line-out", k, out strName, out strXML);

                        pComboLineOut.Items.Add(strName);
                    }

                    if (pComboLineOut.Items.Count > 0)
                        pComboLineOut.SelectedIndex = 0;


                    // Add keying
                    ComboBox pComboKey = (ComboBox)lvItem.SubItems[2].Tag;
                    

                    pDevice.DeviceGetCount(0, "renderer::keying", out nLines);
                    for (int k = 0; k < nLines; k++)
                    {
                        pRender.DeviceGetByIndex(0, "renderer::keying", k, out strName, out strXML);

                        pComboKey.Items.Add(strName);
                    }

                    if (pComboKey.Items.Count > 0)
                        pComboKey.SelectedIndex = 0;

                    // Add line out
                    ComboBox pComboLineIn = (ComboBox)lvItem.SubItems[3].Tag;
                    

                    pDevice.DeviceGetCount(0, "renderer::line-in", out nLines);
                    for (int k = 0; k < nLines; k++)
                    {
                        pRender.DeviceGetByIndex(0, "renderer::line-in", k, out strName, out strXML);

                        pComboLineIn.Items.Add(strName);
                    }

                    if (pComboLineIn.Items.Count > 0)
                        pComboLineIn.SelectedIndex = 0;
                }
            }
            catch (System.Exception) { }
        }

        void ClearRenderers()
        {
            try
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    IMObject pObject = (IMObject)Items[i].Tag;
                    pObject.ObjectClose();
                }

                Items.Clear();
            }
            catch (System.Exception) { }
        }

        private void MRendererCheckList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            bool bHaveStarted = false;
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].Checked && i != e.Index )
                {
                    bHaveStarted = true;
                    break;
                }
            }
            IMObject pObject = (IMObject)Items[e.Index].Tag;
            if (e.NewValue == CheckState.Checked)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    ((IMProps)pObject).PropsSet("rate-control", "true");
                    pObject.ObjectStart(m_pSrcObject);

                    // Events
                    {
                        MRenderer_EventArgs pArg = new MRenderer_EventArgs((MRendererClass)pObject, true, true);

                        EventHandler handler = this.OnRenderingChange;
                        if (handler != null)
                            handler(this, pArg);
                    }
                }
                catch (System.Exception ex)
                {
                    Cursor.Current = Cursors.Default;

                    MessageBox.Show("Error start output to '" + Items[e.Index].Text + "'\n\nErr = " + ex.ToString());
                    e.NewValue = CheckState.Unchecked;
                }

                Cursor.Current = Cursors.Default;
            }
            else
            {
                try
                {
                    pObject.ObjectClose();

                    // Events
                    {
                        MRenderer_EventArgs pArg = new MRenderer_EventArgs((MRendererClass)pObject, false, bHaveStarted);

                        EventHandler handler = this.OnRenderingChange;
                        if (handler != null)
                            handler(this, pArg);
                    }
                }
                catch (System.Exception) { }
            }
        }

        private void MRendererCheckList_ListSubItemChanged(object sender, EventArgs e)
        {
            ListViewEx_EventArgs lvEvent = (ListViewEx_EventArgs)e;

            try
            {
                IMDevice pDevice = (IMDevice)lvEvent.lvItem.Tag;

                if (lvEvent.nSubItem == 1) // Line-out
                    pDevice.DeviceSet("renderer::line-out", lvEvent.lvSubItem.Text, "");
                if (lvEvent.nSubItem == 2) // keying
                    pDevice.DeviceSet("renderer::keying", lvEvent.lvSubItem.Text, "");
                if (lvEvent.nSubItem == 3) // Line-in
                    pDevice.DeviceSet("renderer::line-in", lvEvent.lvSubItem.Text, "");
            }
            catch (System.Exception)
            {
            	// TODO:
            }
        }
    }
}

