using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared.PayrollManagement;
using Microsoft.Extensions.Options;
using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;
using static EntitiesShared.StaticData;

namespace PDFReportGenerators
{
    public class EmployeePayslipPDFReport : IEmployeePayslipPDFReport
    {
        private readonly IConverter _converter;
        private readonly IEmployeeGovtIdCardData _employeeGovtIdCardData;
        private readonly IEmployeePositionData _employeePositionData;
        private readonly PayrollSettings _payrollSettings;

        public EmployeePayslipPDFReport(IConverter converter, IOptions<PayrollSettings> payrollSettings, IEmployeeGovtIdCardData employeeGovtIdCardData, IEmployeePositionData employeePositionData)
        {
            _converter = converter;
            _employeeGovtIdCardData = employeeGovtIdCardData;
            _payrollSettings = payrollSettings.Value;
            _employeePositionData = employeePositionData;
        }

        public void GenerateEmployeePayslips(List<EmployeePayslipModel> payslips)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"<!DOCTYPE html> 
                            <html> 
                            <header>
                                <style>
                                    body{
                                        font-size: 10px;
                                    }

                                    th, td{
                                        padding: 5px;
                                    }

                                    table#parent-table{
                                        text-align: left;
                                    }

                                    table {
                                        width: 100%;
                                        border-collapse: collapse;
                                        page-break-inside: avoid;
                                    }
                                </style>
                            </header>
                            <body>");


            foreach (var payslip in payslips)
            {
                sb.Append(this.ConvertPayslipToHtml(payslip));
            }

            sb.Append(@"</body>
                  </html>");

            this.GeneratePdfReport(sb.ToString(), $"Payslip-{DateTime.Now.ToString("yyyy-MM-dd")}");
        }

        public void GenerateEmployeePayslip(EmployeePayslipModel payslip)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"<!DOCTYPE html> 
                            <html> 
                            <header>
                                <style>
                                    body{
                                        font-size: 10px;
                                    }

                                    th, td{
                                        padding: 5px;
                                    }

