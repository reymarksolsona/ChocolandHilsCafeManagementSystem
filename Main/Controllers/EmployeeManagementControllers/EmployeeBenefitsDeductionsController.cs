using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using Main.Controllers.EmployeeManagementControllers.ControllerInterface;
using Microsoft.Extensions.Logging;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers
{
    public class EmployeeBenefitsDeductionsController : IEmployeeBenefitsDeductionsController
    {
        private readonly ILogger<EmployeeBenefitsDeductionsController> _logger;
        private readonly IEmployeeData _employeeData;
        private readonly IEmployeeBenefitData _employeeBenefitData;
        private readonly ISpecificEmployeeBenefitData _specificEmployeeBenefitData;
        private readonly IEmployeeDeductionData _employeeDeductionData;
        private readonly ISpecificEmployeeDeductionData _specificEmployeeDeductionData;

        public EmployeeBenefitsDeductionsController(ILogger<EmployeeBenefitsDeductionsController> logger,
                                                    IEmployeeData employeeData,
                                                    IEmployeeBenefitData employeeBenefitData,
                                                    ISpecificEmployeeBenefitData specificEmployeeBenefitData,
                                                    IEmployeeDeductionData employeeDeductionData,
                                                    ISpecificEmployeeDeductionData specificEmployeeDeductionData)
        {
            _logger = logger;
            _employeeData = employeeData;
            _employeeBenefitData = employeeBenefitData;
            _specificEmployeeBenefitData = specificEmployeeBenefitData;
            _employeeDeductionData = employeeDeductionData;
            _specificEmployeeDeductionData = specificEmployeeDeductionData;
        }

        #region Benefits CRUD

        public EntityResult<string> DeleteBenefit(long benefitId)
        {
            var results = new EntityResult<string>();

            try
            {
                var benefitDetails = _employeeBenefitData.Get(benefitId);

                if (benefitDetails != null)
                {
                    benefitDetails.IsDeleted = true;
                    benefitDetails.DeletedAt = DateTime.Now;

                    results.IsSuccess = _employeeBenefitData.Update(benefitDetails);
                    results.Messages.Add("Benefit deleted");
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


        public EntityResult<EmployeeBenefitModel> SaveBenefit(EmployeeBenefitModel input, bool isNew)
        {
            var results = new EntityResult<EmployeeBenefitModel>();
            results.IsSuccess = false;

            try
            {
                if (isNew)
                {
                    long benefitId = _employeeBenefitData.Add(input);
                    if (benefitId > 0)
                    {
                        var benefitDetails = _employeeBenefitData.Get(benefitId);

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add new benefit.");
                        results.Data = benefitDetails;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Unable to add new benefit, kindly check system logs for possible errors.");
                    }
                }
                else
                {
                    var benefitDetails = _employeeBenefitData.Get(input.Id);

                    if (benefitDetails != null)
                    {
                        benefitDetails.Amount = input.Amount;
                        benefitDetails.BenefitTitle = input.BenefitTitle;

                        if (this._employeeBenefitData.Update(benefitDetails))
                        {
                            results.IsSuccess = true;
                            results.Messages.Add("Successfully update benefit details.");
                            results.Data = benefitDetails;
                        }
                        else
                        {
                            results.IsSuccess = false;
                            results.Messages.Add("No changes made.");
                        }
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


        public EntityResult<string> DeleteSpecificBenefit(long benefitId)
        {
            var results = new EntityResult<string>();

            try
            {
                var benefitDetails = _specificEmployeeBenefitData.Get(benefitId);

                if (benefitDetails != null)
                {
                    benefitDetails.IsDeleted = true;
                    benefitDetails.DeletedAt = DateTime.Now;

                    results.IsSuccess = _employeeBenefitData.Update(benefitDetails);
                    results.Messages.Add("Benefit deleted");
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

        public EntityResult<SpecificEmployeeBenefitModel> SaveSpecificEmployeeBenefit (SpecificEmployeeBenefitModel input, bool isNew)
        {
            var results = new EntityResult<SpecificEmployeeBenefitModel>();
            results.IsSuccess = false;

            try
            {
                var employeeDetails = _employeeData.GetByEmployeeNumber(input.EmployeeNumber);

                if (employeeDetails == null)
                {
                    results.IsSuccess = false;
                    results.Messages.Add($"{input.EmployeeNumber} - Employee not found");
                    return results;
                }

                if (isNew)
                {
                    input.EmployeeName = employeeDetails.FullName;
                    long benefitId = _specificEmployeeBenefitData.Add(input);

                    if (benefitId > 0)
                    {
                        var benefitDetails = _specificEmployeeBenefitData.Get(benefitId);

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add new benefit.");
                        results.Data = benefitDetails;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Unable to add new benefit, kindly check system logs for possible errors.");
                    }
                }
                else
                {
                    var benefitDetails = _specificEmployeeBenefitData.Get(input.Id);

                    if (benefitDetails != null)
                    {
                        benefitDetails.Amount = input.Amount;
                        benefitDetails.BenefitTitle = input.BenefitTitle;

                        if (this._specificEmployeeBenefitData.Update(benefitDetails))
                        {
                            results.IsSuccess = true;
                            results.Messages.Add("Successfully update benefit details.");
                            results.Data = benefitDetails;
                        }
                        else
                        {
                            results.IsSuccess = false;
                            results.Messages.Add("No changes made.");
                        }
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

        #endregion




        #region Deductions CRUD

        public EntityResult<string> DeleteDeduction(long deductionId)
        {
            var results = new EntityResult<string>();

            try
            {
                var deductionDetails = _employeeDeductionData.Get(deductionId);

                if (deductionDetails != null)
                {
                    deductionDetails.IsDeleted = true;
                    deductionDetails.DeletedAt = DateTime.Now;

                    results.IsSuccess = _employeeDeductionData.Update(deductionDetails);
                    results.Messages.Add("Deduction deleted");
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


        public EntityResult<EmployeeDeductionModel> SaveDeduction(EmployeeDeductionModel input, bool isNew)
        {
            var results = new EntityResult<EmployeeDeductionModel>();
            results.IsSuccess = false;

            try
            {
                if (isNew)
                {
                    long deductinId = _employeeDeductionData.Add(input);
                    if (deductinId > 0)
                    {
                        var deductionDetails = _employeeDeductionData.Get(deductinId);

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add new deduction.");
                        results.Data = deductionDetails;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Unable to add new deduction, kindly check system logs for possible errors.");
                    }
                }
                else
                {
                    var deductionDetails = _employeeDeductionData.Get(input.Id);

                    deductionDetails.Amount = input.Amount;
                    deductionDetails.DeductionTitle = input.DeductionTitle;

                    if (deductionDetails != null)
                    {
                        if (this._employeeDeductionData.Update(deductionDetails))
                        {
                            results.IsSuccess = true;
                            results.Messages.Add("Successfully update deduction details.");
                            results.Data = deductionDetails;
                        }
                        else
                        {
                            results.IsSuccess = false;
                            results.Messages.Add("No changes made.");
                        }
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


        public EntityResult<string> DeleteSpecificDeduction(long deductionId)
        {
            var results = new EntityResult<string>();

            try
            {
                var deductionDetails = _specificEmployeeDeductionData.Get(deductionId);

                if (deductionDetails != null)
                {
                    deductionDetails.IsDeleted = true;
                    deductionDetails.DeletedAt = DateTime.Now;

                    results.IsSuccess = _employeeDeductionData.Update(deductionDetails);
                    results.Messages.Add("Deduction deleted");
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

        public EntityResult<SpecificEmployeeDeductionModel> SaveSpecificDeduction(SpecificEmployeeDeductionModel input, bool isNew)
        {
            var results = new EntityResult<SpecificEmployeeDeductionModel>();
            results.IsSuccess = false;

            try
            {
                var employeeDetails = _employeeData.GetByEmployeeNumber(input.EmployeeNumber);

                if (employeeDetails == null)
                {
                    results.IsSuccess = false;
                    results.Messages.Add($"{input.EmployeeNumber} - Employee not found");
                    return results;
                }

                if (isNew)
                {
                    input.EmployeeName = employeeDetails.FullName;
                    long deductinId = _specificEmployeeDeductionData.Add(input);
                    if (deductinId > 0)
                    {
                        var deductionDetails = _specificEmployeeDeductionData.Get(deductinId);

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add new deduction.");
                        results.Data = deductionDetails;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Unable to add new deduction, kindly check system logs for possible errors.");
                    }
                }
                else
                {
                    var deductionDetails = _specificEmployeeDeductionData.Get(input.Id);

                    deductionDetails.Amount = input.Amount;
                    deductionDetails.DeductionTitle = input.DeductionTitle;

                    if (deductionDetails != null)
                    {
                        if (this._specificEmployeeDeductionData.Update(deductionDetails))
                        {
                            results.IsSuccess = true;
                            results.Messages.Add("Successfully update deduction details.");
                            results.Data = deductionDetails;
                        }
                        else
                        {
                            results.IsSuccess = false;
                            results.Messages.Add("No changes made.");
                        }
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

        #endregion


    }
}
