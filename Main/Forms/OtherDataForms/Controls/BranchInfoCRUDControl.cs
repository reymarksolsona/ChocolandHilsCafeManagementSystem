using EntitiesShared.OtherDataManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.OtherDataForms.Controls
{
    public partial class BranchInfoCRUDControl : UserControl
    {
        public BranchInfoCRUDControl()
        {
            InitializeComponent();
        }

        private List<BranchModel> branches = new();

        public List<BranchModel> Branches
        {
            get { return branches; }
            set { branches = value; }
        }


        private BranchModel branchToAddUpdate;

        public BranchModel BranchToAddUpdate
        {
            get { return branchToAddUpdate; }
            set { branchToAddUpdate = value; }
        }


        public event PropertyChangedEventHandler IsSaveNewChanged;

        private bool _isSaveNew = true;

        public bool IsSaveNew
        {
            get { return _isSaveNew; }
            set {
                _isSaveNew = value; 
                
                if (IsSaveNewChanged != null)
                {
                    IsSaveNewChanged(this, new PropertyChangedEventArgs(IsSaveNew.ToString()));
                }
            }
        }


        public void OnIsSaveNewChange(object sender, PropertyChangedEventArgs e)
        {
            if (this.IsSaveNew)
            {
                this.BtnCancelUpdate.Visible = false;
                this.GBoxBranchForm.Text = "Add new branch";
            }
            else
            {
                this.BtnCancelUpdate.Visible = true;
                this.GBoxBranchForm.Text = "Update branch details";
            }
        }

        public event EventHandler BranchSaved;
        protected virtual void OnBranchSaved(EventArgs e)
        {
            BranchSaved?.Invoke(this, e);
        }

        private void BranchInfoCRUDControl_Load(object sender, EventArgs e)
        {
            IsSaveNewChanged += OnIsSaveNewChange;

            SetDGVBranchListFontAndColors();
            DisplayBranchList();
        }

        private void SetDGVBranchListFontAndColors()
        {
            this.DGVBranchList.BackgroundColor = Color.White;
            this.DGVBranchList.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVBranchList.RowHeadersVisible = false;
            this.DGVBranchList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVBranchList.AllowUserToResizeRows = false;
            this.DGVBranchList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVBranchList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVBranchList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVBranchList.MultiSelect = false;

            this.DGVBranchList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVBranchList.ColumnHeadersHeight = 30;
        }


        public void DisplayBranchList()
        {
            this.DGVBranchList.Rows.Clear();
            if (this.Branches != null)
            {
                this.DGVBranchList.ColumnCount = 4;

                this.DGVBranchList.Columns[0].Name = "BranchId";
                this.DGVBranchList.Columns[0].Visible = false;

                this.DGVBranchList.Columns[1].Name = "BranchName";
                this.DGVBranchList.Columns[1].HeaderText = "Branch Name";

                this.DGVBranchList.Columns[2].Name = "BranchTellNo";
                this.DGVBranchList.Columns[2].HeaderText = "Tell no";

                this.DGVBranchList.Columns[3].Name = "BranchAddress";
                this.DGVBranchList.Columns[3].HeaderText = "Address";

                // Update button
                DataGridViewImageColumn btnUpdateLeaveTypeImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateLeaveTypeImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVBranchList.Columns.Add(btnUpdateLeaveTypeImg);

                // Delete button
                DataGridViewImageColumn btnDeleteLeaveTypeImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteLeaveTypeImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVBranchList.Columns.Add(btnDeleteLeaveTypeImg);

                foreach (var branch in this.Branches)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVBranchList);

                    row.Cells[0].Value = branch.Id;
                    row.Cells[1].Value = branch.BranchName;
                    row.Cells[2].Value = branch.TellNo;
                    row.Cells[3].Value = branch.Address;
                    DGVBranchList.Rows.Add(row);
                }


            }
        }

        public void ResetForm()
        {
            this.TbxBranchName.Text = "";
            this.TbxTellNo.Text = "";
            this.TbxAddress.Text = "";
            this.IsSaveNew = true;
            this.BranchToAddUpdate = null;
        }

        public void DisplaySelectedBranch()
        {
            if (this.BranchToAddUpdate != null)
            {
                this.TbxBranchName.Text = this.BranchToAddUpdate.BranchName;
                this.TbxTellNo.Text = this.BranchToAddUpdate.TellNo;
                this.TbxAddress.Text = this.BranchToAddUpdate.Address;
            }
        }

        private void BtnSaveBranchDetails_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbxBranchName.Text) ||
                string.IsNullOrEmpty(TbxTellNo.Text) ||
                string.IsNullOrEmpty(TbxAddress.Text) )
            {
                MessageBox.Show("Kindly input all details.", "Save branch", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.IsSaveNew == true)
            {
                if (this.Branches != null)
                {
                    var existingBranch = this.Branches.Where(x => 
                                        x.BranchName
                                            .ToLower()
                                            .Contains(this.TbxBranchName.Text.ToLower()) ||
                                        x.TellNo.ToLower() == this.TbxTellNo.Text.ToLower()
                                        ).FirstOrDefault();

                    if (existingBranch != null)
                    {
                        MessageBox.Show("Duplicate Data: Existing branch with the same name or tell no.", "Add new branch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                this.BranchToAddUpdate = new BranchModel
                {
                    BranchName = this.TbxBranchName.Text,
                    TellNo = this.TbxTellNo.Text,
                    Address = this.TbxAddress.Text
                };
            }
            else
            {
                if (this.Branches != null && this.BranchToAddUpdate != null)
                {
                    var existingBranch = this.Branches.Where(x =>
                                        (x.BranchName
                                            .ToLower()
                                            .Contains(this.TbxBranchName.Text.ToLower()) ||
                                        x.TellNo.ToLower() == this.TbxTellNo.Text.ToLower()) &&
                                        x.Id != this.BranchToAddUpdate.Id
                                        ).FirstOrDefault();

                    if (existingBranch != null)
                    {
                        MessageBox.Show("Duplicate Data: Existing branch with the same name or tell no.", "Update branch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    this.BranchToAddUpdate.BranchName = this.TbxBranchName.Text;
                    this.BranchToAddUpdate.TellNo = this.TbxTellNo.Text;
                    this.BranchToAddUpdate.Address = this.TbxAddress.Text;
                }

            }

            OnBranchSaved(EventArgs.Empty);
        }

        public long SelectedBranchIdToDelete { get; set; }

        public event EventHandler DeleteBranch;
        protected virtual void OnDeleteBranch(EventArgs e)
        {
            DeleteBranch?.Invoke(this, e);
        }

        private void DGVBranchList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Update button
            if ((e.ColumnIndex == 4) && e.RowIndex > -1)
            {
                if (DGVBranchList.CurrentRow != null)
                {
                    long branchId = long.Parse(DGVBranchList.CurrentRow.Cells[0].Value.ToString());
                    this.BranchToAddUpdate = this.Branches.Where(x => x.Id == branchId).FirstOrDefault();
                    this.IsSaveNew = false;
                    this.DisplaySelectedBranch();
                }
            }


            // Delete button
            if ((e.ColumnIndex == 5) && e.RowIndex > -1)
            {
                if (DGVBranchList.CurrentRow != null)
                {
                    long branchId = long.Parse(DGVBranchList.CurrentRow.Cells[0].Value.ToString());
                    SelectedBranchIdToDelete = branchId;

                    OnDeleteBranch(EventArgs.Empty);
                }
            }
        }

        private void BtnCancelUpdate_Click(object sender, EventArgs e)
        {
            this.ResetForm();
        }
    }
}
