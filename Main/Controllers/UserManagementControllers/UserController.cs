using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DataAccess.Data.UserManagement.Contracts;
using Shared.Helpers;
using Shared.ResponseModels;
using EntitiesShared.UserManagement;
using Main.Controllers.UserManagementControllers.Validator;
using FluentValidation.Results;
using AutoMapper;
using EntitiesShared.UserManagement.Model;
using System.Transactions;
using DataAccess.Data.EmployeeManagement.Contracts;

namespace Main.Controllers.UserManagementControllers
{
    public class UserController : IUserController
    {
        private readonly ILogger<LoginFrm> _logger;
        private readonly IMapper _mapper;
        private readonly Sessions _sessions;
        private readonly Hashing _hashing;
        private readonly IRoleData _roleData;
        private readonly IUserData _userData;
        private readonly IUserRoleData _userRoleData;
        private readonly IEmployeeData _employeeData;
        private readonly UserAddUpdateValidator _userAddUpdateValidator;

        public UserController(ILogger<LoginFrm> logger,
                                IMapper mapper,
                                Sessions sessions,
                                Hashing hashing,
                                IRoleData roleData,
                                IUserData userData,
                                IUserRoleData userRoleData,
                                IEmployeeData employeeData,
                                UserAddUpdateValidator userAddUpdateValidator)
        {
            _logger = logger;
            _mapper = mapper;
            _sessions = sessions;
            _hashing = hashing;
            _roleData = roleData;
            _userData = userData;
            _userRoleData = userRoleData;
            _employeeData = employeeData;
            _userAddUpdateValidator = userAddUpdateValidator;
        }

