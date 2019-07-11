using CRMOntology.Properties;
using System.Drawing;
using System.Windows.Forms;
namespace CRMOntology.Forms
{
    partial class DatabaseMappingForm
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtStagingDatabaseConnectionString = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBoxGenerateMapFile = new System.Windows.Forms.GroupBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.cmbExistingMap = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGenerateMapFile = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPeriod = new System.Windows.Forms.TextBox();
            this.checkBoxSetAsBackgroundJob = new System.Windows.Forms.CheckBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtOWLFilePath = new System.Windows.Forms.TextBox();
            this.txtSourceConnectionString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.treeListViewDatabase = new CommonTools.TreeListView();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.treeListViewStagingDatabase = new CommonTools.TreeListView();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.treeListViewMap = new CommonTools.TreeListView();
            this.contextMenuStripStaging = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAddToStaging = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnManualTransfer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxGenerateMapFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewStagingDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewMap)).BeginInit();
            this.contextMenuStripStaging.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.txtStagingDatabaseConnectionString);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxGenerateMapFile);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txtPeriod);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxSetAsBackgroundJob);
            this.splitContainer1.Panel1.Controls.Add(this.btnLoad);
            this.splitContainer1.Panel1.Controls.Add(this.btnBrowse);
            this.splitContainer1.Panel1.Controls.Add(this.txtOWLFilePath);
            this.splitContainer1.Panel1.Controls.Add(this.txtSourceConnectionString);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer7);
            this.splitContainer1.Size = new System.Drawing.Size(1100, 625);
            this.splitContainer1.SplitterDistance = 68;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtStagingDatabaseConnectionString
            // 
            this.txtStagingDatabaseConnectionString.Location = new System.Drawing.Point(96, 26);
            this.txtStagingDatabaseConnectionString.Name = "txtStagingDatabaseConnectionString";
            this.txtStagingDatabaseConnectionString.Size = new System.Drawing.Size(410, 20);
            this.txtStagingDatabaseConnectionString.TabIndex = 13;
            this.txtStagingDatabaseConnectionString.Text = "Server=TR00011565;Database=CRMOntology_Staging;Trusted_Connection=True;";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Staging Database";
            // 
            // groupBoxGenerateMapFile
            // 
            this.groupBoxGenerateMapFile.Controls.Add(this.btnManualTransfer);
            this.groupBoxGenerateMapFile.Controls.Add(this.btnValidate);
            this.groupBoxGenerateMapFile.Controls.Add(this.cmbExistingMap);
            this.groupBoxGenerateMapFile.Controls.Add(this.label8);
            this.groupBoxGenerateMapFile.Controls.Add(this.btnGenerateMapFile);
            this.groupBoxGenerateMapFile.Location = new System.Drawing.Point(742, 3);
            this.groupBoxGenerateMapFile.Name = "groupBoxGenerateMapFile";
            this.groupBoxGenerateMapFile.Size = new System.Drawing.Size(346, 62);
            this.groupBoxGenerateMapFile.TabIndex = 11;
            this.groupBoxGenerateMapFile.TabStop = false;
            this.groupBoxGenerateMapFile.Text = "Map File";
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(184, 9);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 11;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // cmbExistingMap
            // 
            this.cmbExistingMap.FormattingEnabled = true;
            this.cmbExistingMap.Location = new System.Drawing.Point(57, 23);
            this.cmbExistingMap.Name = "cmbExistingMap";
            this.cmbExistingMap.Size = new System.Drawing.Size(121, 21);
            this.cmbExistingMap.TabIndex = 10;
            this.cmbExistingMap.SelectedIndexChanged += new System.EventHandler(this.cmbExistingMap_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Name";
            // 
            // btnGenerateMapFile
            // 
            this.btnGenerateMapFile.Location = new System.Drawing.Point(184, 36);
            this.btnGenerateMapFile.Name = "btnGenerateMapFile";
            this.btnGenerateMapFile.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateMapFile.TabIndex = 7;
            this.btnGenerateMapFile.Text = "Generate";
            this.btnGenerateMapFile.UseVisualStyleBackColor = true;
            this.btnGenerateMapFile.Click += new System.EventHandler(this.btnGenerateMapFile_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(596, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Background Job";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(596, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Period in min";
            // 
            // txtPeriod
            // 
            this.txtPeriod.Location = new System.Drawing.Point(684, 34);
            this.txtPeriod.MaxLength = 5;
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.ReadOnly = true;
            this.txtPeriod.Size = new System.Drawing.Size(52, 20);
            this.txtPeriod.TabIndex = 8;
            this.txtPeriod.Text = "5";
            this.txtPeriod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeriod_KeyPress);
            // 
            // checkBoxSetAsBackgroundJob
            // 
            this.checkBoxSetAsBackgroundJob.AutoSize = true;
            this.checkBoxSetAsBackgroundJob.Location = new System.Drawing.Point(684, 13);
            this.checkBoxSetAsBackgroundJob.Name = "checkBoxSetAsBackgroundJob";
            this.checkBoxSetAsBackgroundJob.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSetAsBackgroundJob.TabIndex = 6;
            this.checkBoxSetAsBackgroundJob.UseVisualStyleBackColor = true;
            this.checkBoxSetAsBackgroundJob.CheckedChanged += new System.EventHandler(this.checkBoxSetAsBackgroundJob_CheckedChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(513, 9);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(513, 38);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtOWLFilePath
            // 
            this.txtOWLFilePath.Location = new System.Drawing.Point(96, 45);
            this.txtOWLFilePath.Name = "txtOWLFilePath";
            this.txtOWLFilePath.ReadOnly = true;
            this.txtOWLFilePath.Size = new System.Drawing.Size(411, 20);
            this.txtOWLFilePath.TabIndex = 3;
            this.txtOWLFilePath.Text = "C:\\D\\Private\\Master\\Graduate Thesis\\crm_ontology.rdf";
            // 
            // txtSourceConnectionString
            // 
            this.txtSourceConnectionString.Location = new System.Drawing.Point(95, 6);
            this.txtSourceConnectionString.Name = "txtSourceConnectionString";
            this.txtSourceConnectionString.Size = new System.Drawing.Size(411, 20);
            this.txtSourceConnectionString.TabIndex = 2;
            this.txtSourceConnectionString.Text = "Server=TR00011565;Database=CRMOutOfBox_MSCRM;Trusted_Connection=True;";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To OWL file path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Database";
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer7.Size = new System.Drawing.Size(1100, 553);
            this.splitContainer7.SplitterDistance = 721;
            this.splitContainer7.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(721, 553);
            this.splitContainer2.SplitterDistance = 327;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.treeListViewDatabase);
            this.splitContainer3.Size = new System.Drawing.Size(327, 553);
            this.splitContainer3.SplitterDistance = 25;
            this.splitContainer3.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Source Database";
            // 
            // treeListViewDatabase
            // 
            this.treeListViewDatabase.Images = null;
            this.treeListViewDatabase.Location = new System.Drawing.Point(4, 4);
            this.treeListViewDatabase.Name = "treeListViewDatabase";
            this.treeListViewDatabase.Size = new System.Drawing.Size(320, 515);
            this.treeListViewDatabase.TabIndex = 0;
            this.treeListViewDatabase.Text = "treeListViewDatabase";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.treeListViewStagingDatabase);
            this.splitContainer4.Size = new System.Drawing.Size(390, 553);
            this.splitContainer4.SplitterDistance = 25;
            this.splitContainer4.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Staging Database";
            // 
            // treeListViewStagingDatabase
            // 
            this.treeListViewStagingDatabase.Images = null;
            this.treeListViewStagingDatabase.Location = new System.Drawing.Point(4, 4);
            this.treeListViewStagingDatabase.Name = "treeListViewStagingDatabase";
            this.treeListViewStagingDatabase.Size = new System.Drawing.Size(350, 515);
            this.treeListViewStagingDatabase.TabIndex = 0;
            this.treeListViewStagingDatabase.Text = "treeListViewStagingDatabase";
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.btnRemoveAll);
            this.splitContainer5.Panel1.Controls.Add(this.btnRemove);
            this.splitContainer5.Panel1.Controls.Add(this.btnMap);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainer5.Size = new System.Drawing.Size(375, 553);
            this.splitContainer5.SplitterDistance = 106;
            this.splitContainer5.TabIndex = 0;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(5, 292);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(85, 23);
            this.btnRemoveAll.TabIndex = 2;
            this.btnRemoveAll.Text = "<< Remove All";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(5, 263);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(85, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "<< Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(4, 234);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(86, 23);
            this.btnMap.TabIndex = 0;
            this.btnMap.Text = "Map >>";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.treeListViewMap);
            this.splitContainer6.Size = new System.Drawing.Size(265, 553);
            this.splitContainer6.SplitterDistance = 25;
            this.splitContainer6.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mapped";
            // 
            // treeListViewMap
            // 
            this.treeListViewMap.Images = null;
            this.treeListViewMap.Location = new System.Drawing.Point(4, 4);
            this.treeListViewMap.Name = "treeListViewMap";
            this.treeListViewMap.Size = new System.Drawing.Size(258, 515);
            this.treeListViewMap.TabIndex = 0;
            this.treeListViewMap.Text = "treeListViewMap";
            // 
            // contextMenuStripStaging
            // 
            this.contextMenuStripStaging.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAddToStaging});
            this.contextMenuStripStaging.Name = "contextMenuStripStaging";
            this.contextMenuStripStaging.Size = new System.Drawing.Size(154, 26);
            // 
            // toolStripMenuItemAddToStaging
            // 
            this.toolStripMenuItemAddToStaging.Name = "toolStripMenuItemAddToStaging";
            this.toolStripMenuItemAddToStaging.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItemAddToStaging.Text = "Add to Staging";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnManualTransfer
            // 
            this.btnManualTransfer.Location = new System.Drawing.Point(266, 20);
            this.btnManualTransfer.Name = "btnManualTransfer";
            this.btnManualTransfer.Size = new System.Drawing.Size(75, 23);
            this.btnManualTransfer.TabIndex = 12;
            this.btnManualTransfer.Text = "Manual Transfer";
            this.btnManualTransfer.UseVisualStyleBackColor = true;
            this.btnManualTransfer.Click += new System.EventHandler(this.btnManualTransfer_Click);
            // 
            // DatabaseMappingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 625);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DatabaseMappingForm";
            this.Text = "Database Mapping Form";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxGenerateMapFile.ResumeLayout(false);
            this.groupBoxGenerateMapFile.PerformLayout();
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewDatabase)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewStagingDatabase)).EndInit();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel1.PerformLayout();
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewMap)).EndInit();
            this.contextMenuStripStaging.ResumeLayout(false);
            this.ResumeLayout(false);

        }        

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtOWLFilePath;
        private System.Windows.Forms.TextBox txtSourceConnectionString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxSetAsBackgroundJob;
        private CommonTools.TreeListView treeListViewDatabase;
        private CommonTools.TreeListView treeListViewStagingDatabase;
        private CommonTools.TreeListView treeListViewMap;
        private ContextMenuStrip contextMenuStripStaging;
        private ToolStripMenuItem toolStripMenuItemAddToStaging;
        private Label label6;
        private TextBox txtPeriod;
        private Button btnGenerateMapFile;
        private Label label7;
        private GroupBox groupBoxGenerateMapFile;
        private ComboBox cmbExistingMap;
        private Label label8;
        private TextBox txtStagingDatabaseConnectionString;
        private Label label9;
        private Button btnValidate;
        private Button btnRemoveAll;
        private Button btnManualTransfer;
    }
}