using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDVLD.User
{
    public partial class frmCurrentUserInfo : Form
    {
        private int _UserID;
        public frmCurrentUserInfo(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCurrentUserInfo_Load(object sender, EventArgs e)
        {
            ctrlShowUserInfo1.LoadUserInfo(_UserID);
        }
    }
}
