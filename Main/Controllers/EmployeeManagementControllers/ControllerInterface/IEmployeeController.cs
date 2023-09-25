using EntitiesShared.EmployeeManagement;
using EntitiesShared.EmployeeManagement.Models;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.ControllerInterface
{
    public interface IEmployeeController
    {
        EntityResult<EmployeeDetailsModel> SaveEmployeeDetails(bool isNewEmployee, 
                                                                EmployeeModel employee, 
                                                                List<EmployeeGovtIdCardTempModel> idCards);

        void SaveEmployeeImageFileName(string employeeNumber, string fileName);

        EntityResult<UpdateEmployeeShiftModel> UpdateEmployeesShift(UpdateEmployeeShiftModel newEmpShift);

        EntityResult<EmployeeModel> GetByEmployeeNumber(string employeeNumber);
        List<EmployeeGovtIdCardTempModel> GetAllEmployeeIdCardsMapToCustomModel(string employeeNumber);

        //EntityResult<EmployeeSalaryRateModel> GetEmployeeSalaryRateByEmployeeNumber(string employeeNumber);

        ListOfEntityResult<EmployeeModel> GetAll();
        ListOfEntityResult<EmployeeModel> Search(string searchString);
        ListOfEntityResult<EmployeeModel> GetByDateHire(DateTime dateHire);

        EntityResult<EmployeeDetailsModel> GetEmployeeFullInformations(string employeeNumber);

        string GenerateNewEmployeeNumber(DateTime dateHire);

        bool MarkEmployeeAsQuit(string employeeNumber);
        bool UndoMarkEmployeeAsQuit(string employeeNumber);
        bool MarkEmployeeAsDeleted(string employeeNumber);
    }
}
