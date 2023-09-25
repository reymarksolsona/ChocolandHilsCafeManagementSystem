using EntitiesShared.UserManagement;
using EntitiesShared.UserManagement.Model;
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
using static EntitiesShared.StaticData;

namespace Main.Forms.UserManagementForms.Controls
{
    public partial class UserCRUDControl : UserControl
    {

        public UserCRUDControl()
        {
            InitializeComponent();
        }

        private void UserCRUDControl_Load(object sender, EventArgs e)
        {
            SetDGVUsersFontAndColors();
            DisplayUsers();
            DisplayRoles();
        }

        private void SetDGVUsersFontAndColors()
        {
            this.DGVUsers.BackgroundColor = Color.White;
            this.DGVUsers.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVUsers.RowHeadersVisible = false;
            this.DGVUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVUsers.AllowUserToResizeRows = false;
            this.DGVUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVUsers.MultiSelect = false;

            this.DGVUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVUsers.ColumnHeadersHeight = 30;
        }

        private List<UserModel> users = new List<UserModel>();

        public List<UserModel> Users
        {
            get { return users; }
            set { users = value; }
        }


        private List<RoleModel> roles = new List<RoleModel>();

        public List<RoleModel> Roles
        {
            get { return roles; }
            set { roles = value; }
        }


        // Event handler for search employee
        public event EventHandler SearchByEmployeeNumber;
        protected virtual void OnSearchByEmployeeNumber(EventArgs e)
        {
            SearchByEmployeeNumber?.Invoke(this, e);
        }

        private string employeeNumberToSearch;

        public string EmployeeNumberToSearch
        {
            get { return employeeNumberToSearch; }
            set { employeeNumberToSearch = value; }
        }

        private string searchResultEmployeeFullName;

        public string SearchResultEmployeeFullName
        {
            get { return searchResultEmployeeFullName; }
            set { 
                searchResultEmployeeFullName = value;
                this.TboxUserFullname.Text = value;
            }
        }


        // Event handler for search employee
        public event EventHandler SearchUser;
        protected virtual void OnSearchUser(EventArgs e)
        {
            SearchUser?.Invoke(this, e);
        }

        private string userStringToSearch;

        public string UserStringToSearch
        {
            get { return userStringToSearch; }
            set { userStringToSearch = value; }
        }


        // Event handler for search employee
        public event EventHandler SavedUserInfo;
        protected virtual void OnSavedUserInfo(EventArgs e)
        {
            SavedUserInfo?.Invoke(this, e);
        }

        private UserAddUpdateModel userToAddUpdate;

        public UserAddUpdateModel UserToAddUpdate
        {
            get { return userToAddUpdate; }
            set { userToAddUpdate = value; }
        }

        public bool IsNew { get; set; } = true;


        // Event handler for search employee
        public event EventHandler GetUserInformationOnSelect;
        protected virtual void OnGetUserInformationOnSelect(EventArgs e)
        {
            GetUserInformationOnSelect?.Invoke(this, e);
        }

        // Event handler for delete employee
        public event EventHandler DeleteEmployeeOnSelect;
        protected virtual void OnDeleteEmployeeOnSelect(EventArgs e)
        {
            DeleteEmployeeOnSelect?.Invoke(this, e);
        }

        private long selectedUserId;

        public long SelectedUserId
        {
            get { return selectedUserId; }
            set { selectedUserId = value; }
        }


        private UserModel selectedUserInfo;

        public UserModel SelectedUserInfo
        {
            get { return selectedUserInfo; }
            set { selectedUserInfo = value; }
        }


