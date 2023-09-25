using DataAccess.Data.OtherDataManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.EmployeeManagementForms.Controls
{
    public partial class EmpPositionWithSalaryRateCRUDControl : UserControl
    {
        public EmpPositionWithSalaryRateCRUDControl(INumberOfWorkingDaysInAMonthData numberOfWorkingDaysInAMonthData)
        {
            InitializeComponent();
            _numberOfWorkingDaysInAMonthData = numberOfWorkingDaysInAMonthData;
        }

        private List<EmployeePositionModel> positions;

        public List<EmployeePositionModel> Positions
        {
            get { return positions; }
            set { positions = value; }
        }

        private EmployeePositionModel positionToAddUpdate;

        public EmployeePositionModel PositionToAddUpdate
        {
            get { return positionToAddUpdate; }
            set { positionToAddUpdate = value; }
        }


        public event PropertyChangedEventHandler IsSaveNewChanged;

        private bool _isSaveNew = true;
        private readonly INumberOfWorkingDaysInAMonthData _numberOfWorkingDaysInAMonthData;

        public bool IsSaveNew
        {
            get { return _isSaveNew; }
            set
            {
                _isSaveNew = value;

                if (IsSaveNewChanged != null)
                {
                    IsSaveNewChanged(this, new PropertyChangedEventArgs(IsSaveNew.ToString()));
                }
            }
        }


        public void OnIsSaveNewChange(object sender, PropertyChangedEventArgs e)
        {
            if (this.IsSaveNew)
            {
                this.BtnCancelUpdate.Visible = false;
                this.GboxPositionForm.Text = "Add new position";
            }
            else
            {
                this.BtnCancelUpdate.Visible = true;
                this.GboxPositionForm.Text = "Update position details";
            }
        }


        public event EventHandler PositionSaved;
        protected virtual void OnPositionSaved(EventArgs e)
        {
            PositionSaved?.Invoke(this, e);
        }


        private void EmpPositionWithSalaryRateCRUDControl_Load(object sender, EventArgs e)
        {
            IsSaveNewChanged += OnIsSaveNewChange;

            SetDGVPositionListFontAndColors();
            DisplayPositionList();

            var numberOfWorkingDays = _numberOfWorkingDaysInAMonthData.GetLatestValue();
            if (numberOfWorkingDays != null)
            {
                NumUpDwnNumberOfWorkingDays.Value = numberOfWorkingDays.NumberOfDays;
            }
            else
            {
                NumUpDwnNumberOfWorkingDays.Value = 0;
            }
        }

        private void SetDGVPositionListFontAndColors()
        {
            this.DGVPositionList.BackgroundColor = Color.White;
            this.DGVPositionList.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVPositionList.RowHeadersVisible = false;
            this.DGVPositionList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVPositionList.AllowUserToResizeRows = false;
            this.DGVPositionList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVPositionList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVPositionList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVPositionList.MultiSelect = false;

            this.DGVPositionList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVPositionList.ColumnHeadersHeight = 30;
        }


        public void DisplayPositionList()
        {
            this.DGVPositionList.Rows.Clear();
            if (this.Positions != null)
            {
                this.DGVPositionList.ColumnCount = 5;

                this.DGVPositionList.Columns[0].Name = "PositionId";
                this.DGVPositionList.Columns[0].Visible = false;

                this.DGVPositionList.Columns[1].Name = "PositionTitle";
                this.DGVPositionList.Columns[1].HeaderText = "Title";

                this.DGVPositionList.Columns[2].Name = "DailyRate";
                this.DGVPositionList.Columns[2].HeaderText = "Daily rate";

                this.DGVPositionList.Columns[3].Name = "MonthlyRate";
                this.DGVPositionList.Columns[3].HeaderText = "Monthly rate";

                this.DGVPositionList.Columns[4].Name = "IsSingleEmployeeOnly";
                this.DGVPositionList.Columns[4].HeaderText = "Single employee";

                // Update button
                DataGridViewImageColumn btnUpdateLeaveTypeImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateLeaveTypeImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVPositionList.Columns.Add(btnUpdateLeaveTypeImg);

                // Delete button
                DataGridViewImageColumn btnDeleteLeaveTypeImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteLeaveTypeImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVPositionList.Columns.Add(btnDeleteLeaveTypeImg);

                foreach (var position in this.Positions)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVPositionList);

                    row.Cells[0].Value = position.Id;
                    row.Cells[1].Value = position.Title;
                    row.Cells[2].Value = position.DailyRate;
                    row.Cells[3].Value = position.MonthlyRate;
                    row.Cells[4].Value = position.IsSingleEmployee ? "Single" : "Multiple";
                    DGVPositionList.Rows.Add(row);
                }
            }
        }

        public void ResetForm()
        {
            this.TbxPositionTitle.Text = "";
            this.NumUpDwnMonthlyRate.Value = 0;
            this.NumUpDwnDailyRate.Value = 0;
            this.IsSaveNew = true;
            this.PositionToAddUpdate = null;
        }

        private void BtnCancelUpdate_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        public void DisplaySelectedPositionInForm()
        {
            if (this.PositionToAddUpdate != null)
            {
                this.TbxPositionTitle.Text = this.PositionToAddUpdate.Title;
                this.NumUpDwnMonthlyRate.Value = this.PositionToAddUpdate.MonthlyRate;
                this.NumUpDwnDailyRate.Value = this.PositionToAddUpdate.DailyRate;
            }
        }

        private void BtnSavePosition_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TbxPositionTitle.Text) || this.NumUpDwnDailyRate.Value <= 0)
            {
                MessageBox.Show("Kindly input all details.", "Save position", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.IsSaveNew == true)
            {
                if (this.Positions != null)
                {
                    var existingPositionWithTheSameName = Positions.Where(x => x.Title.ToLower() == this.TbxPositionTitle.Text.ToLower()).FirstOrDefault();

                    if (existingPositionWithTheSameName != null)
                    {
                        MessageBox.Show("Invalid position title, duplicate data", "Save position", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                this.PositionToAddUpdate = new EmployeePositionModel
                {
                    Title = this.TbxPositionTitle.Text,
                    DailyRate = this.NumUpDwnDailyRate.Value,
                    MonthlyRate = this.NumUpDwnMonthlyRate.Value,
                    IsSingleEmployee = this.CboxSingleEmployee.Checked
                };
            }
            else
            {
                if (this.PositionToAddUpdate != null)
                {
                    if (this.Positions != null)
                    {
                        var existingPositionWithTheSameName = Positions
                                                        .Where(x => 
                                                            x.Title.ToLower() == this.TbxPositionTitle.Text.ToLower() && 
                                                            x.Id != this.PositionToAddUpdate.Id)
                                                        .FirstOrDefault();

                        if (existingPositionWithTheSameName != null)
                        {
                            MessageBox.Show("Invalid position title, duplicate data", "Save position", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    this.PositionToAddUpdate.Title = this.TbxPositionTitle.Text;
                    this.PositionToAddUpdate.DailyRate = this.NumUpDwnDailyRate.Value;
                    this.PositionToAddUpdate.MonthlyRate = this.NumUpDwnMonthlyRate.Value;
                    this.PositionToAddUpdate.IsSingleEmployee = this.CboxSingleEmployee.Checked;
                }

                
            }

            OnPositionSaved(EventArgs.Empty);
        }


        public long SelectedPositionIdToDelete { get; set; }

        public event EventHandler DeletePosition;
        protected virtual void OnDeletePosition(EventArgs e)
        {
            DeletePosition?.Invoke(this, e);
        }

        private void DGVPositionList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Update button
            if ((e.ColumnIndex == 5) && e.RowIndex > -1)
            {
                if (DGVPositionList.CurrentRow != null)
                {
                    long positionId = long.Parse(DGVPositionList.CurrentRow.Cells[0].Value.ToString());
                    this.PositionToAddUpdate = this.Positions.Where(x => x.Id == positionId).FirstOrDefault();
                    this.IsSaveNew = false;
                    this.DisplaySelectedPositionInForm();
                }
            }


            // Delete button
            if ((e.ColumnIndex == 6) && e.RowIndex > -1)
            {
                if (DGVPositionList.CurrentRow != null)
                {
                    long positionId = long.Parse(DGVPositionList.CurrentRow.Cells[0].Value.ToString());
                    this.SelectedPositionIdToDelete = positionId;

                    OnDeletePosition(EventArgs.Empty);
                }
            }
        }


        public decimal NumberOfWorkingDays { get; set; }

        public event EventHandler UpdateNumberOfWorkingDays;
        protected virtual void OnUpdateNumberOfWorkingDays(EventArgs e)
        {
            UpdateNumberOfWorkingDays?.Invoke(this, e);
        }

        private void BtnUpdateNumberOfWorkingDaysInAMonth_Click(object sender, EventArgs e)
        {
            this.NumberOfWorkingDays = NumUpDwnNumberOfWorkingDays.Value;
            OnUpdateNumberOfWorkingDays(EventArgs.Empty);
        }

        private void NumUpDwnMonthlyRate_KeyUp(object sender, KeyEventArgs e)
        {
            var numberOfWorkingDays = _numberOfWorkingDaysInAMonthData.GetLatestValue();

            if (numberOfWorkingDays != null && numberOfWorkingDays.NumberOfDays > 0)
            {
                this.NumUpDwnDailyRate.Value = NumUpDwnMonthlyRate.Value / numberOfWorkingDays.NumberOfDays;
            }
        }
    }
}
