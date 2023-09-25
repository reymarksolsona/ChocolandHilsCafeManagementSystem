using DapperGenericDataManager;
using DataAccess.Data.InventoryManagement.Contracts;
using DataAccess.Data.UserManagement.Contracts;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EntitiesShared.UserManagement;

namespace DataAccess.Data.InventoryManagement.Implementations
{
    public class IngInventoryTransactionData : DataManagerCRUD<IngInventoryTransactionModel>, IIngInventoryTransactionData
    {
        private readonly IDbConnectionFactory _dbConnFactory;
        private readonly IUserData _userData;

        public IngInventoryTransactionData(IDbConnectionFactory dbConnFactory, IUserData userData) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
            _userData = userData;
        }

        public List<IngInventoryTransactionModel> GetAllByIngredientAndDateRange(long ingredientId, DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * FROM IngInventoryTransactions AS Trans
                            JOIN Ingredients AS Ing ON Ing.id = Trans.ingredientId
                            JOIN Users AS U ON U.id=Trans.userId
                            WHERE Trans.ingredientId=@IngredientId AND Trans.isDeleted=false AND Trans.createdAt BETWEEN @StartDate AND @EndDate
                            ORDER BY Trans.id DESC";

            var transactions = new List<IngInventoryTransactionModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                transactions = conn.Query<IngInventoryTransactionModel, IngredientModel, UserModel, IngInventoryTransactionModel>(query,
                    (Trans, Ing, U) => {

                        Trans.Ingredient = Ing;
                        Trans.User = U;

                        return Trans;
                    }, new
                    {
                        IngredientId = ingredientId,
                        StartDate = startDate.ToString("yyyy-MM-dd"),
                        EndDate = endDate.ToString("yyyy-MM-dd")
                    }).ToList();

                conn.Close();
            }

            return transactions;
        }


        public List<IngInventoryTransactionModel> GetAllByDateRange(DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * FROM IngInventoryTransactions AS Trans
                            JOIN Ingredients AS Ing ON Ing.id = Trans.ingredientId
                            JOIN Users AS U ON U.id=Trans.userId
                            WHERE Trans.isDeleted=false AND Trans.createdAt BETWEEN @StartDate AND @EndDate
                            ORDER BY Trans.id DESC";

            var transactions = new List<IngInventoryTransactionModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                transactions = conn.Query<IngInventoryTransactionModel, IngredientModel, UserModel, IngInventoryTransactionModel>(query,
                    (Trans, Ing, U) => {

                        Trans.Ingredient = Ing;
                        Trans.User = U;

                        return Trans;
                    }, new
                    {
                        StartDate = startDate.ToString("yyyy-MM-dd"),
                        EndDate = endDate.ToString("yyyy-MM-dd")
                    }).ToList();

                conn.Close();
            }

            return transactions;
        }
    }
}
