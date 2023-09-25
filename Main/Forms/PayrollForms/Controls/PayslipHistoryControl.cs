using EntitiesShared.PayrollManagement;
using Shared.CustomModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.PayrollForms.Controls
{
    public partial class PayslipHistoryControl : UserControl
    {
        public PayslipHistoryControl()
        {
            InitializeComponent();
        }

        private List<DateTime> payslipDateList;

        public List<DateTime> PayslipDateList
        {
            get { return payslipDateList; }
            set { payslipDateList = value; }
        }

        private void PayslipHistoryControl_Load(object sender, EventArgs e)
        {
            DisplayPayslipPaydateList();

            this.DGVEmployeeList.BackgroundColor = Color.White;
            this.DGVEmployeeList.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVEmployeeList.RowHeadersVisible = false;
            this.DGVEmployeeList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVEmployeeList.AllowUserToResizeRows = false;
            this.DGVEmployeeList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVEmployeeList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVEmployeeList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVEmployeeList.MultiSelect = false;
            this.DGVEmployeeList.ReadOnly = false;
            this.DGVEmployeeList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVEmployeeList.ColumnHeadersHeight = 30;
        }

        public void DisplayPayslipPaydateList()
        {
            this.CBoxPayslipDates.Items.Clear();
            // Work shifts load in combo box
            if (this.PayslipDateList != null)
            {
                ComboboxItem item;
                foreach (var paydate in this.PayslipDateList)
                {
                    item = new ComboboxItem();
                    item.Text = paydate.ToShortDateString();
                    item.Value = paydate;
                    this.CBoxPayslipDates.Items.Add(item);
                }
            }
        }

        public DateTime SelectedPayslipPayDate { get; set; }

        public event EventHandler RetrieveEmployeePayslip;
        protected virtual void OnRetrieveEmployeePayslip(EventArgs e)
        {
            RetrieveEmployeePayslip?.Invoke(this, e);
        }

        private void BtnGenerateEmployeePayslip_Click(object sender, EventArgs e)
        {
            var selectedPaydate = this.CBoxPayslipDates.SelectedItem as ComboboxItem;
            if (selectedPaydate != null)
            {
                SelectedPayslipPayDate = DateTime.Parse(selectedPaydate.Value.ToString());
                OnRetrieveEmployeePayslip(EventArgs.Empty);
            }
        }


        private List<EmployeePayslipModel> employeePayslipsByPaydate;

        public List<EmployeePayslipModel> EmployeePayslipsByPaydate
        {
            get { return employeePayslipsByPaydate; }
            set { employeePayslipsByPaydate = value; }
        }


        public void DisplayEmployeesInDGV()
        {
            this.DGVEmployeeList.Rows.Clear();
            if (this.EmployeePayslipsByPaydate != null)
            {
                this.DGVEmployeeList.ColumnCount = 2;

                this.DGVEmployeeList.Columns[0].Name = "EmployeeNumber";
                this.DGVEmployeeList.Columns[0].HeaderText = "Employee Number";

                this.DGVEmployeeList.Columns[1].Name = "FullName";
                this.DGVEmployeeList.Columns[1].HeaderText = "Full name";


                foreach (var emp in this.EmployeePayslipsByPaydate)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVEmployeeList);

                    row.Cells[0].Value = emp.EmployeeNumber;
                    row.Cells[1].Value = emp.Employee.FullName;

                    row.Tag = emp;

                    DGVEmployeeList.Rows.Add(row);
                }

            }
        }



        private void DGVEmployeeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (DGVEmployeeList.CurrentRow != null)
                {

                    var selectedEmployeeNumberToViewPayslip = DGVEmployeeList.CurrentRow.Cells[0].Value.ToString();

                    if (this.EmployeePayslipsByPaydate != null)
                    {
                        var selectedEmployeePayslipDetails = this.EmployeePayslipsByPaydate.Where(x => x.EmployeeNumber == selectedEmployeeNumberToViewPayslip).FirstOrDefault();
                        DisplayEmployeePayslip(selectedEmployeePayslipDetails);
                    }

                }
            }
        }


        public void DisplayEmployeePayslip(EmployeePayslipModel payslip)
        {
            ClearPayslipContainer();
            var payslipItemControlObj = new PayslipItemControl { Employee = payslip.Employee, Payslip = payslip };
            payslipItemControlObj.Location = new Point(this.PanelPayslipDetailsContainer.Width / 2 - payslipItemControlObj.Size.Width / 2, this.PanelPayslipDetailsContainer.Height / 2 - payslipItemControlObj.Size.Height / 2);
            payslipItemControlObj.Anchor = AnchorStyles.None;
            this.PanelPayslipDetailsContainer.Controls.Add(payslipItemControlObj);
        }

        public void ClearPayslipContainer()
        {
            this.PanelPayslipDetailsContainer.Controls.Clear();
        }


        public event EventHandler CancelAllEmployeePayslip;
        protected virtual void OnCancelAllEmployeePayslip(EventArgs e)
        {
            CancelAllEmployeePayslip?.Invoke(this, e);
        }

        private void BtnCancelAllEmployeePayslip_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure, you want to cancel all payslips generated?", "Cancel confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                var selectedPaydate = this.CBoxPayslipDates.SelectedItem as ComboboxItem;
                if (selectedPaydate != null)
                {
                    SelectedPayslipPayDate = DateTime.Parse(selectedPaydate.Value.ToString());
                    OnCancelAllEmployeePayslip(EventArgs.Empty);
                }
            }
        }


        public string SelectedEmployeeNumberToCancel { get; set; }

        public event EventHandler CancelSelectedEmployeePayslip;
        protected virtual void OnCancelSelectedEmployeePayslip(EventArgs e)
        {
            CancelSelectedEmployeePayslip?.Invoke(this, e);
        }

        private void BtnCancelSelectedEmployeePayslip_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure, you want to cancel all payslips generated?", "Cancel confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                var selectedPaydate = this.CBoxPayslipDates.SelectedItem as ComboboxItem;
                if (selectedPaydate != null && DGVEmployeeList.CurrentRow != null)
                {
                    SelectedPayslipPayDate = DateTime.Parse(selectedPaydate.Value.ToString());
                    SelectedEmployeeNumberToCancel = DGVEmployeeList.CurrentRow.Cells[0].Value.ToString();

                    OnCancelSelectedEmployeePayslip(EventArgs.Empty);
                }
            }
            
        }


        public string SelectedEmployeeNumberToGeneratePayslipPDF { get; set; }

        public event EventHandler GeneratePayslipPDFForSelectedEmployee;
        protected virtual void OnGeneratePayslipPDFForSelectedEmployee(EventArgs e)
        {
            GeneratePayslipPDFForSelectedEmployee?.Invoke(this, e);
        }
        private void BtnGeneratePayslipPDF_Click(object sender, EventArgs e)
        {
            var selectedPaydate = this.CBoxPayslipDates.SelectedItem as ComboboxItem;
            if (selectedPaydate != null && DGVEmployeeList.CurrentRow != null)
            {
                SelectedPayslipPayDate = DateTime.Parse(selectedPaydate.Value.ToString());
                SelectedEmployeeNumberToGeneratePayslipPDF = DGVEmployeeList.CurrentRow.Cells[0].Value.ToString();

                OnGeneratePayslipPDFForSelectedEmployee(EventArgs.Empty);
            }
        }


        public event EventHandler GeneratePayslipPDFForAllEmployees;
        protected virtual void OnGeneratePayslipPDFForAllEmployees(EventArgs e)
        {
            GeneratePayslipPDFForAllEmployees?.Invoke(this, e);
        }
        private void BtnGeneratePayslipPDFAll_Click(object sender, EventArgs e)
        {
            OnGeneratePayslipPDFForAllEmployees(EventArgs.Empty);
        }
    }
}
