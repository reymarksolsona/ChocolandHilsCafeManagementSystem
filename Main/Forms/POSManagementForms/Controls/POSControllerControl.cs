using EntitiesShared.POSManagement;
using EntitiesShared.POSManagement.CustomModels;
using Main.Controllers.POSControllers.ControllerInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntitiesShared;
using Shared.CustomModels;
using Shared;

namespace Main.Forms.POSManagementForms.Controls
{
    public partial class POSControllerControl : UserControl
    {
        private readonly IPOSCommandController _iPOSCommandController;
        private readonly IPOSReadController _pOSReadController;
        private readonly POSState _pOSState;
        private readonly OtherSettings _otherSettings;
        private readonly Sessions _sessions;

        public POSControllerControl(IPOSCommandController iPOSCommandController, 
                                    IPOSReadController pOSReadController, 
                                    POSState pOSState,
                                    OtherSettings otherSettings,
                                    Sessions sessions)
        {
            InitializeComponent();
            _iPOSCommandController = iPOSCommandController;
            _pOSReadController = pOSReadController;
            _pOSState = pOSState;
            _otherSettings = otherSettings;
            _sessions = sessions;
        }

        public int CurrentTransactionTableNumber { get; set; }

        private List<SaleTransactionModel> _activedineInTransactions;

        public List<SaleTransactionModel> ActiveDineInTransactions
        {
            get { return _activedineInTransactions; }
            set { _activedineInTransactions = value; }
        }


        private void POSCheckOutControllerControl_Load(object sender, EventArgs e)
        {
            SetDGVActiveDineInTransactionsFontAndColors();

            _pOSState.PropertyChanged += HandleOnCurrentSaleTransactionChanged;
        }

        public void HandleOnCurrentSaleTransactionChanged(object sender, PropertyChangedEventArgs e)
        {
            DisplayCurrentSaleTransaction();
            this.TabControlMain.SelectedIndex = this.TabControlMain.TabPages.IndexOf(TabPageCheckout);
        }


        private void DisplayCurrentSaleTransaction()
        {
            this.ClearCheckOutForm();
            if (_pOSState.CurrentSaleTransaction != null)
            {

                string tableOrOrderNum = "";

                if (_pOSState.CurrentSaleTransaction.TransactionType == StaticData.POSTransactionType.DineIn)
                {
                    this.LblTransactionType.Text = $"Dine-in -> {_pOSState.CurrentSaleTransaction.TableNumberStr}";
                    this.LblTransactionType.BackColor = Color.Blue;
                    this.LblTransactionType.ForeColor = Color.White;
                    this.BtnSelectTable.Enabled = true;
                    tableOrOrderNum = _pOSState.CurrentSaleTransaction.TableNumberStr;
                }

                if (_pOSState.CurrentSaleTransaction.TransactionType == StaticData.POSTransactionType.TakeOut)
                {
                    this.LblTransactionType.Text = $"Take-out -> {_pOSState.CurrentSaleTransaction.TakeOutNumberStr}";
                    this.LblTransactionType.BackColor = Color.Yellow;
                    tableOrOrderNum = _pOSState.CurrentSaleTransaction.TakeOutNumberStr;
                }

                this.TboxTicketNumber.Text = _pOSState.CurrentSaleTransaction.TicketNumber;
                this.TboxCustomerName.Text = _pOSState.CurrentSaleTransaction.CustomerName;

                this.LblCurrentTransTable.Text = tableOrOrderNum;
                this.CurrentTransactionTableNumber = _pOSState.CurrentSaleTransaction.TableNumber;

                //this.LblSubTotal.Text = _pOSState.ToStringSubTotal;
            }

            DisplayCurrentSaleTransactionSubTotal();
        }


        public void DisplayCurrentSaleTransactionSubTotal()
        {
            this.LblSubTotal.Text = "0";
            this.LblNumberOfItems.Text = "0";
            if (_pOSState.CurrentSaleTransaction != null)
            {
                this.LblSubTotal.Text = _pOSState.ToStringSubTotal;
                this.LblNumberOfItems.Text = _pOSState.NumberOfItems.ToString();
            }
        }

        private void ClearCheckOutForm()
        {
            this.LblTransactionType.Text = "Transaction type";
            this.LblTransactionType.BackColor = Color.Transparent;
            this.LblTransactionType.ForeColor = Color.Black;
            this.TboxTicketNumber.Text = "";
            this.TboxCustomerName.Text = "";
            this.LblCurrentTransTable.Text = "";
            this.CurrentTransactionTableNumber = 0;

            this.BtnSelectTable.Enabled = false;
        }

