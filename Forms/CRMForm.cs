using BrightstarDB.Client;
using CRMOntology.BusinessLayer;
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

namespace CRMOntology.Forms
{
    public partial class CRMForm : Form
    {
        private CRMOntologyContext dataContext;
        private IBrightstarService client;
        private const string URI = "http://www.comu.edu.tr/eatamuh/ontologies";

        public CRMForm()
        {
            InitializeComponent();
        }

        private void CRMForm_Load(object sender, EventArgs e)
        {
           
            // Initialise license and stores directory location
            Configuration.Register();

            //create a unique store name
            var storeName = "CRM_Ontology";

            //connection string to the BrightstarDB service
            string connectionString =
                string.Format(@"Type=embedded;storesDirectory={0};StoreName={1};", Configuration.StoresDirectory,
                              storeName);

            dataContext = new CRMOntologyContext(connectionString);
            client = BrightstarService.GetClient(connectionString);            
            
            //getPredicates
            XDocument xDoc = dataContext.ExecuteQuery("SELECT DISTINCT ?predicate WHERE {  ?x ?predicate ?y.}");
            foreach (var sparqlResultRow in xDoc.SparqlResultRows())
            {
                string result = sparqlResultRow.GetColumnValue("predicate").ToString();
                //beautify
                if (result.IndexOf(URI) >= 0)
                {
                    treeViewOntology.Nodes[0].Nodes[0].Nodes.Add(result,result.Replace(URI +"/","").Replace("#",""));
                    treeViewOntology.Nodes[0].Nodes[1].Nodes.Add(result, result.Replace(URI + "/", "").Replace("#", ""));
                }
            }            

        }

        private void CRMForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Shutdown Brightstar processing threads
            BrightstarService.Shutdown();
        }

        private void treeViewOntology_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listViewResult.Items.Clear();
            if (treeViewOntology.SelectedNode.Parent != null)
            {
                if (treeViewOntology.SelectedNode.Parent.Name == "rawview")
                {
                    XDocument xDoc = dataContext.ExecuteQuery("SELECT * WHERE {  ?x <" + treeViewOntology.SelectedNode.Name + "> ?y.}");
                    foreach (var sparqlResultRow in xDoc.SparqlResultRows())
                    {
                        string resultX = sparqlResultRow.GetColumnValue("x").ToString();
                        string resultY = sparqlResultRow.GetColumnValue("y").ToString();
                        listViewResult.Items.Add(resultX).SubItems.AddRange(new string[] { treeViewOntology.SelectedNode.Name, resultY });
                    }
                }

                if (treeViewOntology.SelectedNode.Parent.Name == "wellform")
                {
                    XDocument xDoc = dataContext.ExecuteQuery("SELECT * WHERE {  ?x <" + treeViewOntology.SelectedNode.Name + "> ?y.}");
                    foreach (var sparqlResultRow in xDoc.SparqlResultRows())
                    {
                        string resultX = sparqlResultRow.GetColumnValue("x").ToString();
                        resultX = resultX.Replace(URI + "/", "");
                        //resultX = resultX.Remove(0,resultX.IndexOf("#") + 1);
                        string resultY = sparqlResultRow.GetColumnValue("y").ToString();
                        resultY = resultY.Replace(URI + "/", "");
                        //resultY = resultY.Remove(0, resultY.IndexOf("#") + 1);
                        listViewResult.Items.Add(resultX).SubItems.AddRange(new string[] { treeViewOntology.SelectedNode.Name.Replace(URI +"/","").Replace("#",""), resultY });
                    }
                }
            }
        }

        private void listViewResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////set loading animated gif to richtext field
            //LoadingDataForm dataForm = new LoadingDataForm();
            //dataForm.Location = new Point(Convert.ToInt32(richTextBox1.Location.X * 1.25),Convert.ToInt32(richTextBox1.Location.Y * 1.25));
            //dataForm.Show(this);

            richTextBoxObject.Text = "";
            richTextBoxSubject.Text = "";

            CRMOntology.DataAccessLayer.CRMOntology_StagingEntities SQLServerContext = new DataAccessLayer.CRMOntology_StagingEntities();
            // Initialise license and stores directory location
            Configuration.Register();

            //create a unique store name
            var storeName = "CRM_Ontology";

            //connection string to the BrightstarDB service
            string connectionString =
                string.Format(@"Type=embedded;storesDirectory={0};StoreName={1};", Configuration.StoresDirectory,
                              storeName);

            OWLTransfer transfer = new OWLTransfer();

            CRMOntologyContext OntologyContext = new CRMOntologyContext(connectionString);

            for (int i = 0; i < listViewResult.SelectedItems.Count; i++)
            {
                string strObject = listViewResult.SelectedItems[i].Text;
                string strSubject = listViewResult.SelectedItems[i].SubItems.Count == 3 ? listViewResult.SelectedItems[i].SubItems[2].Text : "";

                string[] strSplit = strObject.Split('#');
                if (strSplit != null && strSplit.Length == 2)
                {
                    //Object
                    richTextBoxObject.AppendText(string.Format("Object {0} - {1}", strSplit[0], Environment.NewLine));
                    DataSet ds = transfer.RetrieveRecordFromMapOWL(SQLServerContext, OntologyContext, Guid.Parse(strSplit[1]), strSplit[0]);
                    if (ds != null)
                    {
                        foreach (DataTable dt in ds.Tables)
                        {
                            foreach(DataRow drow in dt.Rows)
                            {
                                foreach(DataColumn dc in dt.Columns)
                                {
                                    richTextBoxObject.AppendText(string.Format("{0} = {1}{2}",dc.ColumnName, drow[dc].ToString(), Environment.NewLine));
                                }
                            }
                        }
                    }
                    else
                        richTextBoxObject.AppendText(string.Format("No Record found... {0}", Environment.NewLine));                   
                }
                else
                    richTextBoxSubject.AppendText(string.Format("Subject {0}{1}", strObject, Environment.NewLine));
                
                strSplit = strSubject.Split('#');
                if (strSplit != null && strSplit.Length == 2)
                {
                    //Subject
                    richTextBoxSubject.AppendText(string.Format("Subject {0}{1}", strSplit[0], Environment.NewLine));
                    DataSet ds = transfer.RetrieveRecordFromMapOWL(SQLServerContext, OntologyContext, Guid.Parse(strSplit[1]), strSplit[0]);
                    if (ds != null)
                    {
                        foreach (DataTable dt in ds.Tables)
                        {
                            foreach (DataRow drow in dt.Rows)
                            {
                                foreach (DataColumn dc in dt.Columns)
                                {
                                    richTextBoxSubject.AppendText(string.Format("{0} = {1}{2}", dc.ColumnName, drow[dc].ToString(), Environment.NewLine));
                                }
                            }
                        }
                    }
                    else
                        richTextBoxSubject.AppendText(string.Format("No Record found... {0}", Environment.NewLine));                                        
                }
                else
                    richTextBoxSubject.AppendText(string.Format("Subject {0}{1}", strSubject, Environment.NewLine));
            }
            // Shutdown Brightstar processing threads.
            BrightstarDB.Client.BrightstarService.Shutdown();

            //dataForm.Close();
            //dataForm.Dispose();
        }
    }
}
