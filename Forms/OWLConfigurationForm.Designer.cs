namespace CRMOntology.Forms
{
    partial class OWLConfigurationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMappings = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRDFPath = new System.Windows.Forms.TextBox();
            this.btn_LoadRDF = new System.Windows.Forms.Button();
            this.btnStartTransfer = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeListViewTriples = new CommonTools.TreeListView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPeriod = new System.Windows.Forms.TextBox();
            this.checkBoxSetAsBackgroundJob = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewTriples)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mappings : ";
            // 
            // cmbMappings
            // 
            this.cmbMappings.FormattingEnabled = true;
            this.cmbMappings.Location = new System.Drawing.Point(116, 9);
            this.cmbMappings.Name = "cmbMappings";
            this.cmbMappings.Size = new System.Drawing.Size(386, 21);
            this.cmbMappings.TabIndex = 1;
            this.cmbMappings.SelectedIndexChanged += new System.EventHandler(this.cmbMappings_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "RDF File Path :";
            // 
            // txtRDFPath
            // 
            this.txtRDFPath.Location = new System.Drawing.Point(116, 40);
            this.txtRDFPath.Name = "txtRDFPath";
            this.txtRDFPath.Size = new System.Drawing.Size(386, 20);
            this.txtRDFPath.TabIndex = 3;
            // 
            // btn_LoadRDF
            // 
            this.btn_LoadRDF.Location = new System.Drawing.Point(534, 7);
            this.btn_LoadRDF.Name = "btn_LoadRDF";
            this.btn_LoadRDF.Size = new System.Drawing.Size(106, 23);
            this.btn_LoadRDF.TabIndex = 4;
            this.btn_LoadRDF.Text = "Load RDF";
            this.btn_LoadRDF.UseVisualStyleBackColor = true;
            this.btn_LoadRDF.Click += new System.EventHandler(this.btnLoadRDF_Click);
            // 
            // btnStartTransfer
            // 
            this.btnStartTransfer.Location = new System.Drawing.Point(534, 38);
            this.btnStartTransfer.Name = "btnStartTransfer";
            this.btnStartTransfer.Size = new System.Drawing.Size(106, 23);
            this.btnStartTransfer.TabIndex = 5;
            this.btnStartTransfer.Text = "Start Transfer";
            this.btnStartTransfer.UseVisualStyleBackColor = true;
            this.btnStartTransfer.Click += new System.EventHandler(this.btnStartTransfer_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txtPeriod);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxSetAsBackgroundJob);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnStartTransfer);
            this.splitContainer1.Panel1.Controls.Add(this.cmbMappings);
            this.splitContainer1.Panel1.Controls.Add(this.btn_LoadRDF);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtRDFPath);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeListViewTriples);
            this.splitContainer1.Size = new System.Drawing.Size(1023, 723);
            this.splitContainer1.SplitterDistance = 76;
            this.splitContainer1.TabIndex = 6;
            // 
            // treeListViewTriples
            // 
            this.treeListViewTriples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListViewTriples.Images = null;
            this.treeListViewTriples.Location = new System.Drawing.Point(0, 0);
            this.treeListViewTriples.Name = "treeListViewTriples";
            this.treeListViewTriples.Size = new System.Drawing.Size(1023, 643);
            this.treeListViewTriples.TabIndex = 0;
            this.treeListViewTriples.Text = "treeListViewTriples";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(672, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Background Job";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(672, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Period in min";
            // 
            // txtPeriod
            // 
            this.txtPeriod.Location = new System.Drawing.Point(760, 32);
            this.txtPeriod.MaxLength = 5;
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.ReadOnly = true;
            this.txtPeriod.Size = new System.Drawing.Size(52, 20);
            this.txtPeriod.TabIndex = 12;
            this.txtPeriod.Text = "5";
            this.txtPeriod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeriod_KeyPress);
            // 
            // checkBoxSetAsBackgroundJob
            // 
            this.checkBoxSetAsBackgroundJob.AutoSize = true;
            this.checkBoxSetAsBackgroundJob.Location = new System.Drawing.Point(760, 11);
            this.checkBoxSetAsBackgroundJob.Name = "checkBoxSetAsBackgroundJob";
            this.checkBoxSetAsBackgroundJob.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSetAsBackgroundJob.TabIndex = 11;
            this.checkBoxSetAsBackgroundJob.UseVisualStyleBackColor = true;
            this.checkBoxSetAsBackgroundJob.CheckedChanged += new System.EventHandler(this.checkBoxSetAsBackgroundJob_CheckedChanged);
            // 
            // OWLConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 723);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "OWLConfigurationForm";
            this.Text = "OWL Configuration Form";
            this.Load += new System.EventHandler(this.OWLConfigurationForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewTriples)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMappings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRDFPath;
        private System.Windows.Forms.Button btn_LoadRDF;
        private System.Windows.Forms.Button btnStartTransfer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private CommonTools.TreeListView treeListViewTriples;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPeriod;
        private System.Windows.Forms.CheckBox checkBoxSetAsBackgroundJob;
    }
}