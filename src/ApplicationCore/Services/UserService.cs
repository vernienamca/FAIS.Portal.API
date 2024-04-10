using DocumentFormat.OpenXml.Spreadsheet;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Enumeration;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ApplicationCore.Enumeration.LoginEnum;
using Password.Core;

namespace FAIS.ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILoginHistoryRepository _historyRepository;
        private readonly ISettingsRepository _settingsRepository;
        private readonly ILibraryTypeRepository _ILibraryTypeRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public UserService(IUserRepository testRepository
            , ISettingsRepository settingsRepository
            , ILoginHistoryRepository historyRepository
            , ILibraryTypeRepository iLibraryTypeRepository,
            IUserRoleRepository userRoleRepository)
        {
            _userRepository = testRepository;
            _settingsRepository = settingsRepository;
            _historyRepository = historyRepository;
            _ILibraryTypeRepository = iLibraryTypeRepository;
            _userRoleRepository = userRoleRepository;
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

        public async Task<List<UserRoleModel>> GetUserRoles(int userId)
        {
            return await _userRepository.GetUserRoles(userId);
        }

        public string GeneratePassword()
        {
            var settings = _settingsRepository.GetById(1);
            var passwordGenerator = PasswordGeneratorFactory.GetGenerator();

            string password = passwordGenerator.Generate(new Password.Core.PasswordOptions
            {
                Length = settings.MinPasswordLength,
                IncludeLowerCaseLetters = true,
                IncludeUpperCaseLetters = true,
                IncludeDigits = false,
                IncludeSymbols = false
            });

            return password;
        }

        public async Task<User> Add(UserDTO userDTO)
        {
            var settings = _settingsRepository.GetById(1);

            var user = new User()
            {
                FirstName = userDTO.FirstName,
                MiddleName = userDTO.MiddleName,
                LastName = userDTO.LastName,
                EmployeeNumber = userDTO.EmployeeNumber,
                UserName = userDTO.UserName,
                PositionId = int.Parse(userDTO.Position),
                Password = userDTO.Password,
                EmailAddress = userDTO.EmailAddress,
                MobileNumber = userDTO.MobileNumber,
                Photo = userDTO.Photo,
                SessionId = userDTO.SessionId,
                SignInAttempts = userDTO.SignInAttempts,
                StatusCode = int.Parse(userDTO.AccountStatus),
                StatusDate = DateTime.Now,
                DateExpired = DateTime.Now.AddDays(settings.PasswordExpiry),
                CreatedBy = userDTO.CreatedBy,
                CreatedAt = DateTime.Now,
                TempKey = userDTO.TempKey,
            };

            if (!string.IsNullOrEmpty(userDTO.OupFG))
                user.OupFgId = int.Parse(userDTO.OupFG);

            if (!string.IsNullOrEmpty(userDTO.Division))
                user.DivisionId = int.Parse(userDTO.Division);

            return await _userRepository.Add(user);
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

        public void SetUserRoles(int userId, IReadOnlyCollection<UserRoleDTO> userRoles)
        {
            _userRepository.SetUserRoles(userId, userRoles);
        }

        public void SetTAFGs(int userId, IReadOnlyCollection<string> userTAFGs)
        {
            _userRepository.SetTAFGs(userId, userTAFGs);
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
