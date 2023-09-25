using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Data.OtherDataManagement.Contracts;
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

namespace Main.Forms.OtherDataForms.OtherForms
{
    public partial class FrmReassignEmployeesToNewBranch : Form
    {
        private readonly IEmployeeData _employeeData;
        private readonly IBranchData _branchData;

        public FrmReassignEmployeesToNewBranch(IEmployeeData employeeData, IBranchData branchData, long branchIdToDelete)
        {
            InitializeComponent();
            _employeeData = employeeData;
            _branchData = branchData;

            this.BranchIdToDelete = branchIdToDelete;
        }

        public long BranchIdToDelete { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsDone { get; set; }

        private void FrmReassignEmployeesToNewBranch_Load(object sender, EventArgs e)
        {
            var branches = _branchData.GetAllNotDeleted().Where(x => x.Id != this.BranchIdToDelete).ToList();

            if (branches != null && branches.Count > 0)
            {
                ComboboxItem item;

                foreach (var branch in branches)
                {
                    item = new ComboboxItem();
                    item.Text = branch.BranchName;
                    item.Value = branch.Id;

                    this.CBoxBranches.Items.Add(item);
                }
            }

            var branchDetailsToDelete = _branchData.Get(this.BranchIdToDelete);

            if (branchDetailsToDelete == null)
            {
                this.IsCancelled = true;
                this.IsDone = false;
                MessageBox.Show("Unable to find branch details.", "Delete branch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            if (branchDetailsToDelete != null)
            {
                this.LblBranchToDelete.Text = branchDetailsToDelete.BranchName;
            }
        }

        private void BtnCancelUpdateBranch_Click(object sender, EventArgs e)
        {
            this.IsCancelled = true;
            this.IsDone = false;
            this.Close();
        }

        private void BtnSubmitNewBranch_Click(object sender, EventArgs e)
        {
            if (this.CBoxBranches.SelectedIndex >= 0)
            {
                var selectedBranch = this.CBoxBranches.SelectedItem as ComboboxItem;

                if (selectedBranch != null)
                {
                    long selectedBranchId = long.Parse(selectedBranch.Value.ToString());

                    bool isUpdated = _employeeData.MoveEmployeesIntoOtherBranch(this.BranchIdToDelete, selectedBranchId);

                    if (isUpdated == false)
                    {
                        this.IsCancelled = true;
                        this.IsDone = false;
                        MessageBox.Show("Unable to update employee's branch, see system logs for possible errors and report this to developer.", "Update employee's branch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.IsCancelled = false;
                        this.IsDone = true;
                        this.Close();
                    }
                }
            }
        }

        private void BtnForceDelete_Click(object sender, EventArgs e)
        {
            this.IsCancelled = false;
            this.IsDone = true;
            this.Close();
        }
    }
}