        private void SetDGVActiveDineInTransactionsFontAndColors()
        {
            this.DGVActiveDineInTransactions.BackgroundColor = Color.White;
            this.DGVActiveDineInTransactions.DefaultCellStyle.Font = new Font("Century Gothic", 11);
            this.DGVActiveDineInTransactions.RowHeadersVisible = false;
            this.DGVActiveDineInTransactions.RowTemplate.Height = 35;
            this.DGVActiveDineInTransactions.RowTemplate.Resizable = DataGridViewTriState.True;
            this.DGVActiveDineInTransactions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVActiveDineInTransactions.AllowUserToResizeRows = false;
            this.DGVActiveDineInTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVActiveDineInTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 11);
            this.DGVActiveDineInTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVActiveDineInTransactions.MultiSelect = false;
        }

        private void BtnNewTransaction_Click(object sender, EventArgs e)
        {
            if (_pOSState.CurrentSaleTransaction != null)
            {
                MessageBox.Show("Please save current transaction before creating new.", "Creating new transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenFrmNewTransaction();
        }

        public void OpenFrmNewTransaction()
        {
            _pOSState.CurrentSaleTransactionProducts = new List<SaleTransactionProductModel>();
            _pOSState.CurrentSaleTransactionComboMeals = new List<SaleTransactionComboMealModel>();

            FrmNewTransaction frmNewTransaction = new(_iPOSCommandController, _pOSReadController);
            frmNewTransaction.ShowDialog();

            bool isCancelled = frmNewTransaction.IsCancelled;
            bool isInitiateSuccessful = frmNewTransaction.IsInitiateSuccessful;

            if (isCancelled == false && isInitiateSuccessful == true)
            {
                _pOSState.Transaction = POSStateTransaction.New;
                _pOSState.CurrentSaleTransaction = frmNewTransaction.NewSalesTransaction;
            }
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControlMain.SelectedTab == TabControlMain.TabPages[1])
            {
                var activeDineInTransactions = _pOSReadController.GetActiveSalesTransactions();
                this.DisplayActiveTransactions(activeDineInTransactions);
            }
        }

        private void DisplayActiveTransactions(List<SaleTransactionModel> dineInSalesTransactions)
        {
            ActiveDineInTransactions = dineInSalesTransactions;

            this.DGVActiveDineInTransactions.Rows.Clear();
            if (dineInSalesTransactions != null)
            {
                this.DGVActiveDineInTransactions.ColumnCount = 5;

                this.DGVActiveDineInTransactions.Columns[0].Name = "TransactionId";
                this.DGVActiveDineInTransactions.Columns[0].Visible = false;

                this.DGVActiveDineInTransactions.Columns[1].Name = "TicketNumber";
                this.DGVActiveDineInTransactions.Columns[1].HeaderText = "Ticket";

                this.DGVActiveDineInTransactions.Columns[2].Name = "CustomerName";
                this.DGVActiveDineInTransactions.Columns[2].HeaderText = "Customer";

                this.DGVActiveDineInTransactions.Columns[3].Name = "TableNumber";
                this.DGVActiveDineInTransactions.Columns[3].HeaderText = "Table/Order #";

                this.DGVActiveDineInTransactions.Columns[4].Name = "TransactionType";
                this.DGVActiveDineInTransactions.Columns[4].HeaderText = "Type";

                DataGridViewImageColumn btnViewDetailsImg = new DataGridViewImageColumn();
                btnViewDetailsImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnViewDetailsImg.Image = Image.FromFile("./Resources/view-details-24.png");
                this.DGVActiveDineInTransactions.Columns.Add(btnViewDetailsImg);

                foreach(var tran in dineInSalesTransactions)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVActiveDineInTransactions);

                    row.Cells[0].Value = tran.Id;
                    row.Cells[1].Value = tran.TicketNumber;
                    row.Cells[2].Value = tran.CustomerName;
                    row.Cells[3].Value = tran.TransactionType == StaticData.POSTransactionType.DineIn ? tran.TableNumberStr : tran.TakeOutNumberStr;
                    row.Cells[4].Value = tran.TransactionType == StaticData.POSTransactionType.DineIn ? "IN" : "OUT";

                    DGVActiveDineInTransactions.Rows.Add(row);
                }
            }
        }


        public event EventHandler CheckOutDineInTransaction;
        protected virtual void OnCheckOutDineInTransaction(EventArgs e)
        {
            CheckOutDineInTransaction?.Invoke(this, e);
        }


        private void DGVActiveDineInTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // view details button
            if ((e.ColumnIndex == 5) && e.RowIndex > -1)
            {
                if (_pOSState.CurrentSaleTransaction != null)
                {
                    MessageBox.Show("Please save current transaction before creating new.", "Creating new transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (DGVActiveDineInTransactions.CurrentRow != null && this.ActiveDineInTransactions != null)
                {
                    long selectedDineInTransactionId = long.Parse(DGVActiveDineInTransactions.CurrentRow.Cells[0].Value.ToString());

                    this.DisplayOrderDetailsOfSelectedDineInTransaction(selectedDineInTransactionId);
                }
            }
        }

        private void DisplayOrderDetailsOfSelectedDineInTransaction(long selectedDineInTransactionId)
        {
            var selectedDineInTransaction = this.ActiveDineInTransactions.Where(x => x.Id == selectedDineInTransactionId).FirstOrDefault();

            _pOSState.Transaction = POSStateTransaction.Existing;
            _pOSState.CurrentSaleTransactionProducts = _pOSReadController.GetSaleTranProducts(selectedDineInTransaction.Id).ToList();
            _pOSState.CurrentSaleTransactionComboMeals = _pOSReadController.GetSaleTranComboMeals(selectedDineInTransaction.Id).ToList();
            _pOSState.CurrentSaleTransaction = selectedDineInTransaction;
        }

        private void BtnCancelCurrentTransaction_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Continue to cancel current transaction?", "Cancel current transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                var cancelResults = _iPOSCommandController.CancelSaleTransaction(_pOSState.CurrentSaleTransaction.Id);

                string resMsg = "";
                foreach (var msg in cancelResults.Messages)
                {
                    resMsg += msg;
                }

                if (cancelResults.IsSuccess == true)
                {
                    MessageBox.Show(resMsg, "Cancel current transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _pOSState.Transaction = POSStateTransaction.Empty;
                    _pOSState.CurrentSaleTransactionProducts = new List<SaleTransactionProductModel>();
                    _pOSState.CurrentSaleTransactionComboMeals = new List<SaleTransactionComboMealModel>();
                    _pOSState.CurrentSaleTransaction = null;
                }
                else
                {
                    MessageBox.Show(resMsg, "Cancel current transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (_pOSState.CurrentSaleTransaction != null)
            {
                if (this.CurrentTransactionTableNumber == 0 && _pOSState.CurrentSaleTransaction.TransactionType == StaticData.POSTransactionType.DineIn)
                {
                    MessageBox.Show("Kindly select table.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var saveResults = _iPOSCommandController.SaveSaleTransaction(_pOSState.CurrentSaleTransaction.Id, this.CurrentTransactionTableNumber, _pOSState.CurrentSaleTransactionProducts, _pOSState.CurrentSaleTransactionComboMeals);

                string resMsg = "";
                foreach(var msg in saveResults.Messages)
                {
                    resMsg += msg;
                }

                if (saveResults.IsSuccess == true)
                {
                    MessageBox.Show(resMsg, "Save current transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _pOSState.Transaction = POSStateTransaction.Existing;
                    _pOSState.CurrentSaleTransactionProducts = new List<SaleTransactionProductModel>();
                    _pOSState.CurrentSaleTransactionComboMeals = new List<SaleTransactionComboMealModel>();
                    _pOSState.CurrentSaleTransaction = null;
                }
                else
                {
                    MessageBox.Show(resMsg, "Save current transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (_pOSState.CurrentSaleTransaction != null)
            {
                if (this.CurrentTransactionTableNumber == 0 && _pOSState.CurrentSaleTransaction.TransactionType == StaticData.POSTransactionType.DineIn)
                {
                    MessageBox.Show("Kindly select table.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var saveResults = _iPOSCommandController.SaveSaleTransaction(_pOSState.CurrentSaleTransaction.Id, this.CurrentTransactionTableNumber, _pOSState.CurrentSaleTransactionProducts, _pOSState.CurrentSaleTransactionComboMeals);

                string resMsg = "";
                foreach (var msg in saveResults.Messages)
                {
                    resMsg += msg;
                }

                if (saveResults.IsSuccess == true)
                {
                    FrmCheckOut frmCheckOut = new FrmCheckOut(_iPOSCommandController, _pOSState, _otherSettings, _sessions);
                    frmCheckOut.ShowDialog();

                    bool isCheckoutIsSuccessful = frmCheckOut.IsSuccessfulCheckout;

                    if (isCheckoutIsSuccessful)
                    {
                        // print receipt here

                        _pOSState.Transaction = POSStateTransaction.Existing;
                        _pOSState.CurrentSaleTransactionProducts = new List<SaleTransactionProductModel>();
                        _pOSState.CurrentSaleTransactionComboMeals = new List<SaleTransactionComboMealModel>();
                        _pOSState.CurrentSaleTransaction = null;


                        this.TabControlMain.SelectedIndex = this.TabControlMain.TabPages.IndexOf(TabPageCheckout);
                    }
                }
                else
                {
                    MessageBox.Show(resMsg, "Save current transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void BtnSelectTable_Click(object sender, EventArgs e)
        {
            if (_pOSState.CurrentSaleTransaction != null && _pOSState.CurrentSaleTransaction.TransactionType == StaticData.POSTransactionType.DineIn)
            {
                FrmSelectAvailableTable frmSelectAvailableTable = new FrmSelectAvailableTable(_pOSReadController, _iPOSCommandController);
                frmSelectAvailableTable.ShowDialog();

                if (frmSelectAvailableTable.SelectedTableNumber > 0)
                {
                    this.CurrentTransactionTableNumber = frmSelectAvailableTable.SelectedTableNumber;
                    this.LblCurrentTransTable.Text = $"T-{this.CurrentTransactionTableNumber}";
                }
            }
        }
    }
}
