using EntitiesShared.EmployeeManagement;
using EntitiesShared.EmployeeManagement.Models;
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
    public class AttendancePDFReport : IAttendancePDFReport
    {
        private readonly IConverter _converter;
        private readonly PayrollSettings _payrollSettings;

        public AttendancePDFReport(IConverter converter, IOptions<PayrollSettings> payrollSettings)
        {
            _converter = converter;
            _payrollSettings = payrollSettings.Value;
        }
        public void GenerateAttendanceReportPDF(Dictionary<DateTime, AttendanceRecord> attendanceToDisplay, EmployeeModel employee)
        {
            if (employee == null || attendanceToDisplay == null)
                return;

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

            sb.Append($@"<h3>Attendance report report for {employee.FullName} - {employee.EmployeeNumber}</h3>
                    <table id='parent-table'>
                    <thead>
                        <tr style = 'border-bottom: 1px solid gray; text-align: center;' >
                            <th> Date</th>
                            <th> Day </th>
                            <th> Shift </th>
                            <th> Shift Time </th>
                            <th> First Half </th>
                            <th> Second Half </th>
                            <th> Hours </th>
                            <th> Late </th>
                            <th> UT </th>
                            <th> OT </th>
                            <th> Status </th>
                        </tr>
                    </thead>
                    <tbody> ");

            foreach(var record in attendanceToDisplay)
            {
                var workDate = record.Key;
                var attendance = record.Value.record ;

                /*
                 index:
                    0 - workdate
                    1 - day
                    2 - shift
                    3 - workdate start and end date
                    4 - first time in and out
                    5 - second time in and out
                    6 - whole day total hrs
                    7 - late
                    8 - undertime
                    9 - overtime
                    10 - is paid or not
                 */

                if (attendance.Length > 0)
                {
                    sb.Append($@"<tr>
                                <td>{attendance.ElementAtOrDefault(0)}</td>
                                <td>{attendance.ElementAtOrDefault(1)}</td>
                                <td>{attendance.ElementAtOrDefault(2)}</td>
                                <td>{attendance.ElementAtOrDefault(3)}</td>
                                <td>{attendance.ElementAtOrDefault(4)}</td>
                                <td>{attendance.ElementAtOrDefault(5)}</td>
                                <td>{attendance.ElementAtOrDefault(5)}</td>
                                <td>{attendance.ElementAtOrDefault(6)}</td>
                                <td>{attendance.ElementAtOrDefault(7)}</td>
                                <td>{attendance.ElementAtOrDefault(8)}</td>
                                <td>{attendance.ElementAtOrDefault(10)}</td>
                            </tr>");
                }
               
            }


            sb.Append($@"</tbody>
                        </table>
                    </body>
                  </html>");

            this.GeneratePdfReport(sb.ToString(), $"Attendance-report-{DateTime.Now.ToString("yyyy-MM-dd")}");
        }



        private void GeneratePdfReport(string html, string fileName)
        {
            GlobalSettings globalSettings = new GlobalSettings();
            globalSettings.ColorMode = ColorMode.Color;
            globalSettings.Orientation = Orientation.Portrait;
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
