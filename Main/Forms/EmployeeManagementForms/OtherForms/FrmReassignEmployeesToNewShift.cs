using DataAccess.Data.EmployeeManagement.Contracts;
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

namespace Main.Forms.EmployeeManagementForms.OtherForms
{
    public partial class FrmReassignEmployeesToNewShift : Form
    {
        private readonly IEmployeeData _employeeData;
        private readonly IEmployeeShiftData _employeeShiftData;

        public FrmReassignEmployeesToNewShift(IEmployeeData employeeData, IEmployeeShiftData employeeShiftData, long shiftIdToDelete)
        {
            InitializeComponent();
            _employeeData = employeeData;
            _employeeShiftData = employeeShiftData;

            ShiftIdToDelete = shiftIdToDelete;
        }

        public bool IsCancelled { get; set; }
        public bool IsDone { get; set; }

        public long ShiftIdToDelete { get; set; }

        private void FrmReassignEmployeesToNewShift_Load(object sender, EventArgs e)
        {
            var shifts = _employeeShiftData.GetAllNotDeleted().Where(x => x.Id != ShiftIdToDelete).ToList();

            if (shifts != null && shifts.Count > 0)
            {
                ComboboxItem item;

                foreach(var shift in shifts)
                {
                    item = new ComboboxItem();
                    item.Text = shift.Shift;
                    item.Value = shift.Id;

                    this.CBoxShifts.Items.Add(item);
                }
            }

            var shiftDetailsToDelete = _employeeShiftData.Get(ShiftIdToDelete);

            if (shiftDetailsToDelete != null)
            {
                this.LblShiftToDelete.Text = shiftDetailsToDelete.Shift;
            }
        }

        private void BtnCancelUpdateShift_Click(object sender, EventArgs e)
        {
            this.IsCancelled = true;
            this.IsDone = false;
            this.Close();
        }

        private void BtnSubmitNewShift_Click(object sender, EventArgs e)
        {
            if (this.CBoxShifts.SelectedIndex >= 0)
            {
                var selectedShift = this.CBoxShifts.SelectedItem as ComboboxItem;

                if (selectedShift != null)
                {
                    long selectedShiftId = long.Parse(selectedShift.Value.ToString());

                    bool isUpdated = _employeeData.MoveEmployeesIntoNewShift(this.ShiftIdToDelete, selectedShiftId);

                    if (isUpdated == false)
                    {
                        this.IsCancelled = true;
                        this.IsDone = false;
                        MessageBox.Show("Unable to update employee's shift, see system logs for possible errors and report this to developer.", "Update employee's shift", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
