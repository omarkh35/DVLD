using BusinessLayer;
using MyDVLD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MyDVLD.frmAddUpdatePerson;

namespace MyDVLD.User
{
    public partial class ctrlShowUserInfo : UserControl
    {

        private clsUser _User;

        private int _UserID = -1;

        public int UserID
        {
            get { return _UserID; }
        }

        public clsUser UserInfo
        { get { return _User; } }

        public ctrlShowUserInfo()
        {
            InitializeComponent();
        }

        private void _FillUserInfo()
        {
            ctrlShowPersonInfo1.LoadPersonInfo(_User.PersonID);


            _UserID = _User.UserID;
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();
            lblIsActive.Text = _User.IsActive?"Yes":"No";


        }

        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.Find(UserID);
            if (_User== null)
            {
                ResetUserInfo();
                MessageBox.Show("No User with ID. = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }

        public void ResetUserInfo()
        {
            ctrlShowPersonInfo1.ResetPersonInfo();
        
            _UserID = -1;
            lblUserID.Text = "[????]";
            lblUserName.Text = "[????]";
            lblIsActive.Text = "[????]";
            
        }

    }
}
