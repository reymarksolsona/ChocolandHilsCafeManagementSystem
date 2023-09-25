using DapperGenericDataManager;
using DataAccess.Data.InventoryManagement.Contracts;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.InventoryManagement.Implementations
{
    public class ComboMealData : DataManagerCRUD<ComboMealModel>, IComboMealData
    {
        private readonly IDbConnectionFactory _dbConnFactory;
        private readonly IComboMealProductData _comboMealProductData;

        public ComboMealData(IDbConnectionFactory dbConnFactory, IComboMealProductData comboMealProductData) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
            _comboMealProductData = comboMealProductData;
        }

        public List<ComboMealModel> GetAllNotDeleted()
        {
            string query = @"SELECT * FROM ComboMeals WHERE isDeleted=false";

            var comboMeals = this.GetAll(query);

            if (comboMeals != null)
            {
                foreach(var meal in comboMeals)
                {
                    meal.Products = _comboMealProductData.GetAllByComboMeal(meal.Id);
                }
            }

            return comboMeals;
        }
    }
}
