using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Enumeration;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
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
        private readonly ILibraryTypeRepository _ILibraryTypeRepository;

        public UserService(IUserRepository testRepository
            , ISettingsRepository settingsRepository
            , ILoginHistoryRepository historyRepository
            , ILibraryTypeRepository iLibraryTypeRepository)
        {
            _userRepository = testRepository;
            _settingsRepository = settingsRepository;
            _historyRepository = historyRepository;
            _ILibraryTypeRepository = iLibraryTypeRepository;
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

        public async Task<User> GetByTempKey(string tempKey)
        {
            return await _userRepository.GetByTempKey(tempKey);
        }

        public async Task<User> GetByEmailAddress(string emailAddress)
        {
            return await _userRepository.GetByEmailAddress(emailAddress);
        }

        public async Task<List<PermissionModel>> GetPermissions(int id)
        {
            return await _userRepository.GetPermissions(id);
        }

        public async Task<User> Add(UserDTO userDTO)
        {
            var positionId =  _ILibraryTypeRepository.GetPositionIdByName(userDTO.PositionName);
            var divisionId =  _ILibraryTypeRepository.GetPositionIdByName(userDTO.DivisionName);
            var oupfgId = _ILibraryTypeRepository.GetPositionIdByName(userDTO.OupFG);
            var settings = _settingsRepository.GetById(1);

            var user = new User()
            {
                FirstName = userDTO.FirstName,
                MiddleName = userDTO.MiddleName,
                LastName = userDTO.LastName,
                EmployeeNumber = userDTO.EmployeeNumber,
                UserName = userDTO.UserName,
                PositionId = positionId.Id,
                DivisionId = divisionId.Id,
                Password = EncryptionHelper.HashPassword(userDTO.Password),
                EmailAddress = userDTO.EmailAddress,
                MobileNumber = userDTO.MobileNumber,
                OupFgId = oupfgId.Id,
                Photo = userDTO.Photo,
                SessionId = userDTO.SessionId,
                SignInAttempts = userDTO.SignInAttempts,
                StatusCode = userDTO.StatusCode,
                StatusDate = userDTO.StatusDate,
                DateExpired = DateTime.Now.AddDays(settings.PasswordExpiry),
                CreatedBy = userDTO.CreatedBy,
                CreatedAt = DateTime.Now,
                UpdatedBy = userDTO?.UpdatedBy,
                UpdatedAt = DateTime.Now,
                TempKey = userDTO.TempKey,
            };
            var addedUser = await _userRepository.Add(user);
            int userId = await _userRepository.GetLastUserId();

            var userTAFGs = new List<UserTAFG>();
            foreach (var region in userDTO.Region)
            {
                var tafgId = _ILibraryTypeRepository.GetLibraryTypeIdByCode(region);
                var userTAFG = new UserTAFG
                {
                    UserId = userId,
                    TAFGId = tafgId.Id,
                    IsActive = 'Y',
                    StatusDate = userDTO.StatusDate,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = userDTO.CreatedBy,
                    UpdatedBy = userDTO.UpdatedBy,
                };
                userTAFGs.Add(userTAFG);
            }
            await _userRepository.AddTAFGs(userTAFGs);
            return addedUser;
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

        public async Task<DateTime?> GetLastLoginDate(int userId)
        {
            return await _historyRepository.GetLastLoginDate(userId);
        }

        public async Task<User> ResetPassword(string tempKey, string newPassword)
        {
            var settings = _settingsRepository.GetById(1);
            var user = await _userRepository.GetByTempKey(tempKey);

            user.Password = EncryptionHelper.HashPassword(newPassword);
            user.SignInAttempts = 0;
            user.StatusCode = (int)UserStatusEnum.Active;
            user.StatusDate = DateTime.Now;
            user.TempKey = string.Empty;
            user.DateExpired = DateTime.Now.AddDays(settings.PasswordExpiry);

            return await _userRepository.Update(user);
        }

        public async Task<User> ChangePassword(int userId, string newPassword)
        {
            var settings = _settingsRepository.GetById(1);
            var user = await _userRepository.GetById(userId);

            user.Password = EncryptionHelper.HashPassword(newPassword);
            user.SignInAttempts = 0;
            user.StatusCode = (int)UserStatusEnum.Active;
            user.StatusDate = DateTime.Now;
            user.DateExpired = DateTime.Now.AddDays(settings.PasswordExpiry);

            return await _userRepository.Update(user);
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

        public async Task<string> SetTemporaryKey(int id)
        {
            var user = await _userRepository.GetById(id);

            user.TempKey = $"{Guid.NewGuid()}-{DateTime.Now.Date.ToString().Split(' ')[0].Replace("/", string.Empty)}";

            await _userRepository.Update(user);

            return user.TempKey;
        }

        public async Task<User> Update(User user)
        {
            return await _userRepository.Update(user);
        }
        public async Task<string> WriteFile(IFormFile file, string directory)
        {
            return await _userRepository.WriteFile(file, directory);
        }
        public async Task<int> GetLastUserId()
        {
            return await _userRepository.GetLastUserId();
        }

    }
}
