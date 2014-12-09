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
    public partial class MDeviceControl : MControls.ListViewEx
    {
        public MDeviceControl()
        {
            InitializeComponent();

            Columns[1].Tag = new ComboBox();
        }

        private IMDevice m_pDevice;

        public event EventHandler MDeviceChanged;

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pDevice;
            try
            {
                m_pDevice = (IMDevice)pObject;

                FillList( -1 );
            }
            catch (System.Exception) { }

            return pOld;
        }

        // Special flag for prevent nested calls
        int m_nFillList = 0;

        private void FillList(int nStartIndex)
        {
            m_nFillList++;

            ClearList(nStartIndex);
            nStartIndex = nStartIndex < Items.Count ? nStartIndex : Items.Count - 1;
            

            // For set video format
            //             M_VID_PROPS vidProps = new M_VID_PROPS();
            //             vidProps.eVideoFormat = eMVideoFormat.eMVF_NTSC;
            //             m_pMDevice.DeviceFormatSetVideo(ref vidProps);

            // For set composite
            // DeviceGetCount( 1, "renderer::line-out", .. ) -> Y-Cb-Cr, Composite, S-Video...
            // DeviceGetByIndex(...)
            // If line-name == composite -> DeviceSet( "renderer::line-out", line-name);
            try
            {
                // DeviceGetCount( 0, "renderer", .. ) -> Intensity, Decklink,
                // DeviceGetCount( 1, "", .. ) -> renderer,
                // DeviceGetCount( 1, "renderer", .. ) -> line-out, keying, format....

                // DeviceGetCount( 0, "renderer::line-out", .. ) -> Y-Cb-Cr, Composite, S-Video...

                string strType, strName, strXML, strBaseType = "";
                if (nStartIndex >= 0 )
                {
                    strBaseType = Items[nStartIndex].Text;
                }

                // DeviceGetCount( 1, "", .. ) -> video, audio,
                int nTypes = 0;
                m_pDevice.DeviceGetCount(1, strBaseType, out nTypes);
                for (int i = 0; i < nTypes; i++)
                {
                    // Get types (first column)
                    m_pDevice.DeviceGetByIndex( 1, strBaseType, i, out strType, out strXML );

                    // Check for already fill this type (e.g. audio for Decklink)
                    bool bHaveType = false;
                    for (int n = 0; n < Items.Count; n++)
                    {
                        if (Items[n].Text == strType)
                        {
                            bHaveType = true;
                            break;
                        }
                    }

                    if (bHaveType)
                        continue;
                    
                    // Add type (e.g. 'video')
                    ComboBox pCombo;
                    AddNewItem_Combo(strType, 0, out pCombo);

                    // Enum type (e.g. 'video' -> Intensity, Decklink )
                    int nDevices = 0;
                    m_pDevice.DeviceGetCount(0, strType, out nDevices);
                    for( int k = 0; k < nDevices; k++ )
                    {
                        m_pDevice.DeviceGetByIndex( 0, strType, k, out strName, out strXML );

                        pCombo.Items.Add( strName );
                    }

                    // Get current
                    if (pCombo.Items.Count > 0)
                    {
                        int nIndex = 0;
                        try
                        {
                            m_pDevice.DeviceGet(strType, out strName, out strXML, out nIndex);
                            int nSel = pCombo.FindStringExact(strName);
                            pCombo.SelectedIndex = nSel >= 0 ? nSel : 0;
                        }
                        catch (System.Exception)
                        {
                            pCombo.SelectedIndex = 0;
                        }
                    }
                    
                    

                    // Enum nested (e.g. video::line-in
                    FillList( Items.Count );
                }
            }
            catch (System.Exception) { }

            m_nFillList--;
        }

        private void ClearList(int nStartIndex)
        {
            for (int i = Items.Count - 1; i > nStartIndex; i--)
            {
                Items.RemoveAt(i);
            }
        }

        private void MDeviceControl_ListSubItemChanged(object sender, EventArgs e)
        {
            ListViewEx_EventArgs pEvent = (ListViewEx_EventArgs)e;

            try
            {
                // Set device
                m_pDevice.DeviceSet(pEvent.lvItem.Text, pEvent.lvSubItem.Text, "");
                // Update list
                if( m_nFillList == 0 )
                    FillList(-1);

                // For handler
                EventHandler handler = this.MDeviceChanged;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
            catch (System.Exception)
            {
            	// TODO: Error message
                if (m_nFillList == 0)
                    FillList(-1); 
            }
        }

    }
}

