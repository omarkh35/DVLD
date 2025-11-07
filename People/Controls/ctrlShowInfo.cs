using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using MyDVLD.Properties;

namespace MyDVLD
{
    public partial class ctrlShowInfo : UserControl
    {
        private clsPeople _Person;

        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPeople personInfo
        { get { return _Person; } }

        public ctrlShowInfo()
        {
            InitializeComponent();
        }

        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblFullName.Text = "[????]";
            lblPersonID.Text = "[????]";
            lblPhone.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblGendor.Text = "[????]";
            lblEmail.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbGendor.Image = Resources.Man_32;
            pbPersonImage.Image = Resources.Male_512;
        }

        private void _FillPersonInfo()
        {
            llEditPersonInfo.Enabled = true;
            _PersonID = _Person.PersonID; 
            lblFullName.Text = _Person.FullName;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblPhone.Text = _Person.Phone;
            lblNationalNo.Text = _Person.NationalNo;
            lblGendor.Text = _Person.Gendor == 0?"Male":"Female";
            lblEmail.Text = _Person.Email;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblCountry.Text = clsCountries.Find(_Person.NationalityCountryID).CountryName;
            lblAddress.Text = _Person.Address;
            //load Image
            _LoadPersonImage();
        }

        private void _LoadPersonImage()
        {
            if (_Person.Gendor == 0)
            {
                pbGendor.Image = Resources.Male_512;
                pbPersonImage.Image = Resources.Male_512;
            }
            else
            {
                pbGendor.Image = Resources.Female_512;
                pbPersonImage.Image = Resources.Female_512;
            }

            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    


        }

        public void LoadPersonInfo(int  personID)
        {
            _Person=clsPeople.Find(personID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with ID . = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }


        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPeople.Find(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();

            //refresh
            LoadPersonInfo(_PersonID);
            
        }
    }
}
