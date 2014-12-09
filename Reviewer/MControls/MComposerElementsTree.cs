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
    public partial class MComposerElementsTree : MElementsTree
    {

        public MComposerElementsTree()
        {
            InitializeComponent();
            this.MouseClick += new MouseEventHandler(MComposerElementsTree_MouseClick);
            this.KeyDown += new KeyEventHandler(MComposerElementsTree_KeyDown);
        }

        void MComposerElementsTree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelected();
            }
            if (e.Control && e.KeyCode == Keys.Up)
            {
                MoveSelectedUp();
            }

            if (e.Control && e.KeyCode == Keys.Down)
            {
                MoveSelectedDown();
            }
        }

        //protected static List<string> strBaseSceneTypes = new List<string>(new string[] { "background", "scene_3d", "foreground" });
        //protected static List<string> strChildSceneTypes = new List<string>(new string[] { "group", "block", "img", "video", "crawl", "roll", "matrix", "cloud", "cube", "polygon", "star", "ticker", "ticker_item", "loaded_item" });

        private List<MElemementDescriptor> m_ElementDescriptors;
        MElemementDescriptor m_CurrDescriptor;

        public List<MElemementDescriptor> ElementDescriptors
        {
            get { return m_ElementDescriptors; }
            set { m_ElementDescriptors = value; }
        }


        void MComposerElementsTree_MouseClick(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo hitInfo = HitTest(PointToClient(Cursor.Position));
            if (e.Button == MouseButtons.Right && (hitInfo.Location == TreeViewHitTestLocations.Indent || hitInfo.Location == TreeViewHitTestLocations.Label))
            {

                MElement selElement = (MElement)hitInfo.Node.Tag;
                this.SelectedNode = hitInfo.Node;

                int nCount;
                selElement.AttributesGetCount(out nCount);
                string strType, strDesc;
                selElement.ElementTypeGet(out strType);
                if (strType.Contains("."))
                    strType = strType.Substring(0, strType.IndexOf('.'));
                string strID;
                int bHaveID = 0;
                selElement.AttributesHave("id", out bHaveID, out strID);

                ContextMenu cMenu = null;
                if (m_ElementDescriptors != null && m_ElementDescriptors.Count > 0)
                {
                    foreach (MElemementDescriptor desc in m_ElementDescriptors)
                    {
                        if (desc.strName == strType)
                        {
                            m_CurrDescriptor = desc;
                            cMenu = GetContextMenu(desc);
                            break;
                        }
                    }
                }

                if (cMenu != null)
                    cMenu.Show(this, PointToClient(Cursor.Position));

            }
        }

        private ContextMenu GetContextMenu(MElemementDescriptor _descriptor)
        {
            ContextMenu res = new ContextMenu();
            if (_descriptor.strAvailableOptions.Count > 0)
            {
                List<MenuItem> menuItems = new List<MenuItem>();
                for (int i = 0; i < _descriptor.strAvailableOptions.Count; i++)
                {
                    MenuItem item = new MenuItem(_descriptor.strAvailableOptions[i]);
                    if (_descriptor.strAvailableOptions[i] == "Add Video")
                        item.Click += new EventHandler(menuItem_AddVideoClick);
                    if (_descriptor.strAvailableOptions[i] == "Add Text")
                        item.Click += new EventHandler(menuItem_AddTextClick);
                    if (_descriptor.strAvailableOptions[i] == "Add Block")
                        item.Click += new EventHandler(menuItem_AddBlockClick);
                    if (_descriptor.strAvailableOptions[i] == "Add Group")
                        item.Click += new EventHandler(menuItem_AddGroupClick);
                    if (_descriptor.strAvailableOptions[i] == "Add Image")
                        item.Click += new EventHandler(menuItem_AddImageClick);
                    if (_descriptor.strAvailableOptions[i] == "Add Crawl")
                        item.Click += new EventHandler(menuItem_AddCrawlClick);
                    if (_descriptor.strAvailableOptions[i] == "Add Roll")
                        item.Click += new EventHandler(menuItem_AddRollClick);
                    if (_descriptor.strAvailableOptions[i] == "Add Matrix")
                        item.Click += new EventHandler(menuItem_AddMatrixClick);
                    if (_descriptor.strAvailableOptions[i] == "Add Cloud")
                        item.Click += new EventHandler(menuItem_AddCloudClick);
                    if (_descriptor.strAvailableOptions[i] == "Add Cube")
                        item.Click += new EventHandler(menuItem_AddCubeClick);
                    if (_descriptor.strAvailableOptions[i] == "Add Polygon")
                        item.Click += new EventHandler(menuItem_AddPolygonClick);
                    if (_descriptor.strAvailableOptions[i] == "Add Star")
                        item.Click += new EventHandler(menuItem_AddStarClick);
                    if (_descriptor.strAvailableOptions[i] == "Add View")
                        item.Click += new EventHandler(menuItem_AddViewClick);
                    if (_descriptor.strAvailableOptions[i] == "Remove")
                    {
						res.MenuItems.Add("-");
                        item.Click += new EventHandler(menuItem_RemoveClick);
                        item.Text = "Remove (Del)";
                    }
                    if (_descriptor.strAvailableOptions[i] == "Invoke")
                        item.Click += new EventHandler(menuItem_InvokeClick);
                    if (_descriptor.strAvailableOptions[i] == "Add Ticker")
                        item.Click += new EventHandler(menuItem_AddTickerClick);
                    if (_descriptor.strAvailableOptions[i] == "Add Rear Side")
                        item.Click += new EventHandler(menuItem_AddRearClick);
                    if (_descriptor.strAvailableOptions[i] == "Add Cell")
                        item.Click += new EventHandler(menuItem_AddCellClick);
                    if (_descriptor.strAvailableOptions[i] == "Add Face")
                        item.Click += new EventHandler(menuItem_AddFaceClick);
                    if (_descriptor.strAvailableOptions[i] == "Move Up")
                    {
                        item.Click += new EventHandler(menuItem_MoveUpClick);
                        item.Text = "Move Up (Ctrl + Up)";
                    }
                    if (_descriptor.strAvailableOptions[i] == "Move Down")
                    {
                        item.Click += new EventHandler(menuItem_MoveDownClick);
                        item.Text = "Move Down (Ctrl + Down)";
                    }
                    
                    res.MenuItems.Add(item);
                }
            }
            return res;
        }

        private void menuItem_AddVideoClick(object sender, EventArgs e)
        {
            MElemementDescriptor addDescriptor = GetDescriptorByName("video");
            FormInputElementContent frmI = new FormInputElementContent(addDescriptor.strDefaultXML, addDescriptor.strDemoXML);
            frmI.StartPosition = FormStartPosition.CenterParent;
            DialogResult ds = frmI.ShowDialog();
            if (ds == DialogResult.OK)
            {
                AddElementToTreeView(addDescriptor.strName, frmI.strOutContent);
            }
        }

        private void menuItem_AddTextClick(object sender, EventArgs e)
        {
            MElemementDescriptor addDescriptor = GetDescriptorByName("text");
            FormInputElementContent frmI = new FormInputElementContent(addDescriptor.strDefaultXML, addDescriptor.strDemoXML);
            frmI.StartPosition = FormStartPosition.CenterParent;
            DialogResult ds = frmI.ShowDialog();
            if (ds == DialogResult.OK)
            {
                AddElementToTreeView(addDescriptor.strName, frmI.strOutContent);
            }
        }

        private void menuItem_AddBlockClick(object sender, EventArgs e)
        {
            MElemementDescriptor addDescriptor = GetDescriptorByName("block");
            FormInputElementContent frmI = new FormInputElementContent(addDescriptor.strDefaultXML, addDescriptor.strDemoXML);
            frmI.StartPosition = FormStartPosition.CenterParent;
            DialogResult ds = frmI.ShowDialog();
            if (ds == DialogResult.OK)
            {
                AddElementToTreeView(addDescriptor.strName, frmI.strOutContent);
            }
        }

        private void menuItem_AddGroupClick(object sender, EventArgs e)
        {
            MElemementDescriptor addDescriptor = GetDescriptorByName("group");
            FormInputElementContent frmI = new FormInputElementContent(addDescriptor.strDefaultXML, addDescriptor.strDemoXML);
            frmI.StartPosition = FormStartPosition.CenterParent;
            DialogResult ds = frmI.ShowDialog();
            if (ds == DialogResult.OK)
            {
                AddElementToTreeView(addDescriptor.strName, frmI.strOutContent);
            }
        }

        private void menuItem_AddImageClick(object sender, EventArgs e)
        {
            MElemementDescriptor addDescriptor = GetDescriptorByName("img");
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "Image Files |*.jpeg; *.jpg; *.png";
            dlg.InitialDirectory = @"C:\";
            dlg.Title = "Please select an image file";
            dlg.Title = "Please select the text file";
            string strDemoXml = addDescriptor.strDemoXML;
            if (dlg.ShowDialog() == DialogResult.OK && addDescriptor.strDemoXML.Contains(@"src=''"))
                strDemoXml = strDemoXml.Replace(@"src=''", string.Format(@"src='{0}'", dlg.FileName));

            FormInputElementContent frmI = new FormInputElementContent(addDescriptor.strDefaultXML, strDemoXml);
            frmI.StartPosition = FormStartPosition.CenterParent;
            DialogResult ds = frmI.ShowDialog();
            if (ds == DialogResult.OK)
            {
                AddElementToTreeView(addDescriptor.strName, frmI.strOutContent);
            }
        }

        private void menuItem_AddCrawlClick(object sender, EventArgs e)
        {
            MElemementDescriptor addDescriptor = GetDescriptorByName("crawl");
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "Txt Files |*.txt";
            dlg.InitialDirectory = @"C:\";
            dlg.Title = "Please select the text file";
            string strDemoXml = addDescriptor.strDemoXML;
            if (dlg.ShowDialog() == DialogResult.OK && addDescriptor.strDemoXML.Contains(@"src=''"))
                strDemoXml = strDemoXml.Replace(@"src=''", string.Format(@"src='{0}'", dlg.FileName));

            FormInputElementContent frmI = new FormInputElementContent(addDescriptor.strDefaultXML, strDemoXml);
            frmI.StartPosition = FormStartPosition.CenterParent;
            DialogResult ds = frmI.ShowDialog();
            if (ds == DialogResult.OK)
            {
                AddElementToTreeView(addDescriptor.strName, frmI.strOutContent);
            }
        }

        private void menuItem_AddRollClick(object sender, EventArgs e)
        {
            MElemementDescriptor addDescriptor = GetDescriptorByName("roll");
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "Txt Files |*.txt";
            dlg.InitialDirectory = @"C:\";
            dlg.Title = "Please select the text file";
            string strDemoXml = addDescriptor.strDemoXML;
            if (dlg.ShowDialog() == DialogResult.OK && addDescriptor.strDemoXML.Contains(@"src=''"))
                strDemoXml = strDemoXml.Replace(@"src=''", string.Format(@"src='{0}'", dlg.FileName));

            FormInputElementContent frmI = new FormInputElementContent(addDescriptor.strDefaultXML, strDemoXml);
            frmI.StartPosition = FormStartPosition.CenterParent;
            DialogResult ds = frmI.ShowDialog();
            if (ds == DialogResult.OK)
            {
                AddElementToTreeView(addDescriptor.strName, frmI.strOutContent);
            }
        }

        private void menuItem_AddMatrixClick(object sender, EventArgs e)
        {
            MElemementDescriptor addDescriptor = GetDescriptorByName("matrix");
            FormInputElementContent frmI = new FormInputElementContent(addDescriptor.strDefaultXML, addDescriptor.strDemoXML);
            frmI.StartPosition = FormStartPosition.CenterParent;
            DialogResult ds = frmI.ShowDialog();
            if (ds == DialogResult.OK)
            {
                AddElementToTreeView(addDescriptor.strName, frmI.strOutContent);
            }
        }

        private void menuItem_AddCloudClick(object sender, EventArgs e)
        {
            MElemementDescriptor addDescriptor = GetDescriptorByName("cloud");
            FormInputElementContent frmI = new FormInputElementContent(addDescriptor.strDefaultXML, addDescriptor.strDemoXML);
            frmI.StartPosition = FormStartPosition.CenterParent;
            DialogResult ds = frmI.ShowDialog();
            if (ds == DialogResult.OK)
            {
                AddElementToTreeView(addDescriptor.strName, frmI.strOutContent);
            }
        }

        private void menuItem_AddCubeClick(object sender, EventArgs e)
        {
            MElemementDescriptor addDescriptor = GetDescriptorByName("cube");
            FormInputElementContent frmI = new FormInputElementContent(addDescriptor.strDefaultXML, addDescriptor.strDemoXML);
            frmI.StartPosition = FormStartPosition.CenterParent;
            DialogResult ds = frmI.ShowDialog();
            if (ds == DialogResult.OK)
            {
                AddElementToTreeView(addDescriptor.strName, frmI.strOutContent);
            }
        }

        private void menuItem_AddPolygonClick(object sender, EventArgs e)
        {
            MElemementDescriptor addDescriptor = GetDescriptorByName("polygon");
            FormInputElementContent frmI = new FormInputElementContent(addDescriptor.strDefaultXML, addDescriptor.strDemoXML);
            frmI.StartPosition = FormStartPosition.CenterParent;
            DialogResult ds = frmI.ShowDialog();
            if (ds == DialogResult.OK)
            {
                AddElementToTreeView(addDescriptor.strName, frmI.strOutContent);
            }
        }

        private void menuItem_AddStarClick(object sender, EventArgs e)
        {
            MElemementDescriptor addDescriptor = GetDescriptorByName("star");
            FormInputElementContent frmI = new FormInputElementContent(addDescriptor.strDefaultXML, addDescriptor.strDemoXML);
            frmI.StartPosition = FormStartPosition.CenterParent;
            DialogResult ds = frmI.ShowDialog();
            if (ds == DialogResult.OK)
            {
                AddElementToTreeView(addDescriptor.strName, frmI.strOutContent);
            }
        }

        private void menuItem_AddViewClick(object sender, EventArgs e)
        {
            AddElementToTreeView("view", "");
        }

        private void menuItem_RemoveClick(object sender, EventArgs e)
        {
            RemoveSelected();
        }

        private void menuItem_InvokeClick(object sender, EventArgs e)
        {
            MElement pTargetElement = this.SelectedElement;
            if (pTargetElement != null)
            {
                int bHave = 0;
                string sSelected;
                pTargetElement.AttributesHave("selected", out bHave, out sSelected);
                if (bHave == 0 || sSelected != "true")
                {
                    pTargetElement.ElementInvoke("select", "true", TimeForChange);
                }
                else
					pTargetElement.ElementInvoke("select", "false", TimeForChange);
            }
        }

        private void menuItem_AddTickerClick(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "Text Files |*.txt";
            dlg.InitialDirectory = @"C:\";
            dlg.Title = "Please select text file, preferably with short strings";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                AddElementToTreeView("Ticker", string.Format(@"<ticker id='ticker_shift'  item_update='shift' display_time='6.0' in_time='1.0' delay='0.1' out_time='1.0' h='0.5' w='0.5' src='{0}' show='1'>
	                                                                <block shape='rrect-r05' d='0.0' border='0' h='0.7' pos='top' color='black(80)'>
		                                                                <group limit='true' h='0.9' pos='center' w='0.9'>
			                                                                <ticker_item id='line_1' pos='top-left' h='0.33' w='1.0'>
				                                                                <on_show x='1.0'/>
				                                                                <on_hide z='3'/>
			                                                                </ticker_item>
			                                                                <ticker_item id='line_1' pos='top-left' y='.33' h='0.33' w='1.0'>
				                                                                <on_show x='1.0'/>
				                                                                <on_hide z='3'/>
			                                                                </ticker_item>
			                                                                <ticker_item id='line_1' pos='top-left' y='.66' h='0.33' w='1.0'>
				                                                                <on_show x='1.0'/>
				                                                                <on_hide z='10'/>
			                                                                </ticker_item>
		                                                                </group>
	                                                                </block>
	                                                                <block shape='box-lr-i' h='0.25' y='-0.35' d='0.0' limit='true' pos='center' rv='126720.0'>
		                                                                <on_ticker_next time='1'>
			                                                                <add rv='360'/>
		                                                                </on_ticker_next>
		                                                                <ticker_item id='line_1' h='0.9' w='1.0'>
			                                                                <on_show x='1.0'/>
		                                                                </ticker_item>
		                                                                <back>
			                                                                <ticker_item id='line_1' h='0.9' w='1.0'>
				                                                                <on_show x='1.0'/>
			                                                                </ticker_item>
		                                                                </back>
	                                                                </block>
                                                                </ticker>", dlg.FileName));
            } 
        }

        private void menuItem_AddRearClick(object sender, EventArgs e)
        {
            MElemementDescriptor addDescriptor = GetDescriptorByName("rear_side");
            FormInputElementContent frmI = new FormInputElementContent(addDescriptor.strDefaultXML, addDescriptor.strDemoXML);
            frmI.StartPosition = FormStartPosition.CenterParent;
            DialogResult ds = frmI.ShowDialog();
            if (ds == DialogResult.OK)
            {
                AddElementToTreeView(addDescriptor.strName, frmI.strOutContent);
            }
        }

        private void menuItem_AddCellClick(object sender, EventArgs e)
        {
            MElemementDescriptor addDescriptor = GetDescriptorByName("cell");
            FormInputElementContent frmI = new FormInputElementContent(addDescriptor.strDefaultXML, addDescriptor.strDemoXML);
            frmI.StartPosition = FormStartPosition.CenterParent;
            frmI.panelCellFace.Visible = true;
            DialogResult ds = frmI.ShowDialog();
            if (ds == DialogResult.OK)
            {
                MElement pTargetElement = this.SelectedElement;
                string strContent = frmI.strOutContent;
                if (frmI.strOutContent.Contains(@"<cell>") && frmI.strOutContent.Contains(@"</cell>") && pTargetElement != null)
                {
                    int bHave;
                    string strValue;
                    pTargetElement.AttributesHave("layers", out bHave, out strValue);
                    if (bHave == 1 && strValue != "1")
                    {
                        strContent = frmI.strOutContent.Replace(@"<cell>", string.Format(@"<cell.{0}.{1}.{2}>", frmI.numeric1.Value.ToString(), frmI.numeric2.Value.ToString(), frmI.numeric3.Value.ToString()));
                        strContent = strContent.Replace(@"</cell>", string.Format(@"</cell.{0}.{1}.{2}>", frmI.numeric1.Value.ToString(), frmI.numeric2.Value.ToString(), frmI.numeric3.Value.ToString()));
                    }
                    else
                    {
                        strContent = frmI.strOutContent.Replace(@"<cell>", string.Format(@"<cell.{0}.{1}>", frmI.numeric1.Value.ToString(), frmI.numeric2.Value.ToString()));
                        strContent = strContent.Replace(@"</cell>", string.Format(@"</cell.{0}.{1}>", frmI.numeric1.Value.ToString(), frmI.numeric2.Value.ToString()));
                    }
                }
                AddElementToTreeView(addDescriptor.strName, strContent);
            }
        }

        private void menuItem_AddFaceClick(object sender, EventArgs e)
        {
            MElemementDescriptor addDescriptor = GetDescriptorByName("face");
            FormInputElementContent frmI = new FormInputElementContent(addDescriptor.strDefaultXML, addDescriptor.strDemoXML);
            frmI.StartPosition = FormStartPosition.CenterParent;
			frmI.panelCellFace.Visible = true;
			frmI.numeric2.Visible = false;
			frmI.numeric3.Visible = false;
            DialogResult ds = frmI.ShowDialog();
            if (ds == DialogResult.OK)
            {
				MElement pTargetElement = this.SelectedElement;
				string strContent = frmI.strOutContent;
				if (frmI.strOutContent.Contains(@"<face>") && frmI.strOutContent.Contains(@"</face>") && pTargetElement != null)
				{
					strContent = frmI.strOutContent.Replace(@"<face>", string.Format(@"<face.{0}>", frmI.numeric1.Value.ToString()));
					strContent = strContent.Replace(@"</face>", string.Format(@"</face.{0}>", frmI.numeric1.Value.ToString()));
				}
				AddElementToTreeView(addDescriptor.strName, strContent);
            }
        }

        private void menuItem_MoveUpClick(object sender, EventArgs e)
        {
            MoveSelectedUp();
        }

        private void menuItem_MoveDownClick(object sender, EventArgs e)
        {
            MoveSelectedDown();
        }

        private void AddElementToTreeView(string _strType, string _strParam)
        {
            MElement pTargetElement = this.SelectedElement;
            if (pTargetElement != null)
            {
                MElement pChild;
				((IMElements)pTargetElement).ElementsAdd("", _strType, _strParam, out pChild, TimeForChange);
                this.UpdateTree(true);
                this.SelectedElement = pChild;
            }
        }

        private MElemementDescriptor GetDescriptorByName(string _strName)
        {
            if (m_ElementDescriptors != null && m_ElementDescriptors.Count > 0)
            {
                foreach (MElemementDescriptor desc in m_ElementDescriptors)
                {
                    if (desc.strName == _strName)
                    {
                        return desc;
                    }
                }
            }
            return null;
        }
        private void RemoveSelected()
        {
            MElement pTargetElement = this.SelectedElement;
            if (pTargetElement != null)
            {
                MElement pParentElement;
                pTargetElement.ElementParentGet(out pParentElement);
                pTargetElement.ElementDetach(TimeForChange);
                this.UpdateTree(true);
                if (pParentElement != null)
                    SelectedElement = pParentElement;
            }
        }

        private void MoveSelectedUp()
        {
            MElement pTargetElement = this.SelectedElement;
            if (pTargetElement != null)
            {
                pTargetElement.ElementReorder(-1);
                UpdateTree(false);
                SelectedElement = pTargetElement;
            }
        }

        private void MoveSelectedDown()
        {
            MElement pTargetElement = this.SelectedElement;
            if (pTargetElement != null)
            {
                pTargetElement.ElementReorder(1);
                UpdateTree(false);
                SelectedElement = pTargetElement;
            }
        }

    }
}
