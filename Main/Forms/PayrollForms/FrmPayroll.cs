using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Data.EmployeeManagement.Implementations;
using DataAccess.Data.OtherDataManagement.Contracts;
using DataAccess.Data.PayrollManagement.Contracts;
using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared;
using EntitiesShared.PayrollManagement;
using GovContributionCalculators.GovContributionCalculator;
using GovContributionCalculators.Models;
using Main.Controllers.EmployeeManagementControllers.ControllerInterface;
using Main.Forms.PayrollForms.Controls;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PDFReportGenerators;
using Shared;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Main.Forms.PayrollForms
{
    public partial class FrmPayroll : Form
    {
        private readonly ILogger<FrmPayroll> _logger;
        private readonly IEmployeeData _employeeData;
        private readonly IEmployeeAttendanceData _employeeAttendanceData;
        private readonly IEmployeeLeaveData _employeeLeaveData;
        private readonly IEmployeeController _employeeController;
        private readonly IGovernmentAgencyData _governmentAgencyData;
        private readonly IEmployeeGovtIdCardData _employeeGovtIdCardData;
        private readonly IEmployeeBenefitData _employeeBenefitData;
        private readonly IEmployeeDeductionData _employeeDeductionData;
        private readonly IEmployeePayslipData _employeePayslipData;
        private readonly IEmployeePayslipBenefitData _employeePayslipBenefitData;
        private readonly IEmployeePayslipDeductionData _employeePayslipDeductionData;
        private readonly ISpecificEmployeeBenefitData _specificEmployeeBenefitData;
        private readonly ISpecificEmployeeDeductionData _specificEmployeeDeductionData;
        private readonly IEmployeeGovernmentContributionData _employeeGovernmentContributionData;
        private readonly DecimalMinutesToHrsConverter _decimalMinutesToHrsConverter;
        private readonly IEmployeePayslipPDFReport _employeePayslipPDFReport;
        private readonly IPayrollPDFReport _payrollPDFReport;
        private readonly IEmployeeGovContributionsReport _employeeGovContributionsReport;
        private readonly ICashRegisterCashOutTransactionData _cashRegisterCashOutTransactionData;
        private readonly IEmployeeCashAdvanceRequestData _employeeCashAdvanceRequestData;
        private readonly SSSContributionCalculator _sssContributionCalculator;
        private readonly WTaxCalculator _wTaxCalculator;
        private readonly PhilHealthContributionCalculator _philHealthContributionCalculator;
        private readonly PagIbigContributionCalculator _pagIbigContributionCalculator;
        private readonly PayrollSettings _payrollSettings;

        public FrmPayroll(ILogger<FrmPayroll> logger,
                            IEmployeeData employeeData,
                            IEmployeeAttendanceData employeeAttendanceData, 
                           IEmployeeLeaveData employeeLeaveData,
                           IEmployeeController employeeController,
                           IGovernmentAgencyData governmentAgencyData,
                           IEmployeeGovtIdCardData employeeGovtIdCardData,
                           IEmployeeBenefitData employeeBenefitData,
                           IEmployeeDeductionData employeeDeductionData,
                           IEmployeePayslipData employeePayslipData,
                           IEmployeePayslipBenefitData employeePayslipBenefitData,
                           IEmployeePayslipDeductionData employeePayslipDeductionData,
                           ISpecificEmployeeBenefitData specificEmployeeBenefitData,
                           ISpecificEmployeeDeductionData specificEmployeeDeductionData,
                           IEmployeeGovernmentContributionData employeeGovernmentContributionData,
                           DecimalMinutesToHrsConverter decimalMinutesToHrsConverter,
                           IEmployeePayslipPDFReport employeePayslipPDFReport,
                           IPayrollPDFReport payrollPDFReport,
                           IEmployeeGovContributionsReport employeeGovContributionsReport,
                           ICashRegisterCashOutTransactionData cashRegisterCashOutTransactionData,
                           IEmployeeCashAdvanceRequestData employeeCashAdvanceRequestData,
                           SSSContributionCalculator sssContributionCalculator,
                           WTaxCalculator wTaxCalculator,
                           PhilHealthContributionCalculator philHealthContributionCalculator,
                           PagIbigContributionCalculator pagIbigContributionCalculator,
                           IOptions<PayrollSettings> payrollSettings)
        {
            InitializeComponent();
            _logger = logger;
            _employeeData = employeeData;
            _employeeAttendanceData = employeeAttendanceData;
            _employeeLeaveData = employeeLeaveData;
            _employeeController = employeeController;
            _governmentAgencyData = governmentAgencyData;
            _employeeGovtIdCardData = employeeGovtIdCardData;
            _employeeBenefitData = employeeBenefitData;
            _employeeDeductionData = employeeDeductionData;
            _employeePayslipData = employeePayslipData;
            _employeePayslipBenefitData = employeePayslipBenefitData;
            _employeePayslipDeductionData = employeePayslipDeductionData;
            _specificEmployeeBenefitData = specificEmployeeBenefitData;
            _specificEmployeeDeductionData = specificEmployeeDeductionData;
            _employeeGovernmentContributionData = employeeGovernmentContributionData;
            _decimalMinutesToHrsConverter = decimalMinutesToHrsConverter;
            _employeePayslipPDFReport = employeePayslipPDFReport;
            _payrollPDFReport = payrollPDFReport;
            _employeeGovContributionsReport = employeeGovContributionsReport;
            _cashRegisterCashOutTransactionData = cashRegisterCashOutTransactionData;
            _employeeCashAdvanceRequestData = employeeCashAdvanceRequestData;
            _sssContributionCalculator = sssContributionCalculator;
            _wTaxCalculator = wTaxCalculator;
            _philHealthContributionCalculator = philHealthContributionCalculator;
            _pagIbigContributionCalculator = pagIbigContributionCalculator;
            _payrollSettings = payrollSettings.Value;
        }

        private List<SSSContributionTableRow> sssContributionTable;

        public List<SSSContributionTableRow> SSSContributionTable
        {
            get { return sssContributionTable; }
            set { sssContributionTable = value; }
        }

        public WTaxTable WTaxTable { get; set; }
        public PhilHealthContributionSettings PhilHealthContributionTable { get; set; }
        public PagIbigContributionSettings PagIbigContributionTable { get; set; }

        private void FrmPayroll_Load(object sender, EventArgs e)
        {
            this.SSSContributionTable = _sssContributionCalculator.GetContributionTable(_payrollSettings.GovernmentContributionTablesPath);
            this.WTaxTable = _wTaxCalculator.GetMonthlyWTaxTable(_payrollSettings.GovernmentContributionTablesPath);
            this.PhilHealthContributionTable = _philHealthContributionCalculator.GetContributionTable(_payrollSettings.GovernmentContributionTablesPath);
            this.PagIbigContributionTable = _pagIbigContributionCalculator.GetContributionTable(_payrollSettings.GovernmentContributionTablesPath);
        }

        private void CMStripPayroll_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "TStripMenuItemGenerate")
            {
                DisplayGeneratePayrollControl();

            }
            else if (clickedItem != null && clickedItem.Name == "TStripMenuItemHistory")
            {
                DisplayPayrollHistoryControl();
            }
            else if (clickedItem != null && clickedItem.Name == "TStripMenuItemReports")
            {
                DisplayPayrollReportsControl();
            }
        }

        #region Generate payroll
        public void DisplayGeneratePayrollControl()
        {
            this.panelContainer.Controls.Clear();
            var generatePayrollControlObj = new GeneratePayrollControl(_decimalMinutesToHrsConverter);
            generatePayrollControlObj.Location = new Point(this.ClientSize.Width / 2 - generatePayrollControlObj.Size.Width / 2, this.ClientSize.Height / 2 - generatePayrollControlObj.Size.Height / 2);
            generatePayrollControlObj.Anchor = AnchorStyles.None;

            generatePayrollControlObj.Benefits = _employeeBenefitData.GetAllNotDeleted();
            generatePayrollControlObj.Deductions = _employeeDeductionData.GetAllNotDeleted();

            generatePayrollControlObj.InitiatePayrollGeneration += HandleInitiatePayrollGeneration;
            generatePayrollControlObj.GenerateEmployeePayslip += GenerateEmployeePayslip;
            generatePayrollControlObj.ViewEmployeePayslip += HandleViewEmployeePayslip;
            generatePayrollControlObj.CancelAllEmployeePayslip += HandleCancelAllEmployeeGeneratedPayslip;
            generatePayrollControlObj.CancelSelectedEmployeePayslip += HandleCancelSelectedEmployeeGeneratedPayslip;
            generatePayrollControlObj.GeneratePayslipPDF += HandleGeneratePDFForAllEmployeesPayslip;

            this.panelContainer.Controls.Add(generatePayrollControlObj);
        }

        private void HandleInitiatePayrollGeneration(object sender, EventArgs e)
        {
            GeneratePayrollControl generatePayrollControlObj = (GeneratePayrollControl)sender;

            var paydate = generatePayrollControlObj.PayDate;
            var shiftStartDate = generatePayrollControlObj.ShiftStartDate;
            var shiftEndDate = generatePayrollControlObj.ShiftEndDate;

            generatePayrollControlObj.Employees = _employeeController.GetAll().Data;
            generatePayrollControlObj.AttendanceHistory = _employeeAttendanceData.GetAllUnpaidAttendanceRecordByWorkDateRange(shiftStartDate, shiftEndDate);
            generatePayrollControlObj.EmployeeLeaveHistory = _employeeLeaveData.GetAllUnpaidByDateRange(shiftStartDate.Year, shiftStartDate, shiftEndDate);
            generatePayrollControlObj.EmployeesCashAdvance = _employeeCashAdvanceRequestData.GetAllByCashReleaseDateRange(shiftStartDate, shiftEndDate);
            generatePayrollControlObj.CashRegisterTotalSales = _cashRegisterCashOutTransactionData.GetByDateRange(_payrollSettings.SaleAmoutForADayToGetSpecialBonus, shiftStartDate, shiftEndDate);
            
            generatePayrollControlObj.DisplayEmployeeWithAttendanceRecordAndSalary(generatePayrollControlObj.Employees);
            generatePayrollControlObj.DisplayEmployeeCashAdvanceRequestsInDGV();
            generatePayrollControlObj.DisplayCashRegisterTotalSalesInDGV();
        }

        private void GenerateEmployeePayslip(object sender, EventArgs e)
        {
            try
            {
                GeneratePayrollControl generatePayrollControlObj = (GeneratePayrollControl)sender;
                var employeePayslipGenerationData = generatePayrollControlObj.EmployeePayslipGenerations;

                if (employeePayslipGenerationData != null)
                {
                    bool isContinueToGenerate = true;
                    foreach (var empPayslipGen in employeePayslipGenerationData)
                    {
                        string employeeNumber = empPayslipGen.Employee.EmployeeNumber;
                        var payslipWithTheSameDate = _employeePayslipData.GetEmployeePayslipRecordByPaydate(employeeNumber, empPayslipGen.PayDate);

                        if (payslipWithTheSameDate != null)
                        {
                            MessageBox.Show($"{empPayslipGen.Employee.FullName} have existing payslip for paydate: {empPayslipGen.PayDate.ToShortDateString()}",
                                            "Generate payslip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            isContinueToGenerate = false;
                            return;
                        }
                    }

                    if (isContinueToGenerate == false)
                        return;

                    using (var transaction = new TransactionScope())
                    {
                        foreach (var empPayslipGen in employeePayslipGenerationData)
                        {
                            string employeeNumber = empPayslipGen.Employee.EmployeeNumber;

                            var currEmpSpecificBenefits = _specificEmployeeBenefitData.GetAllByEmployeeAndSubmissionDateRange(employeeNumber, empPayslipGen.ShiftStartDate, empPayslipGen.ShiftEndDate);
                            var currEmpSpecificDeductions = _specificEmployeeDeductionData.GetAllByEmployeeAndSubmissionDateRange(employeeNumber, empPayslipGen.ShiftStartDate, empPayslipGen.ShiftEndDate);

                            var newPayslipRec = new EmployeePayslipModel
                            {
                                EmployeeNumber = employeeNumber,
                                StartShiftDate = empPayslipGen.ShiftStartDate,
                                EndShiftDate = empPayslipGen.ShiftEndDate,
                                PayDate = empPayslipGen.PayDate,
                                //DailyRate = 12,
                                NumOfDays = empPayslipGen.PaydaySalaryComputation.NumberOfDays,
                                Late = empPayslipGen.PaydaySalaryComputation.Late,
                                LateTotalDeduction = empPayslipGen.PaydaySalaryComputation.LateTotalDeduction,
                                UnderTime = empPayslipGen.PaydaySalaryComputation.UnderTime,
                                UnderTimeTotalDeduction = empPayslipGen.PaydaySalaryComputation.UnderTimeTotalDeduction,
                                OverTime = empPayslipGen.PaydaySalaryComputation.OverTime,
                                OverTimeTotalRate = empPayslipGen.PaydaySalaryComputation.OverTimeTotalRate,
                                NetBasicSalary = empPayslipGen.PaydaySalaryComputation.NetBasicSalary
                            };

                            var payslipId = _employeePayslipData.Add(newPayslipRec);
                            var payslipData = _employeePayslipData.Get(payslipId);

                            if (payslipData != null)
                            {
                                var employeeGovtIds = _employeeGovtIdCardData.GetAllByEmployeeNumber(employeeNumber);

                                decimal empTotalDeductions = 0;
                                decimal empTotalBenefits = 0;
                                decimal empTotalIncome = newPayslipRec.NetBasicSalary;
                                decimal empNetTakeHomePay = 0;
                                decimal employeeGovtContributionTotal = 0;

                                // loop thru govt. agencies and retrieve employee and employer govt. id contribution
                                decimal empMonthSalary = 10000;
                                if (empPayslipGen.SelectedGovContributions != null && empPayslipGen.SelectedGovContributions.Count > 0)
                                {
                                    if (empPayslipGen.SelectedGovContributions.Contains(StaticData.GovContributions.SSS))
                                    {
                                        var empSSSId = employeeGovtIds.Where(x => x.GovtAgencyEnumVal == StaticData.GovContributions.SSS).FirstOrDefault();

                                        if (empSSSId == null)
                                        {
                                            MessageBox.Show($"{empPayslipGen.Employee.FullName} - please provide SSS id number",
                                            "Generate payslip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            transaction.Dispose();
                                            return;
                                        }

                                        var sssMonthContribution = _sssContributionCalculator
                                                                    .GetEEandERSharedContribution(this.sssContributionTable, empMonthSalary);

                                        if (sssMonthContribution != null)
                                        {
                                            decimal empContributionKinsenas = (sssMonthContribution.EE / 2);
                                            decimal emprContributionKinsenas = (sssMonthContribution.ER / 2);

                                            _employeeGovernmentContributionData.Add(new EmployeeGovernmentContributionModel
                                            {
                                                PayslipId = payslipId,
                                                EmployeeNumber = employeeNumber,
                                                Agency = StaticData.GovContributions.SSS.ToString(),
                                                GovContributionEnumVal = StaticData.GovContributions.SSS,
                                                IdNumber = empSSSId.EmployeeIdNumber,
                                                EmployeeContribution = empContributionKinsenas,
                                                EmployerContribution = emprContributionKinsenas
                                            });

                                            employeeGovtContributionTotal += sssMonthContribution.EE;
                                            empTotalDeductions += empContributionKinsenas;
                                        }
                                    }

                                    if (empPayslipGen.SelectedGovContributions.Contains(StaticData.GovContributions.PhilHealth))
                                    {
                                        var PhilHealthId = employeeGovtIds.Where(x => x.GovtAgencyEnumVal == StaticData.GovContributions.PhilHealth).FirstOrDefault();

                                        if (PhilHealthId == null)
                                        {
                                            MessageBox.Show($"{empPayslipGen.Employee.FullName} - please provide PhilHealth id number",
                                            "Generate payslip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            transaction.Dispose();
                                            return;
                                        }

                                        var philHealthMonthlyContribution = _philHealthContributionCalculator
                                                                            .GetKinsenasContribution(this.PhilHealthContributionTable, empMonthSalary);

                                        if (philHealthMonthlyContribution != null)
                                        {
                                            decimal empContributionKinsenas = (philHealthMonthlyContribution.EE / 2);
                                            decimal emprContributionKinsenas = (philHealthMonthlyContribution.ER / 2);

                                            _employeeGovernmentContributionData.Add(new EmployeeGovernmentContributionModel
                                            {
                                                PayslipId = payslipId,
                                                EmployeeNumber = employeeNumber,
                                                Agency = StaticData.GovContributions.PhilHealth.ToString(),
                                                GovContributionEnumVal = StaticData.GovContributions.PhilHealth,
                                                IdNumber = PhilHealthId.EmployeeIdNumber,
                                                EmployeeContribution = empContributionKinsenas,
                                                EmployerContribution = emprContributionKinsenas
                                            });

                                            employeeGovtContributionTotal += philHealthMonthlyContribution.EE;
                                            empTotalDeductions += empContributionKinsenas;
                                        }
                                    }

                                    if (empPayslipGen.SelectedGovContributions.Contains(StaticData.GovContributions.PagIbig))
                                    {
                                        var PagIbigId = employeeGovtIds.Where(x => x.GovtAgencyEnumVal == StaticData.GovContributions.PagIbig).FirstOrDefault();

                                        if (PagIbigId == null)
                                        {
                                            MessageBox.Show($"{empPayslipGen.Employee.FullName} - please provide PagIbigId id number",
                                            "Generate payslip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            transaction.Dispose();
                                            return;
                                        }


                                        var pagIbigMonthlyContribution = _pagIbigContributionCalculator
                                                                        .GetMonthlyContribution(this.PagIbigContributionTable, empMonthSalary);

                                        if (pagIbigMonthlyContribution != null)
                                        {
                                            decimal empContributionKinsenas = (pagIbigMonthlyContribution.EE / 2);
                                            decimal emprContributionKinsenas = (pagIbigMonthlyContribution.ER / 2);

                                            _employeeGovernmentContributionData.Add(new EmployeeGovernmentContributionModel
                                            {
                                                PayslipId = payslipId,
                                                EmployeeNumber = employeeNumber,
                                                Agency = StaticData.GovContributions.PagIbig.ToString(),
                                                GovContributionEnumVal = StaticData.GovContributions.PagIbig,
                                                IdNumber = PagIbigId.EmployeeIdNumber,
                                                EmployeeContribution = empContributionKinsenas,
                                                EmployerContribution = emprContributionKinsenas
                                            });

                                            employeeGovtContributionTotal += pagIbigMonthlyContribution.EE;
                                            empTotalDeductions += empContributionKinsenas;
                                        }
                                    }

                                    if (empPayslipGen.SelectedGovContributions.Contains(StaticData.GovContributions.WithHoldingTax))
                                    {
                                        decimal monthlyWithholdingTax = _wTaxCalculator
                                                                        .GetMonthlyWithholdingTax(this.WTaxTable, employeeGovtContributionTotal, empMonthSalary);

                                        if (monthlyWithholdingTax > 0)
                                        {
                                            decimal empContributionKinsenas = (monthlyWithholdingTax / 2);

                                            _employeeGovernmentContributionData.Add(new EmployeeGovernmentContributionModel
                                            {
                                                PayslipId = payslipId,
                                                EmployeeNumber = employeeNumber,
                                                Agency = StaticData.GovContributions.WithHoldingTax.ToString(),
                                                GovContributionEnumVal = StaticData.GovContributions.WithHoldingTax,
                                                EmployeeContribution = empContributionKinsenas,
                                                EmployerContribution = 0
                                            });
                                            empTotalDeductions += empContributionKinsenas;
                                        }
                                    }
                                }

                                // normal day overtime
                                if (empPayslipGen.PaydaySalaryComputation.OverTimeTotalRate > 0)
                                {
                                    _employeePayslipBenefitData.Add(new EmployeePayslipBenefitModel
                                    {
                                        PayslipId = payslipId,
                                        EmployeeNumber = employeeNumber,
                                        BenefitTitle = $"Overtime",
                                        Multiplier = empPayslipGen.PaydaySalaryComputation.OverTime,
                                        Amount = empPayslipGen.PaydaySalaryComputation.OverTimeTotalRate,
                                        DisplayType = StaticData.DisplayTypes.Earnings
                                    });

                                    empTotalBenefits += empPayslipGen.PaydaySalaryComputation.OverTimeTotalRate;
                                }

                                // Overtimes
                                if (empPayslipGen.PaydaySalaryComputation.OverTimeDaysWithRate != null && empPayslipGen.PaydaySalaryComputation.OverTimeDaysWithRate.Count > 0)
                                {
                                    foreach(var ot in empPayslipGen.PaydaySalaryComputation.OverTimeDaysWithRate)
                                    {
                                        if (ot.Value.LateTotalDeduction > 0)
                                        {
                                            _employeePayslipBenefitData.Add(new EmployeePayslipBenefitModel
                                            {
                                                PayslipId = payslipId,
                                                EmployeeNumber = employeeNumber,
                                                BenefitTitle = $"Late {ot.Key}",
                                                Multiplier = ot.Value.Late,
                                                Amount = ot.Value.LateTotalDeduction,
                                                DisplayType = StaticData.DisplayTypes.Earnings
                                            });
                                        }
                                        
                                        if (ot.Value.UnderTimeTotalDeduction > 0)
                                        {
                                            _employeePayslipBenefitData.Add(new EmployeePayslipBenefitModel
                                            {
                                                PayslipId = payslipId,
                                                EmployeeNumber = employeeNumber,
                                                BenefitTitle = $"Undertime {ot.Key}",
                                                Multiplier = ot.Value.UnderTime,
                                                Amount = ot.Value.UnderTimeTotalDeduction,
                                                DisplayType = StaticData.DisplayTypes.Earnings
                                            });
                                        }

                                        decimal overTimeTotalRate = ot.Value.TotalRate;

                                        if (ot.Value.OverTimeTotalRate > 0)
                                        {
                                            _employeePayslipBenefitData.Add(new EmployeePayslipBenefitModel
                                            {
                                                PayslipId = payslipId,
                                                EmployeeNumber = employeeNumber,
                                                BenefitTitle = $"Overtime {ot.Key}",
                                                Multiplier = ot.Value.OverTime,
                                                Amount = ot.Value.OverTimeTotalRate,
                                                DisplayType = StaticData.DisplayTypes.Earnings
                                            });
                                            overTimeTotalRate += ot.Value.OverTimeTotalRate;
                                        }

                                        _employeePayslipBenefitData.Add(new EmployeePayslipBenefitModel
                                        {
                                            PayslipId = payslipId,
                                            EmployeeNumber = employeeNumber,
                                            BenefitTitle = $"{ot.Key}",
                                            Multiplier = ot.Value.NumberOfOvertime.ToString(),
                                            Amount = overTimeTotalRate,
                                            DisplayType = StaticData.DisplayTypes.Earnings
                                        });

                                        empTotalBenefits += overTimeTotalRate;
                                    }
                                }

                                // Benefits
                                foreach (var benefit in empPayslipGen.SelectedBenefits)
                                {
                                    _employeePayslipBenefitData.Add(new EmployeePayslipBenefitModel
                                    {
                                        PayslipId = payslipId,
                                        EmployeeNumber = employeeNumber,
                                        BenefitTitle = benefit.BenefitTitle,
                                        Multiplier = "",
                                        Amount = benefit.Amount,
                                        DisplayType = StaticData.DisplayTypes.Benefit
                                    });

                                    empTotalBenefits += benefit.Amount;
                                }

                                // Specific Benefits
                                foreach (var benefit in currEmpSpecificBenefits)
                                {
                                    _employeePayslipBenefitData.Add(new EmployeePayslipBenefitModel
                                    {
                                        PayslipId = payslipId,
                                        EmployeeNumber = employeeNumber,
                                        BenefitTitle = benefit.BenefitTitle,
                                        Multiplier = "",
                                        Amount = benefit.Amount,
                                        DisplayType = StaticData.DisplayTypes.Benefit
                                    });

                                    empTotalBenefits += benefit.Amount;
                                }


                                // Sales bonus here
                                int salesBonusNumberOfDays = empPayslipGen.SelectedSalesReport.Count;
                                if (salesBonusNumberOfDays > 0)
                                {
                                    decimal totalDailySalesBonus = _payrollSettings.EmployeeBonusFromSaleSpecialBonus * salesBonusNumberOfDays;
                                    empTotalBenefits += totalDailySalesBonus;
    
                                    _employeePayslipBenefitData.Add(new EmployeePayslipBenefitModel
                                    {
                                        PayslipId = payslipId,
                                        EmployeeNumber = employeeNumber,
                                        BenefitTitle = "Sales bonus",
                                        Amount = totalDailySalesBonus,
                                        Multiplier = salesBonusNumberOfDays.ToString(),
                                        DisplayType = StaticData.DisplayTypes.Benefit
                                    });
                                }
                                
                                // Cash advance deductions
                                var currentEmpCashAdvanceRequest = empPayslipGen.SelectedEmpCashAdvanceRequests.Where(x => x.EmployeeNumber == employeeNumber).ToList();
                                if (currentEmpCashAdvanceRequest != null && currentEmpCashAdvanceRequest.Count > 0)
                                {
                                    foreach(var cashAdvance in currentEmpCashAdvanceRequest)
                                    {
                                        _employeePayslipDeductionData.Add(new EmployeePayslipDeductionModel
                                        {
                                            PayslipId = payslipId,
                                            EmployeeNumber = employeeNumber,
                                            DeductionTitle = $"Cash advance, release:{cashAdvance.CashReleaseDate.ToShortDateString()}",
                                            Amount = cashAdvance.Amount
                                        });

                                        empTotalDeductions += cashAdvance.Amount;
                                    }
                                }

                                // Deductions
                                foreach (var deduction in empPayslipGen.SelectedDeductions)
                                {
                                    _employeePayslipDeductionData.Add(new EmployeePayslipDeductionModel
                                    {
                                        PayslipId = payslipId,
                                        EmployeeNumber = employeeNumber,
                                        DeductionTitle = deduction.DeductionTitle,
                                        Amount = deduction.Amount
                                    });

                                    empTotalDeductions += deduction.Amount;
                                }

                                // Specific Deductions
                                foreach (var deduction in currEmpSpecificDeductions)
                                {
                                    _employeePayslipDeductionData.Add(new EmployeePayslipDeductionModel
                                    {
                                        PayslipId = payslipId,
                                        EmployeeNumber = employeeNumber,
                                        DeductionTitle = deduction.DeductionTitle,
                                        Amount = deduction.Amount
                                    });

                                    empTotalDeductions += deduction.Amount;
                                }

                                // Benefits
                                empTotalIncome += empTotalBenefits;

                                // deductions
                                empNetTakeHomePay = (empTotalIncome - empTotalDeductions);

                                payslipData.TotalIncome = empTotalIncome;
                                payslipData.BenefitsTotal = empTotalBenefits;

                                // we already deduction the ff. deductions in total income
                                // upon time-out daily salary computation
                                //empTotalDeductions += payslipData.LateTotalDeduction;
                                //empTotalDeductions += payslipData.UnderTimeTotalDeduction;
                                payslipData.DeductionTotal = empTotalDeductions;

                                payslipData.NetTakeHomePay = empNetTakeHomePay;

                                _employeePayslipData.Update(payslipData);

                                // Specific benefits
                                currEmpSpecificBenefits.ForEach(x =>
                                {
                                    x.IsPaid = true;
                                    x.PaymentDate = DateTime.Now;
                                    x.PayslipId = payslipId;
                                });
                                _specificEmployeeBenefitData.UpdateRange(currEmpSpecificBenefits);

                                // Specific deductions
                                currEmpSpecificDeductions.ForEach(x =>
                                {
                                    x.IsDeducted = true;
                                    x.DeductedDate = DateTime.Now;
                                    x.PayslipId = payslipId;
                                });
                                _specificEmployeeDeductionData.UpdateRange(currEmpSpecificDeductions);

                                // Mark employee leave as paid
                                empPayslipGen.EmployeeLeaves.ForEach(x =>
                                {
                                    x.IsPaid = true;
                                    x.PayslipId = payslipId;
                                });
                                _employeeLeaveData.Update(empPayslipGen.EmployeeLeaves);


                                // Mark attendance as paid and store the payslip id
                                empPayslipGen.AttendanceHistory.ForEach(x => {
                                    x.IsPaid = true;
                                    x.PayslipId = payslipId;
                                });
                                _employeeAttendanceData.Update(empPayslipGen.AttendanceHistory);

                            }

                        }

                        transaction.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                MessageBox.Show("Internal error, kindly check system logs and report this error to developer.");
            }
        }


        private void HandleViewEmployeePayslip(object sender, EventArgs e)
        {
            GeneratePayrollControl generatePayrollControlObj = (GeneratePayrollControl)sender;
            string empNum = generatePayrollControlObj.SelectedEmployeeNumberToViewPayslip;

            var employeeDetails = _employeeData.GetByEmployeeNumber(empNum);
            var payslip = _employeePayslipData.GetEmployeePayslipRecordByPaydate(empNum, generatePayrollControlObj.PayDate);
            var attendance = _employeeAttendanceData.GetEmployeeAttendanceByPayslipId(empNum, payslip.Id).Select(s => s.ShiftId);
            List<EmployeePositionShiftData> positionShiftDatas = new List<EmployeePositionShiftData>();
            var shifts = employeeDetails.PositionShift.Where(x => attendance.Contains(x.ShiftId)).ToList();
            if (employeeDetails.PositionShift.Count() > 0)
            {
                foreach (var item in employeeDetails.PositionShift.ToList())
                {
                    employeeDetails.PositionShift.Remove(item);
                }
            }

            employeeDetails.PositionShift.AddRange(shifts);

            generatePayrollControlObj.DisplayEmployeePayslip(employeeDetails, payslip);
        }


        private void HandleCancelAllEmployeeGeneratedPayslip(object sender, EventArgs e)
        {
            GeneratePayrollControl generatePayrollControlObj = (GeneratePayrollControl)sender;

            var paydate = generatePayrollControlObj.PayDate;
            var shiftStartDate = generatePayrollControlObj.ShiftStartDate;
            var shiftEndDate = generatePayrollControlObj.ShiftEndDate;

            if (CancelAllEmployeePayslipByPaydate(paydate))
            {
                generatePayrollControlObj.Employees = _employeeController.GetAll().Data;
                generatePayrollControlObj.AttendanceHistory = _employeeAttendanceData.GetAllUnpaidAttendanceRecordByWorkDateRange(shiftStartDate, shiftEndDate);
                generatePayrollControlObj.EmployeeLeaveHistory = _employeeLeaveData.GetAllUnpaidByDateRange(shiftStartDate.Year, shiftStartDate, shiftEndDate);
                generatePayrollControlObj.DisplayEmployeeWithAttendanceRecordAndSalary(generatePayrollControlObj.Employees);

                generatePayrollControlObj.ClearDGVEmployeeListForOverview();
            }
        }

        private void HandleCancelSelectedEmployeeGeneratedPayslip(object sender, EventArgs e)
        {
            GeneratePayrollControl generatePayrollControlObj = (GeneratePayrollControl)sender;

            var paydate = generatePayrollControlObj.PayDate;
            var shiftStartDate = generatePayrollControlObj.ShiftStartDate;
            var shiftEndDate = generatePayrollControlObj.ShiftEndDate;

            var employeeNumber = generatePayrollControlObj.SelectedEmployeeNumberToViewPayslip;
                
            if (CancelEmployeePayslipByPaydate(paydate, employeeNumber))
            {
                generatePayrollControlObj.Employees = _employeeController.GetAll().Data;
                generatePayrollControlObj.AttendanceHistory = _employeeAttendanceData.GetAllUnpaidAttendanceRecordByWorkDateRange(shiftStartDate, shiftEndDate);
                generatePayrollControlObj.EmployeeLeaveHistory = _employeeLeaveData.GetAllUnpaidByDateRange(shiftStartDate.Year, shiftStartDate, shiftEndDate);
                generatePayrollControlObj.DisplayEmployeeWithAttendanceRecordAndSalary(generatePayrollControlObj.Employees);

                generatePayrollControlObj.ClearDGVEmployeeListForOverview();
            }
        }

        private void HandleGeneratePDFForAllEmployeesPayslip(object sender, EventArgs e)
        {
            GeneratePayrollControl generatePayrollControlObj = (GeneratePayrollControl)sender;
            var paydate = generatePayrollControlObj.PayDate;
            var payslips = _employeePayslipData.GetAllEmpPayslipByPaydate(paydate);

            if (payslips != null)
            {
                _employeePayslipPDFReport.GenerateEmployeePayslips(payslips);
                MessageBox.Show($"Kindly check the generated pdf to {_payrollSettings.GeneratedPDFLoc}.", "Generated PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion


        #region Payroll history
        public void DisplayPayrollHistoryControl()
        {
            this.panelContainer.Controls.Clear();
            var payslipHistoryControl = new PayslipHistoryControl();
            payslipHistoryControl.Location = new Point(this.ClientSize.Width / 2 - payslipHistoryControl.Size.Width / 2, this.ClientSize.Height / 2 - payslipHistoryControl.Size.Height / 2);
            payslipHistoryControl.Anchor = AnchorStyles.None;

            payslipHistoryControl.PayslipDateList = _employeePayslipData.GetPayslipPaydatesList();
            payslipHistoryControl.RetrieveEmployeePayslip += HandleRetrieveEmployeePayslip;
            payslipHistoryControl.CancelAllEmployeePayslip += HandleCancelAllEmployeePayslip;
            payslipHistoryControl.CancelSelectedEmployeePayslip += HandleCancelSelectedEmployeePayslip;
            payslipHistoryControl.GeneratePayslipPDFForAllEmployees += HandleGeneratePDFPayslipForAllEmployees;
            payslipHistoryControl.GeneratePayslipPDFForSelectedEmployee += HandleGeneratePDFPayslipForSelectedEmployee;

            this.panelContainer.Controls.Add(payslipHistoryControl);
        }

        private void HandleRetrieveEmployeePayslip(object sender, EventArgs e)
        {
            PayslipHistoryControl payslipHistoryControlObj = (PayslipHistoryControl)sender;

            var paydate = payslipHistoryControlObj.SelectedPayslipPayDate;

            var payslips = _employeePayslipData.GetAllEmpPayslipByPaydate(paydate);
            payslipHistoryControlObj.EmployeePayslipsByPaydate = payslips;
            payslipHistoryControlObj.DisplayEmployeesInDGV();
        }


        private void HandleCancelAllEmployeePayslip(object sender, EventArgs e)
        {
            PayslipHistoryControl payslipHistoryControlObj = (PayslipHistoryControl)sender;

            var paydate = payslipHistoryControlObj.SelectedPayslipPayDate;

            if (this.CancelAllEmployeePayslipByPaydate(paydate))
            {
                payslipHistoryControlObj.PayslipDateList = _employeePayslipData.GetPayslipPaydatesList();
                payslipHistoryControlObj.DisplayPayslipPaydateList();
                payslipHistoryControlObj.EmployeePayslipsByPaydate = _employeePayslipData.GetAllEmpPayslipByPaydate(paydate);
                payslipHistoryControlObj.DisplayEmployeesInDGV();
                payslipHistoryControlObj.ClearPayslipContainer();
            }
        }

        private void HandleCancelSelectedEmployeePayslip(object sender, EventArgs e)
        {
            PayslipHistoryControl payslipHistoryControlObj = (PayslipHistoryControl)sender;

            var paydate = payslipHistoryControlObj.SelectedPayslipPayDate;
            var employeeNumber = payslipHistoryControlObj.SelectedEmployeeNumberToCancel;

            if (this.CancelEmployeePayslipByPaydate(paydate, employeeNumber))
            {
                payslipHistoryControlObj.PayslipDateList = _employeePayslipData.GetPayslipPaydatesList();
                payslipHistoryControlObj.DisplayPayslipPaydateList();
                payslipHistoryControlObj.EmployeePayslipsByPaydate = _employeePayslipData.GetAllEmpPayslipByPaydate(paydate);
                payslipHistoryControlObj.DisplayEmployeesInDGV();
                payslipHistoryControlObj.ClearPayslipContainer();
            }
        }

        private void HandleGeneratePDFPayslipForAllEmployees(object sender, EventArgs e)
        {
            PayslipHistoryControl payslipHistoryControlObj = (PayslipHistoryControl)sender;
            var paydate = payslipHistoryControlObj.SelectedPayslipPayDate;
            var payslips = _employeePayslipData.GetAllEmpPayslipByPaydate(paydate);

            if (payslips != null)
            {
                _employeePayslipPDFReport.GenerateEmployeePayslips(payslips);
                MessageBox.Show($"Kindly check the generated pdf to {_payrollSettings.GeneratedPDFLoc}.", "Generated PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void HandleGeneratePDFPayslipForSelectedEmployee(object sender, EventArgs e)
        {
            PayslipHistoryControl payslipHistoryControlObj = (PayslipHistoryControl)sender;
            var paydate = payslipHistoryControlObj.SelectedPayslipPayDate;
            string employeeNumber = payslipHistoryControlObj.SelectedEmployeeNumberToGeneratePayslipPDF;

            var payslip = _employeePayslipData.GetEmployeePayslipRecordByPaydate(employeeNumber,paydate);

            if (payslip != null)
            {
                _employeePayslipPDFReport.GenerateEmployeePayslip(payslip);
                MessageBox.Show($"Kindly check the generated pdf to {_payrollSettings.GeneratedPDFLoc}.", "Generated PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion



        public bool CancelAllEmployeePayslipByPaydate(DateTime paydate)
        {
            try
            {
                var employeePayslips = _employeePayslipData.GetAllEmpPayslipByPaydate(paydate);

                if (employeePayslips != null)
                {
                    employeePayslips.ForEach(x => x.IsCancel = true);

                    using (var transaction = new TransactionScope())
                    {
                        foreach (var payslip in employeePayslips)
                        {
                            var attendanceRecordUnderPayslip = _employeeAttendanceData.GetEmployeeAttendanceByPayslipId(payslip.EmployeeNumber, payslip.Id);

                            // Specific benefits
                            var currEmpSpecificBenefits = _specificEmployeeBenefitData.GetAllByEmployeeAndPayslipId(payslip.EmployeeNumber, payslip.Id);
                            currEmpSpecificBenefits.ForEach(x =>
                            {
                                x.IsPaid = false;
                                x.PaymentDate = DateTime.MinValue;
                                x.PayslipId = 0;
                            });
                            _specificEmployeeBenefitData.UpdateRange(currEmpSpecificBenefits);

                            // Specific deductions
                            var currEmpSpecificDeductions = _specificEmployeeDeductionData.GetAllByEmployeeAndPayslipId(payslip.EmployeeNumber, payslip.Id);
                            currEmpSpecificDeductions.ForEach(x =>
                            {
                                x.IsDeducted = false;
                                x.DeductedDate = DateTime.MinValue;
                                x.PayslipId = 0;
                            });
                            _specificEmployeeDeductionData.UpdateRange(currEmpSpecificDeductions);

                            attendanceRecordUnderPayslip.ForEach(x =>
                            {
                                x.IsPaid = false;
                                x.PayslipId = 0;
                            });

                            _employeeAttendanceData.Update(attendanceRecordUnderPayslip);

                            var employeeLeaveUnderPayslip = _employeeLeaveData.GetEmployeeLeavesByPayslipId(payslip.EmployeeNumber, payslip.Id);

                            employeeLeaveUnderPayslip.ForEach(x =>
                            {
                                x.IsPaid = false;
                                x.PayslipId = 0;
                            });

                            _employeeLeaveData.Update(employeeLeaveUnderPayslip);
                        }

                        _employeePayslipData.Update(employeePayslips);

                        transaction.Complete();
                    }

                    MessageBox.Show("Successfully cancel all employee payslip.", "Cancel employee payslip", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                MessageBox.Show("Internal error, kindly check system logs and report this error to developer.");
            }

            return false;
        }

        public bool CancelEmployeePayslipByPaydate(DateTime paydate, string employeeNumber)
        {
            try
            {
                var employeePayslips = _employeePayslipData.GetEmployeePayslipRecordByPaydate(employeeNumber, paydate);

                if (employeePayslips != null)
                {
                    employeePayslips.IsCancel = true;

                    using (var transaction = new TransactionScope())
                    {
                        var attendanceRecordUnderPayslip = _employeeAttendanceData.GetEmployeeAttendanceByPayslipId(employeePayslips.EmployeeNumber, employeePayslips.Id);

                        // Specific benefits
                        var currEmpSpecificBenefits = _specificEmployeeBenefitData.GetAllByEmployeeAndPayslipId(employeePayslips.EmployeeNumber, employeePayslips.Id);
                        currEmpSpecificBenefits.ForEach(x =>
                        {
                            x.IsPaid = false;
                            x.PaymentDate = DateTime.MinValue;
                            x.PayslipId = 0;
                        });
                        _specificEmployeeBenefitData.UpdateRange(currEmpSpecificBenefits);

                        // Specific deductions
                        var currEmpSpecificDeductions = _specificEmployeeDeductionData.GetAllByEmployeeAndPayslipId(employeePayslips.EmployeeNumber, employeePayslips.Id);
                        currEmpSpecificDeductions.ForEach(x =>
                        {
                            x.IsDeducted = false;
                            x.DeductedDate = DateTime.MinValue;
                            x.PayslipId = 0;
                        });
                        _specificEmployeeDeductionData.UpdateRange(currEmpSpecificDeductions);

                        attendanceRecordUnderPayslip.ForEach(x =>
                        {
                            x.IsPaid = false;
                            x.PayslipId = 0;
                        });


                        attendanceRecordUnderPayslip.ForEach(x =>
                        {
                            x.IsPaid = false;
                            x.PayslipId = 0;
                        });

                        _employeeAttendanceData.Update(attendanceRecordUnderPayslip);

                        var employeeLeaveUnderPayslip = _employeeLeaveData.GetEmployeeLeavesByPayslipId(employeePayslips.EmployeeNumber, employeePayslips.Id);

                        employeeLeaveUnderPayslip.ForEach(x =>
                        {
                            x.IsPaid = false;
                            x.PayslipId = 0;
                        });

                        _employeeLeaveData.Update(employeeLeaveUnderPayslip);


                        _employeePayslipData.Update(employeePayslips);

                        transaction.Complete();
                    }

                    MessageBox.Show("Successfully cancel employee payslip.", "Cancel employee payslip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                MessageBox.Show("Internal error, kindly check system logs and report this error to developer.");
            }

            return false;
        }


        #region Payroll reports

        public void DisplayPayrollReportsControl()
        {
            this.panelContainer.Controls.Clear();
            var payrollReportControl = new PayrollReportControl();
            payrollReportControl.Location = new Point(this.ClientSize.Width / 2 - payrollReportControl.Size.Width / 2, this.ClientSize.Height / 2 - payrollReportControl.Size.Height / 2);
            payrollReportControl.Anchor = AnchorStyles.None;

            payrollReportControl.PayslipDateList = _employeePayslipData.GetPayslipPaydatesList();

            payrollReportControl.RetrieveEmployeePayslips += HandleRetrieveEmployeePayslipHistory;
            payrollReportControl.GeneratePDFEmployeePayslipsReport += HandleGeneratePDFEmployeePayslipHistory;
            payrollReportControl.GeneratePDFEmployeeGovtContribReport += HandleGeneratePDFEmployeeGovContribution;

            this.panelContainer.Controls.Add(payrollReportControl);
        }

        private void HandleRetrieveEmployeePayslipHistory(object sender, EventArgs e)
        {
            PayrollReportControl payrollReportControlObj = (PayrollReportControl)sender;

            var paydate = payrollReportControlObj.SelectedPayslipPayDate;

            var payslips = _employeePayslipData.GetAllEmpPayslipByPaydate(paydate);
            payrollReportControlObj.EmployeePayslipsByPaydate = payslips;
            payrollReportControlObj.DisplayPayslipHistory();
        }

        private void HandleGeneratePDFEmployeePayslipHistory(object sender, EventArgs e)
        {
            PayrollReportControl payrollReportControlObj = (PayrollReportControl)sender;

            var paydate = payrollReportControlObj.SelectedPayslipPayDate;

            var payslips = _employeePayslipData.GetAllEmpPayslipByPaydate(paydate);
            
            if (payslips != null)
            {
                _payrollPDFReport.GenerateEmployeePayslipsReport(payslips, paydate);
                MessageBox.Show($"Kindly check the generated pdf to {_payrollSettings.GeneratedPDFLoc}.", "Generated PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void HandleGeneratePDFEmployeeGovContribution(object sender, EventArgs e)
        {
            PayrollReportControl payrollReportControlObj = (PayrollReportControl)sender;

            var selectedMonth = payrollReportControlObj.SelectedMonthForEmpGovtContribReport;

            var payslips = _employeePayslipData.GetAllEmpPayslipByMonth(selectedMonth);

            if (payslips != null)
            {
                _employeeGovContributionsReport.GenerateReport(payslips);
                MessageBox.Show($"Kindly check the generated pdf to {_payrollSettings.GeneratedPDFLoc}.", "Generated PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

    }
}
