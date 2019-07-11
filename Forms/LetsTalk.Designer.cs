namespace CRMOntology.Forms
{
    partial class LetsTalk
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
            this.colorListBox1 = new CommonTools.ColorListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.colorListBox1);
            this.splitContainer1.Size = new System.Drawing.Size(837, 488);
            this.splitContainer1.SplitterDistance = 237;
            this.splitContainer1.TabIndex = 0;
            // 
            // colorListBox1
            // 
            this.colorListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorListBox1.FormattingEnabled = true;
            this.colorListBox1.Location = new System.Drawing.Point(0, 0);
            this.colorListBox1.Name = "colorListBox1";
            this.colorListBox1.SelectedColor = System.Drawing.Color.AliceBlue;
            this.colorListBox1.Size = new System.Drawing.Size(237, 488);
            this.colorListBox1.TabIndex = 0;
            // 
            // LetsTalk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 488);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LetsTalk";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "LetsTalk !!!";
            this.Load += new System.EventHandler(this.LetsTalk_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private CommonTools.ColorListBox colorListBox1;
    }
}