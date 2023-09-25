using EntitiesShared.POSManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.POSControllers.ControllerInterface
{
    public interface IPOSCommandController
    {
        EntityResult<string> MarkTableAsAvailable(int tableNumber);
        EntityResult<string> UpdateMaxTableNumber(decimal newMaxTableNum);

        EntityResult<SaleTransactionModel> InitiateNewTransaction(SaleTransactionModel newSalesTransaction);
        EntityResult<string> SaveSaleTransaction(long saleTransId, int tableNumber, List<SaleTransactionProductModel> products, List<SaleTransactionComboMealModel> comboMeals);

        EntityResult<string> CancelSaleTransaction(long saleTransId);

        EntityResult<string> Checkout(SaleTransactionModel saleTransaction);

        EntityResult<string> SaveCashRegisterCashOutTransaction(CashRegisterCashOutTransactionModel cashOutTrans, bool isNew);
    }
}
