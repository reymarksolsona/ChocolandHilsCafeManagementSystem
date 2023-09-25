using DapperGenericDataManager;
using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Data.OtherDataManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Implementations
{
    public class EmployeeGovtIdCardData : DataManagerCRUD<EmployeeGovtIdCardModel>, IEmployeeGovtIdCardData
    {
        private readonly IDbConnectionFactory _dbConnFactory;
        private readonly IGovernmentAgencyData _governmentAgencyData;

        public EmployeeGovtIdCardData(IDbConnectionFactory dbConnFactory, IGovernmentAgencyData governmentAgencyData) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
            _governmentAgencyData = governmentAgencyData;
        }

        public List<EmployeeGovtIdCardModel> GetAllByEmployeeNumber(string employeeNumber)
        {
            string query = @"SELECT * FROM EmployeeGovtIdCards
                            WHERE isDeleted=false AND employeeNumber=@EmployeeNumber";

            var idCards = this.GetAll(query, new { EmployeeNumber = employeeNumber });

            //foreach(var idCard in idCards)
            //{
            //    idCard.GovernmentAgency = _governmentAgencyData.Get(idCard.GovtAgencyId);
            //}

            return idCards;
        }

        public List<EmployeeGovtIdCardModel> GetAllByGovtAgency(long govtAgencyId)
        {
            string query = @"SELECT * FROM EmployeeGovtIdCards
                            WHERE isDeleted=false AND govtAgencyId=@GovtAgencyId";

            var idCards = this.GetAll(query, new { GovtAgencyId = govtAgencyId });

            //foreach (var idCard in idCards)
            //{
            //    idCard.GovernmentAgency = _governmentAgencyData.Get(idCard.GovtAgencyId);
            //}

            return idCards;
        }

        public EmployeeGovtIdCardModel GetByEmployeeIdNumber(string employeeIdNumber)
        {
            string query = @"SELECT * FROM EmployeeGovtIdCards
                            WHERE isDeleted=false AND employeeIdNumber=@EmployeeIdNumber";

            var idCard = this.GetFirstOrDefault(query, new { EmployeeIdNumber = employeeIdNumber });

            //idCard.GovernmentAgency = _governmentAgencyData.Get(idCard.GovtAgencyId);

            return idCard;
        }
    }
}
