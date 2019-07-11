using CRMOntology.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRMOntology
{
    public partial class CrmMainForm : System.Windows.Forms.Form
    {
        public CrmMainForm()
        {
            InitializeComponent();
            this.databaseMappingToolStripMenuItem.Click += new System.EventHandler(this.eventHandlerDispatcher);
            this.oWLConfigurationToolStripMenuItem.Click += new System.EventHandler(this.eventHandlerDispatcher);
            this.accurateToolStripMenuItem.Click += new System.EventHandler(this.eventHandlerDispatcher);
            this.CRMToolStripMenuItem.Click += new System.EventHandler(this.eventHandlerDispatcher);
            this.SWRLToolStripMenuItem.Click += new System.EventHandler(this.eventHandlerDispatcher);
            this.webServiceMappingToolStripMenuItem.Click += new System.EventHandler(this.eventHandlerDispatcher);
            this.displayInNatureToolStripMenuItem.Click += new System.EventHandler(this.eventHandlerDispatcher);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Name = ((ToolStripMenuItem)sender).Name;
            about.Show(this);
        }

        private void eventHandlerDispatcher(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem _item = new ToolStripMenuItem(((ToolStripMenuItem)sender).Text, ((ToolStripMenuItem)sender).Image, setFocus);
                _item.Name = ((ToolStripMenuItem)sender).Name;
                windowToolStripMenuItem.DropDownItems.Add(_item);
            }
        }

        private void setFocus(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                List<Form> forms = (from x in this.MdiChildren
                           where x.Name == ((ToolStripMenuItem)sender).Name
                           select x).ToList<Form>();
                if (forms.Count > 0 )
                    forms[0].Focus();
            }
        }

        private void formClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form)
            {
                ToolStripItem[] toolStripItems = this.windowToolStripMenuItem.DropDownItems.Find(((Form)sender).Name,true);
                if (toolStripItems.Length > 0 )
                    windowToolStripMenuItem.DropDownItems.Remove(toolStripItems[0]);
            }
        }

        private void oWLConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OWLConfigurationForm form = new OWLConfigurationForm();
            form.MdiParent = this;
            form.Name = ((ToolStripMenuItem)sender).Name;
            form.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClosed);
            form.Show();
        }

        private void databaseMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseMappingForm form = new DatabaseMappingForm();
            form.MdiParent = this;
            form.Name = ((ToolStripMenuItem)sender).Name;
            form.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClosed);
            form.Show();
        }

        private void accurateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccurateSettings form = new AccurateSettings();
            form.MdiParent = this;
            form.Name = ((ToolStripMenuItem)sender).Name;
            form.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClosed);
            form.Show();
        }

        private void CRMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CRMForm form = new CRMForm();
            form.MdiParent = this;
            form.Name = ((ToolStripMenuItem)sender).Name;
            form.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClosed);
            form.Show();
        }

        private void SWRLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SWRLForm form = new SWRLForm();
            form.MdiParent = this;
            form.Name = ((ToolStripMenuItem)sender).Name;
            form.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClosed);
            form.Show();
        }

        private void webServiceMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseMappingForm form = new DatabaseMappingForm(CRMOntology.Forms.DatabaseMappingForm.SourceType.WebService);
            form.MdiParent = this;
            form.Name = ((ToolStripMenuItem)sender).Name;
            form.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClosed);
            form.Show();
        }

        private void displayInNatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayOWLForm form = new DisplayOWLForm();
            form.MdiParent = this;
            form.Name = ((ToolStripMenuItem)sender).Name;
            form.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClosed);
            form.Show();
        }
    }
}
