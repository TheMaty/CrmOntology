using CommonTools;
using BL = CRMOntology.BusinessLayer;
using CRMOntology.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VDS.RDF;
using VDS.RDF.Parsing;
using System.Xml;
using System.Xml.Linq;

namespace CRMOntology.Forms
{
    public partial class DatabaseMappingForm : Form
    {
        public enum SourceType
        {
            Database,
            WebService
        };

        public static bool? isValid;
        
        public DatabaseMappingForm(SourceType source):this()
        {
            switch (source)
            {
                case SourceType.WebService:
                    label1.Text = label3.Text = "Source Service";
                    txtSourceConnectionString.Text = "http://localhost:8080/CRMOutOfBox.svc/";
                    break;
            }

        }

        public DatabaseMappingForm()
        {
            InitializeComponent();

            this.treeListViewDatabase.Columns.Add(new CommonTools.TreeListColumn("name", "Name", 250));
            this.treeListViewDatabase.Columns.Add(new CommonTools.TreeListColumn("type", "Type", 75));
            this.treeListViewDatabase.Columns.Add(new CommonTools.TreeListColumn("size", "Size", 75));
            this.treeListViewDatabase.Images = new ImageList();
            this.treeListViewDatabase.Images.Images.AddStrip(Resources.DataTable);
            this.treeListViewDatabase.Images.Images.AddStrip(Resources.DataRow);

            this.treeListViewStagingDatabase.Columns.Add(new CommonTools.TreeListColumn("name", "Name", 250));
            this.treeListViewStagingDatabase.Columns.Add(new CommonTools.TreeListColumn("type", "Type", 75));
            this.treeListViewStagingDatabase.Columns.Add(new CommonTools.TreeListColumn("size", "Size", 75));
            this.treeListViewStagingDatabase.Images = new ImageList();
            this.treeListViewStagingDatabase.Images.Images.AddStrip(Resources.DataTable);
            this.treeListViewStagingDatabase.Images.Images.AddStrip(Resources.DataRow);

            this.treeListViewMap.Columns.Add(new CommonTools.TreeListColumn("nameFrom", "Name From", 250));
            this.treeListViewMap.Columns.Add(new CommonTools.TreeListColumn("typeFrom", "Type From", 75));
            this.treeListViewMap.Columns.Add(new CommonTools.TreeListColumn("nameTo", "Name To", 250));
            this.treeListViewMap.Columns.Add(new CommonTools.TreeListColumn("typeTo", "Type To", 75));
            this.treeListViewMap.Images = new ImageList();
            this.treeListViewMap.Images.Images.AddStrip(Resources.rdf_icon);
            this.treeListViewMap.Images.Images.AddStrip(Resources.rdf_foldr);

            this.openFileDialog1.AddExtension = true;
            this.openFileDialog1.CheckFileExists = true;
            this.openFileDialog1.CheckPathExists = true;
            this.openFileDialog1.DefaultExt = "*.owl";
            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.Title = "Select Resoruce Description File";
            this.openFileDialog1.AddExtension = true;
            this.openFileDialog1.Filter = "Web Ontology Language (*.owl)|*.owl|All files (*.*)|*.*";
            this.openFileDialog1.FileName = "Select a file ...";
            this.openFileDialog1.ValidateNames = true;

            BL.DatabaseMap databaseMap = new BL.DatabaseMap();
            for (int i = 0; i < databaseMap.DatabaseMaps.Count; i++)
            {
                cmbExistingMap.Items.Add(databaseMap.DatabaseMaps[i].Attribute(XName.Get("name")).Value);
            }       
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            //check selections
            NodesSelection selectionsDB = treeListViewDatabase.NodesSelection;
            if (selectionsDB.Count < 1)
            {
                MessageBox.Show("Please select one item from Source Database");
                return;
            }
            NodesSelection selectionsStagingDB = treeListViewStagingDatabase.NodesSelection;
            if (selectionsStagingDB.Count < 1)
            {
                MessageBox.Show("Please select one item from Staging Database to map");
                return;
            }
            if (selectionsDB.Count != selectionsStagingDB.Count)
            {
                MessageBox.Show("Items must have same number in both side");
                return;
            }

            for (int x = 0; x < selectionsDB.Count; x++)
            {
                Node nodeSourceDB = selectionsDB[x];
                Node nodeStagingDB = selectionsStagingDB[x];

                if ((nodeSourceDB.Parent != null && nodeStagingDB.Parent == null) || (nodeSourceDB.Parent == null && nodeStagingDB.Parent != null))
                {
                    MessageBox.Show("Each selection must be in same level for a node");
                    return;
                }

                if (nodeSourceDB.Nodes.Count != nodeStagingDB.Nodes.Count)
                {
                    MessageBox.Show("Each node must have same number of child nodes in both side");
                    return;
                }               

                Node nodeMapping;
                if (nodeSourceDB.Parent != null)
                {
                    nodeMapping = new Node(new object[] {
                                                nodeSourceDB.Parent["name"].ToString() + "." + nodeSourceDB["name"].ToString(), nodeSourceDB["type"].ToString() ,
                                                nodeStagingDB.Parent["name"].ToString() + "." + nodeStagingDB["name"].ToString(), nodeStagingDB["type"].ToString()}) { ImageId = 0};
                    int currentNodeIndex = CRMOntology.BusinessLayer.Node.GetNodeIndex(treeListViewMap.Nodes, nodeMapping);
                    if (currentNodeIndex < 0)
                    {
                        int selectedNodeIndex = CRMOntology.BusinessLayer.Node.GetNodeIndex(treeListViewMap.Nodes, nodeStagingDB.Parent["name"].ToString());
                        if (selectedNodeIndex >= 0)
                            treeListViewMap.Nodes.NodeAtIndex(selectedNodeIndex).Nodes.Add(nodeMapping);
                        else
                        {
                            treeListViewMap.Nodes.Add(new Node(nodeMapping[2].ToString().Split('.')[0]) { ImageId = 1 }).Nodes.Add(nodeMapping);
                        }
                    }
                    else
                    {
                        MessageBox.Show("double map is not allowed");
                        return;
                    }
                }
                else
                {
                    for (int i = 0; i < nodeSourceDB.Nodes.Count; i++)
                    {
                        nodeMapping = new Node(new object[] {
                                                    nodeSourceDB["name"].ToString() + "." + nodeSourceDB.Nodes[i]["name"].ToString(), nodeSourceDB.Nodes[i]["type"].ToString(),
                                                    nodeStagingDB["name"].ToString() + "." + nodeStagingDB.Nodes[i]["name"].ToString(), nodeStagingDB.Nodes[i]["type"].ToString()}) { ImageId = 0 };
                        int currentNodeIndex = CRMOntology.BusinessLayer.Node.GetNodeIndex(treeListViewMap.Nodes, nodeMapping);
                        if (currentNodeIndex < 0)
                        {
                            int selectedNodeIndex = CRMOntology.BusinessLayer.Node.GetNodeIndex(treeListViewMap.Nodes, nodeStagingDB["name"].ToString());
                            if (selectedNodeIndex >= 0)
                                treeListViewMap.Nodes.NodeAtIndex(selectedNodeIndex).Nodes.Add(nodeMapping);
                            else
                                treeListViewMap.Nodes.Add(new Node(nodeMapping[2].ToString().Split('.')[0]) { ImageId = 1 }).Nodes.Add(nodeMapping);
                        }
                        else
                        {
                            MessageBox.Show("double map is not allowed");
                            return;
                        }
                    }
                }
            }            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            NodesSelection selectionsMapping = treeListViewMap.NodesSelection;            
            if (selectionsMapping.Count != 1)
            {
                MessageBox.Show("Please select one item from Mapping to remove");
            }
            else
            {
                if (treeListViewMap.Nodes.Count <= 0)
                    MessageBox.Show("No record found to delete");
                else
                {
                    int currentNodeIndex = CRMOntology.BusinessLayer.Node.GetNodeIndex(treeListViewMap.Nodes, selectionsMapping[0]);
                    if (currentNodeIndex == 0) //bug in treeviewlist when first node remove the view
                    {
                        NodeCollection nodes = treeListViewMap.Nodes.Clone();
                        if (selectionsMapping[0].Parent == null)
                            nodes.Remove(selectionsMapping[0]);
                        else
                            nodes[currentNodeIndex].Nodes.Remove(selectionsMapping[0]);
                        treeListViewMap.Nodes.Clear();
                        for (int i = 0; i < nodes.Count;i++)
                        {
                            nodes[i].CleanOwner();
                            treeListViewMap.Nodes.Add(nodes[i]);
                        }
                    }
                    else
                        if (selectionsMapping[0].Parent == null)
                            treeListViewMap.Nodes.Remove(selectionsMapping[0]);
                        else
                            treeListViewMap.Nodes[currentNodeIndex].Nodes.Remove(selectionsMapping[0]);

                    treeListViewMap.NodesSelection.Clear();
                    
                    if (treeListViewMap.Nodes.Count > 0)
                    {
                        if (currentNodeIndex < treeListViewMap.Nodes.Count)
                            treeListViewMap.NodesSelection.Add(treeListViewMap.Nodes[currentNodeIndex]);
                        else
                            treeListViewMap.NodesSelection.Add(treeListViewMap.Nodes[currentNodeIndex - 1]);
                    }
                }
            }            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (txtSourceConnectionString.Text == string.Empty || txtStagingDatabaseConnectionString.Text == string.Empty || txtOWLFilePath.Text == string.Empty)
            {
                MessageBox.Show("Please select Connection String for a Source Database and select OWL File to continue");
                return;
            }
          
            #region load Database Schema of Source System
            loadTree(treeListViewDatabase,  txtSourceConnectionString.Text);
            #endregion

            #region load Database Schema of Staging System

            loadTree(treeListViewStagingDatabase, txtStagingDatabaseConnectionString.Text);
            #endregion

        }

