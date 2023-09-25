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
    public class ProductCategoryController : IProductCategoryController
    {
        private readonly ILogger<ProductCategoryController> _logger;
        private readonly IMapper _mapper;
        private readonly IProductCategoryData _productCategoryData;

        public ProductCategoryController(ILogger<ProductCategoryController> logger,
                                            IMapper mapper,
                                            IProductCategoryData productCategoryData)
        {
            _logger = logger;
            _mapper = mapper;
            _productCategoryData = productCategoryData;
        }

        public EntityResult<string> Delete(long categoryId)
        {
            var results = new EntityResult<string>();

            try
            {
                var details = _productCategoryData.Get(categoryId);

                if (details != null)
                {
                    details.IsDeleted = true;
                    details.DeletedAt = DateTime.Now;

                    results.IsSuccess = _productCategoryData.Update(details);
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

        public EntityResult<ProductCategoryModel> Save(ProductCategoryModel input, bool isNew)
        {
            var results = new EntityResult<ProductCategoryModel>();
            results.IsSuccess = false;

            try
            {
                // use fluent validation if we add new column and remove below validation
                if (string.IsNullOrWhiteSpace(input.ProdCategory))
                {
                    results.IsSuccess = true;
                    results.Messages.Add("Invalid category name");
                    return results;
                }

                if (isNew)
                {
                    long newId = _productCategoryData.Add(input);
                    if (newId > 0)
                    {
                        var newDetails = _productCategoryData.Get(newId);

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add new product category.");
                        results.Data = newDetails;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Unable to add new product category, kindly check system logs for possible errors.");
                    }
                }
                else
                {
                    var details = _productCategoryData.Get(input.Id);

                    if (details == null)
                    {
                        results.IsSuccess = false;
                        results.Messages.Add($"Category not found!");
                        return results;
                    }

                    _mapper.Map(input, details);

                    if (this._productCategoryData.Update(details))
                    {
                        results.IsSuccess = true;
                        results.Messages.Add("Successfully update product category.");
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
