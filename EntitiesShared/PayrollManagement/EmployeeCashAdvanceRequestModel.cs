using Dapper.Contrib.Extensions;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.PayrollManagement
{
    [Table("EmployeeCashAdvanceRequests")]
    public class EmployeeCashAdvanceRequestModel : BaseLongModel
    {
        public string EmployeeNumber { get; set; }

        [Write(false)]
        [Computed]
        public EmployeeModel Employee { get; set; }

        public decimal Amount { get; set; }

        public string EmployeeRemarks { get; set; }

        public DateTime NeedOnDate { get; set; }

        public StaticData.EmployeeRequestApprovalStatus ApprovalStatus { get; set; }

        public string EmployerRemarks { get; set; }

        public DateTime CashReleaseDate { get; set; }
    }
}
