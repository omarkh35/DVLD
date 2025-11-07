using BusinessLayer;
using MyDVLD.Global;
using MyDVLD.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDVLD
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmManagePeople();
            form.ShowDialog();
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsUser.Find(clsLoginInfo.CurrentUsername).UserID);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.ShowForm();
            this.Close();
        }

        private void cuurentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCurrentUserInfo frm = new frmCurrentUserInfo(clsUser.Find(clsLoginInfo.CurrentUsername).UserID);
            frm.ShowDialog();
        }
    }
}
