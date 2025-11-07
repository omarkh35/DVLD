namespace MyDVLD.People
{
    partial class frmFindPerson
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
            this.ctrlShowInfoWithFilter1 = new MyDVLD.People.Controls.ctrlShowInfoWithFilter();
            this.lblFind = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlShowInfoWithFilter1
            // 
            this.ctrlShowInfoWithFilter1.FilterEnabled = true;
            this.ctrlShowInfoWithFilter1.Location = new System.Drawing.Point(12, 60);
            this.ctrlShowInfoWithFilter1.Name = "ctrlShowInfoWithFilter1";
            this.ctrlShowInfoWithFilter1.ShowAddPerson = true;
            this.ctrlShowInfoWithFilter1.Size = new System.Drawing.Size(846, 382);
            this.ctrlShowInfoWithFilter1.TabIndex = 0;
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Font = new System.Drawing.Font("Tahoma", 24F);
            this.lblFind.ForeColor = System.Drawing.Color.Gold;
            this.lblFind.Location = new System.Drawing.Point(375, 21);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(94, 48);
            this.lblFind.TabIndex = 1;
            this.lblFind.Text = "Find";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClose.Location = new System.Drawing.Point(864, 434);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmFindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 482);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblFind);
            this.Controls.Add(this.ctrlShowInfoWithFilter1);
            this.Name = "frmFindPerson";
            this.Text = "frmFindPerson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ctrlShowInfoWithFilter ctrlShowInfoWithFilter1;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Button btnClose;
    }
}