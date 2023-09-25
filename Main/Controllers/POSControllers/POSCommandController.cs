using AutoMapper;
using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared.POSManagement;
using FluentValidation.Results;
using Main.Controllers.POSControllers.ControllerInterface;
using Main.Controllers.POSControllers.Validators;
using Microsoft.Extensions.Logging;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesShared;
using DataAccess.Data.InventoryManagement.Contracts;
using Main.Controllers.InventoryControllers;
using System.Transactions;
using EntitiesShared.InventoryManagement;

namespace Main.Controllers.POSControllers
{
    public class POSCommandController : IPOSCommandController
    {
        private readonly ILogger<POSCommandController> _logger;
        private readonly IMapper _mapper;
        private readonly IStoreTableData _storeTableData;
        private readonly ISaleTransactionData _salesTransactionData;
        private readonly ISaleTransactionProductData _saleTransactionProductData;
        private readonly ISaleTransactionComboMealData _saleTransactionComboMealData;
        private readonly ISaleTranProdIngInvDeductionsRecordData _saleTranProdIngInvDeductionsRecordData;
        private readonly ISaleTranComboMealIngInvDeductionsRecordData _saleTranComboMealIngInvDeductionsRecordData;
        private readonly IProductData _productData;
        private readonly IProductIngredientData _productIngredientData;
        private readonly IComboMealData _comboMealData;
        private readonly IComboMealProductData _comboMealProductData;
        private readonly IIngredientInventoryData _ingredientInventoryData;
        private readonly IIngredientInventoryManager _ingredientInventoryManager;
        private readonly ICashRegisterCashOutTransactionData _cashRegisterCashOutTransactionData;
        private readonly Sessions _sessions;
        private readonly InitiateNewDineInSalesTransactionValidator _initiateNewDineInSalesTransValidator;
        private readonly InitiateNewTakeOutSalesTransactionValidator _initiateNewTakeOutSalesTransValidator;

        public POSCommandController(ILogger<POSCommandController> logger,
                                IMapper mapper,
                                IStoreTableData storeTableData,
                                ISaleTransactionData salesTransactionData,
                                ISaleTransactionProductData saleTransactionProductData,
                                ISaleTransactionComboMealData saleTransactionComboMealData,
                                ISaleTranProdIngInvDeductionsRecordData saleTranProdIngInvDeductionsRecordData,
                                ISaleTranComboMealIngInvDeductionsRecordData saleTranComboMealIngInvDeductionsRecordData,
                                IProductData productData,
                                IProductIngredientData productIngredientData,
                                IComboMealData comboMealData,
                                IComboMealProductData comboMealProductData,
                                IIngredientInventoryData ingredientInventoryData,
                                IIngredientInventoryManager ingredientInventoryManager,
                                ICashRegisterCashOutTransactionData cashRegisterCashOutTransactionData,
                                Sessions sessions,
                                InitiateNewDineInSalesTransactionValidator initiateNewDineInSalesTransValidator,
                                InitiateNewTakeOutSalesTransactionValidator initiateNewTakeOutSalesTransValidator)
        {
            _logger = logger;
            _mapper = mapper;
            _storeTableData = storeTableData;
            _salesTransactionData = salesTransactionData;
            _saleTransactionProductData = saleTransactionProductData;
            _saleTransactionComboMealData = saleTransactionComboMealData;
            _saleTranProdIngInvDeductionsRecordData = saleTranProdIngInvDeductionsRecordData;
            _saleTranComboMealIngInvDeductionsRecordData = saleTranComboMealIngInvDeductionsRecordData;
            _productData = productData;
            _productIngredientData = productIngredientData;
            _comboMealData = comboMealData;
            _comboMealProductData = comboMealProductData;
            _ingredientInventoryData = ingredientInventoryData;
            _ingredientInventoryManager = ingredientInventoryManager;
            _cashRegisterCashOutTransactionData = cashRegisterCashOutTransactionData;
            _sessions = sessions;
            _initiateNewDineInSalesTransValidator = initiateNewDineInSalesTransValidator;
            _initiateNewTakeOutSalesTransValidator = initiateNewTakeOutSalesTransValidator;
        }

        public bool CheckIfCanUpdateMaxTableNumber(decimal maxTableNumber)
        {
            var activeTransactionGreaterOrEqualToThisMaxTableNum = _salesTransactionData.GetActiveTransactionGreaterOrEqualToMaxTable((int)maxTableNumber);

            if (activeTransactionGreaterOrEqualToThisMaxTableNum == null)
                return true;

            if (activeTransactionGreaterOrEqualToThisMaxTableNum.Count == 0)
                return true;

            return false;
        }

