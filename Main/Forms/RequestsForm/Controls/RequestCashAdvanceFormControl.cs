using EntitiesShared;
using EntitiesShared.EmployeeManagement;
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
    public partial class RequestCashAdvanceFormControl : UserControl
    {
        private readonly Sessions _sessions;

        public RequestCashAdvanceFormControl(Sessions sessions)
        {
            InitializeComponent();
            _sessions = sessions;
        }

        private void RequestCashAdvanceFormControl_Load(object sender, EventArgs e)
        {
            SetDGVPreviousRequestsFontAndColors();

            if (_sessions.CurrentLoggedInUser.Role.Role.RoleKey == EntitiesShared.StaticData.UserRole.normal)
            {
                this.TboxEmployeeNumber.Enabled = false;
                this.BtnSearchEmployee.Enabled = false;
            }

            TboxEmployeeNumber.Text = CurrentEmployeeNumber;
            DisplayPreviousCashAdvanceRequests();
            DisplayEmployeeDetails();
        }

        private void SetDGVPreviousRequestsFontAndColors()
        {
            this.DGVPreviousRequests.BackgroundColor = Color.White;
            this.DGVPreviousRequests.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVPreviousRequests.RowHeadersVisible = false;
            this.DGVPreviousRequests.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVPreviousRequests.AllowUserToResizeRows = false;
            this.DGVPreviousRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVPreviousRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVPreviousRequests.MultiSelect = false;

            this.DGVPreviousRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVPreviousRequests.ColumnHeadersHeight = 30;
        }


        private List<EmployeeCashAdvanceRequestModel> _previousCashAdvanceRequests;

        public List<EmployeeCashAdvanceRequestModel> PreviousCashAdvanceRequests
        {
            get { return _previousCashAdvanceRequests; }
            set { _previousCashAdvanceRequests = value; }
        }


        private EmployeeCashAdvanceRequestModel _cashAdvanceRequestToAddUpdate;

        public EmployeeCashAdvanceRequestModel CashAdvanceRequestToAddUpdate
        {
            get { return _cashAdvanceRequestToAddUpdate; }
            set { _cashAdvanceRequestToAddUpdate = value; }
        }

        public bool IsSaveNew { get; set; } = true;

        public event EventHandler CashAdvanceSave;
        protected virtual void OnCashAdvanceSave(EventArgs e)
        {
            CashAdvanceSave?.Invoke(this, e);
        }


        private EmployeeModel _currentEmployeeDetails;

        public EmployeeModel CurrentEmployeeDetails
        {
            get { return _currentEmployeeDetails; }
            set { _currentEmployeeDetails = value; }
        }


        public void DisplayEmployeeDetails()
        {
            if (this.CurrentEmployeeDetails != null)
            {
                this.LblEmployeeName.Text = this.CurrentEmployeeDetails.FullName;
            }
        }


        public event EventHandler EnterEmployeeNumber;
        protected virtual void OnEnterEmployeeNumber(EventArgs e)
        {
            EnterEmployeeNumber?.Invoke(this, e);
        }

        private string _currentEmployeeNumber;
        public string CurrentEmployeeNumber
        {
            get { return _currentEmployeeNumber; }
            set {  _currentEmployeeNumber = value;}
        }

        private void BtnSearchEmployee_Click(object sender, EventArgs e)
        {
            CurrentEmployeeNumber = TboxEmployeeNumber.Text;
            OnEnterEmployeeNumber(EventArgs.Empty);
        }

        public void ResetForm()
        {
            //this.CurrentEmployeeNumber = "";
            //this.TboxEmployeeNumber.Text = "";
            this.NumUDwnAmount.Value = 0;
            this.DPicDateNeed.Value = DateTime.Now;
            this.TboxEmployeeRemarks.Text = "";
            this.IsSaveNew = true;
            this.TboxAdminRemarks.Text = "";
        }


        private void BtnSubmitCashAdvanceRequest_Click(object sender, EventArgs e)
        {
            string employeeNumber = this.TboxEmployeeNumber.Text;
            decimal amount = this.NumUDwnAmount.Value;
            DateTime dateNeed = this.DPicDateNeed.Value;
            string remarks = this.TboxEmployeeRemarks.Text;

            if (string.IsNullOrEmpty(employeeNumber))
            {
                MessageBox.Show("Please input employee number", "Cash advance request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (amount <= 0)
            {
                MessageBox.Show("Please input employee number", "Cash advance request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(remarks))
            {
                MessageBox.Show("Please input remarks", "Cash advance request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dateNeed.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Invalid date", "Cash advance request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.IsSaveNew == true)
            {
                if (this.PreviousCashAdvanceRequests != null)
                {
                    var existingRequestWithTheSameDate = this.PreviousCashAdvanceRequests
                                                            .Where(x => x.NeedOnDate.Date == dateNeed.Date).FirstOrDefault();

                    if (existingRequestWithTheSameDate != null)
                    {
                        MessageBox.Show("Existing request with the same date.", "Cash advance request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                this.CashAdvanceRequestToAddUpdate = new EmployeeCashAdvanceRequestModel
                {
                    EmployeeNumber = employeeNumber,
                    Amount = amount,
                    NeedOnDate = dateNeed,
                    EmployeeRemarks = remarks
                };
            }
            else
            {
                if (this.CashAdvanceRequestToAddUpdate != null)
                {
                    if (this.PreviousCashAdvanceRequests != null)
                    {
                        var existingRequestWithTheSameDate = this.PreviousCashAdvanceRequests
                                                                .Where(x => x.NeedOnDate.Date == dateNeed.Date && 
                                                                        x.Id != this.CashAdvanceRequestToAddUpdate.Id)
                                                                .FirstOrDefault();

                        if (existingRequestWithTheSameDate != null)
                        {
                            MessageBox.Show("Existing request with the same date.", "Cash advance request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    this.CashAdvanceRequestToAddUpdate.EmployeeNumber = employeeNumber;
                    this.CashAdvanceRequestToAddUpdate.Amount = amount;
                    this.CashAdvanceRequestToAddUpdate.NeedOnDate = dateNeed;
                    this.CashAdvanceRequestToAddUpdate.EmployeeRemarks = remarks;
                }
            }

            OnCashAdvanceSave(EventArgs.Empty);
        }

        public void DisplayPreviousCashAdvanceRequests()
        {
            this.DGVPreviousRequests.Rows.Clear();
            if (this.PreviousCashAdvanceRequests != null)
            {
                this.DGVPreviousRequests.ColumnCount = 6;

                this.DGVPreviousRequests.Columns[0].Name = "RequestId";
                this.DGVPreviousRequests.Columns[0].HeaderText = "RequestId";
                this.DGVPreviousRequests.Columns[0].Visible = false;

                this.DGVPreviousRequests.Columns[1].Name = "Amount";
                this.DGVPreviousRequests.Columns[1].HeaderText = "Amount";

                this.DGVPreviousRequests.Columns[2].Name = "DateNeed";
                this.DGVPreviousRequests.Columns[2].HeaderText = "Date Need";

                this.DGVPreviousRequests.Columns[3].Name = "Remarks";
                this.DGVPreviousRequests.Columns[3].HeaderText = "Remarks";

                this.DGVPreviousRequests.Columns[4].Name = "Status";
                this.DGVPreviousRequests.Columns[4].HeaderText = "Status";

                this.DGVPreviousRequests.Columns[5].Name = "DateRequested";
                this.DGVPreviousRequests.Columns[5].HeaderText = "Date Requested";

                // Update button
                DataGridViewImageColumn btnUpdateLeaveTypeImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateLeaveTypeImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVPreviousRequests.Columns.Add(btnUpdateLeaveTypeImg);

                // Delete button
                DataGridViewImageColumn btnDeleteLeaveTypeImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteLeaveTypeImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVPreviousRequests.Columns.Add(btnDeleteLeaveTypeImg);

                foreach (var request in this.PreviousCashAdvanceRequests)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVPreviousRequests);

                    row.Cells[0].Value = request.Id;
                    row.Cells[1].Value = request.Amount;
                    row.Cells[2].Value = request.NeedOnDate.ToShortDateString();
                    row.Cells[3].Value = request.EmployeeRemarks;
                    row.Cells[4].Value = request.ApprovalStatus.ToString();
                    row.Cells[5].Value = request.CreatedAt.ToShortDateString();
                    DGVPreviousRequests.Rows.Add(row);
                }
            }
        }

        private void BtnCancelCashAdvanceRequest_Click(object sender, EventArgs e)
        {
            this.ResetForm();
            this.CashAdvanceRequestToAddUpdate = null;
        }

        public void DisplaySelectedRequest()
        {
            if (this.CashAdvanceRequestToAddUpdate != null)
            {
                this.CurrentEmployeeNumber = this.CashAdvanceRequestToAddUpdate.EmployeeNumber;
                this.NumUDwnAmount.Value = this.CashAdvanceRequestToAddUpdate.Amount;
                this.DPicDateNeed.Value = this.CashAdvanceRequestToAddUpdate.NeedOnDate;
                this.TboxEmployeeRemarks.Text = this.CashAdvanceRequestToAddUpdate.EmployeeRemarks;
            }
        }

        public long SelectedRequestIdToDelete { get; set; }

        public event EventHandler CancelRequest;
        protected virtual void OnCancelRequest(EventArgs e)
        {
            CancelRequest?.Invoke(this, e);
        }

        private void DGVPreviousRequests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && DGVPreviousRequests.CurrentRow != null)
            {
                long requestId = long.Parse(DGVPreviousRequests.CurrentRow.Cells[0].Value.ToString());
                var details = this.PreviousCashAdvanceRequests.Where(x => x.Id == requestId).FirstOrDefault();

                if (details != null)
                {
                    this.TboxAdminRemarks.Text = details.EmployerRemarks;
                    this.TboxCashReleaseDate.Text = details.CashReleaseDate.ToShortDateString();
                }
            }

                // update button
            if ((e.ColumnIndex == 6) && e.RowIndex > -1)
            {
                if (DGVPreviousRequests.CurrentRow != null)
                {
                    long requestId = long.Parse(DGVPreviousRequests.CurrentRow.Cells[0].Value.ToString());
                    this.CashAdvanceRequestToAddUpdate = this.PreviousCashAdvanceRequests.Where(x => x.Id == requestId).FirstOrDefault();

                    if (this.CashAdvanceRequestToAddUpdate != null &&
                             this.CashAdvanceRequestToAddUpdate.ApprovalStatus != StaticData.EmployeeRequestApprovalStatus.Pending)
                    {
                        MessageBox.Show($"Not allowed to update this request, the status is already in {this.CashAdvanceRequestToAddUpdate.ApprovalStatus}",
                            "Update request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    this.IsSaveNew = false;
                    this.DisplaySelectedRequest();
                }
            }

            // cancel button
            if ((e.ColumnIndex == 7) && e.RowIndex > -1)
            {
                if (DGVPreviousRequests.CurrentRow != null)
                {
                    long requestId = long.Parse(DGVPreviousRequests.CurrentRow.Cells[0].Value.ToString());
                    this.CashAdvanceRequestToAddUpdate = this.PreviousCashAdvanceRequests.Where(x => x.Id == requestId).FirstOrDefault();

                    if (_sessions.CurrentLoggedInUser.Role.Role.RoleKey == EntitiesShared.StaticData.UserRole.normal && 
                        this.CashAdvanceRequestToAddUpdate != null &&
                        this.CashAdvanceRequestToAddUpdate.ApprovalStatus != StaticData.EmployeeRequestApprovalStatus.Pending)
                    {
                        MessageBox.Show($"Not allowed to cancel this request, the status is already in {this.CashAdvanceRequestToAddUpdate.ApprovalStatus}",
                            "Cancel request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    SelectedRequestIdToDelete = requestId;

                    OnCancelRequest(EventArgs.Empty);
                }
            }
        }

    }
}
