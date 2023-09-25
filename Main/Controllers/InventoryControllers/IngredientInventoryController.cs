using AutoMapper;
using DataAccess.Data.InventoryManagement.Contracts;
using EntitiesShared.InventoryManagement;
using FluentValidation.Results;
using Main.Controllers.InventoryControllers.ControllerInterface;
using Main.Controllers.InventoryControllers.Validator;
using Microsoft.Extensions.Logging;
using Shared.ResponseModels;
using System;
using EntitiesShared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Helpers;

namespace Main.Controllers.InventoryControllers
{
    public class IngredientInventoryController : IIngredientInventoryController
    {
        private readonly ILogger<IngredientInventoryController> _logger;
        private readonly IMapper _mapper;
        private readonly Sessions _sessions;
        private readonly IIngredientData _ingredientData;
        private readonly IIngredientInventoryData _ingredientInventoryData;
        private readonly IIngInventoryTransactionData _ingInventoryTransactionData;
        private readonly IngredientInventoryAddUpdateValidator _ingredientInventoryAddUpdateValidator;
        private readonly UOMConverter _uOMConverter;

        public IngredientInventoryController(ILogger<IngredientInventoryController> logger,
                                            IMapper mapper,
                                            Sessions sessions,
                                            IIngredientData ingredientData,
                                            IIngredientInventoryData ingredientInventoryData,
                                            IIngInventoryTransactionData ingInventoryTransactionData,
                                            IngredientInventoryAddUpdateValidator ingredientInventoryAddUpdateValidator,
                                            UOMConverter uOMConverter)
        {
            _logger = logger;
            _mapper = mapper;
            _sessions = sessions;
            _ingredientData = ingredientData;
            _ingredientInventoryData = ingredientInventoryData;
            _ingInventoryTransactionData = ingInventoryTransactionData;
            _ingredientInventoryAddUpdateValidator = ingredientInventoryAddUpdateValidator;
            _uOMConverter = uOMConverter;
        }


