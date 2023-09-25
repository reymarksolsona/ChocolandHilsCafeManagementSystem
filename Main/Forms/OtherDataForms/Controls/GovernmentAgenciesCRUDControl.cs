using EntitiesShared.EmployeeManagement;
using EntitiesShared.OtherDataManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.OtherDataForms.Controls
{
    public partial class GovernmentAgenciesCRUDControl : UserControl
    {
        public GovernmentAgenciesCRUDControl()
        {
            InitializeComponent();
        }

        private void GovernmentAgenciesCRUDControl_Load(object sender, EventArgs e)
        {
            SetDGVGovernmentAgenciesFontAndColors();
            DisplayGovernmentAgencyList();
        }

        private List<GovernmentAgencyModel> governmentAgencies;

        public List<GovernmentAgencyModel> GovernmentAgencies
        {
            get { return governmentAgencies; }
            set { governmentAgencies = value; }
        }


        private GovernmentAgencyModel governmentAgencyToAddUpdate;

        public GovernmentAgencyModel GovernmentAgencyToAddUpdate
        {
            get { return governmentAgencyToAddUpdate; }
            set { governmentAgencyToAddUpdate = value; }
        }

        public bool IsSaveNew { get; set; } = true;

        // Event handler for saving leave type
        public event EventHandler GovernmentAgencySaved;
        protected virtual void OnGovernmentAgencySaved(EventArgs e)
        {
            GovernmentAgencySaved?.Invoke(this, e);
        }


        // Use on clicking update button
        public event PropertyChangedEventHandler PropertySelectedGovernmentAgencyIdToUpdateChanged;

        private string selectedGovernmentAgencyIdToUpdate;

        public string SelectedGovernmentAgencyIdToUpdate
        {
            get { return selectedGovernmentAgencyIdToUpdate; ; }
            set
            {
                selectedGovernmentAgencyIdToUpdate = value;

                if (PropertySelectedGovernmentAgencyIdToUpdateChanged != null)
                {
                    PropertySelectedGovernmentAgencyIdToUpdateChanged(this, new PropertyChangedEventArgs(SelectedGovernmentAgencyIdToUpdate));
                }
            }
        }

        // Use on clicking delete button
        public event PropertyChangedEventHandler PropertySelectedGovernmentAgencyIdToDeleteChanged;

        private string selectedGovernmentAgencyIdToDelete;

        public string SelectedGovernmentAgencyIdToDelete
        {
            get { return selectedGovernmentAgencyIdToDelete; ; }
            set
            {
                selectedGovernmentAgencyIdToDelete = value;

                if (PropertySelectedGovernmentAgencyIdToDeleteChanged != null)
                {
                    PropertySelectedGovernmentAgencyIdToDeleteChanged(this, new PropertyChangedEventArgs(SelectedGovernmentAgencyIdToDelete));
                }
            }
        }


        private void SetDGVGovernmentAgenciesFontAndColors()
        {
            this.DGVGovernmentAgencies.BackgroundColor = Color.White;
            this.DGVGovernmentAgencies.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVGovernmentAgencies.RowHeadersVisible = false;
            this.DGVGovernmentAgencies.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVGovernmentAgencies.AllowUserToResizeRows = false;
            this.DGVGovernmentAgencies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVGovernmentAgencies.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVGovernmentAgencies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVGovernmentAgencies.MultiSelect = false;

            this.DGVGovernmentAgencies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVGovernmentAgencies.ColumnHeadersHeight = 30;
        }

        public void ResetForm()
        {
            this.TbxAgency.Text = "";
            this.SelectedGovernmentAgencyIdToUpdate = "";
            this.SelectedGovernmentAgencyIdToDelete = "";
            this.BtnCancelUpdate.Visible = false;
            this.GBoxGovtAgencyForm.Text = "Add new";
            this.IsSaveNew = true;
            this.GovernmentAgencyToAddUpdate = null;
        }

        private void BtnCancelUpdate_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        public void DisplaySelectedGovernmentAgency()
        {
            if (this.GovernmentAgencyToAddUpdate != null)
            {
                this.TbxAgency.Text = this.GovernmentAgencyToAddUpdate.GovtAgency;
            }
        }

        private void BtnSaveAgency_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.TbxAgency.Text))
                return;

            // add new
            if (this.IsSaveNew == true)
            {

                var existingGovtAgency = this.GovernmentAgencies.Where(x => x.GovtAgency.ToLower() == this.TbxAgency.Text.ToLower()).FirstOrDefault();

                if (existingGovtAgency != null)
                {
                    MessageBox.Show("Duplicate government agency", "Duplicate entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                this.GovernmentAgencyToAddUpdate = new GovernmentAgencyModel
                {
                    GovtAgency = this.TbxAgency.Text
                };
            }

            // update
            if (this.IsSaveNew == false && this.GovernmentAgencyToAddUpdate != null)
            {
                var existingGovtAgency = this.GovernmentAgencies.Where(x => x.GovtAgency.ToLower() == this.TbxAgency.Text.ToLower() &&
                                                    x.Id != this.GovernmentAgencyToAddUpdate.Id).FirstOrDefault();

                if (existingGovtAgency != null)
                {
                    MessageBox.Show("Duplicate government agency", "Duplicate entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                this.GovernmentAgencyToAddUpdate.GovtAgency = this.TbxAgency.Text;
            }

            OnGovernmentAgencySaved(EventArgs.Empty);
        }


        public void DisplayGovernmentAgencyList()
        {
            this.DGVGovernmentAgencies.Rows.Clear();
            if (this.GovernmentAgencies != null)
            {
                this.DGVGovernmentAgencies.ColumnCount = 3;


                this.DGVGovernmentAgencies.Columns[0].Name = "GovernmentAgencyId";
                this.DGVGovernmentAgencies.Columns[0].Visible = false;

                this.DGVGovernmentAgencies.Columns[1].Name = "AgencyTitle";
                this.DGVGovernmentAgencies.Columns[1].HeaderText = "Agency";

                this.DGVGovernmentAgencies.Columns[2].Name = "CreatedAt";
                this.DGVGovernmentAgencies.Columns[2].HeaderText = "Created At";


                // Update button
                DataGridViewImageColumn btnUpdateImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVGovernmentAgencies.Columns.Add(btnUpdateImg);


                // Delete button
                DataGridViewImageColumn btnDeleteImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVGovernmentAgencies.Columns.Add(btnDeleteImg);


                foreach(var agency in this.GovernmentAgencies)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVGovernmentAgencies);

                    row.Cells[0].Value = agency.Id;
                    row.Cells[1].Value = agency.GovtAgency;
                    row.Cells[2].Value = agency.CreatedAt.ToShortDateString();
                    this.DGVGovernmentAgencies.Rows.Add(row);
                }
            }
        }

        private void DGVGovernmentAgencies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Update button
            if ((e.ColumnIndex == 5) && e.RowIndex > -1)
            {
                if (DGVGovernmentAgencies.CurrentRow != null)
                {
                    string agencyId = DGVGovernmentAgencies.CurrentRow.Cells[0].Value.ToString();

                    SelectedGovernmentAgencyIdToUpdate = agencyId;

                    this.BtnCancelUpdate.Visible = true;
                    this.IsSaveNew = false;
                }
            }

            // Delete button
            if ((e.ColumnIndex == 6) && e.RowIndex > -1)
            {
                if (DGVGovernmentAgencies.CurrentRow != null)
                {
                    string agencyId = DGVGovernmentAgencies.CurrentRow.Cells[0].Value.ToString();
                    SelectedGovernmentAgencyIdToDelete = agencyId;
                }
            }
        }

        private void DGVGovernmentAgencies_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 3 || e.ColumnIndex == 4) && e.RowIndex > -1)
            {
                DGVGovernmentAgencies.Cursor = Cursors.Hand;
            }
            else
            {
                DGVGovernmentAgencies.Cursor = Cursors.Default;
            }
        }
    }
}
