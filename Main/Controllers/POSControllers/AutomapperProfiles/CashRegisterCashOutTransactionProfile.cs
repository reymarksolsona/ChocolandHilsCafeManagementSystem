using AutoMapper;
using EntitiesShared.POSManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.POSControllers.AutomapperProfiles
{
    public class CashRegisterCashOutTransactionProfile : Profile
    {
        public CashRegisterCashOutTransactionProfile()
        {
            CreateMap<CashRegisterCashOutTransactionModel, CashRegisterCashOutTransactionModel>()
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
