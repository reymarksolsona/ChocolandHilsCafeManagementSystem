using EntitiesShared;
using EntitiesShared.PayrollManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.RequestsForm.Controls
{
    public partial class CashAdvanceForApprovalControl : UserControl
    {
        private readonly Sessions _sessions;

        public CashAdvanceForApprovalControl(Sessions sessions)
        {
            InitializeComponent();
            _sessions = sessions;
        }

        private void CashAdvanceForApprovalControl_Load(object sender, EventArgs e)
        {
            SetDGVRequestsFontAndColors();
            DisplayCashAdvanceRequests();

            if (_sessions.CurrentLoggedInUser.Role.Role.RoleKey == EntitiesShared.StaticData.UserRole.normal)
            {
                this.BtnApproved.Enabled = false;
                this.BtnDisapproved.Enabled = false;
            }
        }

        private List<EmployeeCashAdvanceRequestModel> _requests;

        public List<EmployeeCashAdvanceRequestModel> Requests
        {
            get { return _requests; }
            set { _requests = value; }
        }

        private void SetDGVRequestsFontAndColors()
        {
            this.DGVRequests.BackgroundColor = Color.White;
            this.DGVRequests.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVRequests.RowHeadersVisible = false;
            this.DGVRequests.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVRequests.AllowUserToResizeRows = false;
            this.DGVRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVRequests.MultiSelect = false;

            this.DGVRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVRequests.ColumnHeadersHeight = 30;
        }


        public void DisplayCashAdvanceRequests()
        {
            this.DGVRequests.Rows.Clear();
            if (this.Requests != null)
            {
                this.DGVRequests.ColumnCount = 6;

                this.DGVRequests.Columns[0].Name = "RequestId";
                this.DGVRequests.Columns[0].HeaderText = "RequestId";
                this.DGVRequests.Columns[0].Visible = false;

                this.DGVRequests.Columns[1].Name = "Amount";
                this.DGVRequests.Columns[1].HeaderText = "Amount";

                this.DGVRequests.Columns[2].Name = "DateNeed";
                this.DGVRequests.Columns[2].HeaderText = "Date Need";

                this.DGVRequests.Columns[3].Name = "Status";
                this.DGVRequests.Columns[3].HeaderText = "Status";

                this.DGVRequests.Columns[4].Name = "DateRequested";
                this.DGVRequests.Columns[4].HeaderText = "Date Requested";

                this.DGVRequests.Columns[5].Name = "EmployeeName";
                this.DGVRequests.Columns[5].HeaderText = "Employee";

                foreach (var request in this.Requests)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVRequests);

                    row.Cells[0].Value = request.Id;
                    row.Cells[1].Value = request.Amount;
                    row.Cells[2].Value = request.NeedOnDate.ToShortDateString();
                    row.Cells[3].Value = request.ApprovalStatus.ToString();
                    row.Cells[4].Value = request.CreatedAt.ToShortDateString();
                    row.Cells[5].Value = request.Employee.FullName;
                    DGVRequests.Rows.Add(row);
                }
            }
        }

        public long SelectedRequestId { get; set; }

        private void DGVRequests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (DGVRequests.CurrentRow != null)
                {
                    long requestId = long.Parse(DGVRequests.CurrentRow.Cells[0].Value.ToString());
                    this.SelectedRequestId = requestId;

                    var requestDetails = this.Requests.Where(x => x.Id == requestId).FirstOrDefault(); ;

                    if (requestDetails != null)
                    {
                        this.LblEmployeeName.Text = requestDetails.Employee.FullName;
                        this.TboxEmployeeNumber.Text = requestDetails.EmployeeNumber;
                        this.NumUDwnAmount.Value = requestDetails.Amount;
                        this.DPicDateNeed.Value = requestDetails.NeedOnDate;
                        this.TboxEmployeeRemarks.Text = requestDetails.EmployeeRemarks;
                    }
                }
            }
        }


        public StaticData.EmployeeRequestApprovalStatus ApprovalStatus { get; set; }
        public string AdminRemarks { get; set; }
        public DateTime CashReleaseDate { get; set; }


        public event EventHandler RequestApproval;
        protected virtual void OnRequestApproval(EventArgs e)
        {
            RequestApproval?.Invoke(this, e);
        }

        private void Approval(StaticData.EmployeeRequestApprovalStatus status)
        {
            if (string.IsNullOrEmpty(this.TboxAdminRemarks.Text))
            {
                MessageBox.Show("Please input remarks", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.ApprovalStatus = status;
            this.AdminRemarks = this.TboxAdminRemarks.Text;
            this.CashReleaseDate = this.DPicCashReleaseDate.Value;

            OnRequestApproval(EventArgs.Empty);
        }

        private void BtnApproved_Click(object sender, EventArgs e)
        {
            this.Approval(StaticData.EmployeeRequestApprovalStatus.Approved);
        }

        private void BtnDisapproved_Click(object sender, EventArgs e)
        {
            this.Approval(StaticData.EmployeeRequestApprovalStatus.Disapproved);
        }
    }
}
