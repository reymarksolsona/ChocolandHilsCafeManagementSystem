using AutoMapper;
using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using EntitiesShared.EmployeeManagement.Models;
using Main.Controllers.EmployeeManagementControllers.ControllerInterface;
using Microsoft.Extensions.Logging;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;

namespace Main.Controllers.EmployeeManagementControllers
{
    public class WorkforceScheduleController : IWorkforceScheduleController
    {
        private readonly ILogger<WorkforceScheduleController> _logger;
        private readonly IMapper _mapper;
        private readonly IWorkforceScheduleData _workforceScheduleData;

        public WorkforceScheduleController(ILogger<WorkforceScheduleController> logger,
                                        IMapper mapper, IWorkforceScheduleData workforceScheduleData)
        {
            _logger = logger;
            _mapper = mapper;
            _workforceScheduleData = workforceScheduleData;
        }


        public EntityResult<string> DeleteByDateRange(DateTime workDateStart, DateTime workDateEnd)
        {
            var results = new EntityResult<string>();

            try
            {
                var isDeleted = _workforceScheduleData.MassDeleteByDateRange(workDateStart, workDateEnd);

                if (isDeleted)
                {
                    results.IsSuccess = isDeleted;
                    results.Messages.Add("Schedule deleted");
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

        public EntityResult<string> Delete(long scheduleId, DateTime workDate)
        {
            var results = new EntityResult<string>();

            try
            {
                var workforceSched = _workforceScheduleData.GetByIdAndWorkdate(scheduleId, workDate);

                if (workforceSched != null)
                {
                    workforceSched.IsDeleted = true;
                    workforceSched.DeletedAt = DateTime.Now;

                    results.IsSuccess = _workforceScheduleData.Update(workforceSched);
                    results.Messages.Add("Schedule deleted");
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


        public WorkforceScheduling GetWorkforceSchedule()
        {
            WorkforceScheduling workforceScheduling = new WorkforceScheduling();
            workforceScheduling.WorkForceByDate = new Dictionary<DateTime, List<EmployeeModel>>();
            workforceScheduling.WorkforceSchedules = new List<WorkforceScheduleModel>();

            // We just need to retrieve schedule workforce that workdate is greater than or equal to date today
            var workforceScheduleInOurDB = _workforceScheduleData.GetAllNotYetDone(DateTime.Now);

            if (workforceScheduleInOurDB != null && workforceScheduleInOurDB.Count > 0)
            {
                workforceScheduling.WorkforceSchedules = workforceScheduleInOurDB;
                workforceScheduling.StartDate = workforceScheduleInOurDB.FirstOrDefault().WorkDate;
                workforceScheduling.EndDate = workforceScheduleInOurDB.LastOrDefault().WorkDate;

                foreach (var sched in workforceScheduleInOurDB)
                {
                    var tempEmployeeObj = JsonSerializer.Deserialize<EmployeeModel>(JsonSerializer.Serialize(sched.Employee));

                    if (workforceScheduling.WorkForceByDate.ContainsKey(sched.WorkDate))
                    {
                        workforceScheduling.WorkForceByDate[sched.WorkDate].Add(tempEmployeeObj);
                    }
                    else
                    {
                        workforceScheduling.WorkForceByDate[sched.WorkDate] = new List<EmployeeModel>();
                        workforceScheduling.WorkForceByDate[sched.WorkDate].Add(tempEmployeeObj);
                    }
                }
            }

            return workforceScheduling;

        }


        public EntityResult<WorkforceScheduling> Save (WorkforceScheduling workForceSchedule)
        {
            var results = new EntityResult<WorkforceScheduling>();
            results.IsSuccess = false;

            try
            {
                using (var transaction = new TransactionScope())
                {
                    foreach (var schedule in workForceSchedule.WorkForceByDate)
                    {
                        var workDate = schedule.Key;
                        var workforce = schedule.Value;

                        foreach(var emp in workforce)
                        {
                            if (workForceSchedule.WorkforceSchedules != null)
                            {
                                var schedEmpInOurDB = workForceSchedule.WorkforceSchedules
                                                                .Where(x => x.EmployeeNumber == emp.EmployeeNumber &&
                                                                        x.WorkDate == workDate).FirstOrDefault();

                                if (schedEmpInOurDB == null)
                                {
                                    // add new
                                    var newSchedEmp = new WorkforceScheduleModel
                                    {
                                        WorkDate = workDate,
                                        EmployeeNumber = emp.EmployeeNumber
                                    };

                                    _workforceScheduleData.Add(newSchedEmp);
                                }
                                else
                                {
                                    // update (for deleting)
                                    _workforceScheduleData.Update(schedEmpInOurDB);
                                }
                            }
                            else
                            {
                                // add new
                                var newSchedEmp = new WorkforceScheduleModel
                                {
                                    WorkDate = workDate,
                                    EmployeeNumber = emp.EmployeeNumber
                                };
                                _workforceScheduleData.Add(newSchedEmp);
                            }
                        }

                    }

                    transaction.Complete();
                }

                results.Data = this.GetWorkforceSchedule();
                results.IsSuccess = true;
                results.Messages.Add("Successfully save workforce schedule.");

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
