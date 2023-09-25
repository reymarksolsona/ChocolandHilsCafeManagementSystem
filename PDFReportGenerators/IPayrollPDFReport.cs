using EntitiesShared.PayrollManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFReportGenerators
{
    public interface IPayrollPDFReport
    {
        void GenerateEmployeePayslipsReport(List<EmployeePayslipModel> payslips, DateTime paydate);
    }
}
