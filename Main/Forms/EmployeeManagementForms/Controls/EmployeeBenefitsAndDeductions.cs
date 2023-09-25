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
    public partial class EmployeeBenefitsAndDeductions : UserControl
    {
        public EmployeeBenefitsAndDeductions()
        {
            InitializeComponent();
        }

        private void EmployeeBenefitsAndDeductions_Load(object sender, EventArgs e)
        {
            this.DGVEmployeeBenefits.BackgroundColor = Color.White;
            this.DGVEmployeeBenefits.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVEmployeeBenefits.RowHeadersVisible = false;
            this.DGVEmployeeBenefits.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVEmployeeBenefits.AllowUserToResizeRows = false;
            this.DGVEmployeeBenefits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVEmployeeBenefits.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVEmployeeBenefits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVEmployeeBenefits.MultiSelect = false;
            this.DGVEmployeeBenefits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVEmployeeBenefits.ColumnHeadersHeight = 30;
            DisplayBenefitsInDGV();

            this.DGVSpecificEmployeeBenefits.BackgroundColor = Color.White;
            this.DGVSpecificEmployeeBenefits.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVSpecificEmployeeBenefits.RowHeadersVisible = false;
            this.DGVSpecificEmployeeBenefits.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVSpecificEmployeeBenefits.AllowUserToResizeRows = false;
            this.DGVSpecificEmployeeBenefits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVSpecificEmployeeBenefits.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVSpecificEmployeeBenefits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVSpecificEmployeeBenefits.MultiSelect = false;
            this.DGVSpecificEmployeeBenefits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVSpecificEmployeeBenefits.ColumnHeadersHeight = 30;
            DisplaySpecificEmployeeBenefitsInDGV();


            this.DGVEmployeeDeductions.BackgroundColor = Color.White;
            this.DGVEmployeeDeductions.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVEmployeeDeductions.RowHeadersVisible = false;
            this.DGVEmployeeDeductions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVEmployeeDeductions.AllowUserToResizeRows = false;
            this.DGVEmployeeDeductions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVEmployeeDeductions.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVEmployeeDeductions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVEmployeeDeductions.MultiSelect = false;
            this.DGVEmployeeDeductions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVEmployeeDeductions.ColumnHeadersHeight = 30;
            DisplayDeductionsInDGV();


            this.DGVSpecificEmployeeDeductions.BackgroundColor = Color.White;
            this.DGVSpecificEmployeeDeductions.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVSpecificEmployeeDeductions.RowHeadersVisible = false;
            this.DGVSpecificEmployeeDeductions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVSpecificEmployeeDeductions.AllowUserToResizeRows = false;
            this.DGVSpecificEmployeeDeductions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVSpecificEmployeeDeductions.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVSpecificEmployeeDeductions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVSpecificEmployeeDeductions.MultiSelect = false;
            this.DGVSpecificEmployeeDeductions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVSpecificEmployeeDeductions.ColumnHeadersHeight = 30;
            DisplaySpecificEmployeeDeductionsInDGV();

        }


        private List<EmployeeBenefitModel> benefits;

        public List<EmployeeBenefitModel> Benefits
        {
            get { return benefits; }
            set { benefits = value; }
        }


        private List<SpecificEmployeeBenefitModel> specificEmployeeBenefits;

        public List<SpecificEmployeeBenefitModel> SpecificEmployeeBenefits
        {
            get { return specificEmployeeBenefits; }
            set { specificEmployeeBenefits = value; }
        }


        private List<EmployeeDeductionModel> deductions;

        public List<EmployeeDeductionModel> Deductions
        {
            get { return deductions; }
            set { deductions = value; }
        }


        private List<SpecificEmployeeDeductionModel> specificEmployeeDeductions;

        public List<SpecificEmployeeDeductionModel> SpecificEmployeeDeductions
        {
            get { return specificEmployeeDeductions; }
            set { specificEmployeeDeductions = value; }
        }



        private EmployeeBenefitModel benefitToSave;

        public EmployeeBenefitModel BenefitToSave
        {
            get { return benefitToSave; }
            set { benefitToSave = value; }
        }


        private SpecificEmployeeBenefitModel specificEmployeeBenefitToSave;

        public SpecificEmployeeBenefitModel SpecificEmployeeBenefitToSave
        {
            get { return specificEmployeeBenefitToSave; }
            set { specificEmployeeBenefitToSave = value; }
        }


        private EmployeeDeductionModel deductionModel;

        public EmployeeDeductionModel DeductionToSave
        {
            get { return deductionModel; }
            set { deductionModel = value; }
        }


        private SpecificEmployeeDeductionModel specificEmployeeDeductionToSave;

        public SpecificEmployeeDeductionModel SpecificEmployeeDeductionToSave
        {
            get { return specificEmployeeDeductionToSave; }
            set { specificEmployeeDeductionToSave = value; }
        }


        public bool BenefitIsSaveNew { get; set; } = true;
        public bool SpecificBenefitIsSaveNew { get; set; } = true;
        public bool DeductionIsSaveNew { get; set; } = true;
        public bool SpecificDeductionIsSaveNew { get; set; } = true;

        public event EventHandler SaveBenefit;
        protected virtual void OnSaveBenefit(EventArgs e)
        {
            SaveBenefit?.Invoke(this, e);
        }

        public event EventHandler SaveSpecificEmployeeBenefit;
        protected virtual void OnSaveSpecificEmployeeBenefit(EventArgs e)
        {
            SaveSpecificEmployeeBenefit?.Invoke(this, e);
        }

        public event EventHandler SaveDeduction;
        protected virtual void OnSaveDeduction(EventArgs e)
        {
            SaveDeduction?.Invoke(this, e);
        }

        public event EventHandler SaveSpecificEmployeeDeduction;
        protected virtual void OnSaveSpecificEmployeeDeduction(EventArgs e)
        {
            SaveSpecificEmployeeDeduction?.Invoke(this, e);
        }


        public void ResetBenefitForm()
        {
            this.BenefitIsSaveNew = true;
            this.TbxBenefitTitle.Text = "";
            this.NumUpDwnBenefitAmount.Value = 0;
            BtnCancelBenefitUpdate.Visible = false;
        }

        public void ResetSpecificBenefitForm()
        {
            this.SpecificEmployeeBenefitToSave = null;
            this.SpecificBenefitIsSaveNew = true;
            this.TBoxEmployeeNumber.Text = "";
            this.TBoxBenefitTitle.Text = "";
            this.NumUpDwBenefitAmount.Value = 0;
            BtnCancelSpecificEmployeeBenefit.Visible = false;
        }

        public void ResetDeductionForm()
        {
            this.DeductionIsSaveNew = true;
            this.TBoxDeductionTitle.Text = "";
            this.NumUpDwnDeductionAmount.Value = 0;
            BtnCancelUpdateEmpDeduction.Visible = false;
        }

        public void ResetSpecificDeductionForm()
        {
            this.SpecificEmployeeDeductionToSave = null;
            this.SpecificDeductionIsSaveNew = true;
            this.TboxEmployeeNumberForDeduction.Text = "";
            this.TboxSpecificEmpDeductionTitle.Text = "";
            this.NumUpDwnSpecificEmployeeDeductionAmount.Value = 0;
            BtnCancelSpecificEmployeeDeduction.Visible = false;
        }

        private void BtnSaveBenefits_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TbxBenefitTitle.Text))
            {
                MessageBox.Show("Enter benefit title", "Save benefit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.NumUpDwnBenefitAmount.Value <= 0)
            {
                MessageBox.Show("Enter benefit amount", "Save benefit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.BenefitIsSaveNew == false && BenefitToSave != null)
            {
                if (this.Benefits != null)
                {
                    var existingBenefit = this.Benefits
                                                .Where(x => x.BenefitTitle.ToLower() == this.TbxBenefitTitle.Text.ToLower() && x.Id != BenefitToSave.Id)
                                                .FirstOrDefault();
                    if (existingBenefit != null)
                    {
                        MessageBox.Show("Duplicate benefit!", "Save benefit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                BenefitToSave.BenefitTitle = this.TbxBenefitTitle.Text;
                BenefitToSave.Amount = this.NumUpDwnBenefitAmount.Value;
            }
            else
            {
                if (this.Benefits != null)
                {
                    var existingBenefit = this.Benefits
                                                .Where(x => x.BenefitTitle.ToLower() == this.TbxBenefitTitle.Text.ToLower())
                                                .FirstOrDefault();
                    if (existingBenefit != null)
                    {
                        MessageBox.Show("Duplicate benefit!", "Save benefit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                BenefitToSave = new EmployeeBenefitModel
                {
                    BenefitTitle = this.TbxBenefitTitle.Text,
                    Amount = this.NumUpDwnBenefitAmount.Value
                };
            }

            OnSaveBenefit(EventArgs.Empty);
        }


        public void DisplayBenefitsInDGV()
        {
            this.DGVEmployeeBenefits.Rows.Clear();
            if (this.Benefits != null)
            {
                this.DGVEmployeeBenefits.ColumnCount = 3;

                this.DGVEmployeeBenefits.Columns[0].Name = "benefitId";
                this.DGVEmployeeBenefits.Columns[0].Visible = false;

                this.DGVEmployeeBenefits.Columns[1].Name = "BenefitTitle";
                this.DGVEmployeeBenefits.Columns[1].HeaderText = "Title";

                this.DGVEmployeeBenefits.Columns[2].Name = "BenefitAmount";
                this.DGVEmployeeBenefits.Columns[2].HeaderText = "Default amount";

                // Update button
                DataGridViewImageColumn btnUpdateLeaveTypeImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateLeaveTypeImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVEmployeeBenefits.Columns.Add(btnUpdateLeaveTypeImg);

                // Delete button
                DataGridViewImageColumn btnDeleteLeaveTypeImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteLeaveTypeImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVEmployeeBenefits.Columns.Add(btnDeleteLeaveTypeImg);

                foreach(var benefit in this.Benefits)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVEmployeeBenefits);

                    row.Cells[0].Value = benefit.Id;
                    row.Cells[1].Value = benefit.BenefitTitle;
                    row.Cells[2].Value = benefit.Amount;

                    DGVEmployeeBenefits.Rows.Add(row);
                }

            }
        }


        public void DisplaySpecificEmployeeBenefitsInDGV()
        {
            this.DGVSpecificEmployeeBenefits.Rows.Clear();
            if (this.SpecificEmployeeBenefits != null)
            {
                this.DGVSpecificEmployeeBenefits.ColumnCount = 6;

                this.DGVSpecificEmployeeBenefits.Columns[0].Name = "benefitId";
                this.DGVSpecificEmployeeBenefits.Columns[0].Visible = false;

                this.DGVSpecificEmployeeBenefits.Columns[1].Name = "BenefitTitle";
                this.DGVSpecificEmployeeBenefits.Columns[1].HeaderText = "Title";

                this.DGVSpecificEmployeeBenefits.Columns[2].Name = "BenefitAmount";
                this.DGVSpecificEmployeeBenefits.Columns[2].HeaderText = "Default amount";

                this.DGVSpecificEmployeeBenefits.Columns[3].Name = "EmployeeName";
                this.DGVSpecificEmployeeBenefits.Columns[3].HeaderText = "Employee Name";

                this.DGVSpecificEmployeeBenefits.Columns[4].Name = "IsPaid";
                this.DGVSpecificEmployeeBenefits.Columns[4].HeaderText = "Status";

                this.DGVSpecificEmployeeBenefits.Columns[5].Name = "PaymentDate";
                this.DGVSpecificEmployeeBenefits.Columns[5].HeaderText = "Date Paid";

                // Update button
                DataGridViewImageColumn btnUpdateLeaveTypeImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateLeaveTypeImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVSpecificEmployeeBenefits.Columns.Add(btnUpdateLeaveTypeImg);

                // Delete button
                DataGridViewImageColumn btnDeleteLeaveTypeImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteLeaveTypeImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVSpecificEmployeeBenefits.Columns.Add(btnDeleteLeaveTypeImg);

                foreach (var benefit in this.SpecificEmployeeBenefits)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVSpecificEmployeeBenefits);

                    row.Cells[0].Value = benefit.Id;
                    row.Cells[1].Value = benefit.BenefitTitle;
                    row.Cells[2].Value = benefit.Amount;
                    row.Cells[3].Value = benefit.EmployeeName;
                    row.Cells[4].Value = benefit.IsPaid ? "Paid" : "Pending";
                    row.Cells[5].Value = benefit.IsPaid ? benefit.PaymentDate.ToShortDateString() : "";

                    DGVSpecificEmployeeBenefits.Rows.Add(row);
                }

            }
        }


        public void DisplayDeductionsInDGV()
        {
            this.DGVEmployeeDeductions.Rows.Clear();
            if (this.Deductions != null)
            {
                this.DGVEmployeeDeductions.ColumnCount = 3;

                this.DGVEmployeeDeductions.Columns[0].Name = "deductionId";
                this.DGVEmployeeDeductions.Columns[0].Visible = false;

                this.DGVEmployeeDeductions.Columns[1].Name = "DeductionTitle";
                this.DGVEmployeeDeductions.Columns[1].HeaderText = "Title";

                this.DGVEmployeeDeductions.Columns[2].Name = "DeductionAmount";
                this.DGVEmployeeDeductions.Columns[2].HeaderText = "Default amount";

                // Update button
                DataGridViewImageColumn btnUpdateLeaveTypeImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateLeaveTypeImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVEmployeeDeductions.Columns.Add(btnUpdateLeaveTypeImg);

                // Delete button
                DataGridViewImageColumn btnDeleteLeaveTypeImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteLeaveTypeImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVEmployeeDeductions.Columns.Add(btnDeleteLeaveTypeImg);

                foreach (var deduction in this.Deductions)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVEmployeeDeductions);

                    row.Cells[0].Value = deduction.Id;
                    row.Cells[1].Value = deduction.DeductionTitle;
                    row.Cells[2].Value = deduction.Amount;

                    DGVEmployeeDeductions.Rows.Add(row);
                }

            }
        }

        public void DisplaySpecificEmployeeDeductionsInDGV()
        {
            this.DGVSpecificEmployeeDeductions.Rows.Clear();
            if (this.Deductions != null)
            {
                this.DGVSpecificEmployeeDeductions.ColumnCount = 6;

                this.DGVSpecificEmployeeDeductions.Columns[0].Name = "deductionId";
                this.DGVSpecificEmployeeDeductions.Columns[0].Visible = false;

                this.DGVSpecificEmployeeDeductions.Columns[1].Name = "DeductionTitle";
                this.DGVSpecificEmployeeDeductions.Columns[1].HeaderText = "Title";

                this.DGVSpecificEmployeeDeductions.Columns[2].Name = "DeductionAmount";
                this.DGVSpecificEmployeeDeductions.Columns[2].HeaderText = "Default amount";

                this.DGVSpecificEmployeeDeductions.Columns[3].Name = "EmployeeName";
                this.DGVSpecificEmployeeDeductions.Columns[3].HeaderText = "Employee Name";

                this.DGVSpecificEmployeeDeductions.Columns[4].Name = "IsDeducted";
                this.DGVSpecificEmployeeDeductions.Columns[4].HeaderText = "Status";

                this.DGVSpecificEmployeeDeductions.Columns[5].Name = "DateDeducted";
                this.DGVSpecificEmployeeDeductions.Columns[5].HeaderText = "Date Deducted";

                // Update button
                DataGridViewImageColumn btnUpdateLeaveTypeImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateLeaveTypeImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVSpecificEmployeeDeductions.Columns.Add(btnUpdateLeaveTypeImg);

                // Delete button
                DataGridViewImageColumn btnDeleteLeaveTypeImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteLeaveTypeImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVSpecificEmployeeDeductions.Columns.Add(btnDeleteLeaveTypeImg);

                foreach (var deduction in this.SpecificEmployeeDeductions)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVSpecificEmployeeDeductions);

                    row.Cells[0].Value = deduction.Id;
                    row.Cells[1].Value = deduction.DeductionTitle;
                    row.Cells[2].Value = deduction.Amount;
                    row.Cells[3].Value = deduction.EmployeeName;
                    row.Cells[4].Value = deduction.IsDeducted ? "Deducted" : "Pending";
                    row.Cells[5].Value = deduction.IsDeducted ? deduction.DeductedDate.ToShortDateString() : "";

                    DGVSpecificEmployeeDeductions.Rows.Add(row);
                }

            }
        }

        public void DisplaySelectedBenefit()
        {
            if (this.BenefitToSave != null)
            {
                BtnCancelBenefitUpdate.Visible = true;
                this.BenefitIsSaveNew = false;

                this.TbxBenefitTitle.Text = this.BenefitToSave.BenefitTitle;
                this.NumUpDwnBenefitAmount.Value = this.BenefitToSave.Amount;
            }
        }


        public event EventHandler BtnUpdateBenefitClicked;
        protected virtual void OnBtnUpdateBenefitClicked(EventArgs e)
        {
            BtnUpdateBenefitClicked?.Invoke(this, e);
        }

        public event EventHandler BtnDeleteBenefitClicked;
        protected virtual void OnBtnDeleteBenefitClicked(EventArgs e)
        {
            BtnDeleteBenefitClicked?.Invoke(this, e);
        }


        private long benefitIdToDeleteOrUpdate;

        public long BenefitIdToDeleteOrUpdate
        {
            get { return benefitIdToDeleteOrUpdate; }
            set { benefitIdToDeleteOrUpdate = value; }
        }


        private void DGVEmployeeBenefits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // update button
            if ((e.ColumnIndex == 3) && e.RowIndex > -1)
            {
                string benefitIdStr = DGVEmployeeBenefits.CurrentRow.Cells[0].Value.ToString();
                
                if (long.TryParse(benefitIdStr, out long benefitId))
                {
                    BenefitIdToDeleteOrUpdate = benefitId;
                    OnBtnUpdateBenefitClicked(EventArgs.Empty);
                }
            }

            // delete button
            if ((e.ColumnIndex == 4) && e.RowIndex > -1)
            {
                string benefitIdStr = DGVEmployeeBenefits.CurrentRow.Cells[0].Value.ToString();
                
                if (long.TryParse(benefitIdStr, out long benefitId))
                {
                    BenefitIdToDeleteOrUpdate = benefitId;
                    OnBtnDeleteBenefitClicked(EventArgs.Empty);
                }
            }
        }

        private void BtnCancelBenefitUpdate_Click(object sender, EventArgs e)
        {
            ResetBenefitForm();
        }

        private void BtnSaveEmpDeduction_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.TBoxDeductionTitle.Text))
            {
                MessageBox.Show("Enter deduction title", "Save deduction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.NumUpDwnDeductionAmount.Value <= 0)
            {
                MessageBox.Show("Enter deduction amount", "Save deduction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.DeductionIsSaveNew == false && DeductionToSave != null)
            {
                if (this.Deductions != null)
                {
                    var existingDeduction = this.Deductions
                                                .Where(x => x.DeductionTitle.ToLower() == this.TBoxDeductionTitle.Text.ToLower() && x.Id != DeductionToSave.Id)
                                                .FirstOrDefault();
                    if (existingDeduction != null)
                    {
                        MessageBox.Show("Duplicate deduction!", "Save deduction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                DeductionToSave.DeductionTitle = this.TBoxDeductionTitle.Text;
                DeductionToSave.Amount = this.NumUpDwnDeductionAmount.Value;
            }
            else
            {
                if (this.Deductions != null)
                {
                    var existingDeduction = this.Deductions
                                                .Where(x => x.DeductionTitle.ToLower() == this.TBoxDeductionTitle.Text.ToLower())
                                                .FirstOrDefault();
                    if (existingDeduction != null)
                    {
                        MessageBox.Show("Duplicate deduction!", "Save deduction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                DeductionToSave = new EmployeeDeductionModel
                {
                    DeductionTitle = this.TBoxDeductionTitle.Text,
                    Amount = this.NumUpDwnDeductionAmount.Value
                };
            }

            OnSaveDeduction(EventArgs.Empty);
        }

        private void BtnCancelUpdateEmpDeduction_Click(object sender, EventArgs e)
        {
            ResetDeductionForm();
        }

        public void DisplaySelectedDeduction()
        {
            if (this.DeductionToSave != null)
            {
                BtnCancelUpdateEmpDeduction.Visible = true;
                this.DeductionIsSaveNew = false;

                this.TBoxDeductionTitle.Text = this.DeductionToSave.DeductionTitle;
                this.NumUpDwnDeductionAmount.Value = this.DeductionToSave.Amount;
            }
        }


        public event EventHandler BtnUpdateDeductionClicked;
        protected virtual void OnBtnUpdateDeductionClicked(EventArgs e)
        {
            BtnUpdateDeductionClicked?.Invoke(this, e);
        }

        public event EventHandler BtnDeleteDeductionClicked;
        protected virtual void OnBtnDeleteDeductionClicked(EventArgs e)
        {
            BtnDeleteDeductionClicked?.Invoke(this, e);
        }

        private long deductionIdToDeleteOrUpdate;

        public long DeductionIdToDeleteOrUpdate
        {
            get { return deductionIdToDeleteOrUpdate; }
            set { deductionIdToDeleteOrUpdate = value; }
        }


        private void DGVEmployeeDeductions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // update button
            if ((e.ColumnIndex == 3) && e.RowIndex > -1)
            {
                string deductionIdStr = DGVEmployeeDeductions.CurrentRow.Cells[0].Value.ToString();

                if (long.TryParse(deductionIdStr, out long deductionId))
                {
                    DeductionIdToDeleteOrUpdate = deductionId;
                    OnBtnUpdateDeductionClicked(EventArgs.Empty);
                }
            }

            // delete button
            if ((e.ColumnIndex == 4) && e.RowIndex > -1)
            {
                string deductionIdStr = DGVEmployeeDeductions.CurrentRow.Cells[0].Value.ToString();

                if (long.TryParse(deductionIdStr, out long deductionId))
                {
                    DeductionIdToDeleteOrUpdate = deductionId;
                    OnBtnDeleteDeductionClicked(EventArgs.Empty);
                }
            }
        }

        private void BtnSaveSpecificEmployeeBenefit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBoxEmployeeNumber.Text))
            {
                MessageBox.Show("Enter employee number", "Save benefit for specific employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrWhiteSpace(TBoxBenefitTitle.Text))
            {
                MessageBox.Show("Enter benefit title", "Save benefit for specific employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.NumUpDwBenefitAmount.Value <= 0)
            {
                MessageBox.Show("Enter benefit amount", "Save benefit for specific employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.SpecificBenefitIsSaveNew == false && this.SpecificEmployeeBenefitToSave != null)
            {
                if (this.SpecificEmployeeBenefits != null)
                {
                    var existingBenefit = this.SpecificEmployeeBenefits
                                                .Where(x => x.BenefitTitle.ToLower() == TBoxBenefitTitle.Text.ToLower() && 
                                                        x.EmployeeNumber == TBoxEmployeeNumber.Text.ToLower() && 
                                                        x.Id != this.SpecificEmployeeBenefitToSave.Id && 
                                                        x.IsPaid == false)
                                                .FirstOrDefault();

                    if (existingBenefit != null)
                    {
                        MessageBox.Show("Duplicate benefit!", "Save benefit for specific employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                this.SpecificEmployeeBenefitToSave.BenefitTitle = TBoxBenefitTitle.Text;
                this.SpecificEmployeeBenefitToSave.Amount = this.NumUpDwBenefitAmount.Value;
            }
            else
            {
                if (this.SpecificEmployeeBenefits != null)
                {
                    var existingBenefit = this.SpecificEmployeeBenefits
                                                .Where(x => x.BenefitTitle.ToLower() == TBoxBenefitTitle.Text.ToLower() &&
                                                       x.EmployeeNumber == TBoxEmployeeNumber.Text.ToLower() &&
                                                       x.IsPaid == false)
                                                .FirstOrDefault();

                    if (existingBenefit != null)
                    {
                        MessageBox.Show("Duplicate benefit!", "Save benefit for specific employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                this.SpecificEmployeeBenefitToSave = new SpecificEmployeeBenefitModel
                {
                    EmployeeNumber = TBoxEmployeeNumber.Text,
                    BenefitTitle = TBoxBenefitTitle.Text,
                    Amount = this.NumUpDwBenefitAmount.Value
                };
            }

            OnSaveSpecificEmployeeBenefit(EventArgs.Empty);
        }

        private void BtnSaveSpecificEmployeeDeduction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TboxEmployeeNumberForDeduction.Text))
            {
                MessageBox.Show("Enter employee number", "Save specific employee deduction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(this.TboxSpecificEmpDeductionTitle.Text))
            {
                MessageBox.Show("Enter deduction title", "Save specific employee deduction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.NumUpDwnSpecificEmployeeDeductionAmount.Value <= 0)
            {
                MessageBox.Show("Enter deduction amount", "Save specific employee deduction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.SpecificDeductionIsSaveNew == false && this.SpecificEmployeeDeductionToSave != null)
            {
                if (this.SpecificEmployeeDeductions != null)
                {
                    var existingDeduction = this.SpecificEmployeeDeductions
                                                .Where(x => x.DeductionTitle.ToLower() == this.TboxSpecificEmpDeductionTitle.Text.ToLower() &&
                                                        x.Id != this.SpecificEmployeeDeductionToSave.Id &&
                                                        x.EmployeeNumber.ToLower() == TboxEmployeeNumberForDeduction.Text.ToLower() &&
                                                        x.IsDeducted == false)
                                                .FirstOrDefault();

                    if (existingDeduction != null)
                    {
                        MessageBox.Show("Duplicate deduction!", "Save specific employee deduction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                this.SpecificEmployeeDeductionToSave.DeductionTitle = this.TboxSpecificEmpDeductionTitle.Text;
                this.SpecificEmployeeDeductionToSave.Amount = this.NumUpDwnSpecificEmployeeDeductionAmount.Value;
            }
            else
            {
                if (this.SpecificEmployeeDeductions != null)
                {
                    var existingDeduction = this.SpecificEmployeeDeductions
                                                .Where(x => x.DeductionTitle.ToLower() == this.TboxSpecificEmpDeductionTitle.Text.ToLower() &&
                                                        x.EmployeeNumber.ToLower() == TboxEmployeeNumberForDeduction.Text.ToLower() &&
                                                        x.IsDeducted == false)
                                                .FirstOrDefault();

                    if (existingDeduction != null)
                    {
                        MessageBox.Show("Duplicate deduction!", "Save specific employee deduction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                this.SpecificEmployeeDeductionToSave = new SpecificEmployeeDeductionModel {
                    DeductionTitle = this.TboxSpecificEmpDeductionTitle.Text,
                    EmployeeNumber = this.TboxEmployeeNumberForDeduction.Text,
                    Amount = this.NumUpDwnSpecificEmployeeDeductionAmount.Value
                };
            }

            OnSaveSpecificEmployeeDeduction(EventArgs.Empty);
        }


        public void DisplaySelectedSpecificBenefit()
        {
            if (this.SpecificEmployeeBenefitToSave != null)
            {
                this.TBoxEmployeeNumber.Text = this.SpecificEmployeeBenefitToSave.EmployeeNumber;
                this.TBoxBenefitTitle.Text = this.SpecificEmployeeBenefitToSave.BenefitTitle;
                this.NumUpDwBenefitAmount.Value = this.SpecificEmployeeBenefitToSave.Amount;
                this.BtnCancelSpecificEmployeeBenefit.Visible = true;
            }
        }

        public void DisplaySelectedSpecificDeduction()
        {
            if (this.SpecificEmployeeDeductionToSave != null)
            {
                this.TboxEmployeeNumberForDeduction.Text = this.SpecificEmployeeDeductionToSave.EmployeeNumber;
                this.TboxSpecificEmpDeductionTitle.Text = this.SpecificEmployeeDeductionToSave.DeductionTitle;
                this.NumUpDwnSpecificEmployeeDeductionAmount.Value = this.SpecificEmployeeDeductionToSave.Amount;
                this.BtnCancelSpecificEmployeeDeduction.Visible = true;
            }
        }

        private void BtnCancelSpecificEmployeeBenefit_Click(object sender, EventArgs e)
        {
            this.ResetSpecificBenefitForm();
        }


        public event EventHandler BtnDeleteSpecificBenefitClicked;
        protected virtual void OnBtnDeleteSpecificBenefitClicked(EventArgs e)
        {
            BtnDeleteSpecificBenefitClicked?.Invoke(this, e);
        }

        public long SpecificEmpBenefitIdToDelete { get; set; }

        private void DGVSpecificEmployeeBenefits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // update button
            if ((e.ColumnIndex == 6) && e.RowIndex > -1)
            {
                string benefitIdStr = DGVSpecificEmployeeBenefits.CurrentRow.Cells[0].Value.ToString();

                long benefitId = long.Parse(benefitIdStr);
                this.SpecificEmployeeBenefitToSave = this.SpecificEmployeeBenefits.Where(x => x.Id == benefitId).FirstOrDefault();
                this.SpecificBenefitIsSaveNew = false;
                DisplaySelectedSpecificBenefit();
            }

            // delete button
            if ((e.ColumnIndex == 7) && e.RowIndex > -1)
            {
                string benefitIdStr = DGVSpecificEmployeeBenefits.CurrentRow.Cells[0].Value.ToString();

                if (long.TryParse(benefitIdStr, out long benefitId))
                {
                    SpecificEmpBenefitIdToDelete = benefitId;
                    OnBtnDeleteSpecificBenefitClicked(EventArgs.Empty);
                }
            }
        }



        private void BtnCancelSpecificEmployeeDeduction_Click(object sender, EventArgs e)
        {
            this.ResetSpecificDeductionForm();
        }



        public event EventHandler BtnDeleteSpecificDedutionClicked;
        protected virtual void OnBtnDeleteSpecificDedutionClicked(EventArgs e)
        {
            BtnDeleteSpecificDedutionClicked?.Invoke(this, e);
        }

        public long SpecificEmpDeductionIdToDelete { get; set; }

        private void DGVSpecificEmployeeDeductions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // update button
            if ((e.ColumnIndex == 6) && e.RowIndex > -1)
            {
                string deductionIdStr = DGVSpecificEmployeeDeductions.CurrentRow.Cells[0].Value.ToString();

                long deductionId = long.Parse(deductionIdStr);
                this.SpecificEmployeeDeductionToSave = this.SpecificEmployeeDeductions.Where(x => x.Id == deductionId).FirstOrDefault();
                this.SpecificDeductionIsSaveNew = false;
                DisplaySelectedSpecificDeduction();
            }

            // delete button
            if ((e.ColumnIndex == 7) && e.RowIndex > -1)
            {
                string deductionIdStr = DGVSpecificEmployeeDeductions.CurrentRow.Cells[0].Value.ToString();

                if (long.TryParse(deductionIdStr, out long deductionId))
                {
                    SpecificEmpDeductionIdToDelete = deductionId;
                    OnBtnDeleteSpecificDedutionClicked(EventArgs.Empty);
                }
            }
        }
    }
}
