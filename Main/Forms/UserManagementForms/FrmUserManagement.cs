using DataAccess.Data.EmployeeManagement.Contracts;
using Main.Controllers.UserManagementControllers;
using Main.Forms.UserManagementForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.UserManagementForms
{
    public partial class FrmUserManagement : Form
    {
        private readonly IUserController _userController;
        private readonly IEmployeeData _employeeData;

        public FrmUserManagement(IUserController userController, IEmployeeData employeeData)
        {
            InitializeComponent();
            _userController = userController;
            _employeeData = employeeData;
        }

        private void contextMenuStripUserManagement_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;
            if (clickedItem != null && clickedItem.Name == "toolStripMenuItemUserCRUDControl")
            {
                DisplayUserCRUDControl();
            }else if (clickedItem != null && clickedItem.Name == "toolStripMenuItemUserActivityLogs")
            {
                //DisplayAddUpdateGovernmentAgency();
            }
        }

        private void DisplayUserCRUDControl()
        {
            this.panelContainer.Controls.Clear();

            var userCRUDControlObj = new UserCRUDControl();
            //leaveTypeControl.Dock = DockStyle.Fill;
            userCRUDControlObj.Location = new Point(this.ClientSize.Width / 2 - userCRUDControlObj.Size.Width / 2, this.ClientSize.Height / 2 - userCRUDControlObj.Size.Height / 2);
            userCRUDControlObj.Anchor = AnchorStyles.None;

            userCRUDControlObj.Users = _userController.GetAll().Data;
            userCRUDControlObj.Roles = _userController.GetAllRoles();

            userCRUDControlObj.SavedUserInfo += HandleSavedUser;
            userCRUDControlObj.DeleteEmployeeOnSelect += HandleDeleteUser;
            userCRUDControlObj.SearchByEmployeeNumber += HandleSearchByEmployeeNumber;
            userCRUDControlObj.GetUserInformationOnSelect += HandleGetUserInformationOnSelect;

            userCRUDControlObj.SearchUser += HandleSearchUser;
            userCRUDControlObj.ClearSearch += HandleClearSearch;

            this.panelContainer.Controls.Add(userCRUDControlObj);
        }

        private void HandleSavedUser(object sender, EventArgs e)
        {
            UserCRUDControl userCRUDControlObj = (UserCRUDControl)sender;

            var userToAddUpdate = userCRUDControlObj.UserToAddUpdate;
            bool isNew = userCRUDControlObj.IsNew;

            var saveResults = _userController.Save(userToAddUpdate, isNew);

            string resultMessages = "";
            foreach (var msg in saveResults.Messages)
            {
                resultMessages += msg + "\n";
            }


            if (saveResults.IsSuccess)
            {
                MessageBox.Show(resultMessages, "Save user details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                userCRUDControlObj.ResetForm();

                userCRUDControlObj.Users = _userController.GetAll().Data;
                userCRUDControlObj.DisplayUsers();
            }
            else
            {
                MessageBox.Show(resultMessages, "Save user details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void HandleDeleteUser(object sender, EventArgs e)
        {
            UserCRUDControl userCRUDControlObj = (UserCRUDControl)sender;

            DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                long selectedUserId = userCRUDControlObj.SelectedUserId;

                var deleteResult = _userController.Delete(selectedUserId);

                string resultMessages = "";
                foreach (var msg in deleteResult.Messages)
                {
                    resultMessages += msg + "\n";
                }

                MessageBox.Show(resultMessages, "Save user details", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (deleteResult.IsSuccess)
                {
                    userCRUDControlObj.ResetForm();
                    userCRUDControlObj.Users = _userController.GetAll().Data;
                    userCRUDControlObj.DisplayUsers();
                }
            }

            
        }

        private void HandleSearchByEmployeeNumber(object sender, EventArgs e)
        {
            UserCRUDControl userCRUDControlObj = (UserCRUDControl)sender;
            var employeeNumber = userCRUDControlObj.EmployeeNumberToSearch;

            var empDetails = _employeeData.GetByEmployeeNumber(employeeNumber);

            if (empDetails != null)
            {
                userCRUDControlObj.SearchResultEmployeeFullName = $"{empDetails.FirstName} {empDetails.MiddleName} {empDetails.LastName}";
            }
            else
            {
                userCRUDControlObj.SearchResultEmployeeFullName = "";
                MessageBox.Show("Employee not found", "Search employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HandleGetUserInformationOnSelect(object sender, EventArgs e)
        {
            UserCRUDControl userCRUDControlObj = (UserCRUDControl)sender;
            long userId = userCRUDControlObj.SelectedUserId;

            var userInfo = _userController.GetById(userId);

            if (userInfo != null)
            {
                userCRUDControlObj.ResetForm();
                userCRUDControlObj.SelectedUserInfo = userInfo.Data;
                userCRUDControlObj.DisplaySelectedUserInfo();
            }
        }




        private void HandleSearchUser(object sender, EventArgs e)
        {
            UserCRUDControl userCRUDControlObj = (UserCRUDControl)sender;
            string searchString = userCRUDControlObj.UserStringToSearch;

            userCRUDControlObj.Users = _userController.Search(searchString).Data;
            userCRUDControlObj.DisplayUsers();
        }

        private void HandleClearSearch(object sender, EventArgs e)
        {
            UserCRUDControl userCRUDControlObj = (UserCRUDControl)sender;
            userCRUDControlObj.Users = _userController.GetAll().Data;
            userCRUDControlObj.DisplayUsers();
        }
    }
}
