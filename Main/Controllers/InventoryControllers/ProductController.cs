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
using System.Transactions;

namespace Main.Controllers.InventoryControllers
{
    public class ProductController : IProductController
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        private readonly IProductData _productData;
        private readonly IProductIngredientData _productIngredientData;
        private readonly ProductAddUpdateValidator _productAddUpdateValidator;
        private readonly ProductIngredientAddUpdateValidator _validationRules;

        public ProductController(ILogger<ProductController> logger,
                                    IMapper mapper,
                                    IProductData productData,
                                    IProductIngredientData productIngredientData,
                                    ProductAddUpdateValidator productAddUpdateValidator,
                                    ProductIngredientAddUpdateValidator validationRules)
        {
            _logger = logger;
            _mapper = mapper;
            _productData = productData;
            _productIngredientData = productIngredientData;
            _productAddUpdateValidator = productAddUpdateValidator;
            _validationRules = validationRules;
        }


        public void SaveProductImageFileName (long productId, string fileName)
        {
            var productDetails = _productData.Get(productId);

            if (productDetails != null && string.IsNullOrEmpty(fileName) == false)
            {
                productDetails.ImageFilename = fileName;
                _productData.Update(productDetails);
            }
        }

        public string GetNewProductBarcodeLabel()
        {
            return $"P-{DateTime.Now.ToString("yyMMddHHmmssffft")}";
        }

        public EntityResult<ProductModel> Save (List<ProductIngredientModel> ingredients, ProductModel product, bool isNew)
        {
            var results = new EntityResult<ProductModel>();
            results.IsSuccess = false;

            try
            {
                ValidationResult validationResult = _productAddUpdateValidator.Validate(product);

                if (!validationResult.IsValid)
                {
                    foreach (var failure in validationResult.Errors)
                    {
                        results.Messages.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                    results.IsSuccess = false;
                    return results;
                }

                foreach (var newIngredient in ingredients)
                {
                    ValidationResult validationResultIngredient = _validationRules.Validate(newIngredient);

                    if (!validationResultIngredient.IsValid)
                    {
                        foreach (var failure in validationResultIngredient.Errors)
                        {
                            results.Messages.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                        }
                        results.IsSuccess = false;
                        return results;
                    }
                }

                if (isNew)
                {
                    if (product.isBarcodeLblAutoGenerate)
                    {
                        product.BarcodeLbl = this.GetNewProductBarcodeLabel();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(product.BarcodeLbl))
                        {
                            results.IsSuccess = true;
                            results.Messages.Add("Provide product barcode label.");
                            return results;
                        }
                    }

                    using(var transaction = new TransactionScope())
                    {
                        var newProductId = _productData.Add(product);

                        foreach(var ingredient in ingredients)
                        {
                            _productIngredientData.Add(new ProductIngredientModel {
                                ProductId = newProductId,
                                IngredientId = ingredient.IngredientId,
                                UOM = ingredient.UOM,
                                QtyValue = ingredient.QtyValue
                            });
                        }

                        var newProductDetails = _productData.Get(newProductId);

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add new product.");
                        results.Data = newProductDetails;

                        transaction.Complete();
                    }
                }
                else
                {
                    var productDetails = _productData.Get(product.Id);

                    if (productDetails == null)
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Product details not found.");
                        return results;
                    }

                    var productExistingIngredients = _productIngredientData.GetAllByProduct(productDetails.Id);

                    _mapper.Map(product, productDetails);

                    if (string.IsNullOrEmpty(productDetails.BarcodeLbl))
                    {
                        productDetails.BarcodeLbl = this.GetNewProductBarcodeLabel();
                    }

                    using (var transaction = new TransactionScope())
                    {
                        if (_productData.Update(productDetails))
                        {
                            foreach(var newIngredient in ingredients)
                            {
                                if (newIngredient.Id > 0)
                                {
                                    var existingIngredient = productExistingIngredients.Where(x => x.Id == newIngredient.Id).FirstOrDefault();

                                    if (existingIngredient != null)
                                    {
                                        _mapper.Map(newIngredient, existingIngredient);
                                        _productIngredientData.Update(existingIngredient);
                                    }
                                    else
                                    {
                                        _productIngredientData.Add(new ProductIngredientModel
                                        {
                                            ProductId = productDetails.Id,
                                            IngredientId = newIngredient.IngredientId,
                                            UOM = newIngredient.UOM,
                                            QtyValue = newIngredient.QtyValue
                                        });
                                    }
                                }
                                else
                                {
                                    _productIngredientData.Add(new ProductIngredientModel
                                    {
                                        ProductId = productDetails.Id,
                                        IngredientId = newIngredient.IngredientId,
                                        UOM = newIngredient.UOM,
                                        QtyValue = newIngredient.QtyValue
                                    });
                                }
                            }
                        }

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully product details.");
                        results.Data = productDetails;

                        transaction.Complete();
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
