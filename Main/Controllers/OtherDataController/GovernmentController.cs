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
    public class GovernmentController : IGovernmentController
    {
        private readonly ILogger<GovernmentController> _logger;
        private readonly IMapper _mapper;
        private readonly IGovernmentAgencyData _governmentAgencyData;
        private readonly GovernmentAgencyAddUpdateValidator _governmentAgencyAddUpdateValidator;

        public GovernmentController(ILogger<GovernmentController> logger,
                                IMapper mapper,
                                IGovernmentAgencyData governmentAgencyData,
                                GovernmentAgencyAddUpdateValidator governmentAgencyAddUpdateValidator)
        {
            _logger = logger;
            _mapper = mapper;
            _governmentAgencyData = governmentAgencyData;
            _governmentAgencyAddUpdateValidator = governmentAgencyAddUpdateValidator;
        }

        public EntityResult<string> Delete(long agencyId)
        {
            var results = new EntityResult<string>();

            try
            {
                var agencyDetails = _governmentAgencyData.Get(agencyId);

                if (agencyDetails != null)
                {
                    agencyDetails.IsDeleted = true;
                    agencyDetails.DeletedAt = DateTime.Now;

                    results.IsSuccess = _governmentAgencyData.Update(agencyDetails);
                    results.Messages.Add("Agency deleted.");
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

        public ListOfEntityResult<GovernmentAgencyModel> GetAll()
        {
            var results = new ListOfEntityResult<GovernmentAgencyModel>();
            try
            {
                var leaveTypes = _governmentAgencyData.GetAllNotDeleted();
                results.IsSuccess = true;
                results.Messages.Add("Successfully retrieve all govt. agencies data");
                results.Data = leaveTypes;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }

        public EntityResult<GovernmentAgencyModel> GetById(long Id)
        {
            var results = new EntityResult<GovernmentAgencyModel>();
            try
            {
                var resData = _governmentAgencyData.Get(Id);
                results.IsSuccess = true;
                results.Messages.Add("Successfully retrieve govt. agency data");
                results.Data = resData;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }

        public EntityResult<GovernmentAgencyModel> Save(GovernmentAgencyModel input, bool isNew)
        {
            var results = new EntityResult<GovernmentAgencyModel>();
            results.IsSuccess = false;

            try
            {
                ValidationResult validatorResult = _governmentAgencyAddUpdateValidator.Validate(input);

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
                    long agencyId = _governmentAgencyData.Add(input);
                    if (agencyId > 0)
                    {
                        var agencyDetails = _governmentAgencyData.Get(agencyId);

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add new agency");
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
                    var agencyDetails = _governmentAgencyData.Get(input.Id);

                    if (agencyDetails == null)
                    {
                        results.IsSuccess = false;
                        results.Messages.Add($"Agency not found!");
                        return results;
                    }

                    _mapper.Map(input, agencyDetails);

                    if (this._governmentAgencyData.Update(agencyDetails))
                    {
                        results.IsSuccess = true;
                        results.Messages.Add("Successfully update agency.");
                        results.Data = agencyDetails;
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
