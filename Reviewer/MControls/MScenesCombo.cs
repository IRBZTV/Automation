using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MControls
{
    public partial class MScenesCombo : ComboBox
    {
        IMScenes m_pScenes;
        public MScenesCombo()
        {
            InitializeComponent();
        }

        public event EventHandler OnActiveSceneChange;

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pScenes;
            try
            {
                m_pScenes = (IMScenes)pObject;

                UpdateCombo();
            }
            catch (System.Exception) { }

            return pOld;
        }

        public void UpdateCombo()
        {
            Items.Clear();

            IMElements pScene;
            string sSceneName;

            int nCount = 0;
            m_pScenes.ScenesGetCount(out nCount);
            for (int i = 0; i < nCount; i++)
            {
                m_pScenes.ScenesGetByIndex(i, out sSceneName, out pScene);

                Items.Add(sSceneName);
            }

            int nIndex = 0;
            m_pScenes.ScenesActiveGet(out sSceneName, out nIndex, out pScene);

            int nSel = FindStringExact(sSceneName);
            SelectedIndex = nSel;
        }

        private void MScenesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_pScenes.ScenesActiveSet(SelectedItem.ToString(), "");

            if (this.OnActiveSceneChange != null )
                this.OnActiveSceneChange(this, e);
        }
    }
}
