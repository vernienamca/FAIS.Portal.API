using ApplicationCore.Enumeration;
using DocumentFormat.OpenXml.Wordprocessing;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILoginHistoryRepository _historyRepository;

        public UserService(IUserRepository userRepository
            , ILoginHistoryRepository historyRepository)
        {
            _userRepository = userRepository;
            _historyRepository = historyRepository;
        }

        public IQueryable<User> Get()
        {
            return _userRepository.Get();
        }

        public User GetById(decimal id)
        {
            return _userRepository.GetById(id);
        }

        public User GetByUserName(string userName)
        {
            return _userRepository.GetByUserName(userName);
        }

        public List<PermissionModel> GetPermissions(int id)
        {
            return _userRepository.GetPermissions(id);
        }

        public async Task<User> LockedAccount(UserDTO userDto)
        {
            var user = _userRepository.GetById(userDto.Id);

            user.StatusCode = (int)LoginEnum.UserStatus.Locked;

            return await _userRepository.LockedAccount(user);
        }

        public async Task<User> UpdateSignInAttempts(UserDTO userDto)
        {
            var user = _userRepository.GetById(userDto.Id);

            user.SignInAttempts = userDto.LoginStatus == (int)LoginEnum.LoginStatus.Success ? 0 : (user.SignInAttempts + 1);

            return await _userRepository.UpdateSignInAttempts(user);
        }

        public async Task<User> Add(UserDTO userDTO)
        {
            var user = new User()
            {
                FirstName = userDTO.FirstName,
                MiddleName = userDTO.MiddleName,
                LastName = userDTO.LastName,
                EmployeeNumber = userDTO.EmployeeNumber,
                UserName = userDTO.UserName,
                PositionId = userDTO.PositionId,
                DivisionId  = userDTO.DivisionId,
                Password = EncryptionHelper.HashPassword(userDTO.Password),
                EmailAddress = userDTO.EmailAddress,
                MobileNumber    = userDTO.MobileNumber,
                OupFgId= userDTO.OupFgId,
                Photo   = userDTO.Photo, 
                SessionId = userDTO.SessionId,
                SignInAttempts= userDTO.SignInAttempts,
                StatusCode  =  userDTO.StatusCode,
                StatusDate = userDTO.StatusDate,
                DateExpired  =  userDTO.DateExpired,
                CreatedBy = userDTO.CreatedBy,
                CreatedAt = DateTime.Now,
                UpdatedBy = userDTO?.UpdatedBy,
                UpdatedAt = DateTime.Now,
                TempKey = userDTO.TempKey,
            };

            return await _userRepository.Add(user);
        }

        public async Task<LoginHistory> AddLoginHistory(decimal userId, string username, bool isFailed)
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

        public async Task<User> Update(UserDTO userDto)
        {
            var user = _userRepository.GetById(userDto.Id);
            if (user == null)
            {
                return null;
            }


            user.FirstName = userDto.FirstName;
            user.MiddleName = userDto.MiddleName;
            user.LastName = userDto.LastName;
            //EmployeeNumber = userDTO.EmployeeNumber,
            //UserName = userDTO.UserName,
            //PositionId = userDTO.PositionId,
            //DivisionId = userDTO.DivisionId,
            //Password = EncryptionHelper.HashPassword(userDTO.Password),
            //EmailAddress = userDTO.EmailAddress,
            //MobileNumber = userDTO.MobileNumber,
            //OupFgId = userDTO.OupFgId,
            //Photo = userDTO.Photo, 
            //SessionId = userDTO.SessionId,
            //SignInAttempts = userDTO.SignInAttempts,
            //StatusCode = userDTO.StatusCode,
            //StatusDate = userDTO.StatusDate,
            //DateExpired = userDTO.DateExpired,
            //CreatedBy = userDTO.CreatedBy,
            //CreatedAt = DateTime.Now,
            //UpdatedBy = userDTO?.UpdatedBy,
            //UpdatedAt = DateTime.Now,
            //TempKey = userDTO.TempKey,

            return await _userRepository.Update(user);
        }
    }
}
