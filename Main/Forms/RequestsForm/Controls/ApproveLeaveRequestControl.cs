using EntitiesShared;
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
using static EntitiesShared.StaticData;

namespace Main.Forms.RequestsForm.Controls
{
    public partial class ApproveLeaveRequestControl : UserControl
    {
        private readonly Sessions _sessions;
        public ApproveLeaveRequestControl(Sessions sessions)
        {
            InitializeComponent();
            _sessions = sessions;
        }

        private List<EmployeeLeaveModel> employeeLeaveForApproval;

        public List<EmployeeLeaveModel> EmployeeLeaveForApproval
        {
            get { return employeeLeaveForApproval; }
            set { employeeLeaveForApproval = value; }
        }

        public long SelectedLeaveIdForApproval { get; set; }
        public string EmployeeLeaveApprovalRemarks { get; set; }
        public string EmployeeNumber { get; set; }
        public StaticData.EmployeeRequestApprovalStatus EmployeeLeaveApprovalStatus { get; set; }

        private void EmployeeLeaveApproval(StaticData.EmployeeRequestApprovalStatus status)
        {
            if (string.IsNullOrEmpty(TboxAdminRemarks.Text))
            {
                MessageBox.Show("Your remarks is required", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (DGVEmployeeLeaveApproval.CurrentRow != null)
            {
                DialogResult res = MessageBox.Show($"Continue to {status}?", "Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    string remarks = TboxAdminRemarks.Text;

                    string employeeLeaveId = DGVEmployeeLeaveApproval.CurrentRow.Cells[0].Value.ToString();

                    this.EmployeeLeaveApprovalRemarks = TboxAdminRemarks.Text;
                    this.SelectedLeaveIdForApproval = long.Parse(employeeLeaveId);
                    this.EmployeeLeaveApprovalStatus = status;
                    this.EmployeeNumber = DGVEmployeeLeaveApproval.CurrentRow.Cells[7].Value.ToString();

                    OnEmployeeLeaveApproval(EventArgs.Empty);
                }
            }
        }

        public event EventHandler EmployeeLeaveApprovedOrDisapproved;
        protected virtual void OnEmployeeLeaveApproval(EventArgs e)
        {
            EmployeeLeaveApprovedOrDisapproved?.Invoke(this, e);
        }

        private void BtnApprovedEmpLeave_Click(object sender, EventArgs e)
        {
            this.EmployeeLeaveApproval(EmployeeRequestApprovalStatus.Approved);
        }

        private void BtnDisapprovedEmpLeave_Click(object sender, EventArgs e)
        {
            this.EmployeeLeaveApproval(EmployeeRequestApprovalStatus.Disapproved);
        }

        private void ApproveLeaveRequestControl_Load(object sender, EventArgs e)
        {
            SetDisplayList();
            DisplayEmployeeLeavesForApprovalInDGV();
        }

        private void SetDisplayList()
        {

            this.DGVEmployeeLeaveApproval.BackgroundColor = Color.White;
            this.DGVEmployeeLeaveApproval.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVEmployeeLeaveApproval.RowHeadersVisible = false;
            this.DGVEmployeeLeaveApproval.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVEmployeeLeaveApproval.AllowUserToResizeRows = false;
            this.DGVEmployeeLeaveApproval.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVEmployeeLeaveApproval.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVEmployeeLeaveApproval.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVEmployeeLeaveApproval.MultiSelect = false;

            this.DGVEmployeeLeaveApproval.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVEmployeeLeaveApproval.ColumnHeadersHeight = 30;
        }

        public void ClearTextBox()
        {
            this.TboxAdminRemarks.Text = "";
            this.TboxEmployeeLeaveRemarks.Text = "";
        }

        public void DisplayEmployeeLeavesForApprovalInDGV()
        {
            this.DGVEmployeeLeaveApproval.Rows.Clear();
            if (this.EmployeeLeaveForApproval != null)
            {
                this.DGVEmployeeLeaveApproval.ColumnCount = 8;

                this.DGVEmployeeLeaveApproval.Columns[0].Name = "EmployeeLeaveRecordId";
                this.DGVEmployeeLeaveApproval.Columns[0].Visible = false;

                this.DGVEmployeeLeaveApproval.Columns[1].Name = "LeaveType";
                this.DGVEmployeeLeaveApproval.Columns[1].HeaderText = "Leave type";

                this.DGVEmployeeLeaveApproval.Columns[2].Name = "DurationType";
                this.DGVEmployeeLeaveApproval.Columns[2].HeaderText = "DurationType";

                this.DGVEmployeeLeaveApproval.Columns[3].Name = "CreatedAt";
                this.DGVEmployeeLeaveApproval.Columns[3].HeaderText = "Created At";

                this.DGVEmployeeLeaveApproval.Columns[4].Name = "NumberDays";
                this.DGVEmployeeLeaveApproval.Columns[4].HeaderText = "Days";

                this.DGVEmployeeLeaveApproval.Columns[5].Name = "DateRange";
                this.DGVEmployeeLeaveApproval.Columns[5].HeaderText = "Date";

                this.DGVEmployeeLeaveApproval.Columns[6].Name = "ApprovalStatus";
                this.DGVEmployeeLeaveApproval.Columns[6].HeaderText = "Approval";

                this.DGVEmployeeLeaveApproval.Columns[7].Name = "EmployeeNumber";
                this.DGVEmployeeLeaveApproval.Columns[7].Visible = false;

                //// Delete button
                //DataGridViewImageColumn btnDeleteImg = new DataGridViewImageColumn();
                ////btnDeleteLeaveTypeImg.Name = "";
                //btnDeleteImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //btnDeleteImg.Image = Image.FromFile("./Resources/remove-24.png");
                //this.DGVEmployeeLeaveApproval.Columns.Add(btnDeleteImg);

                foreach (var record in this.EmployeeLeaveForApproval)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVEmployeeLeaveApproval);

                    row.Cells[0].Value = record.Id;
                    row.Cells[1].Value = record.LeaveType.LeaveType;
                    row.Cells[2].Value = record.DurationType;
                    row.Cells[3].Value = record.CreatedAt.ToShortDateString();
                    row.Cells[4].Value = record.NumberOfDays;
                    row.Cells[5].Value = $"{record.StartDate.ToString("MMM-dd")} to {record.EndDate.ToString("MMM-dd")}";
                    row.Cells[6].Value = record.ApprovalStatus.ToString();
                    row.Cells[7].Value = record.EmployeeNumber.ToString();

                    this.DGVEmployeeLeaveApproval.Rows.Add(row);
                }
            }

        }

        private void DGVEmployeeLeaveApproval_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (DGVEmployeeLeaveApproval.CurrentRow != null)
                {
                    string employeeLeaveId = DGVEmployeeLeaveApproval.CurrentRow.Cells[0].Value.ToString();
                    long selectedLeaveId = long.Parse(employeeLeaveId);
                    var employeeLeaveDetais = this.EmployeeLeaveForApproval.Where(x => x.Id == selectedLeaveId).FirstOrDefault();

                    if (employeeLeaveDetais != null)
                    {
                        this.TboxEmployeeLeaveRemarks.Text = employeeLeaveDetais.Reason;
                    }
                }
            }
        }
    }
}