                                    table#parent-table{
                                        text-align: left;
                                    }

                                    table {
                                        width: 100%;
                                        border-collapse: collapse;
                                        page-break-inside: avoid;
                                    }
                                </style>
                            </header>
                            <body>");

            sb.Append(this.ConvertPayslipToHtml(payslip));

            sb.Append(@"</body>
                  </html>");

            this.GeneratePdfReport(sb.ToString(), payslip.EmployeeNumber);
        }

        private string ConvertPayslipToHtml(EmployeePayslipModel payslip)
        {
            StringBuilder sb = new StringBuilder();

            var employeeGovtIds = _employeeGovtIdCardData.GetAllByEmployeeNumber(payslip.EmployeeNumber);
            var SSSId = employeeGovtIds.Where(x => x.GovtAgencyEnumVal == GovContributions.SSS).FirstOrDefault();
            var PhilHealthId = employeeGovtIds.Where(x => x.GovtAgencyEnumVal == GovContributions.PhilHealth).FirstOrDefault();
            var PagIbigId = employeeGovtIds.Where(x => x.GovtAgencyEnumVal == GovContributions.PagIbig).FirstOrDefault();

            var positionShifts = payslip.Employee.PositionShift.Select(s => s.PositionId).Distinct();

            List<string> positions = new List<string>();
            foreach (var item in positionShifts)
            {
                var position = _employeePositionData.Get(item);
                positions.Add(position.Title);
            }

            string positionTitles = string.Join(", ", positions.Select(x => x).ToList().ToArray());

            StringBuilder header = new StringBuilder();
            header.Append($@"<hr/>
                            <table id='parent-table'>
                            <thead>
                                <tr>
                                    <th> Employee: {payslip.Employee.FullName}</th>
                                    <th> SSS no: { (SSSId != null ? SSSId.EmployeeIdNumber : "") } </th>
                                </tr>
                                <tr>
                                    <th> ID No: {payslip.EmployeeNumber} </th>
                                    <th> PhilHealth no: {(PhilHealthId != null ? PhilHealthId.EmployeeIdNumber : "")}</th>
                                </tr>
                                <tr>
                                    <th> Position: {positionTitles} </th>
                                    <th> PagIbig no: {(PagIbigId != null ? PagIbigId.EmployeeIdNumber : "")}</th>
                                </tr>
                                <tr style='border-bottom: 1px solid gray;'>
                                    <th> Date generated {DateTime.Now.ToShortDateString()} </th>
                                    <th></th>
                                </tr>
                                <tr style='border-bottom: 1px solid gray; text-align: center;'>
                                    <th colspan='2'>Shift from {payslip.StartShiftDate.ToLongDateString()} to {payslip.EndShiftDate.ToLongDateString()}</th>
                                </tr>
                           </thead>");


            StringBuilder earnings = new StringBuilder();
            string lateDeductions = payslip.LateTotalDeduction > 0 ? 
                            $@"<tr> 
                                    <td>Less Late</td> 
                                    <td>{payslip.Late}</td> 
                                    <td>-{payslip.LateTotalDeduction}</td> 
                            </tr>" : "";

            string underTimeDeductions = payslip.UnderTimeTotalDeduction > 0 ?
                            $@"<tr> 
                                    <td>Less Undertime</td> 
                                    <td>{payslip.UnderTime}</td> 
                                    <td>-{payslip.UnderTimeTotalDeduction}</td> 
                            </tr>" : "";


            StringBuilder benefits = new StringBuilder();
            if (payslip.Benefits != null)
            {
                foreach (var item in payslip.Benefits.Where(x => x.DisplayType == DisplayTypes.Earnings))
                {
                    benefits.Append($@"<tr> 
                                    <td>{item.BenefitTitle}</td> 
                                    <td>{item.Multiplier}</td> 
                                    <td>{item.Amount}</td> 
                            </tr>");
                }

                benefits.Append(@"<tr style='border-bottom: 1px solid gray;'> 
                                    <th>Benefits</th>
                                    <th></th>
                                    <th>Amount</th>
                            </tr>");
                foreach (var item in payslip.Benefits.Where(x => x.DisplayType == DisplayTypes.Benefit))
                {
                    benefits.Append($@"<tr> 
                                    <td>{item.BenefitTitle}</td> 
                                    <td>{item.Multiplier}</td> 
                                    <td>{item.Amount}</td> 
                            </tr>");
                }
            }

            StringBuilder deductions = new StringBuilder();

            deductions.Append(@"<table>");

            if (payslip.EmployeeGovContributions != null)
            {
                deductions.Append(@"<tr style='border-bottom: 1px solid gray;'>
                                <th>Government Contributions</th>
                                <th>Amount</th>
                            </tr>");

                foreach (var contrib in payslip.EmployeeGovContributions)
                {
                    deductions.Append($@"<tr> 
                                    <td>{contrib.GovContributionEnumVal}</td> 
                                    <td>-{contrib.EmployeeContribution}</td> 
                            </tr>");
                }
            }

            if (payslip.Deductions != null)
            {
                deductions.Append(@"<tr style='border-bottom: 1px solid gray;'><th>Deductions</th>
                                        <th>Amount</th>
                                    </tr>");

                foreach (var item in payslip.Deductions)
                {
                    deductions.Append($@"<tr> 
                                    <td>{item.DeductionTitle}</td> 
                                    <td>{item.Amount}</td> 
                            </tr>");
                }
            }


            deductions.Append(@"</table>");


            earnings.Append($@"
                    <table style='border-right: 1px solid gray;'>
                        <thead>
                            <tr>
                                <th>Earnings</th>
                                <th>Multipler</th>
                                <th>Amount</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Daily Rate</td>
                                <td></td>
                                <td>{payslip.DailyRate}</td>
                            </tr>
                            {lateDeductions}
                            {underTimeDeductions}
                            <tr>
                                <td>Net Basic Salary</td>
                                <td>{payslip.NumOfDays}</td>
                                <td>{payslip.NetBasicSalary}</td>
                            </tr>
                            {benefits}
                        </tbody>
                    </table>
            ");

            StringBuilder body = new StringBuilder();
            body.Append($@"
                 <tbody>
                    <tr><td>{earnings}</td> <td>{deductions}</td></tr>
                </tbody>
            ");


            StringBuilder footer = new StringBuilder();
            footer.Append($@"
                <tfoot>
                    <tr style='text-align: center !important; '>
                        <th>Total income: {payslip.TotalIncome}</th>
                        <th>Total Deductions: {payslip.DeductionTotal}</th>
                    </tr>
                    <tr style='text-align: center !important; '>
                          <th colspan='2'>Your net take home pay >>> {payslip.NetTakeHomePay}</th>
                    </tr>
               </tfoot>
                </table>
                <hr/>
               ");

            sb.Append(header);
            sb.Append(body);
            sb.Append(footer);

            return sb.ToString();
        }

        private void GeneratePdfReport(string html, string fileName)
        {

            GlobalSettings globalSettings = new GlobalSettings();
            globalSettings.ColorMode = ColorMode.Color;
            globalSettings.Orientation = Orientation.Portrait;
            globalSettings.PaperSize = PaperKind.A4;
            globalSettings.Margins = new MarginSettings { Top = 10, Bottom = 10 };
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
