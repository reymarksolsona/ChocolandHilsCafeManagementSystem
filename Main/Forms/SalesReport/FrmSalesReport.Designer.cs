
namespace Main.Forms.SalesReport
{
    partial class FrmSalesReport
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
            cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            panelReportHeader = new System.Windows.Forms.Panel();
            splitContainerHeaderReports = new System.Windows.Forms.SplitContainer();
            splitContainerHeaderReportsLeft = new System.Windows.Forms.SplitContainer();
            panelNumberOfSales = new System.Windows.Forms.Panel();
            pictureBox4 = new System.Windows.Forms.PictureBox();
            LblNumberOfTransactionsWhatFor = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            LblNumberOfTransactionsByYear = new System.Windows.Forms.Label();
            panelYearlySales = new System.Windows.Forms.Panel();
            panelYearlySalesRevProCost = new System.Windows.Forms.Panel();
            LblYearlyCost = new System.Windows.Forms.Label();
            LblYearlyProfit = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            LblYearlySaleReportWhatYear = new System.Windows.Forms.Label();
            LblYearlySaleReportAmount = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            splitContainerHeaderReportsRight = new System.Windows.Forms.SplitContainer();
            panelMonthlySales = new System.Windows.Forms.Panel();
            panel1 = new System.Windows.Forms.Panel();
            LblMonthlyCost = new System.Windows.Forms.Label();
            LblMonthlyProfit = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            LblMonthlySaleReportWhatFor = new System.Windows.Forms.Label();
            LblMonthlySaleReportAmount = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            panelWeeklySales = new System.Windows.Forms.Panel();
            panel4 = new System.Windows.Forms.Panel();
            LblWeeklyCost = new System.Windows.Forms.Label();
            LblWeeklyProfit = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            LblWeeklySaleReportWhatFor = new System.Windows.Forms.Label();
            LblWeeklySaleReportAmount = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            panelDashboardBody = new System.Windows.Forms.Panel();
            panelTransactions = new System.Windows.Forms.Panel();
            LVSalesReports = new System.Windows.Forms.ListView();
            ReportType = new System.Windows.Forms.ColumnHeader();
            ReportDate = new System.Windows.Forms.ColumnHeader();
            TotalRevenue = new System.Windows.Forms.ColumnHeader();
            TotalCost = new System.Windows.Forms.ColumnHeader();
            TotalProfit = new System.Windows.Forms.ColumnHeader();
            panel3 = new System.Windows.Forms.Panel();
            label36 = new System.Windows.Forms.Label();
            splitContainerCharts = new System.Windows.Forms.SplitContainer();
            panelSalesTrend = new System.Windows.Forms.Panel();
            panelMainChart = new System.Windows.Forms.Panel();
            label31 = new System.Windows.Forms.Label();
            BtnRefresh = new System.Windows.Forms.Button();
            BtnSubmitFilter = new System.Windows.Forms.Button();
            RBtnFilterTrendByWeek = new System.Windows.Forms.RadioButton();
            FlowLayoutCheckBoxYears = new System.Windows.Forms.FlowLayoutPanel();
            RBtnFilterTrendByYear = new System.Windows.Forms.RadioButton();
            RBtnFilterTrendByMonth = new System.Windows.Forms.RadioButton();
            panel2 = new System.Windows.Forms.Panel();
            label33 = new System.Windows.Forms.Label();
            panelReportHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerHeaderReports).BeginInit();
            splitContainerHeaderReports.Panel1.SuspendLayout();
            splitContainerHeaderReports.Panel2.SuspendLayout();
            splitContainerHeaderReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerHeaderReportsLeft).BeginInit();
            splitContainerHeaderReportsLeft.Panel1.SuspendLayout();
            splitContainerHeaderReportsLeft.Panel2.SuspendLayout();
            splitContainerHeaderReportsLeft.SuspendLayout();
            panelNumberOfSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panelYearlySales.SuspendLayout();
            panelYearlySalesRevProCost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerHeaderReportsRight).BeginInit();
            splitContainerHeaderReportsRight.Panel1.SuspendLayout();
            splitContainerHeaderReportsRight.Panel2.SuspendLayout();
            splitContainerHeaderReportsRight.SuspendLayout();
            panelMonthlySales.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelWeeklySales.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panelDashboardBody.SuspendLayout();
            panelTransactions.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerCharts).BeginInit();
            splitContainerCharts.Panel1.SuspendLayout();
            splitContainerCharts.Panel2.SuspendLayout();
            splitContainerCharts.SuspendLayout();
            panelSalesTrend.SuspendLayout();
            panelMainChart.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // cartesianChart1
            // 
            cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            cartesianChart1.Location = new System.Drawing.Point(0, 0);
            cartesianChart1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new System.Drawing.Size(798, 357);
            cartesianChart1.TabIndex = 1;
            cartesianChart1.Text = "cartesianChart1";
            // 
            // panelReportHeader
            // 
            panelReportHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelReportHeader.BackColor = System.Drawing.Color.White;
            panelReportHeader.Controls.Add(splitContainerHeaderReports);
            panelReportHeader.Location = new System.Drawing.Point(14, 16);
            panelReportHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelReportHeader.MinimumSize = new System.Drawing.Size(0, 315);
            panelReportHeader.Name = "panelReportHeader";
            panelReportHeader.Size = new System.Drawing.Size(1177, 315);
            panelReportHeader.TabIndex = 2;
            // 
            // splitContainerHeaderReports
            // 
            splitContainerHeaderReports.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainerHeaderReports.Location = new System.Drawing.Point(0, 0);
            splitContainerHeaderReports.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            splitContainerHeaderReports.Name = "splitContainerHeaderReports";
            // 
            // splitContainerHeaderReports.Panel1
            // 
            splitContainerHeaderReports.Panel1.Controls.Add(splitContainerHeaderReportsLeft);
            // 
            // splitContainerHeaderReports.Panel2
            // 
            splitContainerHeaderReports.Panel2.Controls.Add(splitContainerHeaderReportsRight);
            splitContainerHeaderReports.Size = new System.Drawing.Size(1177, 315);
            splitContainerHeaderReports.SplitterDistance = 588;
            splitContainerHeaderReports.SplitterWidth = 5;
            splitContainerHeaderReports.TabIndex = 0;
            // 
            // splitContainerHeaderReportsLeft
            // 
            splitContainerHeaderReportsLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainerHeaderReportsLeft.Location = new System.Drawing.Point(0, 0);
            splitContainerHeaderReportsLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            splitContainerHeaderReportsLeft.Name = "splitContainerHeaderReportsLeft";
            // 
            // splitContainerHeaderReportsLeft.Panel1
            // 
            splitContainerHeaderReportsLeft.Panel1.BackColor = System.Drawing.Color.Gainsboro;
            splitContainerHeaderReportsLeft.Panel1.Controls.Add(panelNumberOfSales);
            splitContainerHeaderReportsLeft.Panel1.Padding = new System.Windows.Forms.Padding(11, 13, 11, 13);
            // 
            // splitContainerHeaderReportsLeft.Panel2
            // 
            splitContainerHeaderReportsLeft.Panel2.BackColor = System.Drawing.Color.Gainsboro;
            splitContainerHeaderReportsLeft.Panel2.Controls.Add(panelYearlySales);
            splitContainerHeaderReportsLeft.Panel2.Padding = new System.Windows.Forms.Padding(11, 13, 11, 13);
            splitContainerHeaderReportsLeft.Size = new System.Drawing.Size(588, 315);
            splitContainerHeaderReportsLeft.SplitterDistance = 293;
            splitContainerHeaderReportsLeft.SplitterWidth = 5;
            splitContainerHeaderReportsLeft.TabIndex = 0;
            // 
            // panelNumberOfSales
            // 
            panelNumberOfSales.BackColor = System.Drawing.Color.White;
            panelNumberOfSales.Controls.Add(pictureBox4);
            panelNumberOfSales.Controls.Add(LblNumberOfTransactionsWhatFor);
            panelNumberOfSales.Controls.Add(label12);
            panelNumberOfSales.Controls.Add(LblNumberOfTransactionsByYear);
            panelNumberOfSales.Dock = System.Windows.Forms.DockStyle.Fill;
            panelNumberOfSales.Location = new System.Drawing.Point(11, 13);
            panelNumberOfSales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelNumberOfSales.Name = "panelNumberOfSales";
            panelNumberOfSales.Size = new System.Drawing.Size(271, 289);
            panelNumberOfSales.TabIndex = 0;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.icons8_total_sales_641;
            pictureBox4.Location = new System.Drawing.Point(18, 56);
            pictureBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(86, 100);
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 8;
            pictureBox4.TabStop = false;
            // 
            // LblNumberOfTransactionsWhatFor
            // 
            LblNumberOfTransactionsWhatFor.AutoSize = true;
            LblNumberOfTransactionsWhatFor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            LblNumberOfTransactionsWhatFor.Location = new System.Drawing.Point(117, 108);
            LblNumberOfTransactionsWhatFor.Name = "LblNumberOfTransactionsWhatFor";
            LblNumberOfTransactionsWhatFor.Size = new System.Drawing.Size(56, 28);
            LblNumberOfTransactionsWhatFor.TabIndex = 7;
            LblNumberOfTransactionsWhatFor.Text = "2021";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label12.Location = new System.Drawing.Point(18, 12);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(229, 32);
            label12.TabIndex = 5;
            label12.Text = "NUMBER OF SALES";
            // 
            // LblNumberOfTransactionsByYear
            // 
            LblNumberOfTransactionsByYear.AutoSize = true;
            LblNumberOfTransactionsByYear.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            LblNumberOfTransactionsByYear.ForeColor = System.Drawing.Color.Green;
            LblNumberOfTransactionsByYear.Location = new System.Drawing.Point(117, 68);
            LblNumberOfTransactionsByYear.Name = "LblNumberOfTransactionsByYear";
            LblNumberOfTransactionsByYear.Size = new System.Drawing.Size(62, 37);
            LblNumberOfTransactionsByYear.TabIndex = 6;
            LblNumberOfTransactionsByYear.Text = "200";
            // 
            // panelYearlySales
            // 
            panelYearlySales.BackColor = System.Drawing.Color.White;
            panelYearlySales.Controls.Add(panelYearlySalesRevProCost);
            panelYearlySales.Controls.Add(pictureBox1);
            panelYearlySales.Controls.Add(LblYearlySaleReportWhatYear);
            panelYearlySales.Controls.Add(LblYearlySaleReportAmount);
            panelYearlySales.Controls.Add(label1);
            panelYearlySales.Dock = System.Windows.Forms.DockStyle.Fill;
            panelYearlySales.Location = new System.Drawing.Point(11, 13);
            panelYearlySales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelYearlySales.Name = "panelYearlySales";
            panelYearlySales.Size = new System.Drawing.Size(268, 289);
            panelYearlySales.TabIndex = 1;
            // 
            // panelYearlySalesRevProCost
            // 
            panelYearlySalesRevProCost.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelYearlySalesRevProCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelYearlySalesRevProCost.Controls.Add(LblYearlyCost);
            panelYearlySalesRevProCost.Controls.Add(LblYearlyProfit);
            panelYearlySalesRevProCost.Controls.Add(label15);
            panelYearlySalesRevProCost.Controls.Add(label14);
            panelYearlySalesRevProCost.Location = new System.Drawing.Point(15, 165);
            panelYearlySalesRevProCost.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelYearlySalesRevProCost.Name = "panelYearlySalesRevProCost";
            panelYearlySalesRevProCost.Size = new System.Drawing.Size(241, 110);
            panelYearlySalesRevProCost.TabIndex = 5;
            // 
            // LblYearlyCost
            // 
            LblYearlyCost.AutoSize = true;
            LblYearlyCost.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            LblYearlyCost.Location = new System.Drawing.Point(98, 25);
            LblYearlyCost.Name = "LblYearlyCost";
            LblYearlyCost.Size = new System.Drawing.Size(41, 23);
            LblYearlyCost.TabIndex = 5;
            LblYearlyCost.Text = "0,00";
            // 
            // LblYearlyProfit
            // 
            LblYearlyProfit.AutoSize = true;
            LblYearlyProfit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            LblYearlyProfit.Location = new System.Drawing.Point(98, 51);
            LblYearlyProfit.Name = "LblYearlyProfit";
            LblYearlyProfit.Size = new System.Drawing.Size(41, 23);
            LblYearlyProfit.TabIndex = 4;
            LblYearlyProfit.Text = "0,00";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label15.Location = new System.Drawing.Point(11, 25);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(54, 23);
            label15.TabIndex = 2;
            label15.Text = "COST";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label14.Location = new System.Drawing.Point(11, 51);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(68, 23);
            label14.TabIndex = 1;
            label14.Text = "PROFIT";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_calendar_96;
            pictureBox1.Location = new System.Drawing.Point(16, 56);
            pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(86, 100);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // LblYearlySaleReportWhatYear
            // 
            LblYearlySaleReportWhatYear.AutoSize = true;
            LblYearlySaleReportWhatYear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            LblYearlySaleReportWhatYear.Location = new System.Drawing.Point(114, 108);
            LblYearlySaleReportWhatYear.Name = "LblYearlySaleReportWhatYear";
            LblYearlySaleReportWhatYear.Size = new System.Drawing.Size(56, 28);
            LblYearlySaleReportWhatYear.TabIndex = 3;
            LblYearlySaleReportWhatYear.Text = "2021";
            // 
            // LblYearlySaleReportAmount
            // 
            LblYearlySaleReportAmount.AutoSize = true;
            LblYearlySaleReportAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            LblYearlySaleReportAmount.ForeColor = System.Drawing.Color.Green;
            LblYearlySaleReportAmount.Location = new System.Drawing.Point(114, 68);
            LblYearlySaleReportAmount.Name = "LblYearlySaleReportAmount";
            LblYearlySaleReportAmount.Size = new System.Drawing.Size(110, 37);
            LblYearlySaleReportAmount.TabIndex = 2;
            LblYearlySaleReportAmount.Text = "100,000";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(15, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(214, 32);
            label1.TabIndex = 0;
            label1.Text = "YEARLY REVENUE";
            // 
            // splitContainerHeaderReportsRight
            // 
            splitContainerHeaderReportsRight.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainerHeaderReportsRight.Location = new System.Drawing.Point(0, 0);
            splitContainerHeaderReportsRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            splitContainerHeaderReportsRight.Name = "splitContainerHeaderReportsRight";
            // 
            // splitContainerHeaderReportsRight.Panel1
            // 
            splitContainerHeaderReportsRight.Panel1.BackColor = System.Drawing.Color.Gainsboro;
            splitContainerHeaderReportsRight.Panel1.Controls.Add(panelMonthlySales);
            splitContainerHeaderReportsRight.Panel1.Padding = new System.Windows.Forms.Padding(11, 13, 11, 13);
            // 
            // splitContainerHeaderReportsRight.Panel2
            // 
            splitContainerHeaderReportsRight.Panel2.BackColor = System.Drawing.Color.Gainsboro;
            splitContainerHeaderReportsRight.Panel2.Controls.Add(panelWeeklySales);
            splitContainerHeaderReportsRight.Panel2.Padding = new System.Windows.Forms.Padding(11, 13, 11, 13);
            splitContainerHeaderReportsRight.Size = new System.Drawing.Size(584, 315);
            splitContainerHeaderReportsRight.SplitterDistance = 293;
            splitContainerHeaderReportsRight.SplitterWidth = 5;
            splitContainerHeaderReportsRight.TabIndex = 0;
            // 
            // panelMonthlySales
            // 
            panelMonthlySales.BackColor = System.Drawing.Color.White;
            panelMonthlySales.Controls.Add(panel1);
            panelMonthlySales.Controls.Add(pictureBox2);
            panelMonthlySales.Controls.Add(LblMonthlySaleReportWhatFor);
            panelMonthlySales.Controls.Add(LblMonthlySaleReportAmount);
            panelMonthlySales.Controls.Add(label6);
            panelMonthlySales.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMonthlySales.Location = new System.Drawing.Point(11, 13);
            panelMonthlySales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelMonthlySales.Name = "panelMonthlySales";
            panelMonthlySales.Size = new System.Drawing.Size(271, 289);
            panelMonthlySales.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(LblMonthlyCost);
            panel1.Controls.Add(LblMonthlyProfit);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Location = new System.Drawing.Point(16, 165);
            panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(239, 110);
            panel1.TabIndex = 9;
            // 
            // LblMonthlyCost
            // 
            LblMonthlyCost.AutoSize = true;
            LblMonthlyCost.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            LblMonthlyCost.Location = new System.Drawing.Point(102, 25);
            LblMonthlyCost.Name = "LblMonthlyCost";
            LblMonthlyCost.Size = new System.Drawing.Size(41, 23);
            LblMonthlyCost.TabIndex = 5;
            LblMonthlyCost.Text = "0,00";
            // 
            // LblMonthlyProfit
            // 
            LblMonthlyProfit.AutoSize = true;
            LblMonthlyProfit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            LblMonthlyProfit.Location = new System.Drawing.Point(102, 51);
            LblMonthlyProfit.Name = "LblMonthlyProfit";
            LblMonthlyProfit.Size = new System.Drawing.Size(41, 23);
            LblMonthlyProfit.TabIndex = 4;
            LblMonthlyProfit.Text = "0,00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(15, 25);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(54, 23);
            label4.TabIndex = 2;
            label4.Text = "COST";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(15, 51);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(68, 23);
            label5.TabIndex = 1;
            label5.Text = "PROFIT";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.icons8_calendar_96;
            pictureBox2.Location = new System.Drawing.Point(16, 56);
            pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(86, 100);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // LblMonthlySaleReportWhatFor
            // 
            LblMonthlySaleReportWhatFor.AutoSize = true;
            LblMonthlySaleReportWhatFor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            LblMonthlySaleReportWhatFor.Location = new System.Drawing.Point(109, 108);
            LblMonthlySaleReportWhatFor.Name = "LblMonthlySaleReportWhatFor";
            LblMonthlySaleReportWhatFor.Size = new System.Drawing.Size(62, 28);
            LblMonthlySaleReportWhatFor.TabIndex = 7;
            LblMonthlySaleReportWhatFor.Text = "APRIL";
            // 
            // LblMonthlySaleReportAmount
            // 
            LblMonthlySaleReportAmount.AutoSize = true;
            LblMonthlySaleReportAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            LblMonthlySaleReportAmount.ForeColor = System.Drawing.Color.Green;
            LblMonthlySaleReportAmount.Location = new System.Drawing.Point(109, 68);
            LblMonthlySaleReportAmount.Name = "LblMonthlySaleReportAmount";
            LblMonthlySaleReportAmount.Size = new System.Drawing.Size(110, 37);
            LblMonthlySaleReportAmount.TabIndex = 6;
            LblMonthlySaleReportAmount.Text = "100,000";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(21, 12);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(245, 32);
            label6.TabIndex = 5;
            label6.Text = "MONTHLY REVENUE";
            // 
            // panelWeeklySales
            // 
            panelWeeklySales.BackColor = System.Drawing.Color.White;
            panelWeeklySales.Controls.Add(panel4);
            panelWeeklySales.Controls.Add(pictureBox3);
            panelWeeklySales.Controls.Add(LblWeeklySaleReportWhatFor);
            panelWeeklySales.Controls.Add(LblWeeklySaleReportAmount);
            panelWeeklySales.Controls.Add(label9);
            panelWeeklySales.Dock = System.Windows.Forms.DockStyle.Fill;
            panelWeeklySales.Location = new System.Drawing.Point(11, 13);
            panelWeeklySales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelWeeklySales.Name = "panelWeeklySales";
            panelWeeklySales.Size = new System.Drawing.Size(264, 289);
            panelWeeklySales.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel4.Controls.Add(LblWeeklyCost);
            panel4.Controls.Add(LblWeeklyProfit);
            panel4.Controls.Add(label19);
            panel4.Controls.Add(label20);
            panel4.Location = new System.Drawing.Point(10, 165);
            panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(243, 110);
            panel4.TabIndex = 9;
            // 
            // LblWeeklyCost
            // 
            LblWeeklyCost.AutoSize = true;
            LblWeeklyCost.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            LblWeeklyCost.Location = new System.Drawing.Point(98, 25);
            LblWeeklyCost.Name = "LblWeeklyCost";
            LblWeeklyCost.Size = new System.Drawing.Size(41, 23);
            LblWeeklyCost.TabIndex = 5;
            LblWeeklyCost.Text = "0,00";
            // 
            // LblWeeklyProfit
            // 
            LblWeeklyProfit.AutoSize = true;
            LblWeeklyProfit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            LblWeeklyProfit.Location = new System.Drawing.Point(98, 51);
            LblWeeklyProfit.Name = "LblWeeklyProfit";
            LblWeeklyProfit.Size = new System.Drawing.Size(41, 23);
            LblWeeklyProfit.TabIndex = 4;
            LblWeeklyProfit.Text = "0,00";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label19.Location = new System.Drawing.Point(11, 25);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(54, 23);
            label19.TabIndex = 2;
            label19.Text = "COST";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label20.Location = new System.Drawing.Point(11, 51);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(68, 23);
            label20.TabIndex = 1;
            label20.Text = "PROFIT";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.icons8_calendar_96;
            pictureBox3.Location = new System.Drawing.Point(10, 56);
            pictureBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(86, 100);
            pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // LblWeeklySaleReportWhatFor
            // 
            LblWeeklySaleReportWhatFor.AutoSize = true;
            LblWeeklySaleReportWhatFor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            LblWeeklySaleReportWhatFor.Location = new System.Drawing.Point(103, 108);
            LblWeeklySaleReportWhatFor.Name = "LblWeeklySaleReportWhatFor";
            LblWeeklySaleReportWhatFor.Size = new System.Drawing.Size(70, 28);
            LblWeeklySaleReportWhatFor.TabIndex = 7;
            LblWeeklySaleReportWhatFor.Text = "WK 16";
            // 
            // LblWeeklySaleReportAmount
            // 
            LblWeeklySaleReportAmount.AutoSize = true;
            LblWeeklySaleReportAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            LblWeeklySaleReportAmount.ForeColor = System.Drawing.Color.Green;
            LblWeeklySaleReportAmount.Location = new System.Drawing.Point(103, 68);
            LblWeeklySaleReportAmount.Name = "LblWeeklySaleReportAmount";
            LblWeeklySaleReportAmount.Size = new System.Drawing.Size(110, 37);
            LblWeeklySaleReportAmount.TabIndex = 6;
            LblWeeklySaleReportAmount.Text = "100,000";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label9.Location = new System.Drawing.Point(19, 12);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(219, 32);
            label9.TabIndex = 5;
            label9.Text = "WEEKLY REVENUE";
            // 
            // panelDashboardBody
            // 
            panelDashboardBody.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelDashboardBody.AutoScroll = true;
            panelDashboardBody.BackColor = System.Drawing.Color.Gainsboro;
            panelDashboardBody.Controls.Add(panelTransactions);
            panelDashboardBody.Controls.Add(splitContainerCharts);
            panelDashboardBody.Location = new System.Drawing.Point(14, 339);
            panelDashboardBody.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelDashboardBody.Name = "panelDashboardBody";
            panelDashboardBody.Size = new System.Drawing.Size(1179, 703);
            panelDashboardBody.TabIndex = 3;
            // 
            // panelTransactions
            // 
            panelTransactions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelTransactions.Controls.Add(LVSalesReports);
            panelTransactions.Controls.Add(panel3);
            panelTransactions.Location = new System.Drawing.Point(11, 428);
            panelTransactions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelTransactions.Name = "panelTransactions";
            panelTransactions.Size = new System.Drawing.Size(1155, 261);
            panelTransactions.TabIndex = 4;
            // 
            // LVSalesReports
            // 
            LVSalesReports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { ReportType, ReportDate, TotalRevenue, TotalCost, TotalProfit });
            LVSalesReports.Dock = System.Windows.Forms.DockStyle.Fill;
            LVSalesReports.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LVSalesReports.FullRowSelect = true;
            LVSalesReports.GridLines = true;
            LVSalesReports.HideSelection = false;
            LVSalesReports.Location = new System.Drawing.Point(0, 44);
            LVSalesReports.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            LVSalesReports.Name = "LVSalesReports";
            LVSalesReports.Size = new System.Drawing.Size(1155, 217);
            LVSalesReports.TabIndex = 4;
            LVSalesReports.UseCompatibleStateImageBehavior = false;
            LVSalesReports.View = System.Windows.Forms.View.Details;
            // 
            // ReportType
            // 
            ReportType.Text = "Report Type";
            ReportType.Width = 120;
            // 
            // ReportDate
            // 
            ReportDate.Text = "Report Date";
            ReportDate.Width = 120;
            // 
            // TotalRevenue
            // 
            TotalRevenue.Text = "Revenue";
            TotalRevenue.Width = 120;
            // 
            // TotalCost
            // 
            TotalCost.Text = "Cost";
            TotalCost.Width = 120;
            // 
            // TotalProfit
            // 
            TotalProfit.Text = "Profit";
            TotalProfit.Width = 120;
            // 
            // panel3
            // 
            panel3.BackColor = System.Drawing.Color.White;
            panel3.Controls.Add(label36);
            panel3.Dock = System.Windows.Forms.DockStyle.Top;
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(1155, 44);
            panel3.TabIndex = 3;
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label36.Location = new System.Drawing.Point(5, 7);
            label36.Name = "label36";
            label36.Size = new System.Drawing.Size(197, 32);
            label36.TabIndex = 6;
            label36.Text = "TRANSACTIONS";
            // 
            // splitContainerCharts
            // 
            splitContainerCharts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            splitContainerCharts.Location = new System.Drawing.Point(11, 19);
            splitContainerCharts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            splitContainerCharts.Name = "splitContainerCharts";
            // 
            // splitContainerCharts.Panel1
            // 
            splitContainerCharts.Panel1.BackColor = System.Drawing.Color.White;
            splitContainerCharts.Panel1.Controls.Add(panelSalesTrend);
            splitContainerCharts.Panel1.Controls.Add(panelMainChart);
            // 
            // splitContainerCharts.Panel2
            // 
            splitContainerCharts.Panel2.Controls.Add(BtnRefresh);
            splitContainerCharts.Panel2.Controls.Add(BtnSubmitFilter);
            splitContainerCharts.Panel2.Controls.Add(RBtnFilterTrendByWeek);
            splitContainerCharts.Panel2.Controls.Add(FlowLayoutCheckBoxYears);
            splitContainerCharts.Panel2.Controls.Add(RBtnFilterTrendByYear);
            splitContainerCharts.Panel2.Controls.Add(RBtnFilterTrendByMonth);
            splitContainerCharts.Panel2.Controls.Add(panel2);
            splitContainerCharts.Size = new System.Drawing.Size(1154, 401);
            splitContainerCharts.SplitterDistance = 798;
            splitContainerCharts.SplitterWidth = 5;
            splitContainerCharts.TabIndex = 2;
            // 
            // panelSalesTrend
            // 
            panelSalesTrend.Controls.Add(cartesianChart1);
            panelSalesTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            panelSalesTrend.Location = new System.Drawing.Point(0, 44);
            panelSalesTrend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelSalesTrend.Name = "panelSalesTrend";
            panelSalesTrend.Size = new System.Drawing.Size(798, 357);
            panelSalesTrend.TabIndex = 3;
            // 
            // panelMainChart
            // 
            panelMainChart.Controls.Add(label31);
            panelMainChart.Dock = System.Windows.Forms.DockStyle.Top;
            panelMainChart.Location = new System.Drawing.Point(0, 0);
            panelMainChart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelMainChart.Name = "panelMainChart";
            panelMainChart.Size = new System.Drawing.Size(798, 44);
            panelMainChart.TabIndex = 2;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label31.Location = new System.Drawing.Point(5, 7);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(169, 32);
            label31.TabIndex = 6;
            label31.Text = "SALES TREND";
            // 
            // BtnRefresh
            // 
            BtnRefresh.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            BtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BtnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BtnRefresh.ForeColor = System.Drawing.Color.White;
            BtnRefresh.Image = Properties.Resources.reset_white_24;
            BtnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            BtnRefresh.Location = new System.Drawing.Point(155, 251);
            BtnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new System.Drawing.Size(117, 43);
            BtnRefresh.TabIndex = 15;
            BtnRefresh.Text = "Refresh";
            BtnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            BtnRefresh.UseVisualStyleBackColor = false;
            BtnRefresh.Click += BtnRefresh_Click;
            // 
            // BtnSubmitFilter
            // 
            BtnSubmitFilter.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            BtnSubmitFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BtnSubmitFilter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BtnSubmitFilter.ForeColor = System.Drawing.Color.White;
            BtnSubmitFilter.Image = Properties.Resources.icons8_filter_24;
            BtnSubmitFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            BtnSubmitFilter.Location = new System.Drawing.Point(155, 200);
            BtnSubmitFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            BtnSubmitFilter.Name = "BtnSubmitFilter";
            BtnSubmitFilter.Size = new System.Drawing.Size(117, 43);
            BtnSubmitFilter.TabIndex = 14;
            BtnSubmitFilter.Text = "Submit";
            BtnSubmitFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            BtnSubmitFilter.UseVisualStyleBackColor = false;
            BtnSubmitFilter.Click += BtnSubmitFilter_Click;
            // 
            // RBtnFilterTrendByWeek
            // 
            RBtnFilterTrendByWeek.AutoSize = true;
            RBtnFilterTrendByWeek.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            RBtnFilterTrendByWeek.Location = new System.Drawing.Point(155, 141);
            RBtnFilterTrendByWeek.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            RBtnFilterTrendByWeek.Name = "RBtnFilterTrendByWeek";
            RBtnFilterTrendByWeek.Size = new System.Drawing.Size(96, 32);
            RBtnFilterTrendByWeek.TabIndex = 3;
            RBtnFilterTrendByWeek.Text = "Weekly";
            RBtnFilterTrendByWeek.UseVisualStyleBackColor = true;
            // 
            // FlowLayoutCheckBoxYears
            // 
            FlowLayoutCheckBoxYears.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            FlowLayoutCheckBoxYears.AutoScroll = true;
            FlowLayoutCheckBoxYears.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            FlowLayoutCheckBoxYears.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            FlowLayoutCheckBoxYears.Location = new System.Drawing.Point(14, 59);
            FlowLayoutCheckBoxYears.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            FlowLayoutCheckBoxYears.Name = "FlowLayoutCheckBoxYears";
            FlowLayoutCheckBoxYears.Size = new System.Drawing.Size(113, 321);
            FlowLayoutCheckBoxYears.TabIndex = 4;
            // 
            // RBtnFilterTrendByYear
            // 
            RBtnFilterTrendByYear.AutoSize = true;
            RBtnFilterTrendByYear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            RBtnFilterTrendByYear.Location = new System.Drawing.Point(155, 59);
            RBtnFilterTrendByYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            RBtnFilterTrendByYear.Name = "RBtnFilterTrendByYear";
            RBtnFilterTrendByYear.Size = new System.Drawing.Size(84, 32);
            RBtnFilterTrendByYear.TabIndex = 1;
            RBtnFilterTrendByYear.Text = "Yearly";
            RBtnFilterTrendByYear.UseVisualStyleBackColor = true;
            // 
            // RBtnFilterTrendByMonth
            // 
            RBtnFilterTrendByMonth.AutoSize = true;
            RBtnFilterTrendByMonth.Checked = true;
            RBtnFilterTrendByMonth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            RBtnFilterTrendByMonth.Location = new System.Drawing.Point(155, 100);
            RBtnFilterTrendByMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            RBtnFilterTrendByMonth.Name = "RBtnFilterTrendByMonth";
            RBtnFilterTrendByMonth.Size = new System.Drawing.Size(107, 32);
            RBtnFilterTrendByMonth.TabIndex = 2;
            RBtnFilterTrendByMonth.TabStop = true;
            RBtnFilterTrendByMonth.Text = "Monthly";
            RBtnFilterTrendByMonth.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.White;
            panel2.Controls.Add(label33);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(351, 44);
            panel2.TabIndex = 3;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label33.Location = new System.Drawing.Point(14, 11);
            label33.Name = "label33";
            label33.Size = new System.Drawing.Size(73, 28);
            label33.TabIndex = 6;
            label33.Text = "FILTER";
            // 
            // FrmSalesReport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1205, 1055);
            Controls.Add(panelDashboardBody);
            Controls.Add(panelReportHeader);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "FrmSalesReport";
            Text = "FrmSalesReport";
            Load += FrmSalesReport_Load;
            panelReportHeader.ResumeLayout(false);
            splitContainerHeaderReports.Panel1.ResumeLayout(false);
            splitContainerHeaderReports.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerHeaderReports).EndInit();
            splitContainerHeaderReports.ResumeLayout(false);
            splitContainerHeaderReportsLeft.Panel1.ResumeLayout(false);
            splitContainerHeaderReportsLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerHeaderReportsLeft).EndInit();
            splitContainerHeaderReportsLeft.ResumeLayout(false);
            panelNumberOfSales.ResumeLayout(false);
            panelNumberOfSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panelYearlySales.ResumeLayout(false);
            panelYearlySales.PerformLayout();
            panelYearlySalesRevProCost.ResumeLayout(false);
            panelYearlySalesRevProCost.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            splitContainerHeaderReportsRight.Panel1.ResumeLayout(false);
            splitContainerHeaderReportsRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerHeaderReportsRight).EndInit();
            splitContainerHeaderReportsRight.ResumeLayout(false);
            panelMonthlySales.ResumeLayout(false);
            panelMonthlySales.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelWeeklySales.ResumeLayout(false);
            panelWeeklySales.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panelDashboardBody.ResumeLayout(false);
            panelTransactions.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            splitContainerCharts.Panel1.ResumeLayout(false);
            splitContainerCharts.Panel2.ResumeLayout(false);
            splitContainerCharts.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerCharts).EndInit();
            splitContainerCharts.ResumeLayout(false);
            panelSalesTrend.ResumeLayout(false);
            panelMainChart.ResumeLayout(false);
            panelMainChart.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Panel panelReportHeader;
        private System.Windows.Forms.SplitContainer splitContainerHeaderReports;
        private System.Windows.Forms.SplitContainer splitContainerHeaderReportsLeft;
        private System.Windows.Forms.SplitContainer splitContainerHeaderReportsRight;
        private System.Windows.Forms.Panel panelNumberOfSales;
        private System.Windows.Forms.Panel panelYearlySales;
        private System.Windows.Forms.Panel panelMonthlySales;
        private System.Windows.Forms.Panel panelWeeklySales;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblYearlySaleReportWhatYear;
        private System.Windows.Forms.Label LblYearlySaleReportAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label LblNumberOfTransactionsWhatFor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label LblNumberOfTransactionsByYear;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LblMonthlySaleReportWhatFor;
        private System.Windows.Forms.Label LblMonthlySaleReportAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label LblWeeklySaleReportWhatFor;
        private System.Windows.Forms.Label LblWeeklySaleReportAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelDashboardBody;
        private System.Windows.Forms.SplitContainer splitContainerCharts;
        private System.Windows.Forms.Panel panelYearlySalesRevProCost;
        private System.Windows.Forms.Label LblYearlyCost;
        private System.Windows.Forms.Label LblYearlyProfit;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panelSalesTrend;
        private System.Windows.Forms.Panel panelMainChart;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Panel panelTransactions;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.ListView LVSaleReports;
        private System.Windows.Forms.ColumnHeader ReportDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblMonthlyCost;
        private System.Windows.Forms.Label LblMonthlyProfit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label LblWeeklyCost;
        private System.Windows.Forms.Label LblWeeklyProfit;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutCheckBoxYears;
        private System.Windows.Forms.RadioButton RBtnFilterTrendByWeek;
        private System.Windows.Forms.RadioButton RBtnFilterTrendByYear;
        private System.Windows.Forms.RadioButton RBtnFilterTrendByMonth;
        private System.Windows.Forms.Button BtnSubmitFilter;
        private System.Windows.Forms.ColumnHeader ReportType;
        private System.Windows.Forms.ColumnHeader TotalRevenue;
        private System.Windows.Forms.ColumnHeader TotalCost;
        private System.Windows.Forms.ColumnHeader TotalProfit;
        private System.Windows.Forms.ListView LVSalesReports;
        private System.Windows.Forms.Button BtnRefresh;
    }
}