        public EntityResult<string> Delete (long ingredeintId, long inventoryId, string remarks)
        {
            var results = new EntityResult<string>();

            try
            {
                var details = _ingredientInventoryData.GetByIdAndIngredient(ingredeintId, inventoryId);

                if (details != null)
                {
                    details.IsDeleted = true;
                    details.DeletedAt = DateTime.Now;

                    results.IsSuccess = _ingredientInventoryData.Update(details);
                    results.Messages.Add("Inventory deleted.");

                    _ingInventoryTransactionData.Add(new IngInventoryTransactionModel
                    {
                        IngredientId = details.IngredientId,
                        TransType = StaticData.InventoryTransType.DELETE,
                        QtyVal = details.InitialQtyValue,
                        UnitCost = details.UnitCost,
                        ExpirationDate = details.ExpirationDate,
                        UserId = _sessions.CurrentLoggedInUser.Id,
                        Remarks = remarks,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });

                }
                else
                {
                    results.IsSuccess = false;
                    results.Messages.Add("No changes made.");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }

        public string GetUOMFormatted(StaticData.UOM uom, decimal qtyValue)
        {
            string uomFormatted = "";

            switch (uom)
            {
                case StaticData.UOM.kg:
                    uomFormatted = _uOMConverter.gram_to_kg_format(qtyValue);
                    break;

                case StaticData.UOM.L:
                    uomFormatted = _uOMConverter.ml_to_L_format(qtyValue);
                    break;

                case StaticData.UOM.pcs:
                    uomFormatted = _uOMConverter.pc_format(qtyValue);
                    break;
                default:
                    uomFormatted = "0";
                    break;
            }

            return uomFormatted;
        }

        public EntityResult<IngredientInventoryModel> Save (IngredientInventoryModel input, bool isNew, string remarks)
        {

            var results = new EntityResult<IngredientInventoryModel>();
            results.IsSuccess = false;

            try
            {
                if (input == null)
                {
                    throw new Exception("Empty object for ingredient inventory.");
                }

                ValidationResult validationResult = _ingredientInventoryAddUpdateValidator.Validate(input);

                if (!validationResult.IsValid)
                {
                    foreach (var failure in validationResult.Errors)
                    {
                        results.Messages.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                    results.IsSuccess = false;
                    return results;
                }

                if (isNew)
                {
                    long newInventoryId = _ingredientInventoryData.Add(input);
                    if (newInventoryId > 0)
                    {
                        var inventoryDetails = _ingredientInventoryData.Get(newInventoryId);

                        _ingInventoryTransactionData.Add(new IngInventoryTransactionModel {
                            IngredientId = inventoryDetails.IngredientId,
                            TransType = StaticData.InventoryTransType.NEW,
                            QtyVal = inventoryDetails.InitialQtyValue,
                            UnitCost = inventoryDetails.UnitCost,
                            ExpirationDate = inventoryDetails.ExpirationDate,
                            UserId = _sessions.CurrentLoggedInUser.Id,
                            Remarks = remarks,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        });

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add inventory");
                        results.Data = inventoryDetails;
                    }
                    else
                    {
                        throw new Exception("Unable to add new employee, kindly check system logs for possible errors.");
                    }
                }
                else
                {
                    var existingInventory = _ingredientInventoryData.Get(input.Id);

                    if (existingInventory == null)
                    {
                        throw new Exception("Existing inventory details not found.");
                    }

                    var ingredientDetails = _ingredientData.Get(existingInventory.IngredientId);

                    if (ingredientDetails == null)
                    {
                        throw new Exception("Ingredient details not found.");
                    }

                    string additionalRemarks = "";

                    if (input.UnitCost != existingInventory.UnitCost)
                    {
                        additionalRemarks += $"{Environment.NewLine}Update Unit Cost from {existingInventory.UnitCost} to {input.UnitCost}";
                    }

                    if (input.ExpirationDate != existingInventory.ExpirationDate)
                    {
                        additionalRemarks += $"{Environment.NewLine}Update Expiration date {existingInventory.ExpirationDate.ToShortDateString()} to {input.ExpirationDate.ToShortDateString()}";
                    }

                    if (input.RemainingQtyValue != existingInventory.RemainingQtyValue)
                    {
                        string prevQty = this.GetUOMFormatted(ingredientDetails.UOM, existingInventory.RemainingQtyValue);
                        string newQty = this.GetUOMFormatted(ingredientDetails.UOM, input.RemainingQtyValue);

                        additionalRemarks += $"{Environment.NewLine}Update Quantity value {prevQty} to {newQty}";
                    }

                    _mapper.Map(input, existingInventory);

                    // Update employee details
                    if (this._ingredientInventoryData.Update(existingInventory))
                    {
                        _ingInventoryTransactionData.Add(new IngInventoryTransactionModel
                        {
                            IngredientId = existingInventory.IngredientId,
                            TransType = StaticData.InventoryTransType.UPDATE,
                            QtyVal = existingInventory.InitialQtyValue,
                            UnitCost = existingInventory.UnitCost,
                            ExpirationDate = existingInventory.ExpirationDate,
                            UserId = _sessions.CurrentLoggedInUser.Id,
                            Remarks = $"{remarks} - {additionalRemarks}",
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        });

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully update inventory details");
                        results.Data = existingInventory;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("No changes made.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add(ex.Message);
            }

            return results;
        }


        public EntityResult<IngredientInventoryModel> IncreaseQtyValue (long ingredientId, long inventoryId, decimal qtyValue, string remarks)
        {

            var results = new EntityResult<IngredientInventoryModel>();
            results.IsSuccess = false;

            try
            {
                var inventoryDetails = _ingredientInventoryData.GetByIdAndIngredient(ingredientId, inventoryId);

                if (inventoryDetails == null)
                {
                    throw new Exception("Existing inventory details not found.");
                }

                var ingredientDetails = _ingredientData.Get(ingredientId);

                if (ingredientDetails == null)
                {
                    throw new Exception("Ingredient details not found.");
                }

                if (inventoryDetails != null)
                {
                    inventoryDetails.InitialQtyValue += qtyValue;
                    inventoryDetails.RemainingQtyValue += qtyValue;

                    if (this._ingredientInventoryData.Update(inventoryDetails))
                    {
                        string increaseQtyValue = this.GetUOMFormatted(ingredientDetails.UOM, qtyValue);

                        _ingInventoryTransactionData.Add(new IngInventoryTransactionModel
                        {
                            IngredientId = inventoryDetails.IngredientId,
                            TransType = StaticData.InventoryTransType.INCREASE,
                            QtyVal = qtyValue,
                            UnitCost = inventoryDetails.UnitCost,
                            ExpirationDate = inventoryDetails.ExpirationDate,
                            UserId = _sessions.CurrentLoggedInUser.Id,
                            Remarks = $"{remarks} - {Environment.NewLine} Increase Quantity value to {increaseQtyValue}",
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        });

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully increase inventory quantity value");
                        results.Data = inventoryDetails;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("No changes made.");
                    }
                }
                else
                {
                    results.IsSuccess = false;
                    results.Messages.Add("Inventory details not found.");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add(ex.Message);
            }

            return results;
        }

        public EntityResult<IngredientInventoryModel> DecreaseQtyValue(long ingredientId, long inventoryId, decimal qtyValue, string remarks)
        {

            var results = new EntityResult<IngredientInventoryModel>();
            results.IsSuccess = false;

            try
            {
                var inventoryDetails = _ingredientInventoryData.GetByIdAndIngredient(ingredientId, inventoryId);

                if (inventoryDetails == null)
                {
                    throw new Exception("Existing inventory details not found.");
                }

                var ingredientDetails = _ingredientData.Get(ingredientId);

                if (ingredientDetails == null)
                {
                    throw new Exception("Ingredient details not found.");
                }

                if (inventoryDetails != null)
                {
                    inventoryDetails.InitialQtyValue -= qtyValue;
                    inventoryDetails.RemainingQtyValue -= qtyValue;

                    string decreaseQtyValue = this.GetUOMFormatted(ingredientDetails.UOM, qtyValue);

                    if (this._ingredientInventoryData.Update(inventoryDetails))
                    {
                        _ingInventoryTransactionData.Add(new IngInventoryTransactionModel
                        {
                            IngredientId = inventoryDetails.IngredientId,
                            TransType = StaticData.InventoryTransType.DECREASE,
                            QtyVal = qtyValue,
                            UnitCost = inventoryDetails.UnitCost,
                            ExpirationDate = inventoryDetails.ExpirationDate,
                            UserId = _sessions.CurrentLoggedInUser.Id,
                            Remarks = $"{remarks} - {Environment.NewLine} Decrease Quantity value to {decreaseQtyValue}",
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        });

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully decrease inventory quantity value");
                        results.Data = inventoryDetails;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("No changes made.");
                    }
                }

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
