using AutoMapper;
using EntitiesShared.PayrollManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.RequestControllers.AutomapperProfiles
{
    public class EmployeeCashAdvanceRequestProfile : Profile
    {
        public EmployeeCashAdvanceRequestProfile()
        {
            CreateMap<EmployeeCashAdvanceRequestModel, EmployeeCashAdvanceRequestModel>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.EmployeeNumber, opt => opt.Ignore())
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;
                        if (prop.GetType() == typeof(int) && int.MinValue == (int)prop) return false;
                        if (prop.GetType() == typeof(long) && long.MinValue == (long)prop) return false;

                        return true;
                    }
                ));
        }
    }
}
