using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared.POSManagement.CustomModels;
using LiveCharts;
using LiveCharts.Wpf;
using Main.Controllers.POSControllers.ControllerInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.SalesReport
{
    public partial class FrmSalesReport : Form
    {
        private readonly ISaleTransactionData _saleTransactionData;
        private readonly ISaleTranProdIngInvDeductionsRecordData _saleTranProdIngInvDeductionsRecordData;
        private readonly ISaleTranComboMealIngInvDeductionsRecordData _saleTranComboMealIngInvDeductionsRecordData;
        private Dictionary<int, string> _months = new Dictionary<int, string>();

        public Dictionary<int, string> Months
        {
            get { return _months; }
            set { _months = value; }
        }

        private const string _currencyFormat = "#,##0.##";

        public FrmSalesReport(ISaleTransactionData saleTransactionData,
                            ISaleTranProdIngInvDeductionsRecordData saleTranProdIngInvDeductionsRecordData,
                            ISaleTranComboMealIngInvDeductionsRecordData saleTranComboMealIngInvDeductionsRecordData)
        {
            InitializeComponent();


            //SetChart();
            _saleTransactionData = saleTransactionData;
            _saleTranProdIngInvDeductionsRecordData = saleTranProdIngInvDeductionsRecordData;
            _saleTranComboMealIngInvDeductionsRecordData = saleTranComboMealIngInvDeductionsRecordData;


            Months.Add(1, "January");
            Months.Add(2, "February");
            Months.Add(3, "March");
            Months.Add(4, "April");
            Months.Add(5, "May");
            Months.Add(6, "June");
            Months.Add(7, "July");
            Months.Add(8, "August");
            Months.Add(9, "September");
            Months.Add(10, "October");
            Months.Add(11, "November");
            Months.Add(12, "December");
        }



        private void FrmSalesReport_Load(object sender, EventArgs e)
        {
            DisplayYearsInFlowLayout();
            DefaultDisplayValues();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            DisplayYearsInFlowLayout();
            DefaultDisplayValues();
        }

        public void DisplayYearsInFlowLayout()
        {
            List<YearSalesReportModel> salesReports = new List<YearSalesReportModel>();

            salesReports = _saleTransactionData.GetYearlySalesReport();

            foreach (var report in salesReports)
            {
                var chbx = new CheckBox();
                chbx.Name = $"Year_{report.Yr}";
                chbx.Text = $"{report.Yr}";
                FlowLayoutCheckBoxYears.Controls.Add(chbx);
            }
        }

        public int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }


        public void DefaultDisplayValues()
        {
            DateTime dateNow = DateTime.Now;
            int currentWeekNum = this.GetIso8601WeekOfYear(dateNow);

            GetAndDisplayNumberOfTransaction(dateNow.Year);
            this.GetAndDisplayYearRevenueProfitAndCost(dateNow.Year);
            this.GetAndDisplayMonthlyRevenueProfitAndCost(dateNow.Year, dateNow.Month);
            this.GetAndDisplayWeeklyRevenueProfitAndCost(dateNow.Year, currentWeekNum);

            DisplayMonthlyBarCharByYear(dateNow.Year);

            //var temp = GetMonthlyReportCollection(2020);
            //cartesianChart1.Series.Add(temp.Item2);
            //DisplayWeeklyBarCharByYear(dateNow.Year);
            //DisplayYearlyBarCharByYear();
        }

        #region Header sales report

        public void GetAndDisplayNumberOfTransaction(int year)
        {
            var transactionsCounter = _saleTransactionData.GetNumberOfValidTransactionsByYear(year, EntitiesShared.StaticData.POSTransactionStatus.Paid);
            this.LblNumberOfTransactionsByYear.Text = transactionsCounter.ToString();
            this.LblNumberOfTransactionsWhatFor.Text = year.ToString();
        }

        public void GetAndDisplayYearRevenueProfitAndCost(int year)
        {
            var report = _saleTransactionData.GetSalesReportByYear(year);

            if (report != null)
            {
                this.LblYearlySaleReportAmount.Text = report.TotalSales.ToString(_currencyFormat);
                this.LblYearlySaleReportWhatYear.Text = report.Yr.ToString();

                // profit and cost here
                var product_yearlyCost = _saleTranProdIngInvDeductionsRecordData.GetTotalCostByYear(year);
                var comboMeal_yearlyCost = _saleTranComboMealIngInvDeductionsRecordData.GetTotalCostByYear(year);

                decimal totalCost = (product_yearlyCost.TotalCost + comboMeal_yearlyCost.TotalCost);
                decimal profit = report.TotalSales - totalCost;

                LblYearlyProfit.Text = profit.ToString(_currencyFormat);
                LblYearlyCost.Text = totalCost.ToString(_currencyFormat);

            }
            else
            {
                this.LblYearlySaleReportAmount.Text = "0";
                this.LblYearlySaleReportWhatYear.Text = "Not found!";
                LblYearlyCost.Text = "0";
                LblYearlyProfit.Text = "0";
            }
        }

        public void GetAndDisplayMonthlyRevenueProfitAndCost(int year, int month)
        {
            var report = _saleTransactionData.GetSalesReportYearAndMonth(year, month);

            if (report != null)
            {
                this.LblMonthlySaleReportAmount.Text = report.TotalSales.ToString(_currencyFormat);
                this.LblMonthlySaleReportWhatFor.Text = this.Months[report.Mnth].ToUpper();

                // profit and cost here
                var product_monthlyCost = _saleTranProdIngInvDeductionsRecordData.GetTotalCostByYearAndMonth(year, month);
                var comboMeal_monthlyCost = _saleTranComboMealIngInvDeductionsRecordData.GetTotalCostByYearAndMonth(year, month);

                decimal totalCost = (product_monthlyCost.TotalCost + comboMeal_monthlyCost.TotalCost);
                decimal profit = report.TotalSales - totalCost;

                LblMonthlyProfit.Text = profit.ToString(_currencyFormat);
                LblMonthlyCost.Text = totalCost.ToString(_currencyFormat);
            }
            else
            {
                this.LblMonthlySaleReportAmount.Text = "0";
                this.LblMonthlySaleReportWhatFor.Text = "Not found!";
                LblMonthlyProfit.Text = "0";
                LblMonthlyCost.Text = "0";
            }
        }

        public void GetAndDisplayWeeklyRevenueProfitAndCost(int year, int week)
        {
            var report = _saleTransactionData.GetWeeklySalesReportByYearAndWeek(year, week);

            if (report != null)
            {
                this.LblWeeklySaleReportAmount.Text = report.TotalSales.ToString(_currencyFormat);
                this.LblWeeklySaleReportWhatFor.Text = $"WK-{report.Wk}";

                // profit and cost here
                var product_weeklyCost = _saleTranProdIngInvDeductionsRecordData.GetTotalCostByYearAndWeek(year, week);
                var comboMeal_weeklyCost = _saleTranComboMealIngInvDeductionsRecordData.GetTotalCostByYearAndWeek(year, week);

                decimal totalCost = (product_weeklyCost.TotalCost + comboMeal_weeklyCost.TotalCost);
                decimal profit = report.TotalSales - totalCost;

                LblWeeklyProfit.Text = profit.ToString(_currencyFormat);
                LblWeeklyCost.Text = totalCost.ToString(_currencyFormat);
            }
            else
            {
                this.LblWeeklySaleReportAmount.Text = "0";
                this.LblWeeklySaleReportWhatFor.Text = "Not found!";
                LblWeeklyProfit.Text = "0";
                LblWeeklyCost.Text = "0";
            }
        }

        #endregion

        public void DisplayMonthlyBarCharByYear(int year)
        {
            cartesianChart1.Series = new SeriesCollection();

            var months = GetMonthsList();

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Months",
                Labels = months.ToArray()
            });
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sales",
                LabelFormatter = value => value.ToString("N")
            });


            var values = this.GetMonthlySalesReport(year);
            cartesianChart1.Series.Add(new ColumnSeries
            {
                Title = year.ToString(),
                Values = new ChartValues<decimal>(values)
            });
        }

        public List<int> GetSelectedYears()
        {
            List<int> yearList = new List<int>();
            foreach (var yearCkbox in FlowLayoutCheckBoxYears.Controls)
            {
                var chbox = (CheckBox)yearCkbox;
                if (chbox.Checked)
                {
                    yearList.Add(int.Parse(chbox.Text));
                }
            }
            return yearList;
        }

        public List<string> GetMonthsList()
        {
            List<string> months = new List<string>();

            foreach (var month in this.Months)
            {
                months.Add(month.Value);
            }

            return months;
        }

        public List<int> GetWeekList()
        {
            int weeksNum = 52;

            List<int> weeks = new List<int>();

            for (var wk = 1; wk < weeksNum; wk++)
            {
                weeks.Add(wk);
            }
            return weeks;
        }

        private void BtnSubmitFilter_Click(object sender, EventArgs e)
        {
            bool isYearly = RBtnFilterTrendByYear.Checked;
            bool isMonthly = RBtnFilterTrendByMonth.Checked;
            bool isWeekly = RBtnFilterTrendByWeek.Checked;

            cartesianChart1.Series = new SeriesCollection();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sales",
                LabelFormatter = value => value.ToString("N")
            });

            var selectedYears = GetSelectedYears();

            if (isYearly)
            {
                DisplayChartAndLogForYearlySalesAndCostReport(selectedYears);
            }

            if (isMonthly)
            {
                DisplayChartAndLogForMonthlySalesAndCostReport(selectedYears);
            }

            if (isWeekly)
            {
                DisplayChartAndLogForWeeklySalesAndCostReport(selectedYears);
            }
        }



        private void DisplayChartAndLogForYearlySalesAndCostReport(List<int> selectedYears)
        {
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Yearly",
                Labels = selectedYears.Select(x => x.ToString()).ToArray()
            });

            var salesReports = _saleTransactionData.GetYearlySalesReport(selectedYears.ToArray());
            var costReportFromProducts = _saleTranProdIngInvDeductionsRecordData.GetYearlyCostReport(selectedYears.ToArray());
            var costReportFromComboMeals = _saleTranComboMealIngInvDeductionsRecordData.GetYearlyCostReport(selectedYears.ToArray());

            this.LVSalesReports.Items.Clear();
            // for log
            if (salesReports != null)
            {

                decimal totalRevenue = 0;
                decimal totalCost = 0;
                decimal totalProfit = 0;

                foreach (var saleReport in salesReports)
                {
                    totalRevenue = saleReport.TotalSales;

                    if (costReportFromProducts != null)
                    {
                        var yearCost = costReportFromProducts.Where(x => x.Yr == saleReport.Yr).FirstOrDefault();

                        if (yearCost != null)
                        {
                            totalCost += yearCost.TotalCost;
                        }
                    }

                    if (costReportFromComboMeals != null)
                    {
                        var yearCost = costReportFromComboMeals.Where(x => x.Yr == saleReport.Yr).FirstOrDefault();

                        if (yearCost != null)
                        {
                            totalCost += yearCost.TotalCost;
                        }
                    }

                    totalProfit = totalRevenue - totalCost;

                    string[] row = new string[]
                    {
                            "Yearly",
                            saleReport.Yr.ToString(),
                            totalRevenue.ToString(_currencyFormat),
                            totalCost.ToString(_currencyFormat),
                            totalProfit.ToString(_currencyFormat)
                    };

                    var listViewItem = new ListViewItem(row);
                    listViewItem.Tag = saleReport;

                    this.LVSalesReports.Items.Add(listViewItem);
                }
            }

            // for chart
            if (salesReports != null)
            {
                List<string> weeks = salesReports.Select(x => x.Yr.ToString()).ToList();
                List<decimal> values = salesReports.Select(x => x.TotalSales).ToList();

                var reportSeries = new ColumnSeries
                {
                    Title = "Yearly",
                    Values = new ChartValues<decimal>(values)
                };

                cartesianChart1.Series.Add(reportSeries);
            }
        }


        private void DisplayChartAndLogForMonthlySalesAndCostReport(List<int> selectedYears)
        {
            this.LVSalesReports.Items.Clear();
            var months = GetMonthsList();

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Monthly",
                Labels = months.ToArray()
            });

            foreach (int year in selectedYears)
            {
                var values = this.GetMonthlySalesReport(year);
                cartesianChart1.Series.Add(new ColumnSeries
                {
                    Title = year.ToString(),
                    Values = new ChartValues<decimal>(values)
                });


                this.DisplayMonthlySalesAndCostReportInLog(year);
            }
        }

        public List<decimal> GetMonthlySalesReport(int year)
        {
            List<MonthSalesReportModel> monthSalesReports = _saleTransactionData.GetMonthlySalesReport(year);

            List<decimal> values = new List<decimal>();

            foreach (var month in this.Months)
            {
                var reportByCurrentMonth = monthSalesReports.Where(x => x.Mnth == month.Key).FirstOrDefault();

                if (reportByCurrentMonth != null)
                {
                    values.Add(reportByCurrentMonth.TotalSales);
                }
                else
                {
                    values.Add(0);
                }
            }

            return values;
        }

        public void DisplayMonthlySalesAndCostReportInLog(int year)
        {
            List<MonthSalesReportModel> monthSalesReports = _saleTransactionData.GetMonthlySalesReport(year);

            var monthlyCostReportFromProducts = _saleTranProdIngInvDeductionsRecordData.GetMonthlyCostReport(year);
            var monthlyCostReportFromComboMeals = _saleTranComboMealIngInvDeductionsRecordData.GetMonthlyCostReport(year);

            decimal totalRevenue = 0;
            decimal totalCost = 0;
            decimal totalProfit = 0;
            foreach (var month in this.Months)
            {
                var monthlyCostFromProd = monthlyCostReportFromProducts.Where(x => x.Mnth == month.Key).FirstOrDefault();
                var monthlyCostFromComboMeal = monthlyCostReportFromComboMeals.Where(x => x.Mnth == month.Key).FirstOrDefault();
                var monthlySale = monthSalesReports.Where(x => x.Mnth == month.Key).FirstOrDefault();

                totalCost = (monthlyCostFromProd != null ? monthlyCostFromProd.TotalCost : 0) + (monthlyCostFromComboMeal != null ? monthlyCostFromComboMeal.TotalCost : 0);

                totalRevenue = (monthlySale != null ? monthlySale.TotalSales : 0);
                totalProfit = totalRevenue - totalCost;

                if (totalProfit < 0)
                    totalProfit = 0;

                string[] row = new string[]
                    {
                        "Monthly",
                        $"{month.Value}/{year}",
                        totalRevenue.ToString(_currencyFormat),
                        totalCost.ToString(_currencyFormat),
                        totalProfit.ToString(_currencyFormat)
                    };

                var listViewItem = new ListViewItem(row);
                listViewItem.Tag = month.Key;

                this.LVSalesReports.Items.Add(listViewItem);

            }

        }

        private void DisplayChartAndLogForWeeklySalesAndCostReport(List<int> selectedYears)
        {
            this.LVSalesReports.Items.Clear();

            var weeks = GetWeekList();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Weekly",
                Labels = weeks.Select(x => x.ToString()).ToArray()
            });

            foreach (int year in selectedYears)
            {
                DisplayWeeklySalesAndCostReportInLog(year);

                var values = this.GetWeeklySalesReport(year);
                cartesianChart1.Series.Add(new ColumnSeries
                {
                    Title = year.ToString(),
                    Values = new ChartValues<decimal>(values)
                });
            }
        }


        public void DisplayWeeklySalesAndCostReportInLog(int year)
        {
            var salesReports = _saleTransactionData.GetWeeklySalesReportByYear(year);

            var weeklyCostReportFromProducts = _saleTranProdIngInvDeductionsRecordData.GetWeeklyCostReportByYear(year);
            var weeklyCostReportFromComboMeals = _saleTranComboMealIngInvDeductionsRecordData.GetWeeklyCostReportByYear(year);

            var weeks = GetWeekList();

            decimal totalRevenue = 0;
            decimal totalCost = 0;
            decimal totalProfit = 0;

            foreach (var wk in weeks)
            {
                var weeklyCostFromProd = weeklyCostReportFromProducts.Where(x => x.Wk == wk).FirstOrDefault();
                var weeklyCostFromComboMeal = weeklyCostReportFromComboMeals.Where(x => x.Wk == wk).FirstOrDefault();
                var weeklySale = salesReports.Where(x => x.Wk == wk).FirstOrDefault();

                totalCost = (weeklyCostFromProd != null ? weeklyCostFromProd.TotalCost : 0) + (weeklyCostFromComboMeal != null ? weeklyCostFromComboMeal.TotalCost : 0);

                totalRevenue = (weeklySale != null ? weeklySale.TotalSales : 0);
                totalProfit = totalRevenue - totalCost;

                if (totalProfit < 0)
                    totalProfit = 0;

                string[] row = new string[]
                    {
                        "Weekly",
                        $"W-{wk}-{year}",
                        totalRevenue.ToString(_currencyFormat),
                        totalCost.ToString(_currencyFormat),
                        totalProfit.ToString(_currencyFormat)
                    };

                var listViewItem = new ListViewItem(row);
                listViewItem.Tag = wk;

                this.LVSalesReports.Items.Add(listViewItem);
            }
        }


        public List<decimal> GetWeeklySalesReport(int year)
        {
            var salesReports = _saleTransactionData.GetWeeklySalesReportByYear(year);

            List<decimal> values = new List<decimal>();

            var weeks = GetWeekList();
            foreach (var wk in weeks)
            {
                var reportByCurrentWeek = salesReports.Where(x => x.Wk == wk).FirstOrDefault();

                if (reportByCurrentWeek != null)
                {
                    values.Add(reportByCurrentWeek.TotalSales);
                }
                else
                {
                    values.Add(0);
                }
            }

            return values;
        }

        private void panelDashboardBody_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
