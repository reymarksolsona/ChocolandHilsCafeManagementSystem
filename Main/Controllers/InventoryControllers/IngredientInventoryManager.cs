using AutoMapper;
using DataAccess.Data.InventoryManagement.Contracts;
using EntitiesShared;
using EntitiesShared.InventoryManagement.Models;
using Microsoft.Extensions.Logging;
using Shared.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers
{
    public class IngredientInventoryManager : IIngredientInventoryManager
    {
        private readonly ILogger<ProductCategoryController> _logger;
        private readonly IMapper _mapper;
        private readonly IProductData _productData;
        private readonly IProductIngredientData _productIngredientData;
        private readonly IIngredientData _ingredientData;
        private readonly IIngredientInventoryData _ingredientInventoryData;

        public IngredientInventoryManager(ILogger<ProductCategoryController> logger,
                                            IMapper mapper,
                                            IProductData productData,
                                            IProductIngredientData productIngredientData,
                                            IIngredientData ingredientData,
                                            IIngredientInventoryData ingredientInventoryData)
        {
            _logger = logger;
            _mapper = mapper;
            _productData = productData;
            _productIngredientData = productIngredientData;
            _ingredientData = ingredientData;
            _ingredientInventoryData = ingredientInventoryData;
        }

        // For unit cost
        // we have 500ml and the 1L is 250
        // 250/1000
        public decimal GetActualCostByIngredientQtyValueAndUnitCost(StaticData.UOM uom, decimal ingredientUnitCost)
        {
            decimal actualCost = 0;

            switch (uom) {
                case StaticData.UOM.g:
                    actualCost = ingredientUnitCost / 1000;
                    break;

                case StaticData.UOM.ml:
                    actualCost = ingredientUnitCost / 1000;
                    break;

                case StaticData.UOM.pc:
                case StaticData.UOM.pcs:
                case StaticData.UOM.kg:
                case StaticData.UOM.L:
                    actualCost = ingredientUnitCost;
                    break;

                default:
                    actualCost = 0;
                    break;
            }

            return actualCost;
        }


        public decimal GetProductIngredientCost(long ingredientId, decimal prodIngredientQtyValue, StaticData.UOM prodIngredientUOM)
        {
            var ingredeintDetails = _ingredientData.Get(ingredientId);
            if (ingredeintDetails == null)
                return 0;

            var ingredientInventories = _ingredientInventoryData.GetAllByIngredient(ingredientId).OrderBy(x => x.ExpirationDate);

            if (ingredientInventories == null)
                return 0;

            decimal costTotal = 0;
            decimal remainingProdIngredientQtyValue = prodIngredientQtyValue;

            foreach (var inventory in ingredientInventories)
            {
                var actualUnitCost = this.GetActualCostByIngredientQtyValueAndUnitCost(prodIngredientUOM, inventory.UnitCost);
                costTotal += remainingProdIngredientQtyValue * actualUnitCost;

                remainingProdIngredientQtyValue = remainingProdIngredientQtyValue - inventory.RemainingQtyValue;

                if (remainingProdIngredientQtyValue <= 0)
                    break;

                //// RemainingQtyValue is in g, ml or pc format
                //if (inventory.RemainingQtyValue >= remainingProdIngredientQtyValue && remainingProdIngredientQtyValue > 0)
                //{
                //    var actualUnitCost = this.GetActualCostByIngredientQtyValueAndUnitCost(prodIngredientUOM, inventory.UnitCost);
                //    costTotal += remainingProdIngredientQtyValue * actualUnitCost;

                //    remainingProdIngredientQtyValue = 0;
                //}
                //else if (inventory.RemainingQtyValue < remainingProdIngredientQtyValue && remainingProdIngredientQtyValue > 0)
                //{
                //    var actualUnitCost = this.GetActualCostByIngredientQtyValueAndUnitCost(prodIngredientUOM, inventory.UnitCost);
                //    costTotal += inventory.RemainingQtyValue * actualUnitCost;

                //    remainingProdIngredientQtyValue = remainingProdIngredientQtyValue - inventory.RemainingQtyValue;

                //}

                //if (remainingProdIngredientQtyValue == 0)
                //    break;
            }

            return costTotal;
        }

        // for Qty value only
        // for example, we need 500ml for single ingredient
        // 500ml / 1000 is 0.5, we will deduct 0.5 in our inventory
        public decimal GetProductIngredientActualQtyValueNeedToDeduct(StaticData.UOM uom, decimal qtyValue)
        {
            decimal actualQtyValue = 0;

            switch (uom)
            {
                case StaticData.UOM.g:
                case StaticData.UOM.pc:
                case StaticData.UOM.pcs:
                case StaticData.UOM.ml:
                    actualQtyValue = qtyValue;
                    break;

                case StaticData.UOM.kg:
                case StaticData.UOM.L:
                    actualQtyValue = qtyValue * 1000;
                    break;

                default:
                    actualQtyValue = 0;
                    break;
            }

            return actualQtyValue;
        }

        public decimal GetQtyValue(StaticData.UOM uom, decimal qtyValue)
        {
            decimal actualQtyValue = 0;

            switch (uom)
            {
                case StaticData.UOM.g:
                case StaticData.UOM.pc:
                case StaticData.UOM.pcs:
                case StaticData.UOM.ml:
                    actualQtyValue = qtyValue;
                    break;

                case StaticData.UOM.kg:
                case StaticData.UOM.L:
                    actualQtyValue = qtyValue / 1000;
                    break;

                default:
                    actualQtyValue = 0;
                    break;
            }

            return actualQtyValue;
        }


        public Tuple<StaticData.UOM, decimal> GetProperQtyValAndUOM(StaticData.UOM uom, decimal qtyValue)
        {
            if (uom == StaticData.UOM.ml && qtyValue >= 1000)
            {
                return new Tuple<StaticData.UOM, decimal>(StaticData.UOM.L, qtyValue / 1000);
            }

            if (uom == StaticData.UOM.g && qtyValue >= 1000)
            {
                return new Tuple<StaticData.UOM, decimal>(StaticData.UOM.kg, qtyValue / 1000);
            }

            if (uom == StaticData.UOM.pc && qtyValue > 1)
            {
                return new Tuple<StaticData.UOM, decimal>(StaticData.UOM.pcs, qtyValue);
            }

            return new Tuple<StaticData.UOM, decimal>(uom, qtyValue);
        }

        // Since Ingredient can have multiple inventory 
        // we need to identify what inventories we will deduct the required Qty value of Product's ingredient based on Product's ingredient Unit of measurement
        public List<ProductIngredientInventoryDeduction> GetWhereInventoryThisProductIngredientToDeduct(long ingredientId, decimal prodIngredientRequireQtyValue, StaticData.UOM prodIngredientRequireUOM)
        {
            List<ProductIngredientInventoryDeduction> productIngredientInventoryDeductionFromList = new List<ProductIngredientInventoryDeduction>();

            var ingredeintDetails = _ingredientData.Get(ingredientId);
            if (ingredeintDetails == null)
                return productIngredientInventoryDeductionFromList;

            // deduct from the inventory that near on expiration date
            var ingredientInventories = _ingredientInventoryData.GetAllByIngredient(ingredientId).OrderBy(x => x.ExpirationDate);

            if (ingredientInventories == null)
                return productIngredientInventoryDeductionFromList;

            // RemainingQtyValue in our database is in g, ml format, meeting if we have 30L, the RemainingQtyValue is 30000, or 30000ml
            // so we need 500ml for the product, we will deduct 500 in 30000, the RemainingQtyValue is 29500ml
            decimal remainingProdIngredientQtyValue = GetProductIngredientActualQtyValueNeedToDeduct(prodIngredientRequireUOM, prodIngredientRequireQtyValue);
                //prodIngredientRequireQtyValue;

            int deductionSequence = 1;
            foreach (var inventory in ingredientInventories)
            {
                if (inventory.RemainingQtyValue >= remainingProdIngredientQtyValue && remainingProdIngredientQtyValue > 0)
                {
                    var actualUnitCost = this.GetActualCostByIngredientQtyValueAndUnitCost(prodIngredientRequireUOM, inventory.UnitCost);
                    var qtyValBasedOnUOM = GetQtyValue(prodIngredientRequireUOM, remainingProdIngredientQtyValue);

                    decimal cost = qtyValBasedOnUOM * actualUnitCost;

                    productIngredientInventoryDeductionFromList.Add(new ProductIngredientInventoryDeduction
                    {
                        DeductionSequence = deductionSequence,
                        IngredientId = ingredeintDetails.Id,
                        IngredientInventoryid = inventory.Id,
                        DeductQtyValue = remainingProdIngredientQtyValue,//GetProductIngredientActualQtyValueNeedToDeduct(prodIngredientRequireUOM, remainingProdIngredientQtyValue),
                        UsedUOM = prodIngredientRequireUOM,
                        Cost = cost
                    });

                    remainingProdIngredientQtyValue = 0;

                }
                else if (inventory.RemainingQtyValue < remainingProdIngredientQtyValue && remainingProdIngredientQtyValue > 0)
                {
                    var actualUnitCost = this.GetActualCostByIngredientQtyValueAndUnitCost(prodIngredientRequireUOM, inventory.UnitCost); 
                    var qtyValBasedOnUOM = GetQtyValue(prodIngredientRequireUOM, inventory.RemainingQtyValue);

                    decimal cost = qtyValBasedOnUOM * actualUnitCost;

                    productIngredientInventoryDeductionFromList.Add(new ProductIngredientInventoryDeduction
                    {
                        DeductionSequence = deductionSequence,
                        IngredientId = ingredeintDetails.Id,
                        IngredientInventoryid = inventory.Id,
                        DeductQtyValue = GetProductIngredientActualQtyValueNeedToDeduct(prodIngredientRequireUOM, inventory.RemainingQtyValue),
                        UsedUOM = prodIngredientRequireUOM,
                        Cost = cost
                    });

                    remainingProdIngredientQtyValue = remainingProdIngredientQtyValue - inventory.RemainingQtyValue;
                }

                deductionSequence += 1;
                if (remainingProdIngredientQtyValue == 0)
                    break;
            }

            if (remainingProdIngredientQtyValue > 0)
            {
                throw new IngredientInventoryException($"Not enough ingredient inventory for {ingredeintDetails.IngName}");
            }

            return productIngredientInventoryDeductionFromList;
        }


        public string CheckIfEnoughInventory(long ingredientId, decimal prodIngredientRequireQtyValue, StaticData.UOM prodIngredientRequireUOM)
        {
            try
            {
                var productIngredientInventoryDeductionFromList = GetWhereInventoryThisProductIngredientToDeduct(ingredientId, prodIngredientRequireQtyValue, prodIngredientRequireUOM);
                return "";
            }
            catch(IngredientInventoryException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
