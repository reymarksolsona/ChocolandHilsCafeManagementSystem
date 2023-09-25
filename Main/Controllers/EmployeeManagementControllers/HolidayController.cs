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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers
{
    public class HolidayController : IHolidayController
    {
        private readonly ILogger<HolidayController> _logger;
        private readonly IMapper _mapper;
        private readonly IHolidayData _holidayData;
        private readonly HolidayAddUpdateValidator _holidayAddUpdateValidator;

        public HolidayController(ILogger<HolidayController> logger,
                                IMapper mapper,
                                IHolidayData holidayData,
                                HolidayAddUpdateValidator holidayAddUpdateValidator)
        {
            _logger = logger;
            _mapper = mapper;
            _holidayData = holidayData;
            _holidayAddUpdateValidator = holidayAddUpdateValidator;
        }

        public EntityResult<string> Delete(long holidayId)
        {
            var results = new EntityResult<string>();

            try
            {
                var holidayDetails = _holidayData.Get(holidayId);

                if (holidayDetails != null)
                {
                    holidayDetails.IsDeleted = true;
                    holidayDetails.DeletedAt = DateTime.Now;

                    results.IsSuccess = _holidayData.Update(holidayDetails);
                    results.Messages.Add("Holiday deleted.");
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

        public EntityResult<HolidayModel> Save(HolidayModel input, bool isNew)
        {
            var results = new EntityResult<HolidayModel>();
            results.IsSuccess = false;

            try
            {
                ValidationResult validatorResult = _holidayAddUpdateValidator.Validate(input);

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
                    long itemId = _holidayData.Add(input);
                    if (itemId > 0)
                    {
                        var holidayDetails = _holidayData.Get(itemId);

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add new holiday.");
                        results.Data = holidayDetails;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Unable to add new agency, kindly check system logs for possible errors.");
                    }
                }
                else
                {
                    var holidayDetails = _holidayData.Get(input.Id);

                    if (holidayDetails == null)
                    {
                        results.IsSuccess = false;
                        results.Messages.Add($"Holiday not found!");
                        return results;
                    }

                    _mapper.Map(input, holidayDetails);

                    if (this._holidayData.Update(holidayDetails))
                    {
                        results.IsSuccess = true;
                        results.Messages.Add("Successfully update holiday details.");
                        results.Data = holidayDetails;
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
