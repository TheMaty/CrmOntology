namespace CRMOntology.Forms
{
    partial class SWRLForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listViewRules = new System.Windows.Forms.ListView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.columnHeaderRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1117, 506);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 0;
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
            this.splitContainer2.Panel1.Controls.Add(this.listViewRules);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnRun);
            this.splitContainer2.Panel2.Controls.Add(this.btnEdit);
            this.splitContainer2.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer2.Panel2.Controls.Add(this.btnNew);
            this.splitContainer2.Size = new System.Drawing.Size(1117, 220);
            this.splitContainer2.SplitterDistance = 168;
            this.splitContainer2.TabIndex = 0;
            // 
            // listViewRules
            // 
            this.listViewRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderRule});
            this.listViewRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRules.GridLines = true;
            this.listViewRules.HoverSelection = true;
            this.listViewRules.Location = new System.Drawing.Point(0, 0);
            this.listViewRules.MultiSelect = false;
            this.listViewRules.Name = "listViewRules";
            this.listViewRules.ShowGroups = false;
            this.listViewRules.Size = new System.Drawing.Size(1117, 168);
            this.listViewRules.TabIndex = 0;
            this.listViewRules.UseCompatibleStateImageBehavior = false;
            this.listViewRules.View = System.Windows.Forms.View.Details;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(95, 13);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit Rule";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(176, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete Rule";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(14, 13);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New Rule";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // columnHeaderRule
            // 
            this.columnHeaderRule.Text = "Rules";
            this.columnHeaderRule.Width = 1111;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1117, 282);
            this.textBox1.TabIndex = 0;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(507, 13);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(100, 23);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // SWRLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 506);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "SWRLForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Semantic Web Rule Language Form";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listViewRules;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ColumnHeader columnHeaderRule;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox textBox1;
    }
}