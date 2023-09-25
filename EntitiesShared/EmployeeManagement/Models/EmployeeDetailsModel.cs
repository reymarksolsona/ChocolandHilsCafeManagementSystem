using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement.Models
{
    public class EmployeeDetailsModel
    {
        private EmployeeModel employee;

        public EmployeeModel Employee
        {
            get { return employee; }
            set { employee = value; }
        }


        private List<EmployeeGovtIdCardTempModel> employeeGovtIdCards;

        public List<EmployeeGovtIdCardTempModel> EmployeeGovtIdCards
        {
            get { return employeeGovtIdCards; }
            set { employeeGovtIdCards = value; }
        }


        //private EmployeeSalaryRateModel employeeSalary;

        //public EmployeeSalaryRateModel EmployeeSalary
        //{
        //    get { return employeeSalary; }
        //    set { employeeSalary = value; }
        //}
    }
}
