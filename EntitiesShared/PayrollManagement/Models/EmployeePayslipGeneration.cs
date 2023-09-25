using EntitiesShared.EmployeeManagement;
using EntitiesShared.OtherDataManagement;
using EntitiesShared.POSManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.PayrollManagement.Models
{
    public class EmployeePayslipGeneration
    {

        public DateTime PayDate { get; set; }

        public DateTime ShiftStartDate { get; set; }

        public DateTime ShiftEndDate { get; set; }


        private EmployeeModel employee;

        public EmployeeModel Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        private PaydaySalaryComputationPayslip paydaySalaryComputation;

        public PaydaySalaryComputationPayslip PaydaySalaryComputation
        {
            get { return paydaySalaryComputation; }
            set { paydaySalaryComputation = value; }
        }

        private List<EmployeeAttendanceModel> attendanceHistory;

        public List<EmployeeAttendanceModel> AttendanceHistory
        {
            get { return attendanceHistory; }
            set { attendanceHistory = value; }
        }


        private List<EmployeeLeaveModel> employeeLeaves;

        public List<EmployeeLeaveModel> EmployeeLeaves
        {
            get { return employeeLeaves; }
            set { employeeLeaves = value; }
        }


        private List<StaticData.GovContributions> selectedGovContributions;

        public List<StaticData.GovContributions> SelectedGovContributions
        {
            get { return selectedGovContributions; }
            set { selectedGovContributions = value; }
        }


        private List<EmployeeBenefitModel> selectedBenefits;

        public List<EmployeeBenefitModel> SelectedBenefits
        {
            get { return selectedBenefits; }
            set { selectedBenefits = value; }
        }


        private List<EmployeeCashAdvanceRequestModel> selectedEmpCashAdvanceRequests;

        public List<EmployeeCashAdvanceRequestModel> SelectedEmpCashAdvanceRequests
        {
            get { return selectedEmpCashAdvanceRequests; }
            set { selectedEmpCashAdvanceRequests = value; }
        }


        private List<EmployeeDeductionModel> selectedDeductions;
        public List<EmployeeDeductionModel> SelectedDeductions
        {
            get { return selectedDeductions; }
            set { selectedDeductions = value; }
        }


        private List<CashRegisterCashOutTransactionModel> selectedSalesReport;

        public List<CashRegisterCashOutTransactionModel> SelectedSalesReport
        {
            get { return selectedSalesReport; }
            set { selectedSalesReport = value; }
        }


    }
}
