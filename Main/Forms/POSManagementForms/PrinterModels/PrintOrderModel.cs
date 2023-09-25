using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Forms.POSManagementForms.PrinterModels
{
    public class CustomerInfo
    {
        public string Name { get; set; }
        public string CashAmount { get; set; }
    }

    public class BillSummary
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class Header
    {
        public string StoreName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Cashier { get; set; }
        public string Number { get; set; }
        public string BillNo { get; set; }
        public string DateOfBill { get; set; }
        public string TimeOfBill { get; set; }
    }

    public class ReceiptItem
    {
        public int No { get; set; }
        public string ItemAmt { get; set; }
        public string ItemName { get; set; }
        public int Qty { get; set; }
        public string Rate { get; set; }
        public string CustRmks { get; set; }
    }

    public class Settings
    {
        public Settings()
        {
            PageSize = "Size5";
        }
        public string PrinterName { get; set; }
        public string PrinterType { get; set; }
        public int ItemLength { get; set; }
        public bool PrintLogo { get; set; }
        public string ThankYouNote { get; set; }
        public string ThankYouNote2 { get; set; }
        public string EIDRMK { get; set; }
        public string PrintType { get; set; }
        public string PageSize { get; set; }
    }

    public class ReceiptRootObject
    {
        public string Total { get; set; }
        public string GrandTotal { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
        public List<BillSummary> BillSummary { get; set; }
        public Header Header { get; set; }
        public List<ReceiptItem> Items { get; set; }
        public Settings Settings { get; set; }
    }
}
