using AutoMapper;
using DataAccess.Data.OtherDataManagement.Contracts;
using EntitiesShared.OtherDataManagement;
using FluentValidation.Results;
using Main.Controllers.OtherDataController.ControllerInterface;
using Main.Controllers.OtherDataController.Validator;
using Microsoft.Extensions.Logging;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.OtherDataController
{
    public class BranchInfoController : IBranchInfoController
    {
        private readonly ILogger<BranchInfoController> _logger;
        private readonly IMapper _mapper;
        private readonly BranchAddUpdateValidator _branchValidator;
        private readonly IBranchData _branchData;

        public BranchInfoController(ILogger<BranchInfoController> logger,
                                IMapper mapper,
                                BranchAddUpdateValidator branchValidator,
                                IBranchData branchData)
        {
            _logger = logger;
            _mapper = mapper;
            _branchValidator = branchValidator;
            _branchData = branchData;
        }


        public EntityResult<string> Delete (long branchId)
        {
            var results = new EntityResult<string>();

            try
            {
                var branchDetails = _branchData.Get(branchId);

                if (branchDetails != null)
                {
                    branchDetails.IsDeleted = true;
                    branchDetails.DeletedAt = DateTime.Now;

                    results.IsSuccess = _branchData.Update(branchDetails);
                    results.Messages.Add("Branch deleted.");
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


        public EntityResult<BranchModel> Save(BranchModel input, bool isNew)
        {
            var results = new EntityResult<BranchModel>();
            results.IsSuccess = false;

            try
            {
                ValidationResult validatorResult = _branchValidator.Validate(input);

                if (!validatorResult.IsValid)
                {
                    foreach (var failure in validatorResult.Errors)
                    {
                        results.Messages.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                    results.IsSuccess = false;
                    return results;
                }

                if (isNew)
                {
                    //var existingBranchWithTheSameName = _branchData.GetByBranchName(input.BranchName);

                    //if (existingBranchWithTheSameName != null)
                    //{
                    //    results.IsSuccess = false;
                    //    results.Messages.Add("Existing branch with the same name.");
                    //    return results;
                    //}

                    //var existingBranchWithTheTellNo = _branchData.GetByTellNo(input.TellNo);

                    //if (existingBranchWithTheTellNo != null)
                    //{
                    //    results.IsSuccess = false;
                    //    results.Messages.Add("Existing branch with the same tell no. (should be different contact number per branch)");
                    //    return results;
                    //}

                    long branchId = _branchData.Add(input);
                    if (branchId > 0)
                    {
                        var branchDetails = _branchData.Get(branchId);

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add new branch");
                        results.Data = branchDetails;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Unable to add new branch, kindly check system logs for possible errors.");
                    }
                }
                else
                {
                    var branchDetails = _branchData.Get(input.Id);

                    if (branchDetails == null)
                    {
                        results.IsSuccess = false;
                        results.Messages.Add($"Branch not found!");
                        return results;
                    }

                    _mapper.Map(input, branchDetails);

                    if (this._branchData.Update(branchDetails))
                    {
                        results.IsSuccess = true;
                        results.Messages.Add("Successfully update branch details.");
                        results.Data = branchDetails;
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
