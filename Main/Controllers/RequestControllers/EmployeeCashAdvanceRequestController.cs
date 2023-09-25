using AutoMapper;
using DataAccess.Data.PayrollManagement.Contracts;
using EntitiesShared;
using EntitiesShared.PayrollManagement;
using FluentValidation.Results;
using Main.Controllers.RequestControllers.ControllerInterface;
using Main.Controllers.RequestControllers.Validators;
using Microsoft.Extensions.Logging;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.RequestControllers
{
    public class EmployeeCashAdvanceRequestController : IEmployeeCashAdvanceRequestController
    {
        private readonly ILogger<EmployeeCashAdvanceRequestController> _logger;
        private readonly IMapper _mapper;
        private readonly Sessions _sessions;
        private readonly EmployeeCashAdvanceRequestValidator _employeeCashAdvanceRequestValidator;
        private readonly IEmployeeCashAdvanceRequestData _employeeCashAdvanceRequestData;

        public EmployeeCashAdvanceRequestController(ILogger<EmployeeCashAdvanceRequestController> logger,
                                IMapper mapper,
                                Sessions sessions,
                                EmployeeCashAdvanceRequestValidator employeeCashAdvanceRequestValidator,
                                IEmployeeCashAdvanceRequestData employeeCashAdvanceRequestData)
        {
            _logger = logger;
            _mapper = mapper;
            _sessions = sessions;
            _employeeCashAdvanceRequestValidator = employeeCashAdvanceRequestValidator;
            _employeeCashAdvanceRequestData = employeeCashAdvanceRequestData;
        }


        public EntityResult<string> CancelRequest (long requestId)
        {
            var results = new EntityResult<string>();
            results.IsSuccess = false;

            try
            {
                var requestDetails = _employeeCashAdvanceRequestData.Get(requestId);

                if (requestDetails != null)
                {
                    if (requestDetails.ApprovalStatus != StaticData.EmployeeRequestApprovalStatus.Pending)
                    {
                        results.IsSuccess = false;
                        results.Messages.Add($"Unable to modify this request because the status is already in {requestDetails.ApprovalStatus}");
                        return results;
                    }

                    requestDetails.ApprovalStatus = StaticData.EmployeeRequestApprovalStatus.Cancelled;
                    requestDetails.IsDeleted = true;
                    requestDetails.DeletedAt = DateTime.Now;

                    results.IsSuccess = _employeeCashAdvanceRequestData.Update(requestDetails);
                    results.Messages.Add("Request has been cancelled");
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


       

        public EntityResult<EmployeeCashAdvanceRequestModel> Save(EmployeeCashAdvanceRequestModel input, bool isNew)
        {
            var results = new EntityResult<EmployeeCashAdvanceRequestModel>();
            results.IsSuccess = false;

            try
            {
                ValidationResult validatorResult = _employeeCashAdvanceRequestValidator.Validate(input);

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
                    long requestId = _employeeCashAdvanceRequestData.Add(input);

                    if (requestId > 0)
                    {
                        var branchDetails = _employeeCashAdvanceRequestData.Get(requestId);

                        results.IsSuccess = true;
                        results.Messages.Add("New cash advance request submitted successfully.");
                        results.Data = branchDetails;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Unable submit new cash advance request, kindly check system logs for possible errors.");
                    }
                }
                else
                {
                    var requestDetails = _employeeCashAdvanceRequestData.Get(input.Id);

                    if (requestDetails == null)
                    {
                        results.IsSuccess = false;
                        results.Messages.Add($"Cash advance request not found!");
                        return results;
                    }

                    _mapper.Map(input, requestDetails);

                    if (this._employeeCashAdvanceRequestData.Update(requestDetails))
                    {
                        results.IsSuccess = true;
                        results.Messages.Add("Successfully update request.");
                        results.Data = requestDetails;
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


        public EntityResult<string> Approval(long requestId, StaticData.EmployeeRequestApprovalStatus status, string adminRemarks, DateTime cashReleaseDate)
        {
            var results = new EntityResult<string>();
            results.IsSuccess = false;

            try
            {
                var requestDetails = _employeeCashAdvanceRequestData.Get(requestId);

                if (requestDetails != null)
                {
                    if (requestDetails.ApprovalStatus != StaticData.EmployeeRequestApprovalStatus.Pending)
                    {
                        results.IsSuccess = false;
                        results.Messages.Add($"Unable to modify this request because the status is already in {requestDetails.ApprovalStatus}");
                        return results;
                    }

                    requestDetails.ApprovalStatus = status;
                    requestDetails.EmployerRemarks = adminRemarks;
                    requestDetails.CashReleaseDate = cashReleaseDate;

                    results.IsSuccess = _employeeCashAdvanceRequestData.Update(requestDetails);
                    results.Messages.Add($"Successfully {status} this request");
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
    }
}
