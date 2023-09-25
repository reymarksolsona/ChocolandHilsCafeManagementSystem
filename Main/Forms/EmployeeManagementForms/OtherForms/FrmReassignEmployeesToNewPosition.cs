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
    public partial class FrmReassignEmployeesToNewPosition : Form
    {
        private readonly IEmployeeData _employeeData;
        private readonly IEmployeePositionData _employeePositionData;

        public FrmReassignEmployeesToNewPosition(IEmployeeData employeeData, IEmployeePositionData employeePositionData, long positionIdToDelete)
        {
            InitializeComponent();
            _employeeData = employeeData;
            _employeePositionData = employeePositionData;

            this.PositionIdToDelete = positionIdToDelete;
        }

        public long PositionIdToDelete { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsDone { get; set; }

        private void FrmReassignEmployeesToNewPosition_Load(object sender, EventArgs e)
        {
            var positions = _employeePositionData.GetAllNotDeleted().Where(x => x.Id != this.PositionIdToDelete).ToList();

            if (positions != null && positions.Count > 0)
            {
                ComboboxItem item;

                foreach (var position in positions)
                {
                    item = new ComboboxItem();
                    item.Text = position.Title;
                    item.Value = position.Id;

                    this.CBoxPositions.Items.Add(item);
                }
            }

            var positionDetailsToDelete = _employeePositionData.Get(this.PositionIdToDelete);

            if (positionDetailsToDelete != null)
            {
                this.LblPositionToDelete.Text = positionDetailsToDelete.Title;
            }
        }

        private void BtnCancelUpdatePosition_Click(object sender, EventArgs e)
        {

            this.IsCancelled = true;
            this.IsDone = false;
            this.Close();
        }

        private void BtnSubmitNewPosition_Click(object sender, EventArgs e)
        {
            if (this.CBoxPositions.SelectedIndex >= 0)
            {
                var selectedPosition = this.CBoxPositions.SelectedItem as ComboboxItem;

                if (selectedPosition != null)
                {
                    long selectedPositionId = long.Parse(selectedPosition.Value.ToString());

                    try
                    {
                        _employeeData.MoveEmployeesIntoOtherPosition(this.PositionIdToDelete, selectedPositionId);
                        this.IsCancelled = false;
                        this.IsDone = true;
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        this.IsCancelled = true;
                        this.IsDone = false;
                        throw new Exception(ex.Message);
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