        private void loadTree(TreeListView treelistview,string connectionString)
        {
            //Service Source is not ready so fake action
            connectionString = "Server=TR00011565;Database=CRMOntology_Staging;Trusted_Connection=True;";
            DataSet dsTable = new DataSet();
            try
            {
                dsTable = new BusinessLayer.DataDescription(connectionString).GetTables();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "\n" + exp.StackTrace);
                return;
            }

            foreach (DataTable dtTable in dsTable.Tables)
            {
                foreach (DataRow drTable in dtTable.Rows)
                {
                    CommonTools.Node tableNode = new CommonTools.Node(drTable["name"].ToString());
                    tableNode.ImageId = 0;

                    DataSet dsColumn = new DataSet();
                    try
                    {
                        dsColumn = new BusinessLayer.DataDescription(connectionString).GetColumnsByTableId(drTable["object_id"].ToString());
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message + "\n" + exp.StackTrace);
                        return;
                    }

                    foreach (DataTable dtColumn in dsColumn.Tables)
                    {
                        foreach (DataRow drColumn in dtColumn.Rows)
                        {
                            CommonTools.Node columnNode = new CommonTools.Node(new object[] {
                                                                                                drColumn["name"].ToString(),
                                                                                                drColumn["type"].ToString(),
                                                                                                drColumn["size"].ToString() });
                            columnNode.ImageId = 1;
                            tableNode.Nodes.Add(columnNode);
                        }
                    }

                    treelistview.Nodes.Add(tableNode);
                }
            }
        }

        private void loadTree(TreeListView treelistview, XElement DatabaseElement)
        {
            BL.ResourceDescription ResourceDesc = new BL.ResourceDescription(DatabaseElement);
            Node nodeFolder,nodeMapping;
            foreach (BL.ResourceTable table in ResourceDesc.ResourceTables)
            {
                nodeFolder = new Node(table.Name);
                nodeFolder.ImageId = 1;
                foreach (BL.ResourceMap map in table.ResourceMaps)
                {
                    nodeMapping = new Node(new object[] { map.From, map.FromType, map.To, map.ToType });
                    nodeMapping.ImageId = 0;
                    nodeFolder.Nodes.Add(nodeMapping);
                }
                treelistview.Nodes.Add(nodeFolder);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtOWLFilePath.Text = openFileDialog1.FileName;
        }

        private void txtPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void checkBoxSetAsBackgroundJob_CheckedChanged(object sender, EventArgs e)
        {
            txtPeriod.ReadOnly = !checkBoxSetAsBackgroundJob.Checked;
        }

        private void btnGenerateMapFile_Click(object sender, EventArgs e)
        {            
            bool isExistingMapSelected = false;
            
            if (cmbExistingMap.Text == String.Empty)
            {
                MessageBox.Show("Select map name from list or type name for new map...");
                return;
            }            

            if (!DatabaseMappingForm.isValid.HasValue)
            {
                MessageBox.Show("Mapping has not check for validation!, Please click Validate button to check", "Validation requires");
                return;
            }

            if (!DatabaseMappingForm.isValid.Value)
            {
                MessageBox.Show("Mapping is not valid!, Please click Validate button to display invalid parts", "is not Valid");
                return;
            }

            if (cmbExistingMap.SelectedIndex != -1)
            {
                if (MessageBox.Show("Existing map will destroy,are you sure?", "Existing Map Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                isExistingMapSelected = true;
            }

            BL.DatabaseMap databaseMap = new BL.DatabaseMap();
                      

            if (isExistingMapSelected)
            {
                //delete map from DatabaseMap.xml                
                XElement _deleteElement = databaseMap.DatabaseMaps.Find(x => x.Attribute(XName.Get("name")).Value.Contains(cmbExistingMap.Text));
                databaseMap.DatabaseMaps.Remove(_deleteElement);
                databaseMap.Save();
            }

            //insert DatabaseMap object           
            XElement _newElement = new XElement("DatabaseMap", new XAttribute("name", cmbExistingMap.Text));
            //Source
            _newElement.Add(new XElement("Database", new XAttribute("type", "source"), new XAttribute("connectionString", txtSourceConnectionString.Text)));
            //Staging
            _newElement.Add(new XElement("Database", new XAttribute("type", "staging"), new XAttribute("connectionString", txtStagingDatabaseConnectionString.Text)));
            //OWL File Path
            _newElement.Add(new XElement("OWL", new XAttribute("type", "file"), new XAttribute("path", txtOWLFilePath.Text)));
            //Tables                 
            foreach(Node table in treeListViewMap.Nodes)
            {
                XElement _newTableElement = new XElement("Table", new XAttribute("name",table[0]));
                foreach(Node map in table.Nodes)
                    _newTableElement.Add(new XElement("Map", new XAttribute("from", map[0]), new XAttribute("fromtype", map[1]),new XAttribute("to", map[2]),new XAttribute("totype", map[3])));

                _newElement.Add(_newTableElement);
            }

            databaseMap.DatabaseMaps.Add(_newElement);
            databaseMap.Save();

            BL.OWLConfiguration owlConfiguration = new BL.OWLConfiguration();

            //insert OWLConfiguration object           
            _newElement = new XElement("OWLConfiguration");            
            //Staging
            _newElement.Add(new XElement("Database", new XAttribute("type", "staging"), new XAttribute("connectionString", txtStagingDatabaseConnectionString.Text)));
            //OWL Item
            _newElement.Add(new XElement("OWLItem", new XAttribute("type", "Accurate"), new XAttribute("low", "-1"), new XAttribute("medium", "-1"), new XAttribute("high", "-1"), new XAttribute("businessrequired", "-1"), new XAttribute("businessrecommend", "-1"), new XAttribute("noconstraint", "-1")));

            owlConfiguration.OWLConfigurations.RemoveRange(0, owlConfiguration.OWLConfigurations.Count);
            owlConfiguration.OWLConfigurations.Add(_newElement);
            owlConfiguration.Save();

            MessageBox.Show(cmbExistingMap.Text + " is generated.");
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            DatabaseMapVerification verification = new DatabaseMapVerification();
            verification.nodes = treeListViewMap.Nodes;
            verification.connectionString = txtStagingDatabaseConnectionString.Text;
            verification.ShowDialog();
        }

        private void cmbExistingMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cleare nodes
            treeListViewMap.Nodes.Clear();
            //load selected definition to the map tree
            
            BL.DatabaseMap databaseMap = new BL.DatabaseMap();

            XElement xElement = databaseMap.DatabaseMaps.Find(x => x.FirstAttribute.Value == XName.Get(cmbExistingMap.Text));
            
            if (xElement != null)
                loadTree(treeListViewMap,xElement);
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            treeListViewMap.Nodes.Clear();
        }

        private void btnManualTransfer_Click(object sender, EventArgs e)
        {
            BL.DatabaseMap databaseMap = new BL.DatabaseMap();
            for (int i = 0; i < databaseMap.DatabaseMaps.Count; i++)
            {
                BL.DataTransfer dtransfer = new BL.DataTransfer();
                dtransfer.StartTransfer(databaseMap.DatabaseMaps[i]);
            }       
        }

        #region contextMenuStripStaging_Click
        //void contextMenuStripStaging_Click(object sender, System.EventArgs e)
        //{
        //    NodesSelection selections = treeListViewDatabase.NodesSelection;
        //    foreach(Node node in selections)
        //    {
        //        Node nodeStaging;
        //        if(node.Parent !=null)
        //        {
        //            nodeStaging = new Node(new object[] {
        //                                                    node.Parent["name"].ToString() });
        //            nodeStaging.ImageId = node.Parent.ImageId;
        //            int currentNodeIndex = CRMOntology.BusinessLayer.Node.GetNodeIndex(treeListViewStagingDatabase.Nodes,nodeStaging);
        //            if (currentNodeIndex < 0)
        //                MessageBox.Show("Please create first " + node.Parent["name"] + " for " + node["name"] + " as parent in Staging database");
        //            else
        //            {
        //                nodeStaging = new Node(new object[] {
        //                                                    node["name"].ToString(),
        //                                                    node["type"].ToString(),
        //                                                    node["size"].ToString() });
        //                nodeStaging.ImageId = node.ImageId;
        //                if (CRMOntology.BusinessLayer.Node.GetNodeIndex(treeListViewStagingDatabase.Nodes[currentNodeIndex].Nodes,nodeStaging) < 0)
        //                    treeListViewStagingDatabase.Nodes[currentNodeIndex].Nodes.Add(nodeStaging);
        //                else
        //                    MessageBox.Show(node["name"] + " already exists under " + node.Parent["name"]);
        //            }
        //        }
        //        else
        //        {
        //            nodeStaging = new Node(node["name"].ToString());
        //            nodeStaging.ImageId = node.ImageId;
        //            if (CRMOntology.BusinessLayer.Node.GetNodeIndex(treeListViewStagingDatabase.Nodes,nodeStaging) < 0)
        //                treeListViewStagingDatabase.Nodes.Add(nodeStaging);
        //            else
        //                MessageBox.Show(node["name"] + " exists in Staging Database");
        //        }                                
        //    }
        //}
        #endregion
    }
}
