using Main.Controllers.POSControllers.ControllerInterface;
using Main.Forms.POSManagementForms.PrinterModels;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.POSManagementForms.Controls
{
    public partial class FrmCheckOut : Form
    {
        private readonly IPOSCommandController _iPOSCommandController;
        private readonly POSState _pOSState;
        private readonly OtherSettings _otherSettings;
        private readonly Sessions _sessions;

        public FrmCheckOut(IPOSCommandController iPOSCommandController, 
                           POSState pOSState,
                           OtherSettings otherSettings, 
                           Sessions sessions)
        {
            InitializeComponent();
            _iPOSCommandController = iPOSCommandController;
            _pOSState = pOSState;
            _otherSettings = otherSettings;
            _sessions = sessions;
        }

        public decimal Total { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Discount { get; set; }

        public bool IsDiscountPercentage { get; set; }

        public decimal DiscountPercent { get; set; }

        public decimal CashTotal { get; set; }

        public decimal ChangeTotal { get; set; }

        public decimal DueTotal { get; set; }

        public bool IsSuccessfulCheckout { get; set; }


        private static ReceiptRootObject ReceiptReportData;
        private static int height;
        private static int itemIndex = 0;
        private static int pageNum = 1;
        private static bool printPage = false;
        private static List<PageSizeSettings> PageSizeSettingsList;

        private void FrmCheckOut_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Environment.ExpandEnvironmentVariables("%allusersprofile%") + "/DefaultPrinter/PageConfiguration.config"))
                {
                    PageSizeSettingsList = new List<PageSizeSettings>();
                    PageSizeSettingsList.Add(new PageSizeSettings());
                    File.WriteAllText(Environment.ExpandEnvironmentVariables("%allusersprofile%") + "/DefaultPrinter/PageConfiguration.config", JsonSerializer.Serialize(PageSizeSettingsList));
                    FileSecurity(Environment.ExpandEnvironmentVariables("%allusersprofile%") + "/DefaultPrinter/PageConfiguration.config");
                }
                else
                {
                    PageSizeSettingsList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PageSizeSettings>>(File.ReadAllText(Environment.ExpandEnvironmentVariables("%allusersprofile%") + "/DefaultPrinter/PageConfiguration.config"));
                }
            }
            catch (Exception ex)
            { }


            NumUpDnCustomerCash.Focus();

            bool isContinue = true;
            if (_pOSState.CurrentSaleTransaction == null)
            {
                MessageBox.Show("Error: Current transaction is empty", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isContinue = false;
                this.Close();
            }

            if (_pOSState.CurrentSaleTransactionProducts == null && _pOSState.CurrentSaleTransactionComboMeals == null)
            {
                MessageBox.Show("No item selected", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isContinue = false;
                this.Close();
            }

            if (_pOSState.CurrentSaleTransactionProducts.Count == 0 && _pOSState.CurrentSaleTransactionComboMeals.Count == 0)
            {
                MessageBox.Show("No item selected", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isContinue = false;
                this.Close();
            }

            if (isContinue)
            {
                Total = _pOSState.SubTotal;
                SubTotal = _pOSState.SubTotal;

                var currentTrans = _pOSState.CurrentSaleTransaction;

                TboxSubTotal.Text = _pOSState.ToStringSubTotal;
                TboxTicketNum.Text = currentTrans.TicketNumber;
                TboxCustomer.Text = currentTrans.CustomerName;
                TboxTableNumber.Text = $"T-{currentTrans.TableNumber}";
                LblTotal.Text = _pOSState.ToStringSubTotal;
            }

            NumUpDownDiscountValue.Click += TextBoxOnClick;
            NumUpDnCustomerCash.Click += TextBoxOnClick;
        }

        public void FileSecurity(string FileName)
        {
            var fileInfo = new FileInfo(FileName);
            FileSecurity fSecurity = System.IO.FileSystemAclExtensions.GetAccessControl(fileInfo);
            fSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            System.IO.FileSystemAclExtensions.SetAccessControl(fileInfo, fSecurity);
        }

        private void TextBoxOnClick(object sender, EventArgs eventArgs)
        {
            var textBox = (NumericUpDown)sender;
            textBox.Select(0, textBox.Value.ToString().Length);
            textBox.Focus();
        }

        private void BtnCancelCheckout_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ComputeTotalWithDiscount()
        {
            IsDiscountPercentage = CBoxUsePercentageInDiscount.Checked;
            Discount = NumUpDownDiscountValue.Value;

            if (IsDiscountPercentage)
            {
                var discountPercentage = Discount / 100;

                DiscountPercent = discountPercentage;
                Discount = SubTotal * discountPercentage;
            }

            if (Discount > SubTotal)
            {
                MessageBox.Show("Invalid dicount", "Compute discount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Total = SubTotal - Discount;
            LblTotal.Text = Total.ToString("#,##0.##");
            LblDiscountTotal.Text = Discount.ToString("#,##0.##");

            CashTotal = NumUpDnCustomerCash.Value;

            decimal dueTotal = Total - CashTotal;
            decimal changeTotal = CashTotal - Total;

            DueTotal = dueTotal > 0 ? dueTotal : 0;
            ChangeTotal = changeTotal > 0 ? changeTotal : 0;

            TboxChange.Text = ChangeTotal.ToString("#,##0.##");
            TboxDue.Text =  DueTotal.ToString("#,##0.##");
        }

        private void NumUpDownDiscountValue_KeyUp(object sender, KeyEventArgs e)
        {
            ComputeTotalWithDiscount();
        }

        private void CBoxUsePercentageInDiscount_CheckedChanged(object sender, EventArgs e)
        {
            ComputeTotalWithDiscount();
        }

        private void NumUpDnCustomerCash_KeyUp(object sender, KeyEventArgs e)
        {
            ComputeTotalWithDiscount();
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (this.CashTotal == 0 || this.DueTotal > 0)
            {
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Continue on checkout?", "Checkout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                _pOSState.CurrentSaleTransaction.SubTotalAmount = this.SubTotal;
                _pOSState.CurrentSaleTransaction.DiscountAmount = this.Discount;
                _pOSState.CurrentSaleTransaction.DiscountIsPercentage = this.IsDiscountPercentage;
                _pOSState.CurrentSaleTransaction.DiscountPercent = this.DiscountPercent;
                _pOSState.CurrentSaleTransaction.TotalAmount = this.Total;
                _pOSState.CurrentSaleTransaction.CustomerCashAmount = this.CashTotal;
                _pOSState.CurrentSaleTransaction.CustomerChangeAmount = this.ChangeTotal;
                _pOSState.CurrentSaleTransaction.CustomerDueAmount = this.DueTotal;

                var checkoutResults = _iPOSCommandController.Checkout(_pOSState.CurrentSaleTransaction);

                string resMsg = "";
                foreach (var msg in checkoutResults.Messages)
                {
                    resMsg += msg;
                }

                if (checkoutResults.IsSuccess)
                {
                    // print receipt here
                    PopulateReceiptRootObject();
                    CashReceipt();

                    MessageBox.Show(resMsg, "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.IsSuccessfulCheckout = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(resMsg, "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.IsSuccessfulCheckout = false;
                }
            }
        }



        // Print methods:

        public void PopulateReceiptRootObject()
        {
            ReceiptRootObject receiptRootObject = new();

            receiptRootObject.Header = new()
            {
                StoreName = "Chonoland Hils Cafe",
                Phone = "",
                Address = "Nabunturan, Davao de Oro",
                Cashier = _sessions.CurrentLoggedInUser.FullName,
                Number = _pOSState.CurrentSaleTransaction.TransactionType == EntitiesShared.StaticData.POSTransactionType.DineIn ? _pOSState.CurrentSaleTransaction.TableNumberStr : _pOSState.CurrentSaleTransaction.TakeOutNumberStr,
                City = "Davao de Oro",
                BillNo = _pOSState.CurrentSaleTransaction.TicketNumber,
                DateOfBill = DateTime.Now.ToShortDateString(),
                TimeOfBill = DateTime.Now.ToShortTimeString()
            };

            receiptRootObject.Settings = new()
            {
                PrinterName = "Microsoft XPS Document Writer",
                PrinterType = "Default",
                ItemLength = 40,
                PrintLogo = true,
                ThankYouNote = "Thank you for choosing to order from us.",
                EIDRMK = "Thank you",
                PrintType = "Cash"
            };


            receiptRootObject.Total = _pOSState.CurrentSaleTransaction.SubTotalAmount.ToString();
            receiptRootObject.GrandTotal = _pOSState.CurrentSaleTransaction.TotalAmount.ToString();

            receiptRootObject.BillSummary = new List<BillSummary>();
            receiptRootObject.BillSummary.Add(new BillSummary { key = "Discount", value = _pOSState.CurrentSaleTransaction.DiscountAmount.ToString() });

            receiptRootObject.CustomerInfo = new();
            receiptRootObject.CustomerInfo.Name = _pOSState.CurrentSaleTransaction.CustomerName;
            receiptRootObject.CustomerInfo.CashAmount = _pOSState.CurrentSaleTransaction.CustomerCashAmount.ToString();

            List<ReceiptItem> receiptItems = new List<ReceiptItem>();
            int counter = 1;
            foreach (var prod in _pOSState.CurrentSaleTransactionProducts)
            {
                receiptItems.Add(new ReceiptItem
                {
                    No = counter,
                    ItemAmt = prod.totalAmount.ToString(),
                    ItemName = prod.Product.ProdName,
                    Qty = prod.Qty
                });

                counter += 1;
            }

            foreach (var comboMeal in _pOSState.CurrentSaleTransactionComboMeals)
            {
                receiptItems.Add(new ReceiptItem
                {
                    No = counter,
                    ItemAmt = comboMeal.totalAmount.ToString(),
                    ItemName = comboMeal.ComboMeal.Title,
                    Qty = comboMeal.Qty
                });

                counter += 1;
            }

            receiptRootObject.Items = receiptItems;

            ReceiptReportData = receiptRootObject;
        }

        private void CashReceipt()
        {
            itemIndex = 0;
            pageNum = 1;
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = ReceiptReportData.Settings.PrinterName;
            printDocument.PrinterSettings.PrintToFile = _otherSettings.IsPOSReceiptAutoSave;
            printDocument.PrinterSettings.PrintFileName =  $"{_otherSettings.POSReceiptFileLoc}{DateTime.Now.ToString("yyMMddHHmmssffftt")}.oxps";
            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt);

            printDocument.Print();
        }

        public static void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //this prints the reciept
            var pageSetting = PageSizeSettingsList.Where(i => i.PageSize == ReceiptReportData.Settings.PageSize).FirstOrDefault();

            Graphics graphic = e.Graphics;

            Font font = new Font(pageSetting.PageSetting.CashItemFontName, pageSetting.PageSetting.CashItemFontSize); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();
            height = e.PageSettings.PaperSize.Height - 12;

            int startX = pageSetting.PageSetting.XPoint;
            int startY = pageSetting.PageSetting.YPoint;
            int offset = pageSetting.PageSetting.Offset;
            startY = 10;
            Rectangle rect;
            if (File.Exists(Environment.ExpandEnvironmentVariables("%allusersprofile%") + "/DefaultPrinter/logo.jpg"))
            {
                //rect = new Rectangle(5, startY, pageSetting.PageSetting.LogoWidth, pageSetting.PageSetting.LogoHeight);
                var image = Image.FromFile(Environment.ExpandEnvironmentVariables("%allusersprofile%") + "/DefaultPrinter/logo.jpg");
                graphic.DrawImage(image, pageSetting.PageSetting.LogoXPoint, startY, pageSetting.PageSetting.LogoWidth, pageSetting.PageSetting.LogoHeight);

                offset = offset + pageSetting.PageSetting.LogoHeight;
            }

            rect = new Rectangle(5, startY + offset, pageSetting.PageSetting.RecWidth, 20);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;

            if (pageNum == 1)
            {
                // Header:

                //Rectangle rect = new Rectangle(5, startY,   POS_PrintUsingPrintDocument.Properties.Settings.Default.ItemWidth, 20);
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                graphic.DrawString(ReceiptReportData.Header.StoreName, new Font(pageSetting.PageSetting.HeaderCashFontName, pageSetting.PageSetting.HeaderCashFontSize, FontStyle.Bold), Brushes.Black, rect, sf);
                offset = offset + (int)fontHeight + 5;

                if (ReceiptReportData.Header.Address != null)
                {
                    rect.Y = startY + offset;
                    graphic.DrawString(ReceiptReportData.Header.Address, new Font(pageSetting.PageSetting.SubHeaderFontName, pageSetting.PageSetting.SubHeaderFontSize), new SolidBrush(Color.Black), rect, format);
                    offset = offset + (int)fontHeight + 5;
                }

                if (ReceiptReportData.Header.City != null)
                {
                    rect.Y = startY + offset;
                    graphic.DrawString(ReceiptReportData.Header.City, new Font(pageSetting.PageSetting.SubHeaderFontName, pageSetting.PageSetting.SubHeaderFontSize), new SolidBrush(Color.Black), rect, format);
                    offset = offset + (int)fontHeight + 5;
                }

                if (ReceiptReportData.Header.Phone != null)
                {
                    rect.Y = startY + offset;
                    graphic.DrawString(ReceiptReportData.Header.Phone, new Font(pageSetting.PageSetting.SubHeaderFontName, pageSetting.PageSetting.SubHeaderFontSize), new SolidBrush(Color.Black), rect, format);
                    offset = offset + (int)fontHeight + 5;
                }


                graphic.DrawString("-------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + (int)fontHeight + 5;

                Font fontBoldnBig = new Font(pageSetting.PageSetting.CashItemFontName, pageSetting.PageSetting.BillNoRowFontSize, FontStyle.Bold); //must use a mono spaced font as the spaces need to line up


                if (ReceiptReportData.CustomerInfo != null)
                {

                    graphic.DrawString(string.Format("{0,-" + (ReceiptReportData.Settings.ItemLength + 6 + 9) + "}", "Customer: " + ReceiptReportData.CustomerInfo.Name), new Font(pageSetting.PageSetting.CashItemFontName, pageSetting.PageSetting.CashItemFontSize), new SolidBrush(Color.Black), startX, startY + offset);
                    graphic.DrawString(string.Format("{0,-" + "26".ToString() + "}", "Bill No: " + ReceiptReportData.Header.BillNo), new Font(pageSetting.PageSetting.CashItemFontName, pageSetting.PageSetting.CashItemFontSize), new SolidBrush(Color.Black), startX + 180, startY + offset);
                    offset = offset + (int)fontHeight + 3;


                    rect = new Rectangle(startX + pageSetting.PageSetting.QuantityPoint - 10, startY + offset, 140, 20);
                    StringFormat sfright = new StringFormat();
                    sfright.LineAlignment = StringAlignment.Far;
                    sfright.Alignment = StringAlignment.Far;

                    //graphic.DrawString(string.Format("{0,-" + (ReceiptReportData.Settings.ItemLength + 6 + 9) + "}\n", "Bill No: " + ReceiptReportData.Header.BillNo), fontBoldnBig, new SolidBrush(Color.Black), startX, startY + offset);
                    //graphic.DrawString(string.Format("{0,9:N2}\n", "Date: " + ReceiptReportData.Header.DateOfBill), fontBoldnBig, new SolidBrush(Color.Black), rect, sfright);
                    //offset = offset + (int)fontHeight + 5;


                    graphic.DrawString(string.Format("{0,-" + (ReceiptReportData.Settings.ItemLength + 6 + 9) + "}", $"Cashier: {ReceiptReportData.Header.Cashier}"), new Font(pageSetting.PageSetting.CashItemFontName, pageSetting.PageSetting.CashItemFontSize), new SolidBrush(Color.Black), startX, startY + offset);
                    graphic.DrawString(string.Format("{0,-" + "26".ToString() + "}", "Date: " + ReceiptReportData.Header.DateOfBill), new Font(pageSetting.PageSetting.CashItemFontName, pageSetting.PageSetting.CashItemFontSize), new SolidBrush(Color.Black), startX + 180, startY + offset);
                    offset = offset + (int)fontHeight + 3;

                    graphic.DrawString(string.Format("{0,-" + (ReceiptReportData.Settings.ItemLength + 6 + 9) + "}", $"Number: {ReceiptReportData.Header.Number}"), new Font(pageSetting.PageSetting.CashItemFontName, pageSetting.PageSetting.CashItemFontSize), new SolidBrush(Color.Black), startX, startY + offset);
                    graphic.DrawString(string.Format("{0,-" + "26".ToString() + "}", "Time: " + ReceiptReportData.Header.TimeOfBill), new Font(pageSetting.PageSetting.CashItemFontName, pageSetting.PageSetting.CashItemFontSize), new SolidBrush(Color.Black), startX + 180, startY + offset);
                    offset = offset + (int)fontHeight + 3;

                }


                graphic.DrawString("-------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + (int)fontHeight + 5;



                rect = new Rectangle(pageSetting.PageSetting.XPoint, startY + offset, pageSetting.PageSetting.RecWidth, 20);
                sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Near;
                startY = 10;

                Font fontBold = new Font(pageSetting.PageSetting.CashItemFontName, pageSetting.PageSetting.CashItemFontSize, FontStyle.Bold); //must use a mono spaced font as the spaces need to line up

                graphic.DrawString(string.Format("{0,-" + "26".ToString() + "}", "Menu Item"), fontBold, Brushes.Black, rect, sf);
                sf.Alignment = StringAlignment.Far;
                rect = new Rectangle(startX + pageSetting.PageSetting.QuantityPoint, startY + offset, 35, 20);
                graphic.DrawString(string.Format("{0,6}", "Qty"), fontBold, Brushes.Black, rect, sf);
                rect = new Rectangle(startX + pageSetting.PageSetting.PricePoint, startY + offset, 60, 20);
                graphic.DrawString(string.Format("{0,9}", "Rate"), fontBold, Brushes.Black, rect, sf);
                rect = new Rectangle(startX + pageSetting.PageSetting.AmountPoint, startY + offset, 90, 20);
                graphic.DrawString(string.Format("{0,9}", "Amount"), fontBold, Brushes.Black, rect, sf);

                offset = offset + (int)fontHeight + 5;
                pageNum = pageNum + 1;
            }

            graphic.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            while (itemIndex < ReceiptReportData.Items.Count && startY + offset <= height)
            {
                ReceiptItem item = ReceiptReportData.Items[itemIndex];
                offset = ItemFormat(item, graphic, font, fontHeight, startX, startY, offset, pageSetting);
                itemIndex = itemIndex + 1;
            }

            if (itemIndex == ReceiptReportData.Items.Count && startY + offset <= height)
            {
                graphic.DrawString("-------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + (int)fontHeight + 5;

                Font fontBoldnBig = new Font(pageSetting.PageSetting.CashItemFontName, pageSetting.PageSetting.BillNoRowFontSize, FontStyle.Bold); //must use a mono spaced font as the spaces need to line up

                rect = new Rectangle(startX + pageSetting.PageSetting.TotalPoint, startY + offset, pageSetting.PageSetting.WidthSummary, 20);
                StringFormat sfright = new StringFormat();
                sfright.LineAlignment = StringAlignment.Far;
                sfright.Alignment = StringAlignment.Far;

                graphic.DrawString(string.Format("{0,-" + (ReceiptReportData.Settings.ItemLength + 6 + 9) + "}\n", "Total"), fontBoldnBig, new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString(string.Format("{0,9:N2}\n", ReceiptReportData.Total), fontBoldnBig, new SolidBrush(Color.Black), rect, sfright);
                offset = offset + (int)fontHeight + 5;

                graphic.DrawString("-------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + (int)fontHeight + 5;

                Font fontBold = new Font(pageSetting.PageSetting.CashItemFontName, pageSetting.PageSetting.CashItemFontSize, FontStyle.Bold); //must use a mono spaced font as the spaces need to line up

                var sfSummary = new StringFormat();
                sfSummary.LineAlignment = StringAlignment.Center;
                sfSummary.Alignment = StringAlignment.Near;
                sfSummary.Alignment = StringAlignment.Far;
                foreach (var summary in ReceiptReportData.BillSummary)
                {
                    graphic.DrawString(string.Format("{0,-" + "26".ToString() + "}", summary.key), fontBold, new SolidBrush(Color.Black), startX, startY + offset);
                    rect = new Rectangle(startX + pageSetting.PageSetting.AmountPoint, startY + offset, 90, 20);
                    graphic.DrawString(string.Format("{0,9:N2}", summary.value), fontBold, new SolidBrush(Color.Black), rect, sfSummary);
                    offset = offset + (int)fontHeight + 5;
                }

                if (ReceiptReportData.BillSummary != null && ReceiptReportData.BillSummary.Count > 0)
                {
                    graphic.DrawString("-------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight + 5;
                }

                rect = new Rectangle(startX + pageSetting.PageSetting.TotalPoint, startY + offset, pageSetting.PageSetting.WidthSummary, 20);

                graphic.DrawString(string.Format("{0,-" + (ReceiptReportData.Settings.ItemLength + 6 + 9) + "}\n", "Grand Total"), fontBoldnBig, new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString(string.Format("{0,9:N2}\n", ReceiptReportData.GrandTotal), fontBoldnBig, new SolidBrush(Color.Black), rect, sfright);
                offset = offset + (int)fontHeight + 5;

                graphic.DrawString("-------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + (int)fontHeight + 5;

                rect.X = startX;
                rect.Width = pageSetting.PageSetting.AmountPoint + 90;
                rect.Y = startY + offset;

                graphic.DrawString(ReceiptReportData.Settings.ThankYouNote, new Font(pageSetting.PageSetting.CashItemFontName, 10), new SolidBrush(Color.Black), rect, format);
                offset = offset + (int)fontHeight + 5;
                if (!string.IsNullOrEmpty(ReceiptReportData.Settings.ThankYouNote2))
                {
                    rect.Y = startY + offset;
                    graphic.DrawString(ReceiptReportData.Settings.ThankYouNote2, new Font(pageSetting.PageSetting.CashItemFontName, 10), new SolidBrush(Color.Black), rect, format);
                    offset = offset + (int)fontHeight + 5;
                }
                rect.Height = 35;
                rect.Y = startY + offset;
                offset = offset + (int)fontHeight + 5;
                graphic.DrawString(ReceiptReportData.Settings.ThankYouNote, new Font("Bauhaus 93", 14), new SolidBrush(Color.Black), rect, format);
                rect.Y = startY + offset;
                offset = offset + (int)fontHeight + 5;
                graphic.DrawString(ReceiptReportData.Settings.ThankYouNote, new Font("Bodoni MT Poster Compressed", 14), new SolidBrush(Color.Black), rect, format);
                rect.Y = startY + offset;
                offset = offset + (int)fontHeight + 5;
                graphic.DrawString(ReceiptReportData.Settings.ThankYouNote, new Font("Brush Script MT", 14), new SolidBrush(Color.Black), rect, format);
                rect.Y = startY + offset;
                offset = offset + (int)fontHeight + 5;
                rect.Height = 50;
                graphic.DrawString(ReceiptReportData.Settings.ThankYouNote, new Font("test", 14), new SolidBrush(Color.Black), rect, format);
                offset = offset + (int)fontHeight + 5;
                printPage = true;
            }

            if (startY + offset < height || printPage == true)
            {
                e.HasMorePages = false;
            }
            else
            {
                e.HasMorePages = true;
            }

        }

        //This function split item name into multiple lines depending upon length parameter
        public static string getStrSplit(string x, int length)
        {
            string result = string.Empty;
            if (x.Length <= length)
            {
                return x;
            }
            else
            {
                var sub = x.Substring(0, length);
                result += sub + "\n" + getStrSplit(x.Replace(sub, ""), length);
            }

            return result;
        }

        public static int ItemFormat(ReceiptItem item, Graphics graphic, Font font, float fontHeight, int startX, int startY, int offset, PageSizeSettings pageSetting)
        {
            StringFormat sFormat = new StringFormat(StringFormat.GenericTypographic);
            sFormat.Trimming = StringTrimming.None;
            sFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
            var outStr = getStrSplit(item.ItemName, pageSetting.PageSetting.ItemLength);
            var outlst = outStr.Split('\n').ToList();

            Rectangle rect = new Rectangle(pageSetting.PageSetting.XPoint, startY + offset, pageSetting.PageSetting.RecWidth, 20);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Near;
            startY = 10;
            graphic.DrawString(string.Format("{0,-" + pageSetting.PageSetting.ItemLength.ToString() + "}", outlst[0]), font, Brushes.Black, rect, sf);
            sf.Alignment = StringAlignment.Far;
            rect = new Rectangle(startX + pageSetting.PageSetting.QuantityPoint, startY + offset, 30, 20);
            graphic.DrawString(string.Format("{0,6}", item.Qty), font, Brushes.Black, rect, sf);
            rect = new Rectangle(startX + pageSetting.PageSetting.PricePoint, startY + offset, 60, 20);
            graphic.DrawString(string.Format("{0,9}", item.Rate), font, Brushes.Black, rect, sf);
            rect = new Rectangle(startX + pageSetting.PageSetting.AmountPoint, startY + offset, 90, 20);
            graphic.DrawString(string.Format("{0,9}", item.ItemAmt), font, Brushes.Black, rect, sf);

            offset = offset + (int)fontHeight + 5;
            sf.Alignment = StringAlignment.Near;
            if (outlst.Count > 1)
            {
                int skip = 1;
                foreach (var i in outlst.Skip(skip))
                {
                    rect = new Rectangle(pageSetting.PageSetting.XPoint, startY + offset, pageSetting.PageSetting.RecWidth, 20);

                    graphic.DrawString(string.Format("{0,-" + "50".ToString() + "}", i), font, Brushes.Black, rect, sf);
                    offset = offset + (int)fontHeight + 5;
                    skip = skip + 1;
                }
            }

            if (!string.IsNullOrEmpty(item.CustRmks))
            {
                var outStrRmk = getStrSplit("Customer Remark: " + item.CustRmks, pageSetting.PageSetting.KitchenItemLength);
                var outlstRmk = outStrRmk.Split('\n').ToList();

                rect = new Rectangle(pageSetting.PageSetting.XPoint, startY + offset, pageSetting.PageSetting.RecWidth, 20);
                graphic.DrawString(string.Format("{0,-" + pageSetting.PageSetting.KitchenItemLength.ToString() + "}", outlstRmk[0]), font, Brushes.Black, rect, sf);
                offset = offset + (int)fontHeight + 5;


                if (outlstRmk.Count > 1)
                {
                    int skip = 1;

                    foreach (var i in outlstRmk.Skip(skip))
                    {
                        rect = new Rectangle(pageSetting.PageSetting.XPoint, startY + offset, pageSetting.PageSetting.RecWidth, 20);

                        graphic.DrawString(string.Format("{0,-" + pageSetting.PageSetting.KitchenItemLength.ToString() + "}", i), font, Brushes.Black, rect, sf);
                        offset = offset + (int)fontHeight + 5;
                        skip = skip + 1;
                    }
                }
            }


            return offset;
        }
    }
}
