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
    public partial class LeaveTypeCRUDControl : UserControl
    {
        public LeaveTypeCRUDControl()
        {
            InitializeComponent();
        }

        private void LeaveTypeCRUDControl_Load(object sender, EventArgs e)
        {

            SetDGVLeaveTypesFontAndColors();
            DisplayLeaveTypeList();
        }

        private List<LeaveTypeModel> leaveTypes = new List<LeaveTypeModel>();

        public List<LeaveTypeModel> LeaveTypes
        {
            get { return leaveTypes; }
            set { leaveTypes = value; }
        }

        private LeaveTypeModel leaveTypeToAddUpdate;

        public LeaveTypeModel LeaveTypeToAddUpdate
        {
            get { return leaveTypeToAddUpdate; }
            set { leaveTypeToAddUpdate = value; }
        }

        // assume, default transaction is save new
        public bool IsSaveNew { get; set; } = true;

        // Event handler for saving leave type
        public event EventHandler LeaveTypeSaved;
        protected virtual void OnLeaveTypeSaved(EventArgs e)
        {
            LeaveTypeSaved?.Invoke(this, e);
        }

        // Use on clicking update button
        public event PropertyChangedEventHandler PropertySelectedLeaveTypeIdToUpdateChanged;

        private string selectedLeaveTypeToUpdateId;
        public string SelectedLeaveTypeToUpdateId
        {
            get { return selectedLeaveTypeToUpdateId; }
            set
            {
                selectedLeaveTypeToUpdateId = value;
                if (PropertySelectedLeaveTypeIdToUpdateChanged != null)
                {
                    PropertySelectedLeaveTypeIdToUpdateChanged(this, new PropertyChangedEventArgs(SelectedLeaveTypeToUpdateId));
                }
            }
        }

        // Use on clicking delete button
        public event PropertyChangedEventHandler PropertySelectedLeaveTypeIdToDeleteChanged;

        private string selectedLeaveTypeToDeleteId;
        public string SelectedLeaveTypeToDeleteId
        {
            get { return selectedLeaveTypeToDeleteId; }
            set
            {
                selectedLeaveTypeToDeleteId = value;
                if (PropertySelectedLeaveTypeIdToDeleteChanged != null)
                {
                    PropertySelectedLeaveTypeIdToDeleteChanged(this, new PropertyChangedEventArgs(selectedLeaveTypeToDeleteId));
                }
            }
        }

        public void ResetForm()
        {
            this.TbxLeaveType.Text = "";
            this.TboxNumberOfDays.Text = "";
            this.SelectedLeaveTypeToUpdateId = ""; // for update
            this.SelectedLeaveTypeToDeleteId = ""; // for delete
            this.BtnCancelUpdate.Visible = false;
            this.GBoxLeaveTypeForm.Text = "Add new leave type";
            this.IsSaveNew = true;
            this.LeaveTypeToAddUpdate = null;
            this.CboxDisable.Visible = false;
        }

        public void DisplaySelectedLeaveType()
        {
            if (this.LeaveTypeToAddUpdate != null)
            {
                this.CboxDisable.Checked = this.LeaveTypeToAddUpdate.IsActive ? false : true;
                this.TbxLeaveType.Text = this.LeaveTypeToAddUpdate.LeaveType;
                this.TboxNumberOfDays.Text = this.LeaveTypeToAddUpdate.NumberOfDays.ToString();
            }
        }

        private void BtnSaveLeaveType_Click(object sender, EventArgs e)
        {
            if (int.TryParse(this.TboxNumberOfDays.Text, out int numberOfDays) == false)
            {
                MessageBox.Show("Invalid number of days", "Save leave type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.IsSaveNew == true)
            {
                if (this.LeaveTypes != null)
                {
                    var existingLeave = this.LeaveTypes.Where(x => x.LeaveType.ToLower() == this.TbxLeaveType.Text.ToLower()).FirstOrDefault();

                    if (existingLeave != null)
                    {
                        MessageBox.Show("Duplicate leave type", "Save leave type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                this.LeaveTypeToAddUpdate = new LeaveTypeModel
                {
                    IsActive = true,
                    LeaveType = this.TbxLeaveType.Text,
                    NumberOfDays = numberOfDays
                };
            }
            else
            {
                if (this.LeaveTypeToAddUpdate != null)
                {
                    if (this.LeaveTypes != null)
                    {
                        var existingLeave = this.LeaveTypes.Where(x =>
                                                x.LeaveType.ToLower() == this.TbxLeaveType.Text.ToLower() &&
                                                x.Id != this.LeaveTypeToAddUpdate.Id).FirstOrDefault();

                        if (existingLeave != null)
                        {
                            MessageBox.Show("Duplicate leave type", "Save leave type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    this.LeaveTypeToAddUpdate.LeaveType = this.TbxLeaveType.Text;
                    this.LeaveTypeToAddUpdate.NumberOfDays = numberOfDays;
                    this.LeaveTypeToAddUpdate.IsActive = this.CboxDisable.Checked ? false : true;
                    this.LeaveTypeToAddUpdate.UpdatedAt = DateTime.Now;
                    //Id = long.Parse(this.SelectedLeaveTypeId),
                }
            }

            OnLeaveTypeSaved(EventArgs.Empty);
        }

        public void DisplayLeaveTypeList()
        {
            this.DGVLeaveTypes.Rows.Clear();
            if (this.LeaveTypes != null)
            {
                this.DGVLeaveTypes.ColumnCount = 6;

                this.DGVLeaveTypes.Columns[0].Name = "LeaveTypeId";
                this.DGVLeaveTypes.Columns[0].HeaderText = "LeaveTypeId";
                this.DGVLeaveTypes.Columns[0].Visible = false;

                this.DGVLeaveTypes.Columns[1].Name = "LeaveTypeTitle";
                this.DGVLeaveTypes.Columns[1].HeaderText = "LeaveType Title";

                this.DGVLeaveTypes.Columns[2].Name = "NumberOfDays";
                this.DGVLeaveTypes.Columns[2].HeaderText = "Number of days";

                this.DGVLeaveTypes.Columns[3].Name = "Active";
                this.DGVLeaveTypes.Columns[3].HeaderText = "Active";

                this.DGVLeaveTypes.Columns[4].Name = "CreatedAtDate";
                this.DGVLeaveTypes.Columns[4].HeaderText = "Created At";

                this.DGVLeaveTypes.Columns[5].Name = "UpdateAtDate";
                this.DGVLeaveTypes.Columns[5].HeaderText = "Updated At";

                // Update button
                DataGridViewImageColumn btnUpdateLeaveTypeImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateLeaveTypeImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVLeaveTypes.Columns.Add(btnUpdateLeaveTypeImg);

                // Delete button
                DataGridViewImageColumn btnDeleteLeaveTypeImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteLeaveTypeImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVLeaveTypes.Columns.Add(btnDeleteLeaveTypeImg);

                foreach (var leaveType in this.LeaveTypes)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVLeaveTypes);

                    if (leaveType.IsActive)
                        row.DefaultCellStyle.ForeColor = ForeColor = Color.Black;
                    else
                        row.DefaultCellStyle.ForeColor = ForeColor = Color.DimGray;

                    row.Cells[0].Value = leaveType.Id;
                    row.Cells[1].Value = leaveType.LeaveType;
                    row.Cells[2].Value = leaveType.NumberOfDays;
                    row.Cells[3].Value = leaveType.IsActive ? "YES" : "NO";
                    row.Cells[4].Value = leaveType.CreatedAt.ToShortDateString();
                    row.Cells[5].Value = leaveType.UpdatedAt.ToShortDateString();
                    DGVLeaveTypes.Rows.Add(row);
                }


            }
        }


        private void DGVLeaveTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Update button
            if ((e.ColumnIndex == 6) && e.RowIndex > -1)
            {
                if (DGVLeaveTypes.CurrentRow != null)
                {
                    string leaveTypeId = DGVLeaveTypes.CurrentRow.Cells[0].Value.ToString();

                    SelectedLeaveTypeToUpdateId = leaveTypeId;

                    this.CboxDisable.Visible = true;
                    this.BtnCancelUpdate.Visible = true;
                    this.GBoxLeaveTypeForm.Text = "Update leave type";
                    this.IsSaveNew = false;
                }
            }

            // Delete button
            if ((e.ColumnIndex == 7) && e.RowIndex > -1)
            {
                if (DGVLeaveTypes.CurrentRow != null)
                {
                    string leaveTypeId = DGVLeaveTypes.CurrentRow.Cells[0].Value.ToString();
                    SelectedLeaveTypeToDeleteId = leaveTypeId;
                }
            }
        }

        private void DGVLeaveTypes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 6 || e.ColumnIndex == 7) && e.RowIndex > -1)
            {
                DGVLeaveTypes.Cursor = Cursors.Hand;
            }
            else
            {
                DGVLeaveTypes.Cursor = Cursors.Default;
            }
        }


        private void BtnCancelUpdate_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void SetDGVLeaveTypesFontAndColors()
        {
            this.DGVLeaveTypes.BackgroundColor = Color.White;
            this.DGVLeaveTypes.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            //this.DGVLeaveTypes.DefaultCellStyle.ForeColor = Color.White;
            //this.DGVLeaveTypes.DefaultCellStyle.BackColor = Color.FromArgb(99, 99, 138);
            //this.DGVLeaveTypes.DefaultCellStyle.SelectionForeColor = Color.FromArgb(42, 42, 64);
            //this.DGVLeaveTypes.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

            this.DGVLeaveTypes.RowHeadersVisible = false;
            this.DGVLeaveTypes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVLeaveTypes.AllowUserToResizeRows = false;
            this.DGVLeaveTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVLeaveTypes.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            //this.DGVLeaveTypes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            //this.DGVLeaveTypes.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //this.DGVLeaveTypes.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(42, 42, 64);
            //this.DGVLeaveTypes.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

            this.DGVLeaveTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVLeaveTypes.MultiSelect = false;

            this.DGVLeaveTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVLeaveTypes.ColumnHeadersHeight = 30;
        }

    }
}
