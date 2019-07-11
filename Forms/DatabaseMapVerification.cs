using CommonTools;
using CRMOntology.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRMOntology.Forms
{
    public partial class DatabaseMapVerification : Form
    {
        public TreeListViewNodes nodes = null;
        public string connectionString = string.Empty;
        public DatabaseMapVerification()
        {
            InitializeComponent();
            this.treeListView1.Columns.Add(new CommonTools.TreeListColumn("name", "Name", 500));
            this.treeListView1.Images = new ImageList();
            this.treeListView1.Images.Images.AddStrip(Resources.db_valid);
            this.treeListView1.Images.Images.AddStrip(Resources.db_invalid);
            DatabaseMappingForm.isValid = true;
        }

        private void btnValid_Click(object sender, EventArgs e)
        {
            if (!DatabaseMappingForm.isValid.Value)
                MessageBox.Show("Mapping is not valid!", "is Valid");
            this.Close();
        }

        private void DatabaseMapVerification_Load(object sender, EventArgs e)
        {
            if (nodes == null && connectionString == string.Empty)
            {
                MessageBox.Show(@" Please set ""nodes"" and ""connnectionString"" properties before calling the form", "Invalid Form Calls");
                this.Close();
                return;
            }
            loadTree();
        }

        private void loadTree()
        {
            DataSet dsTable = new DataSet();
            try
            {
                dsTable = new BusinessLayer.DataDescription(connectionString).GetAllPrimaryKeys();                                
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
                    if (drTable["table_name"].ToString() == "TransferHistoryBase" || drTable["table_name"].ToString() == "OWLMapBase")
                        //remove TransferHistoryBase from checkList since it is administrative table.
                        continue;

                    CommonTools.Node tableNode = new CommonTools.Node(drTable["table_name"].ToString());
                    if (CRMOntology.BusinessLayer.Node.GetNodeIndex(treeListView1.Nodes, drTable["table_name"].ToString()) >= 0)
                        continue;

                    CommonTools.Node columnNode = new CommonTools.Node(new object[] {"Primary Key"});
                    if (CRMOntology.BusinessLayer.Node.GetNodeIndex(nodes, drTable["table_name"].ToString() + "." + drTable["column_name"].ToString()) >= 0)
                    {
                        columnNode.ImageId = 0;
                    }
                    else
                    {
                        columnNode.ImageId = 1;
                        DatabaseMappingForm.isValid = false;
                    }
                    tableNode.Nodes.Add(columnNode);

                    columnNode = new CommonTools.Node(new object[] {"CreatedOn"});
                    if (CRMOntology.BusinessLayer.Node.GetNodeIndex(nodes, drTable["table_name"].ToString() + "." + "CreatedOn") >= 0)
                    {
                        columnNode.ImageId = 0;
                    }
                    else
                    {
                        columnNode.ImageId = 1;
                        DatabaseMappingForm.isValid = false;
                    }
                    tableNode.Nodes.Add(columnNode);

                    columnNode = new CommonTools.Node(new object[] { "ModifiedOn" });
                    if (CRMOntology.BusinessLayer.Node.GetNodeIndex(nodes, drTable["table_name"].ToString() + "." + "ModifiedOn") >= 0)
                    {
                        columnNode.ImageId = 0;
                    }
                    else
                    {
                        columnNode.ImageId = 1;
                        DatabaseMappingForm.isValid = false;
                    }
                    tableNode.Nodes.Add(columnNode);
                    tableNode.ExpandAll();

                    treeListView1.Nodes.Add(tableNode);
                }
            }           

        }
    }
}
