namespace MyDVLD
{
    partial class frmtester
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dcfasscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cvdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dsvcsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sdfdsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::MyDVLD.Properties.Resources.Logo_Final;
            this.pictureBox1.Location = new System.Drawing.Point(0, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 407);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dcfasscToolStripMenuItem,
            this.dsvcsToolStripMenuItem,
            this.sdfdsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 43);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dcfasscToolStripMenuItem
            // 
            this.dcfasscToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cvdToolStripMenuItem});
            this.dcfasscToolStripMenuItem.Name = "dcfasscToolStripMenuItem";
            this.dcfasscToolStripMenuItem.Size = new System.Drawing.Size(111, 39);
            this.dcfasscToolStripMenuItem.Text = "dcfassc";
            // 
            // cvdToolStripMenuItem
            // 
            this.cvdToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dssToolStripMenuItem});
            this.cvdToolStripMenuItem.Name = "cvdToolStripMenuItem";
            this.cvdToolStripMenuItem.Size = new System.Drawing.Size(224, 40);
            this.cvdToolStripMenuItem.Text = "cvd";
            // 
            // dssToolStripMenuItem
            // 
            this.dssToolStripMenuItem.Name = "dssToolStripMenuItem";
            this.dssToolStripMenuItem.Size = new System.Drawing.Size(224, 40);
            this.dssToolStripMenuItem.Text = "dss";
            // 
            // dsvcsToolStripMenuItem
            // 
            this.dsvcsToolStripMenuItem.Name = "dsvcsToolStripMenuItem";
            this.dsvcsToolStripMenuItem.Size = new System.Drawing.Size(90, 39);
            this.dsvcsToolStripMenuItem.Text = "dsvcs";
            // 
            // sdfdsToolStripMenuItem
            // 
            this.sdfdsToolStripMenuItem.Name = "sdfdsToolStripMenuItem";
            this.sdfdsToolStripMenuItem.Size = new System.Drawing.Size(89, 39);
            this.sdfdsToolStripMenuItem.Text = "sdfds";
            // 
            // frmtester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmtester";
            this.Text = "frmtester";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dcfasscToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cvdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dssToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dsvcsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sdfdsToolStripMenuItem;
    }
}