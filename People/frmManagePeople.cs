using BusinessLayer;
using MyDVLD.People;
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
    public partial class frmManagePeople : Form
    {

        private DataView _dataView;

        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreashPeopleList();
        }

        private void _RefreashPeopleList()
        {
            //dgvPeople.DataSource = clsPeopleBusiness.GetAllPeople();
            //lblCountRecords.Text= dgvPeople.RowCount.ToString();

            _dataView = new DataView(clsPeople.GetAllPeople());
            dgvPeople.DataSource = _dataView;
            lblCountRecords.Text = _dataView.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                _ApplyFilter();
            }
        }

        private void _ApplyFilter()
        {
            if (_dataView == null) return;

            string filteredColumn = cbFilter.SelectedItem?.ToString() ?? "None";
            string searchedText = tbFilter.Text.Trim();

            if (string.IsNullOrEmpty(searchedText) || filteredColumn == "None")
            {
                _dataView.RowFilter = string.Empty;
            }
            else if (filteredColumn == "PersonID")
            {
                if (int.TryParse(searchedText, out int personID))
                {
                    _dataView.RowFilter = $"{filteredColumn} = {personID}";
                }
                else
                {
                    _dataView.RowFilter = "1 = 0";
                }
            }
            else
            {
                string safeSearchText = searchedText.Replace("'", "''");
                _dataView.RowFilter = $"{filteredColumn} LIKE '%{safeSearchText}%'";
            }

            lblCountRecords.Text = _dataView.Count.ToString();
        }

        private void cbFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tbFilter.Visible = cbFilter.SelectedIndex != 0;
            _ApplyFilter();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form form = new frmAddUpdatePerson();
            form.ShowDialog();  
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmShowPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            form.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new frmAddUpdatePerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            form.ShowDialog();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _RefreashPeopleList();
        }
    }
}
