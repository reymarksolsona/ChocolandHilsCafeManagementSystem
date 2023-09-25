
namespace Main.Forms.EmployeeManagementForms
{
    partial class FrmMainEmployeeManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MenuStripEmployeeManagement = new System.Windows.Forms.MenuStrip();
            this.MenuItemEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.EmployeeMenuItemsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripItem_DetailsCRUD = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripItem_List = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripItem_Benefits_Deductions = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripItem_PositionAndSalaryRate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemWorkSchedules = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkSchedulesMenItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.WorkShiftsMenItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmpWorkShiftScheds = new System.Windows.Forms.ToolStripMenuItem();
            this.HolidaysMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PayrollMenuItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AttendanceStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PayslipStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BenefisStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeductionStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SalaryStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LeaveTypesStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.FileLeaveSchedStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GovtIdsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListToolStripDDItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToolStripDDItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripEmployeeManagement.SuspendLayout();
            this.EmployeeMenuItemsMenuStrip.SuspendLayout();
            this.WorkSchedulesMenItems.SuspendLayout();
            this.PayrollMenuItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStripEmployeeManagement
            // 
            this.MenuStripEmployeeManagement.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuStripEmployeeManagement.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemEmployee,
            this.MenuItemWorkSchedules});
            this.MenuStripEmployeeManagement.Location = new System.Drawing.Point(0, 0);
            this.MenuStripEmployeeManagement.Name = "MenuStripEmployeeManagement";
            this.MenuStripEmployeeManagement.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.MenuStripEmployeeManagement.Size = new System.Drawing.Size(1143, 35);
            this.MenuStripEmployeeManagement.TabIndex = 3;
            this.MenuStripEmployeeManagement.Text = "Main menu strip";
            // 
            // MenuItemEmployee
            // 
            this.MenuItemEmployee.DropDown = this.EmployeeMenuItemsMenuStrip;
            this.MenuItemEmployee.Name = "MenuItemEmployee";
            this.MenuItemEmployee.Size = new System.Drawing.Size(106, 29);
            this.MenuItemEmployee.Text = "Employee";
            // 
            // EmployeeMenuItemsMenuStrip
            // 
            this.EmployeeMenuItemsMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.EmployeeMenuItemsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripItem_DetailsCRUD,
            this.ToolStripItem_List,
            this.ToolStripItem_Benefits_Deductions,
            this.ToolStripItem_PositionAndSalaryRate});
            this.EmployeeMenuItemsMenuStrip.Name = "EmployeeMenuItems";
            this.EmployeeMenuItemsMenuStrip.OwnerItem = this.MenuItemEmployee;
            this.EmployeeMenuItemsMenuStrip.Size = new System.Drawing.Size(283, 165);
            this.EmployeeMenuItemsMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.EmployeeMenuItemsMenuStrip_ItemClicked);
            // 
            // ToolStripItem_DetailsCRUD
            // 
            this.ToolStripItem_DetailsCRUD.Name = "ToolStripItem_DetailsCRUD";
            this.ToolStripItem_DetailsCRUD.Size = new System.Drawing.Size(282, 32);
            this.ToolStripItem_DetailsCRUD.Text = "Details";
            // 
            // ToolStripItem_List
            // 
            this.ToolStripItem_List.Name = "ToolStripItem_List";
            this.ToolStripItem_List.Size = new System.Drawing.Size(282, 32);
            this.ToolStripItem_List.Text = "List";
            // 
            // ToolStripItem_Benefits_Deductions
            // 
            this.ToolStripItem_Benefits_Deductions.Name = "ToolStripItem_Benefits_Deductions";
            this.ToolStripItem_Benefits_Deductions.Size = new System.Drawing.Size(282, 32);
            this.ToolStripItem_Benefits_Deductions.Text = "Benefits and Deductions";
            // 
            // ToolStripItem_PositionAndSalaryRate
            // 
            this.ToolStripItem_PositionAndSalaryRate.Name = "ToolStripItem_PositionAndSalaryRate";
            this.ToolStripItem_PositionAndSalaryRate.Size = new System.Drawing.Size(282, 32);
            this.ToolStripItem_PositionAndSalaryRate.Text = "Position and Salary Rates";
            // 
            // MenuItemWorkSchedules
            // 
            this.MenuItemWorkSchedules.DropDown = this.WorkSchedulesMenItems;
            this.MenuItemWorkSchedules.Name = "MenuItemWorkSchedules";
            this.MenuItemWorkSchedules.Size = new System.Drawing.Size(154, 29);
            this.MenuItemWorkSchedules.Text = "Work Schedules";
            // 
            // WorkSchedulesMenItems
            // 
            this.WorkSchedulesMenItems.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.WorkSchedulesMenItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorkShiftsMenItem,
            this.EmpWorkShiftScheds,
            this.HolidaysMenuItem});
            this.WorkSchedulesMenItems.Name = "WorkSchedulesMenItems";
            this.WorkSchedulesMenItems.OwnerItem = this.MenuItemWorkSchedules;
            this.WorkSchedulesMenItems.ShowImageMargin = false;
            this.WorkSchedulesMenItems.Size = new System.Drawing.Size(264, 100);
            this.WorkSchedulesMenItems.Text = "Work Schedules";
            this.WorkSchedulesMenItems.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.WorkSchedulesMenItems_ItemClicked);
            // 
            // WorkShiftsMenItem
            // 
            this.WorkShiftsMenItem.Name = "WorkShiftsMenItem";
            this.WorkShiftsMenItem.Size = new System.Drawing.Size(263, 32);
            this.WorkShiftsMenItem.Text = "Shifts";
            // 
            // EmpWorkShiftScheds
            // 
            this.EmpWorkShiftScheds.Name = "EmpWorkShiftScheds";
            this.EmpWorkShiftScheds.Size = new System.Drawing.Size(263, 32);
            this.EmpWorkShiftScheds.Text = "Employee work schedules";
            // 
            // HolidaysMenuItem
            // 
            this.HolidaysMenuItem.Name = "HolidaysMenuItem";
            this.HolidaysMenuItem.Size = new System.Drawing.Size(263, 32);
            this.HolidaysMenuItem.Text = "Holidays";
            // 
            // PayrollMenuItems
            // 
            this.PayrollMenuItems.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.PayrollMenuItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AttendanceStripMenuItem,
            this.PayslipStripMenuItem,
            this.BenefisStripMenuItem,
            this.DeductionStripMenuItem,
            this.SalaryStripMenuItem,
            this.LeaveTypesStripMenuItem});
            this.PayrollMenuItems.Name = "PayrollMenuItems";
            this.PayrollMenuItems.Size = new System.Drawing.Size(179, 196);
            this.PayrollMenuItems.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.PayrollMenuItems_ItemClicked);
            // 
            // AttendanceStripMenuItem
            // 
            this.AttendanceStripMenuItem.Name = "AttendanceStripMenuItem";
            this.AttendanceStripMenuItem.Size = new System.Drawing.Size(178, 32);
            this.AttendanceStripMenuItem.Text = "Attendance";
            // 
            // PayslipStripMenuItem
            // 
            this.PayslipStripMenuItem.Name = "PayslipStripMenuItem";
            this.PayslipStripMenuItem.Size = new System.Drawing.Size(178, 32);
            this.PayslipStripMenuItem.Text = "Payslip";
            // 
            // BenefisStripMenuItem
            // 
            this.BenefisStripMenuItem.Name = "BenefisStripMenuItem";
            this.BenefisStripMenuItem.Size = new System.Drawing.Size(178, 32);
            this.BenefisStripMenuItem.Text = "Benefits";
            // 
            // DeductionStripMenuItem
            // 
            this.DeductionStripMenuItem.Name = "DeductionStripMenuItem";
            this.DeductionStripMenuItem.Size = new System.Drawing.Size(178, 32);
            this.DeductionStripMenuItem.Text = "Deductions";
            // 
            // SalaryStripMenuItem
            // 
            this.SalaryStripMenuItem.Name = "SalaryStripMenuItem";
            this.SalaryStripMenuItem.Size = new System.Drawing.Size(178, 32);
            this.SalaryStripMenuItem.Text = "Salary";
            // 
            // LeaveTypesStripMenuItem
            // 
            this.LeaveTypesStripMenuItem.Name = "LeaveTypesStripMenuItem";
            this.LeaveTypesStripMenuItem.Size = new System.Drawing.Size(178, 32);
            this.LeaveTypesStripMenuItem.Text = "Leave Types";
            // 
            // panelContainer
            // 
            this.panelContainer.AutoScroll = true;
            this.panelContainer.BackColor = System.Drawing.SystemColors.Control;
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 35);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Padding = new System.Windows.Forms.Padding(14, 17, 14, 17);
            this.panelContainer.Size = new System.Drawing.Size(1143, 715);
            this.panelContainer.TabIndex = 5;
            // 
            // FileLeaveSchedStripMenuItem
            // 
            this.FileLeaveSchedStripMenuItem.Name = "FileLeaveSchedStripMenuItem";
            this.FileLeaveSchedStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.FileLeaveSchedStripMenuItem.Text = "File leave schedule";
            // 
            // GovtIdsStripMenuItem
            // 
            this.GovtIdsStripMenuItem.Name = "GovtIdsStripMenuItem";
            this.GovtIdsStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.GovtIdsStripMenuItem.Text = "Government Ids";
            // 
            // ListToolStripDDItem
            // 
            this.ListToolStripDDItem.Name = "ListToolStripDDItem";
            this.ListToolStripDDItem.Size = new System.Drawing.Size(172, 22);
            this.ListToolStripDDItem.Text = "List";
            // 
            // AddToolStripDDItem
            // 
            this.AddToolStripDDItem.Name = "AddToolStripDDItem";
            this.AddToolStripDDItem.Size = new System.Drawing.Size(172, 22);
            this.AddToolStripDDItem.Text = "Add";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem2.Text = "Add";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem3.Text = "List";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem4.Text = "Government Ids";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem5.Text = "File leave schedule";
            // 
            // FrmMainEmployeeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 750);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.MenuStripEmployeeManagement);
            this.MainMenuStrip = this.MenuStripEmployeeManagement;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMainEmployeeManagement";
            this.Text = "Employee Management";
            this.MenuStripEmployeeManagement.ResumeLayout(false);
            this.MenuStripEmployeeManagement.PerformLayout();
            this.EmployeeMenuItemsMenuStrip.ResumeLayout(false);
            this.WorkSchedulesMenItems.ResumeLayout(false);
            this.PayrollMenuItems.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MenuStripEmployeeManagement;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEmployee;
        private System.Windows.Forms.ToolStripMenuItem MenuItemWorkSchedules;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.ToolStripMenuItem FileLeaveSchedStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GovtIdsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListToolStripDDItem;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripDDItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ContextMenuStrip EmployeeMenuItemsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripItem_DetailsCRUD;
        private System.Windows.Forms.ToolStripMenuItem ToolStripItem_List;
        private System.Windows.Forms.ContextMenuStrip PayrollMenuItems;
        private System.Windows.Forms.ToolStripMenuItem AttendanceStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PayslipStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BenefisStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeductionStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LeaveTypesStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SalaryStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip WorkSchedulesMenItems;
        private System.Windows.Forms.ToolStripMenuItem WorkShiftsMenItem;
        private System.Windows.Forms.ToolStripMenuItem EmpWorkShiftScheds;
        private System.Windows.Forms.ToolStripMenuItem HolidaysMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripItem_Benefits_Deductions;
        private System.Windows.Forms.ToolStripMenuItem ToolStripItem_PositionAndSalaryRate;
    }
}