        public EntityResult<string> Delete(long userId)
        {
            var results = new EntityResult<string>();

            try
            {
                var userDetails = _userData.Get(userId);

                if (userDetails != null)
                {
                    userDetails.IsDeleted = true;
                    userDetails.DeletedAt = DateTime.Now;

                    results.IsSuccess = _userData.Update(userDetails);
                    results.Messages.Add("User deleted.");
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


        public ListOfEntityResult<UserModel> Search(string searchStr)
        {
            var results = new ListOfEntityResult<UserModel>();
            try
            {
                var users = _userData.Search(searchStr);

                if (users != null)
                {
                    foreach (var user in users)
                    {
                        user.Role = _userRoleData.GetUserRole(user.Id);
                    }
                }

                results.IsSuccess = true;
                results.Messages.Add("Successfully retrieve users.");
                results.Data = users;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }

        public ListOfEntityResult<UserModel> GetAll()
        {
            var results = new ListOfEntityResult<UserModel>();
            try
            {
                var users = _userData.GetAllNotDeleted();

                if (users != null)
                {
                    foreach(var user in users)
                    {
                        user.Role = _userRoleData.GetUserRole(user.Id);
                    }
                }

                results.IsSuccess = true;
                results.Messages.Add("Successfully retrieve all users");
                results.Data = users;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }

        public List<RoleModel> GetAllRoles()
        {
            var results = new List<RoleModel>();
            results = _roleData.GetAll();
            return results;
        }


        public EntityResult<UserModel> GetById(long userId)
        {
            var results = new EntityResult<UserModel>();
            try
            {
                var user = _userData.Get(userId);

                if (user != null)
                    user.Role = _userRoleData.GetUserRole(user.Id);

                results.IsSuccess = true;
                results.Messages.Add("Successfully retrieve user data.");
                results.Data = user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }

        public EntityResult<UserModel> GetByUsername(string userName)
        {
            var results = new EntityResult<UserModel>();
            try
            {
                var user = _userData.GetUserByUserName(userName);

                if (user != null)
                {
                    user.Role = _userRoleData.GetUserRole(user.Id);
                    results.IsSuccess = true;
                    results.Messages.Add("Successfully retrieve user data.");
                    results.Data = user;
                    return results;
                }

                results.IsSuccess = false;
                results.Messages.Add("User not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }

        public EntityResult<UserModel> Save(UserAddUpdateModel input, bool isNew)
        {
            var results = new EntityResult<UserModel>();
            results.IsSuccess = false;

            try
            {
                ValidationResult validatorResult = _userAddUpdateValidator.Validate(input);

                if (!validatorResult.IsValid)
                {
                    foreach (var failure in validatorResult.Errors)
                    {
                        results.Messages.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                    results.IsSuccess = false;
                    return results;
                }

                var roleDetails = _roleData.GetByRolekey(input.Role);

                if (roleDetails == null)
                {
                    results.IsSuccess = false;
                    results.Messages.Add("Role not found.");
                    return results;
                }

                var userDetails = _userData.GetUserByUserName(input.UserName);

                if (userDetails != null && isNew == true)
                {
                    results.IsSuccess = false;
                    results.Messages.Add("Duplicate username, kindly use other username.");
                    return results;
                }

                if (userDetails == null && isNew == false)
                {
                    results.IsSuccess = false;
                    results.Messages.Add("Changing username is not allowed.");
                    return results;
                }

                var employeeDetails = _employeeData.GetByEmployeeNumber(input.UserName);
                if (employeeDetails == null)
                {
                    results.IsSuccess = false;
                    results.Messages.Add("Employee number doesn't existing.");
                    return results;
                }

                if (userDetails == null && isNew == true)
                {
                    if (string.IsNullOrWhiteSpace(input.Password))
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Enter password");
                        return results;
                    }

                    var hashedPassword = _hashing.GetSHA512String(input.Password);

                    var newUser = new UserModel
                    {
                        UserName = input.UserName,
                        FullName = input.FullName,
                        PasswordSha512 = hashedPassword,
                        IsActive = input.IsActive
                    };

                    using (var transaction = new TransactionScope())
                    {
                        long userId = _userData.Add(newUser);

                        if (userId > 0)
                        {
                            _userRoleData.Add(new UserRoleModel { UserId = userId, RoleId = roleDetails.Id });

                            results.IsSuccess = true;
                            results.Messages.Add("Successfully add new user");
                            results.Data = newUser;
                        }
                        else
                        {
                            results.IsSuccess = false;
                            results.Messages.Add("Unable to add new user, kindly check system logs for possible errors.");
                        }

                        transaction.Complete();
                    }
                }
                else if (userDetails != null && isNew == false)
                {
                    userDetails.FullName = input.FullName;
                    userDetails.UserName = input.UserName;

                    if (string.IsNullOrWhiteSpace(input.Password) == false)
                    {
                        var hashedPassword = _hashing.GetSHA512String(input.Password);
                        userDetails.PasswordSha512 = hashedPassword;
                    }

                    userDetails.IsActive = input.IsActive;

                    var userRole = _userRoleData.GetUserRole(userDetails.Id);

                    using (var transaction = new TransactionScope())
                    {
                        if (_userData.Update(userDetails))
                        {
                            if (userRole != null)
                            {
                                userRole.RoleId = roleDetails.Id;
                                _userRoleData.Update(userRole);
                            }
                            else
                            {
                                _userRoleData.Add(new UserRoleModel { UserId = userDetails.Id, RoleId = roleDetails.Id });
                            }

                            results.IsSuccess = true;
                            results.Messages.Add("Successfully update user.");
                            results.Data = userDetails;
                        }
                        else
                        {
                            results.IsSuccess = false;
                            results.Messages.Add("No changes made.");
                        }

                        transaction.Complete();
                    }
                }
                else
                {
                    results.IsSuccess = false;
                    results.Messages.Add("Invalid transaction, kindly cancel this request or reopen this application.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }

        public EntityResult<UserModel> SignIn(string username, string password)
        {
            var result = new EntityResult<UserModel>();
            result.IsSuccess = false;
            result.Messages.Add("Login failed");

            try
            {
                string hashPassword = _hashing.GetSHA512String(password);
                var userInfo = _userData.GetUserByUserName(username);

                if (userInfo != null && userInfo.IsActive)
                {
                    if (userInfo.PasswordSha512.ToUpper() == hashPassword.ToUpper())
                    {
                        // Add user role
                        userInfo.Role = _userRoleData.GetUserRole(userInfo.Id);

                        result.Data = userInfo;
                        result.IsSuccess = true;
                        result.Messages.Add("User found.");
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Messages.Add("Invalid password.");
                    }
                }
            }catch(Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                result.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return result;
        }
    }
}
