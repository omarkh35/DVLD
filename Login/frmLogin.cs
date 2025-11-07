using BusinessLayer;
using MyDVLD.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDVLD.User
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (!clsUser.IsUserExist(this.txtUserName.Text))
            {
                MessageBox.Show("Incorrect UserName/Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsUser user = clsUser.Find(this.txtUserName.Text);
            if (user.Password != this.txtPassword.Text)
            {
                MessageBox.Show("Incorrect UserName/Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!user.IsActive)
            {
                MessageBox.Show("This User is Deactivated. Contact the Admin", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (chkRememberMe.Checked)
            {
                clsLoginInfo.SaveCredentials(user.UserName, user.Password);
            }
            else
            {
                clsLoginInfo.ClearCredentials();
            }

            clsLoginInfo.CurrentUsername = user.UserName;
            clsLoginInfo.CurrentPassword = user.Password;
            clsLoginInfo.IsLoggedIn = true;

            frmMain frmMain = new frmMain();
            frmMain.Show();
            this.Hide();


        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            TextBox temp=((TextBox) sender);

            if (string.IsNullOrEmpty(temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "Tis Field Is Required");
            }
            else
                errorProvider1.SetError(temp, null);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            TextBox temp = ((TextBox)sender);

            if (string.IsNullOrEmpty(temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "Tis Field Is Required");
            }
            else
                errorProvider1.SetError(temp, null);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            var credentials = clsLoginInfo.LoadCredentials();
            if (!string.IsNullOrEmpty(credentials.Username) && !string.IsNullOrEmpty(credentials.Password))
            {
                txtUserName.Text = credentials.Username;
                txtPassword.Text = credentials.Password;
                chkRememberMe.Checked = true;
            }
        }

        public void ShowForm()
        {
            this.Show();
        }
        
    }
}
