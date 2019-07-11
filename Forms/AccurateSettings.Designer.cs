namespace CRMOntology.Forms
{
    partial class AccurateSettings
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
            this.txtNoConstraint = new System.Windows.Forms.TextBox();
            this.txtBusinessRecommend = new System.Windows.Forms.TextBox();
            this.txtBusinessRequired = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLow = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMedium = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHigh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeListViewStaging = new CommonTools.TreeListView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnNoConstraint = new System.Windows.Forms.Button();
            this.btnBusinessRecommend = new System.Windows.Forms.Button();
            this.btnBusinessRequired = new System.Windows.Forms.Button();
            this.treeListViewAccurateXML = new CommonTools.TreeListView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewStaging)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewAccurateXML)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.txtNoConstraint);
            this.splitContainer1.Panel1.Controls.Add(this.txtBusinessRecommend);
            this.splitContainer1.Panel1.Controls.Add(this.txtBusinessRequired);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.txtLow);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtMedium);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtHigh);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1030, 509);
            this.splitContainer1.SplitterDistance = 102;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtNoConstraint
            // 
            this.txtNoConstraint.Location = new System.Drawing.Point(130, 74);
            this.txtNoConstraint.Name = "txtNoConstraint";
            this.txtNoConstraint.Size = new System.Drawing.Size(45, 20);
            this.txtNoConstraint.TabIndex = 12;
            this.txtNoConstraint.Text = "0";
            this.txtNoConstraint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoConstraint_KeyPress);
            this.txtNoConstraint.Validated += new System.EventHandler(this.txtNoConstraint_Validated);
            // 
            // txtBusinessRecommend
            // 
            this.txtBusinessRecommend.Location = new System.Drawing.Point(130, 40);
            this.txtBusinessRecommend.Name = "txtBusinessRecommend";
            this.txtBusinessRecommend.Size = new System.Drawing.Size(45, 20);
            this.txtBusinessRecommend.TabIndex = 11;
            this.txtBusinessRecommend.Text = "0";
            this.txtBusinessRecommend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusinessRecommend_KeyPress);
            this.txtBusinessRecommend.Validated += new System.EventHandler(this.txtBusinessRecommend_Validated);
            // 
            // txtBusinessRequired
            // 
            this.txtBusinessRequired.Location = new System.Drawing.Point(130, 7);
            this.txtBusinessRequired.Name = "txtBusinessRequired";
            this.txtBusinessRequired.Size = new System.Drawing.Size(45, 20);
            this.txtBusinessRequired.TabIndex = 10;
            this.txtBusinessRequired.Text = "0";
            this.txtBusinessRequired.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusinessRequired_KeyPress);
            this.txtBusinessRequired.Validated += new System.EventHandler(this.txtBusinessRequired_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "No Constraint : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Business Recommend : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Business Required :";
            // 
            // txtLow
            // 
            this.txtLow.Location = new System.Drawing.Point(511, 8);
            this.txtLow.Name = "txtLow";
            this.txtLow.Size = new System.Drawing.Size(56, 20);
            this.txtLow.TabIndex = 6;
            this.txtLow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLow_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(458, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Low : ";
            // 
            // txtMedium
            // 
            this.txtMedium.Location = new System.Drawing.Point(511, 40);
            this.txtMedium.Name = "txtMedium";
            this.txtMedium.Size = new System.Drawing.Size(56, 20);
            this.txtMedium.TabIndex = 4;
            this.txtMedium.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMedium_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(458, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Medium : ";
            // 
            // txtHigh
            // 
            this.txtHigh.Location = new System.Drawing.Point(511, 73);
            this.txtHigh.Name = "txtHigh";
            this.txtHigh.Size = new System.Drawing.Size(56, 20);
            this.txtHigh.TabIndex = 2;
            this.txtHigh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHigh_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(458, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "High :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(900, 33);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeListViewStaging);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1030, 403);
            this.splitContainer2.SplitterDistance = 449;
            this.splitContainer2.TabIndex = 0;
            // 
            // treeListViewStaging
            // 
            this.treeListViewStaging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListViewStaging.Images = null;
            this.treeListViewStaging.Location = new System.Drawing.Point(0, 0);
            this.treeListViewStaging.Name = "treeListViewStaging";
            this.treeListViewStaging.Size = new System.Drawing.Size(449, 403);
            this.treeListViewStaging.TabIndex = 0;
            this.treeListViewStaging.Text = "treeListView1";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.btnRemove);
            this.splitContainer3.Panel1.Controls.Add(this.btnNoConstraint);
            this.splitContainer3.Panel1.Controls.Add(this.btnBusinessRecommend);
            this.splitContainer3.Panel1.Controls.Add(this.btnBusinessRequired);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.treeListViewAccurateXML);
            this.splitContainer3.Size = new System.Drawing.Size(577, 403);
            this.splitContainer3.SplitterDistance = 174;
            this.splitContainer3.TabIndex = 0;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(14, 306);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(152, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "<< Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnNoConstraint
            // 
            this.btnNoConstraint.Location = new System.Drawing.Point(14, 237);
            this.btnNoConstraint.Name = "btnNoConstraint";
            this.btnNoConstraint.Size = new System.Drawing.Size(152, 23);
            this.btnNoConstraint.TabIndex = 2;
            this.btnNoConstraint.Text = "No Constraint >>";
            this.btnNoConstraint.UseVisualStyleBackColor = true;
            this.btnNoConstraint.Click += new System.EventHandler(this.btnNoConstraint_Click);
            // 
            // btnBusinessRecommend
            // 
            this.btnBusinessRecommend.Location = new System.Drawing.Point(14, 154);
            this.btnBusinessRecommend.Name = "btnBusinessRecommend";
            this.btnBusinessRecommend.Size = new System.Drawing.Size(152, 23);
            this.btnBusinessRecommend.TabIndex = 1;
            this.btnBusinessRecommend.Text = "Business Reccommend >>";
            this.btnBusinessRecommend.UseVisualStyleBackColor = true;
            this.btnBusinessRecommend.Click += new System.EventHandler(this.btnBusinessRecommend_Click);
            // 
            // btnBusinessRequired
            // 
            this.btnBusinessRequired.Location = new System.Drawing.Point(14, 73);
            this.btnBusinessRequired.Name = "btnBusinessRequired";
            this.btnBusinessRequired.Size = new System.Drawing.Size(152, 23);
            this.btnBusinessRequired.TabIndex = 0;
            this.btnBusinessRequired.Text = "Business Required >>";
            this.btnBusinessRequired.UseVisualStyleBackColor = true;
            this.btnBusinessRequired.Click += new System.EventHandler(this.btnBusinessRequired_Click);
            // 
            // treeListViewAccurateXML
            // 
            this.treeListViewAccurateXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListViewAccurateXML.Images = null;
            this.treeListViewAccurateXML.Location = new System.Drawing.Point(0, 0);
            this.treeListViewAccurateXML.Name = "treeListViewAccurateXML";
            this.treeListViewAccurateXML.Size = new System.Drawing.Size(399, 403);
            this.treeListViewAccurateXML.TabIndex = 0;
            this.treeListViewAccurateXML.Text = "treeListView2";
            // 
            // AccurateSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 509);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccurateSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Accurate Settings";
            this.Load += new System.EventHandler(this.AccurateSettings_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewStaging)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewAccurateXML)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtLow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMedium;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHigh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox txtNoConstraint;
        private System.Windows.Forms.TextBox txtBusinessRecommend;
        private System.Windows.Forms.TextBox txtBusinessRequired;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private CommonTools.TreeListView treeListViewStaging;
        private System.Windows.Forms.Button btnNoConstraint;
        private System.Windows.Forms.Button btnBusinessRecommend;
        private System.Windows.Forms.Button btnBusinessRequired;
        private CommonTools.TreeListView treeListViewAccurateXML;
        private System.Windows.Forms.Button btnRemove;
    }
}