using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDVLD.People.Controls
{
    public partial class ctrlShowInfoWithFilter : UserControl
    {

        public event Action<int> OnPersonChoosen;

        protected virtual void PersonChoosen(int PersonID)
        {
            Action<int> handler = OnPersonChoosen;
            if (handler != null)
            {
                handler(PersonID);
            }
        }



        public ctrlShowInfoWithFilter()
        {
            InitializeComponent();
        }


        private bool _ShowAddPerson = true;

        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }
            set
            {
                _ShowAddPerson = value;
                btnAddNew.Visible = _ShowAddPerson;
            }
        }


        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        private int _PersonID = -1;
        public int PersonID
        {
            get { return ctrlShowInfo1.PersonID; }
        }

        public clsPeople SelectedPersonInfo
        {
            get { return ctrlShowInfo1.personInfo; }
        }

        public void LoadPErsonInfo(int PrsonID)
        {
            cbFilter.SelectedIndex = 1;
            tbFilter.Text = PrsonID.ToString();
            _FindNow();
        }

        private void _FindNow()
        {
            switch(cbFilter.Text)
            {
                case "National No":
                    ctrlShowInfo1.LoadPersonInfo(tbFilter.Text); 
                    break;
                case "Person ID":
                    ctrlShowInfo1.LoadPersonInfo(int.Parse(tbFilter.Text));
                    break;

                default:
                    break;
            }
            if(OnPersonChoosen != null&&FilterEnabled)
            {
                OnPersonChoosen(ctrlShowInfo1.PersonID);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson form = new frmAddUpdatePerson();
            form.DataBack += Form_DataBack;
            form.ShowDialog();
        }

        private void Form_DataBack(object sender, int PersonID)
        {
            _PersonID = PersonID;
            LoadPErsonInfo(_PersonID);
        }

        private void tbFilter_Validating(object sender, CancelEventArgs e)
        {
            TextBox temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "This Is Required");
            }
            else
                errorProvider1.SetError(temp, null);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilter.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FindNow();
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
            }

            if(cbFilter.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
