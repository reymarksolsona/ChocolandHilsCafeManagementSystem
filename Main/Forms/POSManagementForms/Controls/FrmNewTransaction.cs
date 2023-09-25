using EntitiesShared.POSManagement.CustomModels;
using Main.Controllers.POSControllers.ControllerInterface;
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
using EntitiesShared;
using EntitiesShared.POSManagement;

namespace Main.Forms.POSManagementForms.Controls
{
    public partial class FrmNewTransaction : Form
    {
        private readonly IPOSCommandController _iPOSCommandController;
        private readonly IPOSReadController _pOSReadController;

        public FrmNewTransaction(IPOSCommandController iPOSCommandController, 
                                 IPOSReadController pOSReadController)
        {
            InitializeComponent();
            _iPOSCommandController = iPOSCommandController;
            _pOSReadController = pOSReadController;
        }

        public bool IsCancelled { get; set; }
        public bool IsInitiateSuccessful { get; set; }

        public int SelectedTableNumber { get; set; }

        private SaleTransactionModel _newSalesTransaction;

        public SaleTransactionModel NewSalesTransaction
        {
            get { return _newSalesTransaction; }
            set { _newSalesTransaction = value; }
        }

        private void FrmNewTransaction_Load(object sender, EventArgs e)
        {
            NewSalesTransaction = null;
            TboxCustomerName.Focus();
        }

        private void BtnContinueToCreateNewTrans_Click(object sender, EventArgs e)
        {
            StaticData.POSTransactionType transType = StaticData.POSTransactionType.DineIn;

            if (RBtnDineIn.Checked)
            {
                transType = StaticData.POSTransactionType.DineIn;
            }

            if (RBtnTakeOut.Checked)
            {
                transType = StaticData.POSTransactionType.TakeOut;
            }

            string customerName = string.IsNullOrEmpty(TboxCustomerName.Text) ? "NA" : TboxCustomerName.Text;

            if (this.SelectedTableNumber == 0 && transType == StaticData.POSTransactionType.DineIn)
            {
                MessageBox.Show("Kindly choose table.", "Initiate new transaction.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var newTrans = new SaleTransactionModel
            {
                TransactionType = transType,
                CustomerName = customerName,
                TableNumber = this.SelectedTableNumber
            };

            var initiateResult = _iPOSCommandController.InitiateNewTransaction(newTrans);

            string resultMessages = "";
            foreach (var msg in initiateResult.Messages)
            {
                resultMessages += msg + "\n";
            }

            if (initiateResult.IsSuccess == false)
            {
                MessageBox.Show(resultMessages, $"Initiate {transType}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            NewSalesTransaction = initiateResult.Data;

            this.IsCancelled = false;
            this.IsInitiateSuccessful = true;
            this.Close();
        }

        private void BtnCancelCreateNewTrans_Click(object sender, EventArgs e)
        {
            this.NewSalesTransaction = null;
            this.IsCancelled = true;
            this.IsInitiateSuccessful = false;
            this.Close();
        }

        private void BtnSelectTable_Click(object sender, EventArgs e)
        {
            FrmSelectAvailableTable frmSelectAvailableTable = new FrmSelectAvailableTable(_pOSReadController, _iPOSCommandController);
            frmSelectAvailableTable.ShowDialog();

            if (frmSelectAvailableTable.SelectedTableNumber > 0) {
                this.SelectedTableNumber = frmSelectAvailableTable.SelectedTableNumber;
                this.LblTableNumber.Text = $"T-{this.SelectedTableNumber}";
            }
            else
            {
                this.SelectedTableNumber = 0;
                this.LblTableNumber.Text = $"";
                MessageBox.Show("No selected table", "Select table", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