        public EntityResult<string> UpdateMaxTableNumber (decimal newMaxTableNum)
        {
            var results = new EntityResult<string>();
            results.IsSuccess = false;


            var lastData = _storeTableData.GetTheLastTransaction();

            if (lastData == null)
            {
                var tableId = _storeTableData.Add(new StoreTableModel { NumberOfTables = newMaxTableNum });

                if (tableId > 0)
                {
                    results.IsSuccess = true;
                    results.Messages.Add("Successfully update number of tables");
                    return results;
                }
            }

            if (lastData != null)
            {
                bool canWeUpdateMaxTable = CheckIfCanUpdateMaxTableNumber(newMaxTableNum);

                if (canWeUpdateMaxTable == false)
                {
                    results.IsSuccess = false;
                    results.Messages.Add($"Unable to update number of tables. Ongoing transaction(s) using tables greater than or equal to {newMaxTableNum}");
                    return results;
                }

                if (canWeUpdateMaxTable)
                {
                    lastData.NumberOfTables = newMaxTableNum;
                    if (_storeTableData.Update(lastData))
                    {
                        results.IsSuccess = true;
                        results.Messages.Add("Successfully update number of tables");
                        return results;
                    }
                }
            }

            results.Messages.Add("Unable to update number of tables");

            return results;
        }

        public EntityResult<string> MarkTableAsAvailable(int tableNumber)
        {
            var results = new EntityResult<string>();
            results.IsSuccess = false;


            var ongoingTransactionUsingThisTable = _salesTransactionData.GetSalesTransactionByTableNumberAndTransType(tableNumber, StaticData.POSTransactionType.DineIn);

            if (ongoingTransactionUsingThisTable != null)
            {
                var singleTransUsingThisTable = ongoingTransactionUsingThisTable.Where(x => x.TableNumber == tableNumber && x.TransStatus == StaticData.POSTransactionStatus.OnGoing).FirstOrDefault();

                if (singleTransUsingThisTable != null)
                {
                    results.IsSuccess = false;
                    results.Messages.Add("Ongoing transaction using this table");
                    return results;
                }
            }

            var markTableResult = _salesTransactionData.MarkTableAsAvailable(tableNumber);

            if (markTableResult)
            {
                results.IsSuccess = true;
                results.Messages.Add("Successfully mark this table as available");
                return results;
            }

            results.IsSuccess = false;
            results.Messages.Add("Unable to mark this table as available");

            return results;
        }

        public string GetTicketNumber()
        {
            return DateTime.Now.ToString("yyMMddHHmmssffft");
        }

