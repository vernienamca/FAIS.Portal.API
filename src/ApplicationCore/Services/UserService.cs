using ApplicationCore.Enumeration;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<User> Get()
        {
            return _repository.Get();
        }

        public User GetById(decimal id)
        {
            return _repository.GetById(id);
        }

        public User GetByUserName(string userName)
        {
            return _repository.GetByUserName(userName);
        }

        public async Task<User> LockedAccount(UserDTO userDto)
        {
            var user = _repository.GetById(userDto.Id);

            user.StatusCode = (int)LoginEnum.UserStatus.Locked;

            return await _repository.LockedAccount(user);
        }

        public async Task<User> UpdateSignInAttempts(UserDTO userDto)
        {
            var user = _repository.GetById(userDto.Id);

            user.SignInAttempts = userDto.LoginStatus == (int)LoginEnum.LoginStatus.Success ? 0 : (user.SignInAttempts + 1);

            return await _repository.UpdateSignInAttempts(user);
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

            return await _repository.Add(user);
        }


    }
}
