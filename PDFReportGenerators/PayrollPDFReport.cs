using EntitiesShared.PayrollManagement;
using Microsoft.Extensions.Options;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace PDFReportGenerators
{
    public class PayrollPDFReport : IPayrollPDFReport
    {
        private readonly IConverter _converter;
        private readonly PayrollSettings _payrollSettings;

        public PayrollPDFReport(IConverter converter, IOptions<PayrollSettings> payrollSettings)
        {
            _converter = converter;
            _payrollSettings = payrollSettings.Value;
        }

        public void GenerateEmployeePayslipsReport(List<EmployeePayslipModel> payslips, DateTime paydate)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"<!DOCTYPE html> 
                            <html> 
                            <header>
                                <style>
                                    th, td{
                                        padding: 5px;
                                    }

                                    table#parent-table thead{
                                        text-align: left;
                                    }

                                    table {
                                        width: 100%;
                                        border-collapse: collapse;
                                    }
                                </style>
                            </header>
                            <body>");

            sb.Append($@"<h3>Payroll report</h3>
                    <table id='parent-table'>
                    <thead>
                        <tr style='border-bottom: 1px solid gray;'>
                            <th colspan='15'> Paydate: {paydate.ToLongDateString()} </ th >
                        </tr>
                        <tr style = 'border-bottom: 1px solid gray; text-align: center;' >
                            <th> Emp#</th>
                            <th> Fullname </th>
                            <th> Shift Range </th>
                            <th> Daily Rate </th>
                            <th> Late </th>
                            <th> Late deduction </th>
                            <th> UT </th>
                            <th> UT deduction </th>
                            <th> Benefits </th>
                            <th> Deductions </th>
                            <th> Net Take Home </th>
                            <th> Days </th>
                            <th> EE Govt. Contribution </th>
                            <th> ER Govt. Contribution </th>
                            <th> Total Govt. contribution </th>
                        </tr>
                    </thead>
                    <tbody> ");

            decimal totalPayment = 0;
            decimal totalGovContributionForCurrentEmp = 0;
            decimal empTotalGovContribution = 0;
            decimal emprTotalGovContribution = 0;

            foreach (var payslip in payslips)
            {
                totalGovContributionForCurrentEmp = payslip.EmployeeGovContributions.Sum(x => x.TotalContribution);
                empTotalGovContribution = payslip.EmployeeGovContributions.Sum(x => x.EmployeeContribution);
                emprTotalGovContribution = payslip.EmployeeGovContributions.Sum(x => x.EmployerContribution);

                sb.Append($@"<tr>
                                <td>{payslip.EmployeeNumber}</td>
                                <td>{payslip.Employee.FullName}</td>
                                <td>{payslip.StartShiftDate.ToString("dd/MM")}-{payslip.EndShiftDate.ToString("dd/MM")}</td>
                                <td>{payslip.DailyRate.ToString()}</td>
                                <td>{payslip.Late}</td>
                                <td>{payslip.LateTotalDeduction}</td>
                                <td>{payslip.UnderTime}</td>
                                <td>{payslip.UnderTimeTotalDeduction}</td>
                                <td>{payslip.BenefitsTotal}</td>
                                <td>{payslip.DeductionTotal}</td>
                                <td>{payslip.NetTakeHomePay}</td>
                                <td>{payslip.NumOfDays}</td>
                                <td>{empTotalGovContribution}</td>
                                <td>{emprTotalGovContribution}</td>
                                <td>{totalGovContributionForCurrentEmp}</td>
                            </tr>");

                totalPayment += payslip.NetTakeHomePay;
            }

            sb.Append($@"</tbody>
                            <tfoot>
                                <tr><td colspan='13' style='text-align: right;'>Total: {totalPayment}</td></tr>
                            </tfoot>
                        </table>
                    </body>
                  </html>");

            this.GeneratePdfReport(sb.ToString(), $"Payslip-report-{DateTime.Now.ToString("yyyy-MM-dd")}");
        }


        private void GeneratePdfReport(string html, string fileName)
        {
            GlobalSettings globalSettings = new GlobalSettings();
            globalSettings.ColorMode = ColorMode.Color;
            globalSettings.Orientation = Orientation.Landscape;
            globalSettings.PaperSize = PaperKind.A4;
            globalSettings.Margins = new MarginSettings { Top = 5, Bottom = 5 };
            globalSettings.Out = $@"{_payrollSettings.GeneratedPDFLoc}{fileName}.pdf";

            ObjectSettings objectSettings = new ObjectSettings();
            objectSettings.PagesCount = true;
            objectSettings.HtmlContent = html;

            WebSettings webSettings = new WebSettings();
            webSettings.DefaultEncoding = "utf-8";

            //HeaderSettings headerSettings = new HeaderSettings();
            //headerSettings.FontSize = 15;
            //headerSettings.FontName = "Ariel";
            //headerSettings.Right = "Page [page] of [toPage]";
            //headerSettings.Line = true;

            //FooterSettings footerSettings = new FooterSettings();
            //footerSettings.FontSize = 12;
            //footerSettings.FontName = "Ariel";
            //footerSettings.Center = "This is for demonstration purposes only.";
            //footerSettings.Line = true;


            //objectSettings.HeaderSettings = headerSettings;
            //objectSettings.FooterSettings = footerSettings;
            objectSettings.WebSettings = webSettings;

            HtmlToPdfDocument htmlToPdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings },
            };
            _converter.Convert(htmlToPdfDocument);
        }
    }
}
