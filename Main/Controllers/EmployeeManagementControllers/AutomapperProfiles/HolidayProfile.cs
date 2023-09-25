using AutoMapper;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.AutomapperProfiles
{
    public class HolidayProfile : Profile
    {
        public HolidayProfile()
        {
            CreateMap<HolidayModel, HolidayModel>()
                .ForMember(x => x.Id, opt => opt.Ignore())
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
