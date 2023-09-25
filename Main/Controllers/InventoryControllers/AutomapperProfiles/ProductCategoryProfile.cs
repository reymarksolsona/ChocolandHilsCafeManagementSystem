using AutoMapper;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers.AutomapperProfiles
{
    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategoryModel, ProductCategoryModel>()
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
