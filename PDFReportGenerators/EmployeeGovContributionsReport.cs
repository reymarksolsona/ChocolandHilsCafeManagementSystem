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
    public class EmployeeGovContributionsReport : IEmployeeGovContributionsReport
    {
        private readonly IConverter _converter;
        private readonly PayrollSettings _payrollSettings;

        public EmployeeGovContributionsReport(IConverter converter, IOptions<PayrollSettings> payrollSettings)
        {
            _converter = converter;
            _payrollSettings = payrollSettings.Value;
        }

        public void GenerateReport(List<EmployeePayslipModel> payslips)
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

                                    table#parent-table tr{
                                        border: 1px solid gray;
                                    }

                                </style>
                            </header>
                            <body>");


            var groupPayslip = payslips.GroupBy(x => x.EmployeeNumber);

            foreach(var item in groupPayslip)
            {
                sb.Append(this.ConvertPayslipToHtml(item.ToList()));
            }

            //foreach (var payslip in payslips)
            //{
            //    sb.Append(this.ConvertPayslipToHtml(payslip));
            //}

            sb.Append(@"</body>
                  </html>");

            this.GeneratePdfReport(sb.ToString(), $"Employee-Gov-Contributions-{DateTime.Now.ToString("yyyy-MM-dd")}");
        }

        private string ConvertPayslipToHtml(List<EmployeePayslipModel> employeePayslips)
        {
            StringBuilder sb = new StringBuilder();

            if (employeePayslips != null && employeePayslips.Count > 0)
            {
                var empTemp = employeePayslips.FirstOrDefault();
                if (empTemp != null)
                {
                    sb.Append($@"<h3>Employee: {empTemp.Employee.FullName} - {empTemp.EmployeeNumber}</h3>");
                }
            }

            sb.Append($@"<hr/>
                            <table id='parent-table'>
                            <thead>
                                <tr>
                                    <td>Payslip</td>
                                    <td>Government contribution</td>
                                </tr>
                           </thead><tbody>");

            StringBuilder payslipSb = new StringBuilder();
            StringBuilder contributionsSb = new StringBuilder();

            if (employeePayslips != null && employeePayslips.Count > 0)
            {
                decimal totalEmpGovContribByCurrentMonth = 0;

                foreach(var payslip in employeePayslips)
                {
                    payslipSb = new StringBuilder();
                    payslipSb.Append($@"<table>
                         <tr>
                            <td>Paydate</td>
                            <td>{payslip.PayDate}</td>
                         </tr>
                         <tr>   
                            <td>Benefits</td>
                            <td>{payslip.BenefitsTotal}</td>
                         </tr>
                         <tr>
                            <td>Net basic salary</td>
                             <td>{payslip.NetBasicSalary}</td>
                         </tr>
                         <tr>
                            <td>Total Income</td>
                             <td>{payslip.TotalIncome}</td>
                         </tr>
                         <tr>
                            <td>Deductions</td>
                            <td>{payslip.DeductionTotal}</td>
                         </tr>
                         <tr>
                            <td>Net take home</td>
                            <td>{payslip.NetTakeHomePay}</td>
                         </tr>
                    </table>");

                    contributionsSb = new StringBuilder();

                    contributionsSb.Append(@"<table>
                        <thead>
                            <tr>
                                <th>Agency</th>
                                <th>Emp. Id #</th>
                                <th>EE contribution</th>
                                <th>ER contribution</th>
                                <th>Total</th>
                            </tr>
                        </thead>
                        <tbody>");

                    decimal totalEmpContribTemp = 0;
                    decimal totalEmprContribTemp = 0;
                    decimal totalContribTemp = 0;

                    foreach (var contrib in payslip.EmployeeGovContributions)
                    {
                        contributionsSb.Append($@"<tr>
                                    <td>{contrib.GovContributionEnumVal}</td>
                                    <td>{contrib.IdNumber}</td>
                                    <td>{contrib.EmployeeContribution}</td>
                                    <td>{contrib.EmployerContribution}</td>
                                    <td>{contrib.TotalContribution}</td>
                            </tr>");

                        totalEmpContribTemp += contrib.EmployeeContribution;
                        totalEmprContribTemp += contrib.EmployerContribution;
                        totalContribTemp += contrib.TotalContribution;
                        totalEmpGovContribByCurrentMonth += contrib.TotalContribution;
                    }

                    contributionsSb.Append($@"<tr>
                                    <td>Total</td>
                                    <td>{totalEmpContribTemp}</td>
                                    <td>{totalEmprContribTemp}</td>
                                    <td>{totalContribTemp}</td>
                            </tr>");


                    contributionsSb.Append(@"</tbody></table>");

                    sb.Append($@"<tr><td>{ payslipSb }</td> <td>{ contributionsSb }</td></tr>");
                }

                sb.Append($@"<tr>
                            <td>
                                <h3>Employee total Gov. contributions: </h3>
                             </td> 
                            <td><h3>{ totalEmpGovContribByCurrentMonth }</h3></td></tr>");
            }

            sb.Append("</tbody></table>");

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
