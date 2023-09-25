using EntitiesShared.PayrollManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFReportGenerators
{
    public interface IEmployeePayslipPDFReport
    {
        void GenerateEmployeePayslips(List<EmployeePayslipModel> payslips);
        void GenerateEmployeePayslip(EmployeePayslipModel payslip);
    }
}
