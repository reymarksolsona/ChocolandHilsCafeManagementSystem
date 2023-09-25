using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.OtherDataManagement
{
    [Table("GovernmentAgencies")]
    public class GovernmentAgencyModel : BaseLongModel
    {
        private string govtAgency;

        public string GovtAgency
        {
            get { return govtAgency; }
            set { govtAgency = value; }
        }

        //public StaticData.GovContributions GovtAgencyContribId { get; set; }
    }
}