        public void DisplaySelectedUserInfo()
        {
            this.IsNew = false;
            if (this.SelectedUserInfo != null)
            {
                this.BtnCancelUpdate.Visible = true;
                this.CboxDisable.Visible = true;

                this.TboxUserName.Text = this.SelectedUserInfo.UserName;
                this.TboxUserFullname.Text = this.SelectedUserInfo.FullName;

                this.CboxDisable.Checked = this.SelectedUserInfo.IsActive ? false : true;

                if (this.SelectedUserInfo.Role != null)
                {
                    for(int i=0; i< this.CBoxPermissions.Items.Count; i++)
                    {
                        var item = this.CBoxPermissions.Items[i] as ComboboxItem;
                        UserRole role = (UserRole)Enum.Parse(typeof(UserRole), item.Value.ToString());

                        if (this.SelectedUserInfo.Role.Role.RoleKey == role)
                        {
                            this.CBoxPermissions.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    this.CBoxPermissions.SelectedIndex = -1;
                }
            }
        }


        public void ResetForm()
        {
            UserToAddUpdate = null;
            SelectedUserInfo = null;

            this.IsNew = true;
            this.TboxUserName.Text = "";
            this.TboxUserFullname.Text = "";
            this.TBoxPassword.Text = "";

            this.CboxDisable.Checked = false;
            this.CboxDisable.Visible = false;

            this.CBoxPermissions.SelectedIndex = -1;

            this.BtnCancelUpdate.Visible = false;


            this.SelectedUserId = 0;
            this.SearchResultEmployeeFullName = "";
            this.EmployeeNumberToSearch = "";
        }

        private void BtnSaveUser_Click(object sender, EventArgs e)
        {
            //if (this.RBtnAdminUser.Checked == false && this.RBtnNormalUser.Checked == false)
            //{
            //    MessageBox.Show("Choose user permission", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}


            var selectedUserPermission = this.CBoxPermissions.SelectedItem as ComboboxItem;
            if (selectedUserPermission == null)
            {
                MessageBox.Show("Choose user permission", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            UserRole role = (UserRole)Enum.Parse(typeof(UserRole), selectedUserPermission.Value.ToString());

            //if (this.RBtnAdminUser.Checked)
            //{
            //    role = UserRole.admin;
            //}

            UserToAddUpdate = new UserAddUpdateModel
            {
                UserName = this.TboxUserName.Text,
                FullName = this.TboxUserFullname.Text,
                Password = this.TBoxPassword.Text,
                IsActive = this.CboxDisable.Checked == false ? true : false, // uncheck the user is active
                Role = role
            };

            OnSavedUserInfo(EventArgs.Empty);
        }

        private void TboxUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.EmployeeNumberToSearch = this.TboxUserName.Text;
                this.OnSearchByEmployeeNumber(EventArgs.Empty);
            }
        }


        public void DisplayRoles()
        {
            this.CBoxPermissions.Items.Clear();
            if (this.Roles != null)
            {
                ComboboxItem item;
                foreach(var role in this.Roles)
                {
                    item = new ComboboxItem();
                    item.Text = role.RoleKey.ToString();
                    item.Value = role.RoleKey;
                    this.CBoxPermissions.Items.Add(item);
                }
            }
        }

        public void DisplayUsers()
        {
            this.DGVUsers.Rows.Clear();
            if (this.Users != null)
            {
                // id, username, fullname, permission, update button
                this.DGVUsers.ColumnCount = 5;

                this.DGVUsers.Columns[0].Name = "userId";
                this.DGVUsers.Columns[0].Visible = false;

                this.DGVUsers.Columns[1].Name = "Username";
                this.DGVUsers.Columns[1].Visible = true;

                this.DGVUsers.Columns[2].Name = "FullName";
                this.DGVUsers.Columns[2].Visible = true;

                this.DGVUsers.Columns[3].Name = "Permission";
                this.DGVUsers.Columns[3].Visible = true;

                this.DGVUsers.Columns[4].Name = "Status";
                this.DGVUsers.Columns[4].Visible = true;

                // Update button
                DataGridViewImageColumn btnUpdateImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVUsers.Columns.Add(btnUpdateImg);


                // Delete button
                DataGridViewImageColumn btnDeleteLeaveTypeImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteLeaveTypeImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVUsers.Columns.Add(btnDeleteLeaveTypeImg);

                foreach (var user in this.Users)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVUsers);

                    if (user.IsActive)
                        row.DefaultCellStyle.ForeColor = ForeColor = Color.Black;
                    else
                        row.DefaultCellStyle.ForeColor = ForeColor = Color.DimGray;

                    row.Cells[0].Value = user.Id;
                    row.Cells[1].Value = user.UserName;
                    row.Cells[2].Value = user.FullName;
                    row.Cells[3].Value = user.Role != null ? user.Role.Role.RoleKey.ToString().ToUpper() : "-";

                    row.Cells[4].Value = user.IsActive ? "Active" : "Disabled";

                    this.DGVUsers.Rows.Add(row);
                }
            }
        }

        private void DGVUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // update button
            if (e.RowIndex > -1 && (e.ColumnIndex == 5))
            {
                if (this.DGVUsers.CurrentRow != null)
                {
                    string userId = this.DGVUsers.CurrentRow.Cells[0].Value.ToString();

                    if (long.TryParse(userId, out long userIdLong))
                    {
                        this.SelectedUserId = userIdLong;
                        this.OnGetUserInformationOnSelect(EventArgs.Empty);
                    }
                }
            }

            // delete button
            if (e.RowIndex > -1 && (e.ColumnIndex == 6))
            {
                if (this.DGVUsers.CurrentRow != null)
                {
                    string userId = this.DGVUsers.CurrentRow.Cells[0].Value.ToString();

                    if (long.TryParse(userId, out long userIdLong))
                    {
                        this.SelectedUserId = userIdLong;
                        this.OnDeleteEmployeeOnSelect(EventArgs.Empty);
                    }
                }
            }
        }

        private void BtnCancelUpdate_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void TBoxSearchEmployeeStr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.UserStringToSearch = this.TBoxSearchEmployeeStr.Text;
                this.OnSearchUser(EventArgs.Empty);
            }
        }

        // Event handler for search employee
        public event EventHandler ClearSearch;
        protected virtual void OnClearSearch(EventArgs e)
        {
            ClearSearch?.Invoke(this, e);
        }
        private void BtnClearSearchResult_Click(object sender, EventArgs e)
        {
            TBoxSearchEmployeeStr.Text = "";
            OnClearSearch(EventArgs.Empty);
        }
    }
}
