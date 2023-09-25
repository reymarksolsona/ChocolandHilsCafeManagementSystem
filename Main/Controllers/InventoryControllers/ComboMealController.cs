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
using System.Transactions;

namespace Main.Controllers.InventoryControllers
{
    public class ComboMealController : IComboMealController
    {
        private readonly ILogger<LoginFrm> _logger;
        private readonly IMapper _mapper;
        private readonly IComboMealData _comboMealData;
        private readonly IComboMealProductData _comboMealProductData;

        public ComboMealController(ILogger<LoginFrm> logger,
                                    IMapper mapper,
                                    IComboMealData comboMealData,
                                    IComboMealProductData comboMealProductData)
        {
            _logger = logger;
            _mapper = mapper;
            _comboMealData = comboMealData;
            _comboMealProductData = comboMealProductData;
        }


        public string GetNewComboMealBarcodeLabel()
        {
            return $"C-{DateTime.Now.ToString("yyMMddHHmmssffft")}";
        }

        public EntityResult<string> Delete(long ingredientId)
        {
            var results = new EntityResult<string>();

            try
            {
                var details = _comboMealData.Get(ingredientId);

                if (details != null)
                {
                    details.IsDeleted = true;
                    details.DeletedAt = DateTime.Now;

                    results.IsSuccess = _comboMealData.Update(details);
                    results.Messages.Add("Combo Meal deleted.");
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

        public void SaveComboMealImageFileName (long comboMealId, string fileName)
        {
            var comboMealDetails = _comboMealData.Get(comboMealId);

            if (comboMealDetails != null && string.IsNullOrEmpty(fileName) == false)
            {
                comboMealDetails.ImageFilename = fileName;
                _comboMealData.Update(comboMealDetails);
            }
        }

        public EntityResult<ComboMealModel> Save (ComboMealModel comboMeal, List<ComboMealProductModel> products, bool isNew)
        {
            var results = new EntityResult<ComboMealModel>();
            results.IsSuccess = false;

            try
            {
                if (string.IsNullOrWhiteSpace(comboMeal.Title))
                {
                    results.IsSuccess = false;
                    results.Messages.Add("Provide combo meal title");
                    return results;
                }

                if (isNew)
                {

                    if (comboMeal.isBarcodeLblAutoGenerate)
                    {
                        comboMeal.BarcodeLbl = this.GetNewComboMealBarcodeLabel();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(comboMeal.BarcodeLbl))
                        {
                            results.IsSuccess = true;
                            results.Messages.Add("Provide combo meal barcode label.");
                            return results;
                        }
                    }


                    using (var transaction = new TransactionScope())
                    {
                        long newComboMealId = _comboMealData.Add(comboMeal);

                        if (newComboMealId > 0)
                        {
                            var newComboMeal = _comboMealData.Get(newComboMealId);

                            foreach(var prod in products)
                            {
                                _comboMealProductData.Add(new ComboMealProductModel {
                                    ComboMealId = newComboMealId,
                                    ProductId = prod.ProductId,
                                    Quantity = prod.Quantity
                                });
                            }

                            results.IsSuccess = true;
                            results.Messages.Add("Successfully add new combo meal.");
                            results.Data = newComboMeal;
                        }
                        else
                        {
                            results.IsSuccess = false;
                            results.Messages.Add("Unable to add new ingredient, kindly check system logs for possible errors.");
                        }

                        transaction.Complete();
                    }

                }
                else
                {
                    var comboMealDetails = _comboMealData.Get(comboMeal.Id);
                    
                    if (comboMealDetails == null)
                    {
                        results.IsSuccess = false;
                        results.Messages.Add($"Combo meal details not found!");
                        return results;
                    }
                    var comboMealExistingProds = _comboMealProductData.GetAllByComboMeal(comboMealDetails.Id);

                    _mapper.Map(comboMeal, comboMealDetails);

                    if (string.IsNullOrEmpty(comboMealDetails.BarcodeLbl))
                    {
                        comboMealDetails.BarcodeLbl = this.GetNewComboMealBarcodeLabel();
                    }

                    using (var transaction = new TransactionScope())
                    {
                        this._comboMealData.Update(comboMealDetails);

                        if (comboMealExistingProds == null)
                        {
                            // insert all
                            foreach (var prod in products)
                            {
                                _comboMealProductData.Add(new ComboMealProductModel
                                {
                                    ComboMealId = comboMealDetails.Id,
                                    ProductId = prod.ProductId,
                                    Quantity = prod.Quantity
                                });
                            }
                        }
                        else
                        {
                            foreach (var prod in products)
                            {
                                var existingProd = comboMealExistingProds.Where(x => x.ProductId == prod.ProductId).FirstOrDefault();

                                if (existingProd == null)
                                {
                                    _comboMealProductData.Add(new ComboMealProductModel
                                    {
                                        ComboMealId = comboMealDetails.Id,
                                        ProductId = prod.ProductId,
                                        Quantity = prod.Quantity
                                    });
                                }
                                else
                                {
                                    _mapper.Map(prod, existingProd);
                                    _comboMealProductData.Update(existingProd);
                                }
                            }
                        }

                        transaction.Complete();
                    }


                    results.IsSuccess = true;
                    results.Messages.Add("Successfully update ingredient.");
                    results.Data = comboMealDetails;
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
