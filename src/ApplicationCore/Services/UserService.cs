using ApplicationCore.Enumeration;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ILibraryTypeRepository _ILibraryTypeRepository;
      

        public UserService(IUserRepository repository,ILibraryTypeRepository libraryTypeRepository)
        {
            _repository = repository;
            _ILibraryTypeRepository = libraryTypeRepository;
           
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

        public List<PermissionModel> GetPermissions(int id)
        {
            return _repository.GetPermissions(id);
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

            var positionId = await _ILibraryTypeRepository.GetPositionIdByName(userDTO.positionName);
            var divisionId = await _ILibraryTypeRepository.GetPositionIdByName(userDTO.divisionName);
            

            var user = new User()
            {
                FirstName = userDTO.FirstName,
                MiddleName = userDTO.MiddleName,
                LastName = userDTO.LastName,
                EmployeeNumber = userDTO.EmployeeNumber,
                UserName = userDTO.UserName,
                PositionId = positionId.Id,
                DivisionId  = divisionId.Id,
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
