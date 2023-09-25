using Dapper.Contrib.Extensions;
using EntitiesShared.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement
{
    [Table("IngInventoryTransactions")]
    public class IngInventoryTransactionModel : BaseLongModel
    {
        public long IngredientId { get; set; }

        [Write(false)]
        [Computed]
        public IngredientModel Ingredient { get; set; }

        public StaticData.InventoryTransType TransType { get; set; }

        public decimal QtyVal { get; set; }

        public decimal UnitCost { get; set; }

        public DateTime ExpirationDate { get; set; }

        public long UserId { get; set; }

        private UserModel user;
        [Write(false)]
        [Computed]
        public UserModel User
        {
            get { return user; }
            set { user = value; }
        }


        public string Remarks { get; set; }
    }
}
