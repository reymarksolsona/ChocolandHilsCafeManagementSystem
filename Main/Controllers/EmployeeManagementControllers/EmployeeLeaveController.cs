using AutoMapper;
using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared;
using EntitiesShared.EmployeeManagement;
using FluentValidation.Results;
using Main.Controllers.EmployeeManagementControllers.ControllerInterface;
using Main.Controllers.EmployeeManagementControllers.Validator;
using Microsoft.Extensions.Logging;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers
{
    public class EmployeeLeaveController : IEmployeeLeaveController
    {
        private readonly ILogger<EmployeeLeaveController> _logger;
        private readonly IMapper _mapper;
        private readonly IEmployeeLeaveData _employeeLeaveData;
        private readonly EmployeeLeaveAddUpdateValidator _employeeLeaveAddUpdateValidator;

        public EmployeeLeaveController(ILogger<EmployeeLeaveController> logger,
                                IMapper mapper,
                                IEmployeeLeaveData employeeLeaveData,
                                EmployeeLeaveAddUpdateValidator employeeLeaveAddUpdateValidator)
        {
            _logger = logger;
            _mapper = mapper;
            _employeeLeaveData = employeeLeaveData;
            _employeeLeaveAddUpdateValidator = employeeLeaveAddUpdateValidator;
        }

        public EntityResult<string> Delete(long empLeaveId, string employeeNumber)
        {
            var results = new EntityResult<string>();

            try
            {
                var empLeaveDetails = _employeeLeaveData.Get(empLeaveId);

                if (empLeaveDetails != null && empLeaveDetails.EmployeeNumber == employeeNumber)
                {
                    empLeaveDetails.IsDeleted = true;
                    empLeaveDetails.DeletedAt = DateTime.Now;

                    results.IsSuccess = _employeeLeaveData.Update(empLeaveDetails);
                    results.Messages.Add("Employee leave deleted.");
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

        public EntityResult<string> Approval(long empLeaveId, string employeeNumber, string remarks, StaticData.EmployeeRequestApprovalStatus status)
        {
            var results = new EntityResult<string>();

            try
            {
                var empLeaveDetails = _employeeLeaveData.Get(empLeaveId);

                if (empLeaveDetails != null && empLeaveDetails.EmployeeNumber == employeeNumber)
                {
                    empLeaveDetails.EmployerRemarks = remarks;
                    empLeaveDetails.ApprovalStatus = status;

                    results.IsSuccess = _employeeLeaveData.Update(empLeaveDetails);
                    results.Messages.Add($"{status} done!");
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


        public EntityResult<EmployeeLeaveModel> Save(EmployeeLeaveModel input, bool isNew)
        {
            var results = new EntityResult<EmployeeLeaveModel>();
            results.IsSuccess = false;

            try
            {
                ValidationResult validatorResult = _employeeLeaveAddUpdateValidator.Validate(input);

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
                    long itemId = _employeeLeaveData.Add(input);
                    if (itemId > 0)
                    {
                        var empLeaveDetails = _employeeLeaveData.Get(itemId);

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add new employee leave");
                        results.Data = empLeaveDetails;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Unable to add new employee leave, kindly check system logs for possible errors.");
                    }
                }
                else
                {
                    var empLeaveDetails = _employeeLeaveData.Get(input.Id);

                    if (empLeaveDetails == null)
                    {
                        results.IsSuccess = false;
                        results.Messages.Add($"Employee leave details not found!");
                        return results;
                    }

                    _mapper.Map(input, empLeaveDetails);

                    if (this._employeeLeaveData.Update(empLeaveDetails))
                    {
                        results.IsSuccess = true;
                        results.Messages.Add("Successfully update employee leave details.");
                        results.Data = empLeaveDetails;
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
