using CRMOntology.Properties;
using BL = CRMOntology.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using CommonTools;
using CRMOntology.BusinessLayer;

namespace CRMOntology.Forms
{
    public partial class AccurateSettings : Form
    {
        public AccurateSettings()
        {
            InitializeComponent();

            this.treeListViewStaging.Columns.Add(new CommonTools.TreeListColumn("name", "Name", 250));
            this.treeListViewStaging.Images = new ImageList();
            this.treeListViewStaging.Images.Images.AddStrip(Resources.DataTable);
            this.treeListViewStaging.Images.Images.AddStrip(Resources.DataRow);

            this.treeListViewAccurateXML.Columns.Add(new CommonTools.TreeListColumn("name", "Name", 250));
            this.treeListViewAccurateXML.Columns.Add(new CommonTools.TreeListColumn("businessconstraint", "BusinessConstraint", 250));
            this.treeListViewAccurateXML.Images = new ImageList();
            this.treeListViewAccurateXML.Images.Images.AddStrip(Resources.BusinessRequired);
            this.treeListViewAccurateXML.Images.Images.AddStrip(Resources.BusinessRecommend);
            this.treeListViewAccurateXML.Images.Images.AddStrip(Resources.NoConstraint);
        }

        private void txtHigh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMedium_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBusinessRequired_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBusinessRecommend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNoConstraint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AccurateSettings_Load(object sender, EventArgs e)
        {
            BL.OWLConfiguration owlConfig = new BL.OWLConfiguration();

            XElement xElement = owlConfig.OWLConfigurations.Count > 0 ? owlConfig.OWLConfigurations[0] : null;

            if (xElement != null)
            {
                BL.OWLDescription OWLDesc = new BL.OWLDescription(xElement);

                //set account - contact related tables to calculate accuration of a customer record
                DataSet dsTable = new DataSet();
                try
                {
                    dsTable = new BusinessLayer.DataDescription(OWLDesc.StagingDatabase.ConnectionString).GetCustomerReferencedTables();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message + "\n" + exp.StackTrace);
                    return;
                }

                foreach (DataTable dtTable in dsTable.Tables)
                {
                    foreach (DataRow drColumn in dtTable.Rows)
                    {
                        CommonTools.Node tableNode = new CommonTools.Node(drColumn["ParentObject"].ToString());
                        tableNode.ImageId = 0;

                        DataSet dsTableChild = new BusinessLayer.DataDescription(OWLDesc.StagingDatabase.ConnectionString).GetColumnsByTableId(drColumn["ParentObjectId"].ToString());

                        foreach (DataTable dtTableChild in dsTableChild.Tables)
                        {
                            foreach (DataRow drColumnChild in dtTableChild.Rows)
                            {
                                CommonTools.Node columnNode = new CommonTools.Node(new object[] {
                                                                                                drColumnChild["name"].ToString() 
                                });
                                columnNode.ImageId = 1;
                                tableNode.Nodes.Add(columnNode);
                            }
                        }
                        treeListViewStaging.Nodes.Add(tableNode);
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            NodesSelection selectionsMapping = treeListViewAccurateXML.NodesSelection;
            if (selectionsMapping.Count != 1)
            {
                MessageBox.Show("Please select one item from Mapping to remove");
            }
            else
            {
                if (treeListViewAccurateXML.Nodes.Count <= 0)
                    MessageBox.Show("No record found to delete");
                else
                {
                    int currentNodeIndex = CRMOntology.BusinessLayer.Node.GetNodeIndex(treeListViewAccurateXML.Nodes, selectionsMapping[0]);
                    if (currentNodeIndex == 0) //bug in treeListViewAccurateXML when first node remove the view
                    {
                        NodeCollection nodes = treeListViewAccurateXML.Nodes.Clone();
                        if (selectionsMapping[0].Parent == null)
                            nodes.Remove(selectionsMapping[0]);
                        else
                            nodes[currentNodeIndex].Nodes.Remove(selectionsMapping[0]);
                        treeListViewAccurateXML.Nodes.Clear();
                        for (int i = 0; i < nodes.Count; i++)
                        {
                            nodes[i].CleanOwner();
                            treeListViewAccurateXML.Nodes.Add(nodes[i]);
                        }
                    }
                    else
                        if (selectionsMapping[0].Parent == null)
                            treeListViewAccurateXML.Nodes.Remove(selectionsMapping[0]);
                        else
                            treeListViewAccurateXML.Nodes[currentNodeIndex].Nodes.Remove(selectionsMapping[0]);

                    treeListViewAccurateXML.NodesSelection.Clear();

                    if (treeListViewAccurateXML.Nodes.Count > 0)
                    {
                        if (currentNodeIndex < treeListViewAccurateXML.Nodes.Count)
                            treeListViewAccurateXML.NodesSelection.Add(treeListViewAccurateXML.Nodes[currentNodeIndex]);
                        else
                            treeListViewAccurateXML.NodesSelection.Add(treeListViewAccurateXML.Nodes[currentNodeIndex - 1]);
                    }
                }
            }            
        }

        private void btnBusinessRequired_Click(object sender, EventArgs e)
        {
            //check selections
            NodesSelection selectionsDB = treeListViewStaging.NodesSelection;
            if (selectionsDB.Count < 1)
            {
                MessageBox.Show("Please select one item from Staging");
                return;
            }

            for (int x = 0; x < selectionsDB.Count; x++)
            {
                CommonTools.Node nodeStaging = selectionsDB[x];

                if (nodeStaging.Parent == null)
                {
                    MessageBox.Show("You are not allowed to select " + nodeStaging[0].ToString() + ". Please select columns instead of Table");
                    continue;
                }

                CommonTools.Node nodeMapping;
                nodeMapping = new CommonTools.Node(new object[] {
                    nodeStaging.Parent["name"].ToString() + "." + nodeStaging["name"].ToString(), BusinessConstraint.BusinessRequired.ToString()}) { ImageId = 0 };
                int currentNodeIndex = CRMOntology.BusinessLayer.Node.GetNodeIndex(treeListViewAccurateXML.Nodes, nodeMapping[0]);
                if (currentNodeIndex < 0)
                {
                    treeListViewAccurateXML.Nodes.Add(nodeMapping);
                }
                else
                {
                    MessageBox.Show("double map is not allowed");
                    return;
                }
            }

            calculateAccuracy();
        }

        private void btnBusinessRecommend_Click(object sender, EventArgs e)
        {
            //check selections
            NodesSelection selectionsDB = treeListViewStaging.NodesSelection;
            if (selectionsDB.Count < 1)
            {
                MessageBox.Show("Please select one item from Staging");
                return;
            }

            for (int x = 0; x < selectionsDB.Count; x++)
            {
                CommonTools.Node nodeStaging = selectionsDB[x];

                CommonTools.Node nodeMapping;
                nodeMapping = new CommonTools.Node(new object[] {
                    nodeStaging.Parent["name"].ToString() + "." + nodeStaging["name"].ToString(), BusinessConstraint.BusinessRecommend.ToString()}) { ImageId = 1 };
                int currentNodeIndex = CRMOntology.BusinessLayer.Node.GetNodeIndex(treeListViewAccurateXML.Nodes, nodeMapping[0]);
                if (currentNodeIndex < 0)
                {
                    treeListViewAccurateXML.Nodes.Add(nodeMapping);
                }
                else
                {
                    MessageBox.Show("double map is not allowed");
                    return;
                }
            }

            calculateAccuracy();
        }

        private void btnNoConstraint_Click(object sender, EventArgs e)
        {
            //check selections
            NodesSelection selectionsDB = treeListViewStaging.NodesSelection;
            if (selectionsDB.Count < 1)
            {
                MessageBox.Show("Please select one item from Staging");
                return;
            }

            for (int x = 0; x < selectionsDB.Count; x++)
            {
                CommonTools.Node nodeStaging = selectionsDB[x];

                CommonTools.Node nodeMapping;
                nodeMapping = new CommonTools.Node(new object[] {
                    nodeStaging.Parent["name"].ToString() + "." + nodeStaging["name"].ToString(), BusinessConstraint.NoConstraint.ToString()}) { ImageId = 2 };
                int currentNodeIndex = CRMOntology.BusinessLayer.Node.GetNodeIndex(treeListViewAccurateXML.Nodes, nodeMapping[0]);
                if (currentNodeIndex < 0)
                {
                    treeListViewAccurateXML.Nodes.Add(nodeMapping);
                }
                else
                {
                    MessageBox.Show("double map is not allowed");
                    return;
                }
            }

            calculateAccuracy();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBusinessRequired.Text.Length < 1 && txtBusinessRecommend.Text.Length < 1 && txtNoConstraint.Text.Length < 1)
            {
                MessageBox.Show("Please fill High,Medium and Low fields in order to calculate exact value of accuration ");
                return;
            }

            BL.OWLConfiguration owlConfiguration = new BL.OWLConfiguration();

            //insert OWLConfiguration object           
            XElement _newElement = new XElement("OWLItem", new XAttribute("type", "Accurate"), new XAttribute("low", txtLow.Text), new XAttribute("medium", txtMedium.Text), new XAttribute("high", txtHigh.Text), new XAttribute("businessrequired", txtBusinessRequired.Text), new XAttribute("businessrecommend", txtBusinessRecommend.Text), new XAttribute("noconstraint", txtNoConstraint.Text));

            foreach (CommonTools.Node node in treeListViewAccurateXML.Nodes)
            {
                _newElement.Add(new XElement("Map", new XAttribute("key", node[0]), new XAttribute("value", node[1])));
            }

            OWLItem _owlItem = (OWLItem)OWLItem.CreateOWLItem(_newElement);

            _owlItem.Save();

            MessageBox.Show("Accurate configuration file has just completed.", "Accurate");
        }

        private void txtBusinessRequired_Validated(object sender, EventArgs e)
        {
            if (txtBusinessRequired.Text.Length < 0)
            {
                txtBusinessRequired.Text = "0";
            }
            if (!validateValues())
                txtBusinessRequired.Focus();
            else
                calculateAccuracy();
        }

        private void txtBusinessRecommend_Validated(object sender, EventArgs e)
        {
            if (txtBusinessRecommend.Text.Length < 0)
            {
                txtBusinessRecommend.Text = "0";
            }
            if (!validateValues())
                txtBusinessRecommend.Focus();
            else
                calculateAccuracy();
        }

        private void txtNoConstraint_Validated(object sender, EventArgs e)
        {
            if (txtNoConstraint.Text.Length < 0)
            {
                txtNoConstraint.Text = "0";
            }
            if (!validateValues())
                txtNoConstraint.Focus();
            else
                calculateAccuracy();
        }

        private bool validateValues()
        {
            if (int.Parse(txtBusinessRequired.Text) < int.Parse(txtBusinessRecommend.Text) || int.Parse(txtBusinessRecommend.Text) < int.Parse(txtNoConstraint.Text))
            {
                MessageBox.Show("value order must be following; Business Required < Business Recommend < No Constraint.");
                return false;
            }

            return true;
        }

        private void calculateAccuracy()
        {
            int totalValue = 0;
            //calculate total value
            foreach(CommonTools.Node node in treeListViewAccurateXML.Nodes)
            {
                if (node["businessconstraint"].ToString() == BusinessConstraint.BusinessRecommend.ToString())
                        totalValue += int.Parse(txtBusinessRecommend.Text);
                else if (node["businessconstraint"].ToString() == BusinessConstraint.BusinessRequired.ToString())
                        totalValue += int.Parse(txtBusinessRequired.Text);
                else if (node["businessconstraint"].ToString() == BusinessConstraint.NoConstraint.ToString())
                        totalValue += int.Parse(txtNoConstraint.Text);
            }

            txtHigh.Text = ((int)(totalValue * 0.90)).ToString();
            txtMedium.Text = ((int)(totalValue * 0.60)).ToString();
            txtLow.Text = ((int)(totalValue * 0.30)).ToString();
        }
        
    }
}
