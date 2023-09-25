using AutoMapper;
using DataAccess.Data.InventoryManagement.Contracts;
using EntitiesShared.InventoryManagement;
using Main.Controllers.InventoryControllers.ControllerInterface;
using Microsoft.Extensions.Logging;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers
{
    public class IngredientCategoryController : IIngredientCategoryController
    {
        private readonly ILogger<IngredientCategoryController> _logger;
        private readonly IMapper _mapper;
        private readonly IIngredientCategoryData _ingredientCategoryData;

        public IngredientCategoryController(ILogger<IngredientCategoryController> logger,
                                            IMapper mapper,
                                            IIngredientCategoryData ingredientCategoryData)
        {
            _logger = logger;
            _mapper = mapper;
            _ingredientCategoryData = ingredientCategoryData;
        }

        public EntityResult<string> Delete(long categoryId)
        {
            var results = new EntityResult<string>();

            try
            {
                var details = _ingredientCategoryData.Get(categoryId);

                if (details != null)
                {
                    details.IsDeleted = true;
                    details.DeletedAt = DateTime.Now;

                    results.IsSuccess = _ingredientCategoryData.Update(details);
                    results.Messages.Add("Category deleted.");
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


        public EntityResult<IngredientCategoryModel> Save(IngredientCategoryModel input, bool isNew)
        {
            var results = new EntityResult<IngredientCategoryModel>();
            results.IsSuccess = false;

            try
            {
                // use fluent validation if we add new column and remove below validation

                if (string.IsNullOrWhiteSpace(input.Category))
                {
                    results.IsSuccess = true;
                    results.Messages.Add("Invalid category name");
                    return results;
                }

                if (isNew)
                {
                    long newId = _ingredientCategoryData.Add(input);
                    if (newId > 0)
                    {
                        var newDetails = _ingredientCategoryData.Get(newId);

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add new ingredient category.");
                        results.Data = newDetails;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Unable to add new ingredient category, kindly check system logs for possible errors.");
                    }
                }
                else
                {
                    var details = _ingredientCategoryData.Get(input.Id);

                    if (details == null)
                    {
                        results.IsSuccess = false;
                        results.Messages.Add($"Category not found!");
                        return results;
                    }

                    _mapper.Map(input, details);

                    if (this._ingredientCategoryData.Update(details))
                    {
                        results.IsSuccess = true;
                        results.Messages.Add("Successfully update ingredient category.");
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
