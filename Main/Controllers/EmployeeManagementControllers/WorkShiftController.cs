using AutoMapper;
using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using FluentValidation.Results;
using Main.Controllers.EmployeeManagementControllers.ControllerInterface;
using Main.Controllers.EmployeeManagementControllers.Validator;
using Microsoft.Extensions.Logging;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers
{
    public class WorkShiftController : IWorkShiftController
    {
        private readonly ILogger<WorkShiftController> _logger;
        private readonly IMapper _mapper;
        private readonly IEmployeeShiftData _employeeShiftData;
        private readonly IEmployeeShiftDayData _employeeShiftDayData;
        private readonly EmployeeShiftAddUpdateValidator _employeeShiftAddUpdateValidator;

        public WorkShiftController(ILogger<WorkShiftController> logger,
                                IMapper mapper,
                                IEmployeeShiftData employeeShiftData,
                                IEmployeeShiftDayData employeeShiftDayData,
                                EmployeeShiftAddUpdateValidator employeeShiftAddUpdateValidator)
        {
            _logger = logger;
            _mapper = mapper;
            _employeeShiftData = employeeShiftData;
            _employeeShiftDayData = employeeShiftDayData;
            _employeeShiftAddUpdateValidator = employeeShiftAddUpdateValidator;
        }

        public EntityResult<string> Delete(long shiftId)
        {
            var results = new EntityResult<string>();

            try
            {
                var shiftDetails = _employeeShiftData.Get(shiftId);

                if (shiftDetails != null)
                {
                    shiftDetails.IsDeleted = true;
                    shiftDetails.DeletedAt = DateTime.Now;

                    results.IsSuccess = _employeeShiftData.Update(shiftDetails);
                    results.Messages.Add("Shift deleted.");
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

        public ListOfEntityResult<EmployeeShiftModel> GetAll()
        {
            var results = new ListOfEntityResult<EmployeeShiftModel>();
            try
            {
                var workShifts = _employeeShiftData.GetAllNotDeleted();
                results.IsSuccess = true;
                results.Messages.Add("Successfully retrieve all govt. agencies data");
                results.Data = workShifts;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }

        public EntityResult<EmployeeShiftModel> GetById(long Id)
        {
            var results = new EntityResult<EmployeeShiftModel>();
            try
            {
                var resData = _employeeShiftData.Get(Id);
                results.IsSuccess = true;
                results.Messages.Add("Successfully retrieve shift data");
                results.Data = resData;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }

        public EntityResult<EmployeeShiftModel> Save(EmployeeShiftModel input, List<EmployeeShiftDayModel> shiftDays, bool isNew)
        {
            var results = new EntityResult<EmployeeShiftModel>();
            results.IsSuccess = false;

            try
            {
                ValidationResult validatorResult = _employeeShiftAddUpdateValidator.Validate(input);

                if (!validatorResult.IsValid)
                {
                    foreach (var failure in validatorResult.Errors)
                    {
                        results.Messages.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                    results.IsSuccess = false;
                    return results;
                }

                using (var transaction = new TransactionScope())
                {
                    if (isNew)
                    {
                        long itemId = _employeeShiftData.Add(input);
                        if (itemId > 0)
                        {
                            var agencyDetails = _employeeShiftData.Get(itemId);

                            shiftDays.ForEach(x => x.ShiftId = itemId);

                            _employeeShiftDayData.AddRange(shiftDays);


                            results.IsSuccess = true;
                            results.Messages.Add("Successfully add new shift");
                            results.Data = agencyDetails;
                        }
                        else
                        {
                            results.IsSuccess = false;
                            results.Messages.Add("Unable to add new agency, kindly check system logs for possible errors.");
                        }
                    }
                    else
                    {
                        var shiftDetails = _employeeShiftData.Get(input.Id);

                        if (shiftDetails == null)
                        {
                            results.IsSuccess = false;
                            results.Messages.Add($"Shift not found!");
                            return results;
                        }

                        //var existingShiftDays = _employeeShiftDayData.GetByShiftId(shiftDetails.Id);

                        //_mapper.Map(shiftDays, existingShiftDays);
                        _mapper.Map(input, shiftDetails);

                        if (this._employeeShiftData.Update(shiftDetails))
                        {

                            foreach(var dayName in shiftDays)
                            {
                                if (dayName.IsNeedToAdd == true)
                                {
                                    dayName.ShiftId = shiftDetails.Id;
                                    _employeeShiftDayData.Add(dayName);
                                }
                                else if (dayName.IsNeedToUpdate == true)
                                {
                                    _employeeShiftDayData.Update(dayName);
                                }
                            }


                            results.IsSuccess = true;
                            results.Messages.Add("Successfully update shift.");
                            results.Data = shiftDetails;
                        }
                        else
                        {
                            results.IsSuccess = false;
                            results.Messages.Add("No changes made.");
                        }
                    }

                    transaction.Complete();
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
