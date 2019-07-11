namespace CRMOntology.Forms
{
    partial class CRMForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Raw View");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Well Form");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("CRM Ontology", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeViewOntology = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewResult = new System.Windows.Forms.ListView();
            this.columnHeaderSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPredicate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderObject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.richTextBoxObject = new System.Windows.Forms.RichTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.richTextBoxSubject = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeViewOntology);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer.Size = new System.Drawing.Size(1184, 507);
            this.splitContainer.SplitterDistance = 142;
            this.splitContainer.TabIndex = 0;
            // 
            // treeViewOntology
            // 
            this.treeViewOntology.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewOntology.Location = new System.Drawing.Point(0, 0);
            this.treeViewOntology.Name = "treeViewOntology";
            treeNode1.Name = "rawview";
            treeNode1.Text = "Raw View";
            treeNode2.Name = "wellform";
            treeNode2.Text = "Well Form";
            treeNode3.Name = "crmontology";
            treeNode3.Text = "CRM Ontology";
            this.treeViewOntology.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treeViewOntology.Size = new System.Drawing.Size(142, 507);
            this.treeViewOntology.TabIndex = 0;
            this.treeViewOntology.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewOntology_AfterSelect);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewResult);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1038, 507);
            this.splitContainer1.SplitterDistance = 707;
            this.splitContainer1.TabIndex = 1;
            // 
            // listViewResult
            // 
            this.listViewResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSubject,
            this.columnHeaderPredicate,
            this.columnHeaderObject});
            this.listViewResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResult.GridLines = true;
            this.listViewResult.HoverSelection = true;
            this.listViewResult.Location = new System.Drawing.Point(0, 0);
            this.listViewResult.MultiSelect = false;
            this.listViewResult.Name = "listViewResult";
            this.listViewResult.ShowGroups = false;
            this.listViewResult.Size = new System.Drawing.Size(707, 507);
            this.listViewResult.TabIndex = 0;
            this.listViewResult.UseCompatibleStateImageBehavior = false;
            this.listViewResult.View = System.Windows.Forms.View.Details;
            this.listViewResult.SelectedIndexChanged += new System.EventHandler(this.listViewResult_SelectedIndexChanged);
            
            // 
            // columnHeaderSubject
            // 
            this.columnHeaderSubject.Text = "Subject";
            this.columnHeaderSubject.Width = 250;
            // 
            // columnHeaderPredicate
            // 
            this.columnHeaderPredicate.Text = "Predicate";
            this.columnHeaderPredicate.Width = 250;
            // 
            // columnHeaderObject
            // 
            this.columnHeaderObject.Text = "Object";
            this.columnHeaderObject.Width = 250;
            // 
            // richTextBoxObject
            // 
            this.richTextBoxObject.BackColor = System.Drawing.Color.LightYellow;
            this.richTextBoxObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxObject.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBoxObject.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxObject.Name = "richTextBoxObject";
            this.richTextBoxObject.ReadOnly = true;
            this.richTextBoxObject.Size = new System.Drawing.Size(327, 253);
            this.richTextBoxObject.TabIndex = 0;
            this.richTextBoxObject.Text = "";

            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.richTextBoxObject);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.richTextBoxSubject);
            this.splitContainer2.Size = new System.Drawing.Size(327, 507);
            this.splitContainer2.SplitterDistance = 253;
            this.splitContainer2.TabIndex = 1;
            // 
            // richTextBoxSubject
            // 
            this.richTextBoxSubject.BackColor = System.Drawing.Color.LightYellow;
            this.richTextBoxSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxSubject.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBoxSubject.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxSubject.Name = "richTextBoxSubject";
            this.richTextBoxSubject.ReadOnly = true;
            this.richTextBoxSubject.Size = new System.Drawing.Size(327, 250);
            this.richTextBoxSubject.TabIndex = 1;
            this.richTextBoxSubject.Text = "";
            
            // 
            // CRMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 507);
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CRMForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CRM Ontology Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CRMForm_FormClosing);
            this.Load += new System.EventHandler(this.CRMForm_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeViewOntology;
        private System.Windows.Forms.ListView listViewResult;
        private System.Windows.Forms.ColumnHeader columnHeaderSubject;
        private System.Windows.Forms.ColumnHeader columnHeaderPredicate;
        private System.Windows.Forms.ColumnHeader columnHeaderObject;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextBoxObject;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox richTextBoxSubject;
    }
}