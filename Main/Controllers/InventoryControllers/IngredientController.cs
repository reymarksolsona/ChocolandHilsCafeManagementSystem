using AutoMapper;
using DataAccess.Data.InventoryManagement.Contracts;
using EntitiesShared.InventoryManagement;
using FluentValidation.Results;
using Main.Controllers.InventoryControllers.ControllerInterface;
using Main.Controllers.InventoryControllers.Validator;
using Microsoft.Extensions.Logging;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers
{
    public class IngredientController : IIngredientController
    {
        private readonly ILogger<LoginFrm> _logger;
        private readonly IMapper _mapper;
        private readonly IIngredientData _ingredientData;
        private readonly IngredientAddUpdateValidator _ingredientAddUpdateValidator;

        public IngredientController(ILogger<LoginFrm> logger,
                                    IMapper mapper,
                                    IIngredientData ingredientData,
                                    IngredientAddUpdateValidator ingredientAddUpdateValidator)
        {
            _logger = logger;
            _mapper = mapper;
            _ingredientData = ingredientData;
            _ingredientAddUpdateValidator = ingredientAddUpdateValidator;
        }

        public EntityResult<string> Delete(long ingredientId)
        {
            var results = new EntityResult<string>();

            try
            {
                var details = _ingredientData.Get(ingredientId);

                if (details != null)
                {
                    details.IsDeleted = true;
                    details.DeletedAt = DateTime.Now;

                    results.IsSuccess = _ingredientData.Update(details);
                    results.Messages.Add("Ingredient deleted.");
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


        public EntityResult<IngredientModel> Save(IngredientModel input, bool isNew)
        {
            var results = new EntityResult<IngredientModel>();
            results.IsSuccess = false;

            try
            {
                ValidationResult validationResult = _ingredientAddUpdateValidator.Validate(input);

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
                    long newId = _ingredientData.Add(input);
                    if (newId > 0)
                    {
                        var newDetails = _ingredientData.Get(newId);

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add new ingredient.");
                        results.Data = newDetails;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Unable to add new ingredient, kindly check system logs for possible errors.");
                    }
                }
                else
                {
                    var details = _ingredientData.Get(input.Id);

                    if (details == null)
                    {
                        results.IsSuccess = false;
                        results.Messages.Add($"Ingredient not found!");
                        return results;
                    }

                    _mapper.Map(input, details);

                    if (this._ingredientData.Update(details))
                    {
                        results.IsSuccess = true;
                        results.Messages.Add("Successfully update ingredient.");
                        results.Data = details;
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
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }
    }
}
