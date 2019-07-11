using CRMOntology.BusinessLayer;
using CRMOntology.Properties;
using CRMOntology.RDFLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using VDS.RDF;
using VDS.RDF.Parsing;
using BL = CRMOntology.BusinessLayer;

namespace CRMOntology.Forms
{
    public partial class OWLConfigurationForm : Form
    {
        public OWLConfigurationForm()
        {
            InitializeComponent();

            this.treeListViewTriples.Columns.Add(new CommonTools.TreeListColumn("subject", "Subject", 400));
            this.treeListViewTriples.Columns.Add(new CommonTools.TreeListColumn("predicate", "Predicate", 300));
            this.treeListViewTriples.Columns.Add(new CommonTools.TreeListColumn("object", "Object", 300));
            this.treeListViewTriples.Images = new ImageList();
            this.treeListViewTriples.Images.Images.AddStrip(Resources.rdf_icon);
        }

        private void OWLConfigurationForm_Load(object sender, EventArgs e)
        {            
            BL.DatabaseMap databaseMap = new BL.DatabaseMap();
            for (int i = 0; i < databaseMap.DatabaseMaps.Count; i++)
            {
                cmbMappings.Items.Add(databaseMap.DatabaseMaps[i].Attribute(XName.Get("name")).Value);
            }              
        }

        private void cmbMappings_SelectedIndexChanged(object sender, EventArgs e)
        {
            BL.DatabaseMap databaseMap = new BL.DatabaseMap();
            BL.ResourceDescription ResourceDesc = new BL.ResourceDescription(databaseMap.DatabaseMaps[cmbMappings.SelectedIndex]);
            txtRDFPath.Text = ResourceDesc.OWLResource.Path;
        }

        private void checkBoxSetAsBackgroundJob_CheckedChanged(object sender, EventArgs e)
        {
            txtPeriod.ReadOnly = !checkBoxSetAsBackgroundJob.Checked;
        }

        private void txtPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnLoadRDF_Click(object sender, EventArgs e)
        {
            #region load OWL
            IGraph g = new Graph();

            try
            {
                FileLoader.Load(g, txtRDFPath.Text);
                
                if (g.Triples.Count > 0)
                {
                    foreach (Triple triple in g.Triples)
                    {
                        if (triple.Subject.NodeType == NodeType.Blank || triple.Object.NodeType == NodeType.Blank)
                            continue;

                        CommonTools.Node node = new CommonTools.Node(new object[] {
                                                                                    triple.Subject.ToString(),
                                                                                    triple.Predicate.ToString(),
                                                                                    triple.Object.ToString()});
                        node.ImageId = 0;
                        treeListViewTriples.Nodes.Add(node);
                    }
                }
                else
                {
                    MessageBox.Show("could find any valid triple(s) in the given file", "Triples Error");
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "OWL Graph Error");
            }
            
            
         

            #endregion
        }

        private void btnStartTransfer_Click(object sender, EventArgs e)
        {
            // Initialise license and stores directory location
            Configuration.Register();

            //create a unique store name
            var storeName = "CRM_Ontology";

            //connection string to the BrightstarDB service
            string connectionString =
                string.Format(@"Type=embedded;storesDirectory={0};StoreName={1};", Configuration.StoresDirectory,
                              storeName);

            OWLTransfer transfer = new OWLTransfer();
            transfer.StartTransfer(connectionString);
            
        }
    }
}