        public EntityResult<SaleTransactionModel> InitiateNewTransaction(SaleTransactionModel newSalesTransaction)
        {
            var results = new EntityResult<SaleTransactionModel>();
            results.IsSuccess = false;

            try
            {
                var activeTakeOutTrans = _salesTransactionData
                                            .GetSalesTransactionByStatusAndTransType(StaticData.POSTransactionStatus.OnGoing, 
                                            StaticData.POSTransactionType.TakeOut); // will return the list in DESC ORDER

                var lastTakeOutTransaction = activeTakeOutTrans != null ? activeTakeOutTrans.FirstOrDefault() : null; // so it's okay to get the first item
                int newTakeOutNumber = lastTakeOutTransaction == null ? 1 : lastTakeOutTransaction.TakeOutNumber + 1;


                newSalesTransaction.TicketNumber = GetTicketNumber();
                newSalesTransaction.CurrentUser = _sessions.CurrentLoggedInUser.FullName;
                newSalesTransaction.TransStatus = StaticData.POSTransactionStatus.OnGoing;

                if (newSalesTransaction.TransactionType == StaticData.POSTransactionType.DineIn)
                {
                    ValidationResult validationResult = _initiateNewDineInSalesTransValidator.Validate(newSalesTransaction);

                    if (!validationResult.IsValid)
                    {
                        foreach (var failure in validationResult.Errors)
                        {
                            results.Messages.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                        }
                        results.IsSuccess = false;
                        return results;
                    }

                    newSalesTransaction.TakeOutNumber = 0;
                }

                if (newSalesTransaction.TransactionType == StaticData.POSTransactionType.TakeOut)
                {
                    ValidationResult validationResult = _initiateNewTakeOutSalesTransValidator.Validate(newSalesTransaction);

                    if (!validationResult.IsValid)
                    {
                        foreach (var failure in validationResult.Errors)
                        {
                            results.Messages.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                        }
                        results.IsSuccess = false;
                        return results;
                    }

                    newSalesTransaction.TakeOutNumber = newTakeOutNumber;
                }

                long newSalesTransId = _salesTransactionData.Add(newSalesTransaction);

                if (newSalesTransId > 0)
                {
                    var salesTransDetails = _salesTransactionData.Get(newSalesTransId);

                    results.IsSuccess = true;
                    results.Messages.Add("Successfully initiate sales transaction.");
                    results.Data = salesTransDetails;
                }
                else
                {
                    results.IsSuccess = false;
                    results.Messages.Add("Unable to initiate new sales transaction, kindly check system logs for possible errors.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }


        public EntityResult<string> SaveSaleTransaction(long saleTransId, int tableNumber, List<SaleTransactionProductModel> products, List<SaleTransactionComboMealModel> comboMeals)
        {
            var results = new EntityResult<string>();
            results.IsSuccess = false;

            try
            {
                if (products == null && comboMeals == null)
                {
                    results.Messages.Add("Add item first.");
                    return results;
                }

                if (saleTransId == 0 || saleTransId == long.MinValue)
                {
                    results.Messages.Add("Unable to save this current transaction, kindly initiate new.");
                    return results;
                }

                var saleTransactionDetailsInDb = _salesTransactionData.Get(saleTransId);

                if (saleTransactionDetailsInDb == null)
                {
                    results.Messages.Add("Unable to save this current transaction, kindly initiate new.");
                    return results;
                }

                using var transaction = new TransactionScope();

                //_mapper.Map(newSalesTransaction, saleTransactionDetailsInDb);

                var saveProductsResults = this.SaveSaleTransactionProducts(saleTransactionDetailsInDb.Id, products);

                foreach (var res in saveProductsResults.Messages)
                {
                    results.Messages.Add(res);
                }

                var saveComboMealsResults = this.SaveSaleTransactionComboMeals(saleTransactionDetailsInDb.Id, comboMeals);

                foreach (var res in saveComboMealsResults.Messages)
                {
                    results.Messages.Add(res);
                }

                decimal subTotal = 0;

                foreach(var prod in products)
                {
                    subTotal += prod.totalAmount;
                }

                foreach(var cm in comboMeals)
                {
                    subTotal += cm.totalAmount;
                }

                saleTransactionDetailsInDb.SubTotalAmount = subTotal;

                if (tableNumber != saleTransactionDetailsInDb.TableNumber)
                {
                    saleTransactionDetailsInDb.TableNumber = tableNumber;
                }

                _salesTransactionData.Update(saleTransactionDetailsInDb);

                transaction.Complete();

                results.IsSuccess = true;
                results.Messages.Add("Successfully saved current transaction.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add(ex.Message);
            }

            return results;
        }

        public EntityResult<string> SaveSaleTransactionProducts(long saleTransactionId, List<SaleTransactionProductModel> products)
        {
            var results = new EntityResult<string>();
            results.IsSuccess = false;

            // NOTE for TODO next: we will return the qty value to last ingredient's inventory
            var existingSaleTranProducts = _saleTransactionProductData.GetAllBySaleTransId(saleTransactionId).ToList();

            foreach(var existingSaleTranProd in existingSaleTranProducts)
            {
                var existingProdInProductList = products.Where(x => x.ProductId == existingSaleTranProd.ProductId).FirstOrDefault();

                // meaning, we completely delete the item from order or cart
                if (existingProdInProductList == null)
                {
                    var productInfo = _productData.Get(existingSaleTranProd.ProductId);

                    if (productInfo == null)
                    {
                        results.Messages.Add($"{existingProdInProductList.Product.ProdName}: Product not found.");
                        return results;
                    }

                    existingSaleTranProd.IsDeleted = true;
                    existingSaleTranProd.DeletedAt = DateTime.Now;

                    _saleTransactionProductData.Update(existingSaleTranProd);
                    this.ReturnRequiredIngredientQtyToInventory(productInfo, existingSaleTranProd.Qty, existingSaleTranProd.Id);
                }
            }

            foreach (var item in products)
            {
                var productInfo = _productData.Get(item.ProductId);

                if (productInfo == null)
                {
                    results.Messages.Add($"{item.Product.ProdName}: Product not found.");
                    return results;
                }

                item.SalesTransId = saleTransactionId;
                item.totalAmount = item.Qty * item.productCurrentPrice;

                if (existingSaleTranProducts == null || (existingSaleTranProducts != null && existingSaleTranProducts.Count == 0))
                {
                    var saleTransProdId = _saleTransactionProductData.Add(item); // <--- save sale transaction product
                    this.DeductRequiredIngredientsFromInventory(productInfo, item.Qty, saleTransProdId);
                }

                if (existingSaleTranProducts != null && existingSaleTranProducts.Count > 0)
                {
                    var existingSaleTranProd = existingSaleTranProducts.Where(x => x.ProductId == item.ProductId).FirstOrDefault();

                    if (existingSaleTranProd == null)
                    {
                        var saleTransProdId = _saleTransactionProductData.Add(item);// <--- save sale transaction product
                        this.DeductRequiredIngredientsFromInventory(productInfo, item.Qty, saleTransProdId);
                    }

                    if (existingSaleTranProd != null)
                    {
                        if (existingSaleTranProd.Qty > item.Qty)
                        {
                            // get removed qty by the user
                            int orderQtyDiff = existingSaleTranProd.Qty - item.Qty;
                            //existingSaleTranProd.Qty = item.Qty; // replace the existing qty to new

                            // update existing sale transaction product
                            _mapper.Map(item, existingSaleTranProd);

                            _saleTransactionProductData.Update(existingSaleTranProd);
                            this.ReturnRequiredIngredientQtyToInventory(productInfo, orderQtyDiff, existingSaleTranProd.Id);
                            // meaning, the user decrease the qty of existing prod
                        }

                        if (existingSaleTranProd.Qty < item.Qty)
                        {
                            // get the added qty by the user
                            int orderQtyDiff = item.Qty - existingSaleTranProd.Qty;
                            //existingSaleTranProd.Qty = item.Qty; // replace the existing qty to new

                            // update existing sale transaction product
                            _mapper.Map(item, existingSaleTranProd);

                            _saleTransactionProductData.Update(existingSaleTranProd);// <--- save sale transaction product
                            this.DeductRequiredIngredientsFromInventory(productInfo, orderQtyDiff, existingSaleTranProd.Id);
                            // the user increase the qty of existing prod
                        }
                    }
                }
            }

            return results;
        }

        public void ReturnRequiredIngredientQtyToInventory(ProductModel productInfo, int orderReturnQty, long saleTransProdId)
        {
            // Get all needed ingredients for current product
            var productIngredients = _productIngredientData.GetAllByProduct(productInfo.Id);

            foreach (var prodIngredient in productIngredients)
            {
                // Qty Value we need to return based on number of return order(s)
                var productQtyWeNeedToReturn = prodIngredient.QtyValue * orderReturnQty; // ex. 500ml * 5 orders

                // return the qty to the last inventory (far from expiration date)
                var saleTranProdIngInvDeductionRecords = _saleTranProdIngInvDeductionsRecordData
                                                            .GetAllBySaleTranProductId(saleTransProdId, prodIngredient.IngredientId)
                                                            .OrderByDescending(x => x.DeductionSequence).ToList();

                // we need the ing's inventory id, qty value we need to return
                foreach(var invDeductionRec in saleTranProdIngInvDeductionRecords)
                {
                    var ingInventory = _ingredientInventoryData.GetByIdAndIngredientIncludeDeletedAndSoldOut(invDeductionRec.IngredientId, invDeductionRec.IngredientInventoryId);
                    
                    if (ingInventory == null)
                    {
                        throw new Exception("Invalid ingredient inventory id");
                    }

                    if (invDeductionRec.DeductedQtyValue >= productQtyWeNeedToReturn && productQtyWeNeedToReturn > 0)
                    {
                        decimal actualQtyValueWeNeedToReturn = _ingredientInventoryManager.GetProductIngredientActualQtyValueNeedToDeduct(invDeductionRec.UsedUOM, productQtyWeNeedToReturn);

                        // return qty value in inventory
                        ingInventory.RemainingQtyValue += actualQtyValueWeNeedToReturn;
                        ingInventory.IsDeleted = false;
                        ingInventory.IsSoldOut = false;

                        // assume that deducted qty value is greater than the return qty value
                        decimal remainingInDeductedQtyVal = invDeductionRec.DeductedQtyValue - actualQtyValueWeNeedToReturn;

                        if (remainingInDeductedQtyVal == 0)
                        {
                            invDeductionRec.IsDeleted = true;
                            invDeductionRec.DeletedAt = DateTime.Now;
                        }

                        if (remainingInDeductedQtyVal > 0)
                        {
                            invDeductionRec.DeductedQtyValue = remainingInDeductedQtyVal;
                        }

                        productQtyWeNeedToReturn = 0;
                    }

                    if (invDeductionRec.DeductedQtyValue < productQtyWeNeedToReturn && productQtyWeNeedToReturn > 0)
                    {
                        productQtyWeNeedToReturn = productQtyWeNeedToReturn - invDeductionRec.DeductedQtyValue;

                        decimal actualQtyValueWeNeedToReturn = _ingredientInventoryManager.GetProductIngredientActualQtyValueNeedToDeduct(invDeductionRec.UsedUOM, invDeductionRec.DeductedQtyValue);

                        // return qty value in inventory
                        ingInventory.RemainingQtyValue += actualQtyValueWeNeedToReturn;
                        ingInventory.IsDeleted = false;
                        ingInventory.IsSoldOut = false;

                        invDeductionRec.IsDeleted = true;
                        invDeductionRec.DeletedAt = DateTime.Now;
                    }

                    // update this ingredient inventory immediately 
                    _ingredientInventoryData.Update(ingInventory);
                }

                // update sale transaction product ingredient deduction records
                _saleTranProdIngInvDeductionsRecordData.UpdateRange(saleTranProdIngInvDeductionRecords);
            }
        }

        public void DeductRequiredIngredientsFromInventory(ProductModel productInfo, int orderQty, long saleTransProdId)
        {
            // Get all needed ingredients for current product
            var productIngredients = _productIngredientData.GetAllByProduct(productInfo.Id);
            foreach (var prodIngredient in productIngredients)
            {
                // Qty Value we need to deduct based on number of orders
                var productQtyWeNeedToDeduct = prodIngredient.QtyValue * orderQty; // ex. 500ml * 5 orders

                // we need the list of inventories we can deduct the product's ingredient qty value
                // because, in single ingredient, we can have multiple inventory
                var inventoriesWhereWeCanDeductProductIngredientQtyValue = _ingredientInventoryManager
                                                                            .GetWhereInventoryThisProductIngredientToDeduct(prodIngredient.IngredientId, productQtyWeNeedToDeduct, prodIngredient.UOM)
                                                                            .OrderBy(x => x.DeductionSequence);

                // deduct require qty value in our ingredient's inventories
                foreach (var inventory in inventoriesWhereWeCanDeductProductIngredientQtyValue)
                {
                    var inventoryDetails = _ingredientInventoryData.GetByIdAndIngredient(inventory.IngredientId, inventory.IngredientInventoryid);

                    decimal newRemainingQtyValue = (inventoryDetails.RemainingQtyValue - inventory.DeductQtyValue);

                    if (newRemainingQtyValue == 0)
                    {
                        inventoryDetails.RemainingQtyValue = 0;
                        inventoryDetails.IsSoldOut = true;
                    }
                    else
                    {
                        inventoryDetails.RemainingQtyValue = newRemainingQtyValue;
                    }

                    _ingredientInventoryData.Update(inventoryDetails);


                    // store above data so we can use it in case we need to revert all deductions
                    _saleTranProdIngInvDeductionsRecordData.Add(new SaleTranProdIngInvDeductionsRecordModel
                    {
                        DeductionSequence = inventory.DeductionSequence,
                        SaleTransProductId = saleTransProdId,
                        IngredientId = prodIngredient.IngredientId,
                        IngredientInventoryId = inventory.IngredientInventoryid,
                        IngredientUOM = prodIngredient.Ingredient.UOM,
                        UsedUOM = prodIngredient.UOM,
                        DeductedQtyValue = inventory.DeductQtyValue,
                        IngInvCurrentUnitCost = inventoryDetails.UnitCost,
                        TotalCost = inventory.Cost
                    });
                }
            }
        }


        public EntityResult<string> SaveSaleTransactionComboMeals(long saleTransactionId, List<SaleTransactionComboMealModel> comboMeals)
        {
            var results = new EntityResult<string>();
            results.IsSuccess = false;

            // NOTE for TODO next: we will return the qty value to last ingredient's inventory
            var existingSaleTranComboMeals = _saleTransactionComboMealData.GetAllBySaleTranId(saleTransactionId).ToList();

            foreach(var existingSaleTranComboMeal in existingSaleTranComboMeals)
            {
                var existingComboMealInTheComboMealList = comboMeals.Where(x => x.ComboMealId == existingSaleTranComboMeal.ComboMealId).FirstOrDefault();

                // meaning, we completely delete the item from order or cart
                if (existingComboMealInTheComboMealList == null)
                {
                    var comboMealProducts = _comboMealProductData.GetAllByComboMealPlain(existingSaleTranComboMeal.ComboMealId);

                    if (comboMealProducts == null)
                        throw new Exception($"{existingComboMealInTheComboMealList.ComboMeal.Title}: Combo Meal's products not found.");

                    existingSaleTranComboMeal.IsDeleted = true;
                    existingSaleTranComboMeal.DeletedAt = DateTime.Now;

                    _saleTransactionComboMealData.Update(existingSaleTranComboMeal);
                    this.ReturnRequiredComboMealProdsIngredients(comboMealProducts, existingSaleTranComboMeal.Qty, existingSaleTranComboMeal.Id);
                }
            }

            foreach (var item in comboMeals)
            {
                var comboMealProducts = _comboMealProductData.GetAllByComboMealPlain(item.ComboMealId);

                if (comboMealProducts == null)
                    throw new Exception($"{item.ComboMeal.Title}: Combo Meal's products not found.");

                item.SalesTransId = saleTransactionId;
                item.totalAmount = item.Qty * item.ComboMealCurrentPrice;

                if (existingSaleTranComboMeals == null || (existingSaleTranComboMeals != null && existingSaleTranComboMeals.Count == 0))
                {
                    var saleTransComboMealId = _saleTransactionComboMealData.Add(item);
                    this.DeductRequiredComboMealProdsIngredients(comboMealProducts, item.Qty, saleTransComboMealId);
                }

                if (existingSaleTranComboMeals != null && existingSaleTranComboMeals.Count > 0)
                {
                    var saleTranComboMeal = existingSaleTranComboMeals.Where(x => x.ComboMealId == item.ComboMealId).FirstOrDefault();

                    if (saleTranComboMeal == null)
                    {
                        var saleTransComboMealId = _saleTransactionComboMealData.Add(item);
                        this.DeductRequiredComboMealProdsIngredients(comboMealProducts, item.Qty, saleTransComboMealId);
                    }

                    if (saleTranComboMeal != null)
                    {
                        if (saleTranComboMeal.Qty > item.Qty)
                        {
                            //get removed qty
                            int returnOrderQtyDiff = saleTranComboMeal.Qty - item.Qty;
                            //saleTranComboMeal.Qty = item.Qty;

                            // update sale transaction combo meal
                            _mapper.Map(item, saleTranComboMeal);

                            _saleTransactionComboMealData.Update(saleTranComboMeal);
                            this.ReturnRequiredComboMealProdsIngredients(comboMealProducts, returnOrderQtyDiff, saleTranComboMeal.Id);
                        }

                        if (saleTranComboMeal.Qty < item.Qty)
                        {
                            // get added qty
                            int addedOrderQtyDiff = item.Qty - saleTranComboMeal.Qty;
                            //saleTranComboMeal.Qty = item.Qty;

                            _mapper.Map(item, saleTranComboMeal);
                            _saleTransactionComboMealData.Update(saleTranComboMeal);
                            this.DeductRequiredComboMealProdsIngredients(comboMealProducts, item.Qty, saleTranComboMeal.Id);
                        }

                    }
                }
            }

            return results;
        }

        public void DeductRequiredComboMealProdsIngredients(List<ComboMealProductModel> comboMealProducts, int orderQty, long saleTransComboMealId)
        {
            foreach(var comboMealProd in comboMealProducts)
            {
                var productInfo = _productData.Get(comboMealProd.ProductId);
                int realOrderQty = comboMealProd.Quantity * orderQty;

                this.DeductComboMealProdRequiredIngredientsFromInventory(productInfo, realOrderQty, saleTransComboMealId);
            }
        }

        public void ReturnRequiredComboMealProdsIngredients(List<ComboMealProductModel> comboMealProducts, int returnOrderQty, long saleTransComboMealId)
        {
            foreach (var comboMealProd in comboMealProducts)
            {
                var productInfo = _productData.Get(comboMealProd.ProductId);
                int realReturnOrderQty = comboMealProd.Quantity * returnOrderQty;

                this.ReturnComboMealProdRequiredIngredientQtyToInventory(productInfo, realReturnOrderQty, saleTransComboMealId);
            }
        }

        public void DeductComboMealProdRequiredIngredientsFromInventory(ProductModel productInfo, int orderQty, long saleTransComboMealId)
        {
            // Get all needed ingredients for current product
            var productIngredients = _productIngredientData.GetAllByProduct(productInfo.Id);
            foreach (var prodIngredient in productIngredients)
            {
                // Qty Value we need to deduct based on number of orders
                var productQtyWeNeedToDeduct = prodIngredient.QtyValue * orderQty; // ex. 500ml * 5 orders

                // we need the list of inventories we can deduct the product's ingredient qty value
                // because, in single ingredient, we can have multiple inventory
                var inventoriesWhereWeCanDeductProductIngredientQtyValue = _ingredientInventoryManager
                                                                            .GetWhereInventoryThisProductIngredientToDeduct(prodIngredient.IngredientId, productQtyWeNeedToDeduct, prodIngredient.UOM)
                                                                            .OrderBy(x => x.DeductionSequence);

                // deduct require qty value in our ingredient's inventories
                foreach (var inventory in inventoriesWhereWeCanDeductProductIngredientQtyValue)
                {
                    var inventoryDetails = _ingredientInventoryData.GetByIdAndIngredient(inventory.IngredientId, inventory.IngredientInventoryid);

                    decimal newRemainingQtyValue = (inventoryDetails.RemainingQtyValue - inventory.DeductQtyValue);

                    if (newRemainingQtyValue == 0)
                    {
                        inventoryDetails.RemainingQtyValue = 0;
                        inventoryDetails.IsSoldOut = true;
                    }
                    else
                    {
                        inventoryDetails.RemainingQtyValue = newRemainingQtyValue;
                    }

                    _ingredientInventoryData.Update(inventoryDetails);

                    // store above data so we can use it in case we need to revert all deductions
                    _saleTranComboMealIngInvDeductionsRecordData.Add(new SaleTranComboMealIngInvDeductionsRecordModel
                    {
                        DeductionSequence = inventory.DeductionSequence,
                        SaleTransComboMealId = saleTransComboMealId,
                        ProductId = productInfo.Id,
                        IngredientId = prodIngredient.IngredientId,
                        IngredientInventoryId = inventory.IngredientInventoryid,
                        IngredientUOM = prodIngredient.Ingredient.UOM,
                        UsedUOM = prodIngredient.UOM,
                        DeductedQtyValue = inventory.DeductQtyValue,
                        IngInvCurrentUnitCost = inventoryDetails.UnitCost,
                        TotalCost = inventory.Cost
                    });
                }
            }
        }

        public void ReturnComboMealProdRequiredIngredientQtyToInventory(ProductModel productInfo, int orderReturnQty, long saleTransComboMealId)
        {
            // Get all needed ingredients for current product
            var productIngredients = _productIngredientData.GetAllByProduct(productInfo.Id);

            foreach (var prodIngredient in productIngredients)
            {
                // Qty Value we need to return based on number of return order(s)
                var productQtyWeNeedToReturn = prodIngredient.QtyValue * orderReturnQty; // ex. 500ml * 5 orders

                // return the qty to the last inventory (far from expiration date)
                var saleTranComboMealIngInvDeductionRecords = _saleTranComboMealIngInvDeductionsRecordData
                                                            .GetAllBySaleTranComboMealId(saleTransComboMealId, productInfo.Id, prodIngredient.IngredientId)
                                                            .OrderByDescending(x => x.DeductionSequence).ToList();

                // we need the ing's inventory id, qty value we need to return
                foreach (var invDeductionRec in saleTranComboMealIngInvDeductionRecords)
                {
                    var ingInventory = _ingredientInventoryData.GetByIdAndIngredientIncludeDeletedAndSoldOut(invDeductionRec.IngredientId, invDeductionRec.IngredientInventoryId);

                    if (ingInventory == null)
                    {
                        throw new Exception("Invalid ingredient inventory id");
                    }

                    if (invDeductionRec.DeductedQtyValue >= productQtyWeNeedToReturn && productQtyWeNeedToReturn > 0)
                    {
                        decimal actualQtyValueWeNeedToReturn = _ingredientInventoryManager.GetProductIngredientActualQtyValueNeedToDeduct(invDeductionRec.UsedUOM, productQtyWeNeedToReturn);

                        // return qty value in inventory
                        ingInventory.RemainingQtyValue += actualQtyValueWeNeedToReturn;
                        ingInventory.IsDeleted = false;
                        ingInventory.IsSoldOut = false;

                        // assume that deducted qty value is greater than the return qty value
                        decimal remainingInDeductedQtyVal = invDeductionRec.DeductedQtyValue - actualQtyValueWeNeedToReturn;

                        if (remainingInDeductedQtyVal == 0)
                        {
                            invDeductionRec.IsDeleted = true;
                            invDeductionRec.DeletedAt = DateTime.Now;
                        }

                        if (remainingInDeductedQtyVal > 0)
                        {
                            invDeductionRec.DeductedQtyValue = remainingInDeductedQtyVal;
                        }

                        productQtyWeNeedToReturn = 0;
                    }

                    if (invDeductionRec.DeductedQtyValue < productQtyWeNeedToReturn && productQtyWeNeedToReturn > 0)
                    {
                        productQtyWeNeedToReturn = productQtyWeNeedToReturn - invDeductionRec.DeductedQtyValue;
                       
                        decimal actualQtyValueWeNeedToReturn = _ingredientInventoryManager.GetProductIngredientActualQtyValueNeedToDeduct(invDeductionRec.UsedUOM, invDeductionRec.DeductedQtyValue);

                        // return qty value in inventory
                        ingInventory.RemainingQtyValue += actualQtyValueWeNeedToReturn;
                        ingInventory.IsDeleted = false;
                        ingInventory.IsSoldOut = false;

                        invDeductionRec.IsDeleted = true;
                        invDeductionRec.DeletedAt = DateTime.Now;
                    }

                    // update this ingredient inventory immediately 
                    _ingredientInventoryData.Update(ingInventory);
                }

                // update sale transaction product ingredient deduction records
                _saleTranComboMealIngInvDeductionsRecordData.UpdateRange(saleTranComboMealIngInvDeductionRecords);
            }
        }


        public EntityResult<string> CancelSaleTransaction(long saleTransId)
        {
            var results = new EntityResult<string>();
            results.IsSuccess = false;

            try
            {
                if (saleTransId == 0 || saleTransId == long.MinValue)
                {
                    results.Messages.Add("Unable to save this current transaction, kindly initiate new.");
                    return results;
                }

                var saleTransactionDetailsInDb = _salesTransactionData.Get(saleTransId);

                if (saleTransactionDetailsInDb == null)
                {
                    results.Messages.Add("Unable to save this current transaction, kindly initiate new.");
                    return results;
                }

                using var transaction = new TransactionScope();

                saleTransactionDetailsInDb.TransStatus = StaticData.POSTransactionStatus.Cancelled;

                _salesTransactionData.Update(saleTransactionDetailsInDb);

                this.ReturnAllSaleTransactionProducts(saleTransactionDetailsInDb.Id);
                this.ReturnAllSaleTransactionComboMeals(saleTransactionDetailsInDb.Id);

                transaction.Complete();

                results.IsSuccess = true;
                results.Messages.Add("Successfully cancel current transaction.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add(ex.Message);
            }

            return results;
        }

        public void ReturnAllSaleTransactionProducts(long saleTransactionId)
        {
            var existingSaleTranProducts = _saleTransactionProductData.GetAllBySaleTransId(saleTransactionId).ToList();
            foreach (var existingSaleTranProd in existingSaleTranProducts)
            {
                var productInfo = _productData.Get(existingSaleTranProd.ProductId);

                existingSaleTranProd.IsDeleted = true;
                existingSaleTranProd.DeletedAt = DateTime.Now;

                _saleTransactionProductData.Update(existingSaleTranProd);
                this.ReturnRequiredIngredientQtyToInventory(productInfo, existingSaleTranProd.Qty, existingSaleTranProd.Id);
            }
        }


        public void ReturnAllSaleTransactionComboMeals(long saleTransactionId)
        {
            var existingSaleTranComboMeals = _saleTransactionComboMealData.GetAllBySaleTranId(saleTransactionId).ToList();

            foreach (var existingSaleTranComboMeal in existingSaleTranComboMeals)
            {
                var comboMealProducts = _comboMealProductData.GetAllByComboMealPlain(existingSaleTranComboMeal.ComboMealId);

                existingSaleTranComboMeal.IsDeleted = true;
                existingSaleTranComboMeal.DeletedAt = DateTime.Now;

                _saleTransactionComboMealData.Update(existingSaleTranComboMeal);
                this.ReturnRequiredComboMealProdsIngredients(comboMealProducts, existingSaleTranComboMeal.Qty, existingSaleTranComboMeal.Id);
            }
        }



        public EntityResult<string> Checkout(SaleTransactionModel saleTransaction)
        {
            var results = new EntityResult<string>();
            results.IsSuccess = false;

            try
            {
                if (saleTransaction.Id == 0 || saleTransaction.Id == long.MinValue)
                {
                    results.Messages.Add("Unable to save this current transaction, kindly initiate new.");
                    return results;
                }

                var saleTransactionInDB = _salesTransactionData.Get(saleTransaction.Id);

                _mapper.Map(saleTransaction, saleTransactionInDB);

                saleTransactionInDB.TransStatus = StaticData.POSTransactionStatus.Paid;

                if (_salesTransactionData.Update(saleTransactionInDB))
                {
                    results.IsSuccess = true;
                    results.Messages.Add("Checkout transaction successfully");
                    return results;
                }

                results.IsSuccess = false;
                results.Messages.Add("Unable to process checkout transaction");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add(ex.Message);
            }

            return results;
        }


        public EntityResult<string> SaveCashRegisterCashOutTransaction(CashRegisterCashOutTransactionModel cashOutTrans, bool isNew)
        {
            var results = new EntityResult<string>();
            results.IsSuccess = false;

            try
            {
                if (cashOutTrans == null)
                {
                    results.IsSuccess = false;
                    results.Messages.Add("Invalid cash out transaction");
                    return results;
                }

                cashOutTrans.CurrentUser = _sessions.CurrentLoggedInUser.FullName;

                if (isNew)
                {
                    //var lastTrans = _cashRegisterCashOutTransactionData.GetLastTransaction();

                    //if (lastTrans != null && lastTrans.CreatedAt == DateTime.Now)
                    //{
                    //    results.IsSuccess = false;
                    //    results.Messages.Add("");
                    //    return results;
                    //}

                    long cashTransId = 0;

                    // transaction scope
                    using var transaction = new TransactionScope();
                    cashTransId = _cashRegisterCashOutTransactionData.Add(cashOutTrans);
                    _salesTransactionData.MassSalesTransactionSalesCashout(StaticData.POSTransactionStatus.Paid, DateTime.Now);
                    transaction.Complete();


                    if (cashTransId > 0)
                    {
                        results.IsSuccess = true;
                        results.Messages.Add("Successfull save cash out transaction.");
                        return results;
                    }

                }

                if (isNew == false)
                {
                    // update
                    if (cashOutTrans.Id == 0 || cashOutTrans.Id == long.MinValue)
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Cash out transaction object: missing id");
                        return results;
                    }

                    var cashOutTransInOurDb = _cashRegisterCashOutTransactionData.Get(cashOutTrans.Id);

                    _mapper.Map(cashOutTrans, cashOutTransInOurDb);

                    bool isDoneUpdate = false;

                    // transaction scope
                    using var transaction = new TransactionScope();
                    isDoneUpdate = _cashRegisterCashOutTransactionData.Update(cashOutTransInOurDb);
                    _salesTransactionData.MassSalesTransactionSalesCashout(StaticData.POSTransactionStatus.Paid, DateTime.Now);
                    transaction.Complete();

                    if (isDoneUpdate)
                    {
                        results.IsSuccess = true;
                        results.Messages.Add("Successfull save cash out transaction.");
                        return results;
                    }
                }

                results.IsSuccess = false;
                results.Messages.Add("Unable to save cash out transaction.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add(ex.Message);
            }

            return results;
        }
    }
}
