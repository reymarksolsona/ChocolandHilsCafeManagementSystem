using AutoMapper;
using DataAccess.Data.OtherDataManagement.Contracts;
using EntitiesShared.OtherDataManagement;
using FluentValidation.Results;
using Main.Controllers.OtherDataController.ControllerInterface;
using Main.Controllers.OtherDataController.Validator;
using Microsoft.Extensions.Logging;
using Shared.ResponseModels;
using System;

namespace Main.Controllers.OtherDataController
{
    public class LeaveTypeController : ILeaveTypeController
    {
        private readonly ILogger<LoginFrm> _logger;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeData _leaveTypeData;
        private readonly LeaveTypeAddUpdateValidator _validationRules;

        public LeaveTypeController(ILogger<LoginFrm> logger,
                                IMapper mapper,
                                ILeaveTypeData leaveTypeData,
                                LeaveTypeAddUpdateValidator validationRules)
        {
            _logger = logger;
            _mapper = mapper;
            _leaveTypeData = leaveTypeData;
            _validationRules = validationRules;
        }


        public EntityResult<LeaveTypeModel> GetById(long Id)
        {
            var results = new EntityResult<LeaveTypeModel>();
            try
            {
                var employees = _leaveTypeData.Get(Id);
                results.IsSuccess = true;
                results.Messages.Add("Successfully retrieve leave type data");
                results.Data = employees;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }

        public ListOfEntityResult<LeaveTypeModel> GetAll()
        {
            var results = new ListOfEntityResult<LeaveTypeModel>();
            try
            {
                var leaveTypes = _leaveTypeData.GetAllNotDeleted();
                results.IsSuccess = true;
                results.Messages.Add("Successfully retrieve all leave type data");
                results.Data = leaveTypes;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }


        public EntityResult<string> Delete(long leaveTypeId)
        {
            var results = new EntityResult<string>();

            try
            {
                var leaveTypeDetails = _leaveTypeData.Get(leaveTypeId);

                if (leaveTypeDetails != null)
                {
                    leaveTypeDetails.IsDeleted = true;
                    leaveTypeDetails.DeletedAt = DateTime.Now;

                    results.IsSuccess = _leaveTypeData.Update(leaveTypeDetails);
                    results.Messages.Add("Leave type deleted.");
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


        public EntityResult<LeaveTypeModel> Save(LeaveTypeModel input, bool isNew)
        {
            var results = new EntityResult<LeaveTypeModel>();
            results.IsSuccess = false;

            try
            {
                ValidationResult validatorResult = _validationRules.Validate(input);

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
                    long newLeaveTypeId = _leaveTypeData.Add(input);
                    if (newLeaveTypeId > 0)
                    {
                        var newLeaveTypeDetails = _leaveTypeData.Get(newLeaveTypeId);

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add new leave type");
                        results.Data = newLeaveTypeDetails;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Unable to add new leave type, kindly check system logs for possible errors.");
                    }
                }
                else
                {
                    var leaveTypeDetails = _leaveTypeData.Get(input.Id);

                    if (leaveTypeDetails == null)
                    {
                        results.IsSuccess = false;
                        results.Messages.Add($"Leave type not found!");
                        return results;
                    }

                    _mapper.Map(input, leaveTypeDetails);

                    if (this._leaveTypeData.Update(leaveTypeDetails))
                    {
                        results.IsSuccess = true;
                        results.Messages.Add("Successfully update leave type.");
                        results.Data = leaveTypeDetails;
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
