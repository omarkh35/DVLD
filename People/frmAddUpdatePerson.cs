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
using System.IO;
using MyDVLD.Global;


namespace MyDVLD
{
    public partial class frmAddUpdatePerson : Form
    {

        public delegate void DataBackEventHandler(object sender, int PersonID);

        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew =  0, Update = 1 };

        public enum enGendor { Male =0 , Female = 1 };

        private enMode _Mode;
        private int _PersonID = -1;
        clsPeople _clsPeople;

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PersonID = PersonID;
        }

        private void _ResetDefualtValues()
        {
            _FillCountriesinComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
                _clsPeople = new clsPeople();
            }
            else
            {
                lblTitle.Text = "Update Person";
            }

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtNationalNo.Text = "";
            txtEmail.Text = "";

            cbCountry.SelectedIndex = cbCountry.FindString("Syria");

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);




        }
        private void _FillCountriesinComboBox()
        {
            DataTable dataTable = clsCountries.GetAllCountries();
            foreach (DataRow row in dataTable.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }

        private void _LoadData()
        {
            _clsPeople = clsPeople.Find(_PersonID);

            if(_clsPeople == null)
            {
                MessageBox.Show("No Person With ID= " + _PersonID + " Is Found","Person Not Found ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lblPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _clsPeople.FirstName;
            txtSecondName.Text = _clsPeople.SecondName;
            txtThirdName.Text = _clsPeople.ThirdName;
            txtLastName.Text = _clsPeople.LastName;
            txtNationalNo.Text = _clsPeople.NationalNo;
            txtPhone.Text = _clsPeople.Phone;
            txtEmail.Text = _clsPeople.Email;
            txtAddress.Text = _clsPeople.Address;
            //imlemaent Find
            cbCountry.SelectedItem = clsCountries.Find(_clsPeople.NationalityCountryID).CountryName;
            dtpDateOfBirth.Text = _clsPeople.DateOfBirth.ToShortDateString();
            if(_clsPeople.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            if (_clsPeople.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _clsPeople.ImagePath;

            }

            llRemoveImage.Visible = (_clsPeople.ImagePath != "");


        }
        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if(!_HandelImage())
            {
                return;
            }


            _clsPeople.FirstName = txtFirstName.Text.Trim() ;
            _clsPeople.SecondName = txtSecondName.Text.Trim() ;
            _clsPeople.ThirdName = txtThirdName.Text.Trim() ;
            _clsPeople.LastName = txtLastName.Text.Trim() ;
            _clsPeople.NationalNo = txtNationalNo.Text.Trim() ;
            _clsPeople.Phone = txtPhone.Text.Trim() ;
            _clsPeople.Email = txtEmail.Text.Trim() ;
            _clsPeople.Address = txtAddress.Text.Trim() ;
            //imlemaent Find
            _clsPeople.NationalityCountryID = clsCountries.Find(cbCountry.Text).CountryID;
             _clsPeople.DateOfBirth= dtpDateOfBirth.Value ;
            if (rbMale.Checked )
            _clsPeople.Gendor = 0;
            else
                _clsPeople.Gendor = 1;
            if (pbPersonImage.ImageLocation != null)
                _clsPeople.ImagePath = pbPersonImage.ImageLocation;
            else
                _clsPeople.ImagePath = "";
            if(_clsPeople.Save())
            {
                lblTitle.Text = "Update Person";
                lblPersonID.Text = _clsPeople.PersonID.ToString();
                _Mode = enMode.Update;
                

                MessageBox.Show("Saved Successfully.");

                DataBack?.Invoke(this, _clsPeople.PersonID);
                
            }
            else
                MessageBox.Show("Failed To Save");


        }

        private bool _HandelImage()
        {
            if(_clsPeople.ImagePath!=pbPersonImage.ImageLocation)
            {

                if(_clsPeople.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_clsPeople.ImagePath);
                    }
                    catch (IOException)
                    {

                    }
                }

                if(pbPersonImage.ImageLocation != null)
                {
                    string FileName = pbPersonImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProgramFolder(ref FileName))
                    {
                        pbPersonImage.ImageLocation = FileName;
                        return true;
                    }
                    else
                        return false;

                }

            }
            return true;
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender) ;
            if(string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This Is Required");
            }
            else
                errorProvider1.SetError(Temp, null);

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;

            if(!clsValidation.ValidateEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "This Is Wrong Formmat");
            }
            else
                errorProvider1.SetError(txtEmail, null);

        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmptyTextBox(sender, e);

            if(txtNationalNo.Text.Trim()!=_clsPeople.NationalNo && clsPeople.IsPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "This National No Exist");
            }
            else
                errorProvider1.SetError(txtEmail, null);

        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string File = openFileDialog1.FileName;
                pbPersonImage.Load(File);
                llRemoveImage.Visible = false;
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.Image = null;

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

        }
    }
}
