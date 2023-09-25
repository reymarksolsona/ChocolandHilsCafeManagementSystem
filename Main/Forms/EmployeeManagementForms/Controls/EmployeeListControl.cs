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
    public partial class EmployeeListControl : UserControl
    {
        public EmployeeListControl()
        {
            InitializeComponent();
        }


        private void EmployeeListControl_Load(object sender, EventArgs e)
        {
            SetDGVEmployeesFontAndColors();
            DisplayEmployeeList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string selectedEmployeeNumber;

        public string SelectedEmployeeNumber
        {
            get { return selectedEmployeeNumber; }
            set
            {
                selectedEmployeeNumber = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(SelectedEmployeeNumber));
                }
            }
        }

        public event EventHandler SearchStringEnter;
        public event EventHandler ReloadEmployeeList;

        protected virtual void OnSearchStringEnter(EventArgs e)
        {
            SearchStringEnter?.Invoke(this, e);
        }

        protected virtual void OnReloadEmployeeList(EventArgs e)
        {
            ReloadEmployeeList?.Invoke(this, e);
        }

        private SearchEmployeeParameters searchEmployeeParameters = new SearchEmployeeParameters();

        public SearchEmployeeParameters SearchEmployeeParameters
        {
            get { return searchEmployeeParameters; }
            set { searchEmployeeParameters = value; }
        }



        private List<EmployeeModel> employees;

        public List<EmployeeModel> Employees
        {
            get { return employees; }
            set { employees = value; }
        }


        public void DisplayEmployeeList()
        {
            if (Employees != null)
            {
                this.DGVEmployeeList.Rows.Clear();
                this.DGVEmployeeList.ColumnCount = 11;

                this.DGVEmployeeList.Columns[0].Name = "EmployeeNumber";
                this.DGVEmployeeList.Columns[0].HeaderText = "Employee #";
                this.DGVEmployeeList.Columns[0].Visible = true;

                this.DGVEmployeeList.Columns[1].Name = "Fullname";
                this.DGVEmployeeList.Columns[1].HeaderText = "Fullname";

                this.DGVEmployeeList.Columns[2].Name = "EmpAddress";
                this.DGVEmployeeList.Columns[2].HeaderText = "Address";

                this.DGVEmployeeList.Columns[3].Name = "DateOfBirth";
                this.DGVEmployeeList.Columns[3].HeaderText = "Date of birth";

                this.DGVEmployeeList.Columns[4].Name = "MobileNumber";
                this.DGVEmployeeList.Columns[4].HeaderText = "Mobile #";

                this.DGVEmployeeList.Columns[5].Name = "EmailAddress";
                this.DGVEmployeeList.Columns[5].HeaderText = "Email";

                this.DGVEmployeeList.Columns[6].Name = "BranchAssign";
                this.DGVEmployeeList.Columns[6].HeaderText = "Branch Assign";

                this.DGVEmployeeList.Columns[7].Name = "DateHire";
                this.DGVEmployeeList.Columns[7].HeaderText = "Date hire";

                this.DGVEmployeeList.Columns[8].Name = "Shift";
                this.DGVEmployeeList.Columns[8].HeaderText = "Shift";

                this.DGVEmployeeList.Columns[9].Name = "PositionName";
                this.DGVEmployeeList.Columns[9].HeaderText = "Position";

                this.DGVEmployeeList.Columns[10].Name = "Status";
                this.DGVEmployeeList.Columns[10].HeaderText = "Status";


                DataGridViewImageColumn btnViewDetailsImg = new DataGridViewImageColumn();
                btnViewDetailsImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnViewDetailsImg.Image = Image.FromFile("./Resources/view-details-24.png");
                this.DGVEmployeeList.Columns.Add(btnViewDetailsImg);


                foreach (var employee in Employees)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVEmployeeList);

                    row.Cells[0].Value = employee.EmployeeNumber;
                    row.Cells[1].Value = $" {employee.LastName.ToUpper()} {employee.FirstName}, {employee.MiddleName}";
                    row.Cells[2].Value = employee.Address;
                    row.Cells[3].Value = employee.BirthDate.ToShortDateString();
                    row.Cells[4].Value = employee.MobileNumber;
                    row.Cells[5].Value = employee.EmailAddress;
                    row.Cells[6].Value = (employee.Branch != null) ? employee.Branch.BranchName : "";
                    row.Cells[7].Value = employee.DateHire.ToShortDateString();
                    row.Cells[8].Value = employee.Shift.Shift;
                    row.Cells[9].Value = (employee.Position != null) ? employee.Position.Title : "";
                    row.Cells[10].Value = employee.IsQuit ? "RESIGNED" : "";
                    //row.Cells[10].Value = employee.CreatedAt.ToShortDateString();
                    DGVEmployeeList.Rows.Add(row);
                }
            }

        }

        private void DGVEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11 && e.RowIndex > -1)
            {
                if (DGVEmployeeList.CurrentRow != null)
                {
                    string employeeNumber = DGVEmployeeList.CurrentRow.Cells[0].Value.ToString();
                    SelectedEmployeeNumber = employeeNumber;
                }
            }
        }

        private void DGVEmployees_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11 && e.RowIndex > -1)
            {
                DGVEmployeeList.Cursor = Cursors.Hand;
            }
            else
            {
                DGVEmployeeList.Cursor = Cursors.Default;
            }
        }

        private void SetDGVEmployeesFontAndColors()
        {
            this.DGVEmployeeList.BackgroundColor = Color.White;
            this.DGVEmployeeList.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            //this.DGVEmployees.DefaultCellStyle.ForeColor = Color.White;
            //this.DGVEmployees.DefaultCellStyle.BackColor = Color.FromArgb(99, 99, 138);
            //this.DGVEmployees.DefaultCellStyle.SelectionForeColor = Color.FromArgb(42, 42, 64);
            //this.DGVEmployees.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

            this.DGVEmployeeList.RowHeadersVisible = false;
            this.DGVEmployeeList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVEmployeeList.AllowUserToResizeRows = false;
            this.DGVEmployeeList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVEmployeeList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            //this.DGVEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            //this.DGVEmployees.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //this.DGVEmployees.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(42, 42, 64);
            //this.DGVEmployees.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;


            this.DGVEmployeeList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVEmployeeList.MultiSelect = false;

            this.DGVEmployeeList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVEmployeeList.ColumnHeadersHeight = 30;
        }

        private void TbxSearchString_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SearchEmployeeParameters.SearchString = this.TbxSearchString.Text;
                OnSearchStringEnter(EventArgs.Empty);
            }
        }

        private void BtnReloadEmployees_Click(object sender, EventArgs e)
        {
            OnReloadEmployeeList(EventArgs.Empty);
        }

    }

    public class SearchEmployeeParameters
    {
        public string SearchString { get; set; }

        //public DateTime DateHire { get; set; }

        //public DateTime DateOfBirth { get; set; }
    }
}
