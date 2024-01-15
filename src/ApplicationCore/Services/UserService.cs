using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Enumeration;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ApplicationCore.Enumeration.LoginEnum;

namespace FAIS.ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILoginHistoryRepository _historyRepository;
        private readonly ISettingsRepository _settingsRepository;

        public UserService(IUserRepository testRepository
            , ISettingsRepository settingsRepository
            , ILoginHistoryRepository historyRepository)
        {
            _userRepository = testRepository;
            _settingsRepository = settingsRepository;
            _historyRepository = historyRepository;
        }

        public IReadOnlyCollection<UserModel> Get()
        {
            return _userRepository.Get();
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<User> GetByUserName(string userName)
        {
            return await _userRepository.GetByUserName(userName);
        }

        public async Task<List<PermissionModel>> GetPermissions(int id)
        {
            return await _userRepository.GetPermissions(id);
        }

        public async Task<User> Add(UserDTO userDto)
        {
            try
            {
                var settings = _settingsRepository.GetById(1);

                var testData = new User()
                {
                    FirstName = userDto.FirstName,
                    MiddleName = userDto.MiddleName,
                    LastName = userDto.LastName,
                    EmployeeNumber = userDto.EmployeeNumber,
                    UserName = userDto.UserName,
                    PositionId = userDto.PositionId,
                    DivisionId = userDto.DivisionId,
                    Password = EncryptionHelper.HashPassword(userDto.Password),
                    EmailAddress = userDto.EmailAddress,
                    MobileNumber = userDto.MobileNumber,
                    OupFgId = userDto.OupFgId,
                    Photo = userDto.Photo,
                    SessionId = userDto.SessionId,
                    SignInAttempts = userDto.SignInAttempts,
                    StatusCode = (int)UserStatusEnum.Active,
                    StatusDate = DateTime.Now,
                    DateExpired = DateTime.Now.AddDays(settings.PasswordExpiry),
                    CreatedBy = userDto.CreatedBy,
                    CreatedAt = DateTime.Now
                };

                return await _userRepository.Add(testData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LoginHistory> AddLoginHistory(int userId, string username, bool isFailed = false)
        {
            var history = new LoginHistory()
            {
                UserId = userId,
                Username = username,
                IsFailed = isFailed ? 'Y' : 'N',
                CreatedAt = DateTime.Now
            };

            return await _historyRepository.Add(history);
        }

        public async Task<User> LockAccount(int id)
        {
            var user = await _userRepository.GetById(id);

            user.StatusCode = (int)UserStatusEnum.Locked;

            return await _userRepository.Update(user);
        }

        public async Task<User> UpdateSignInAttempts(UserDTO userDto)
        {
            var user = await _userRepository.GetById(userDto.Id);

            user.SignInAttempts = userDto.LoginStatus == (int)LoginStatus.Success ? 0 : (user.SignInAttempts + 1);

            return await _userRepository.Update(user);
        }

        public async Task<User> SetTemporaryKey(int id)
        {
            var user = await _userRepository.GetById(id);

            user.TempKey = $"{Guid.NewGuid()}-{DateTime.Now.Date.ToString().Split(' ')[0].Replace("/", string.Empty)}";

            return await _userRepository.Update(user);
        }
    }
}
