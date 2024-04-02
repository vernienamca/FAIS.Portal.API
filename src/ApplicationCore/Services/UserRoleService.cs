using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
namespace FAIS.ApplicationCore.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _repository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
   
        public UserRoleService(IUserRoleRepository repository, IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _repository = repository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public IReadOnlyCollection<UserRoleModel> Get()
        {
            return _repository.Get();
        }

       public IReadOnlyCollection<string> GetUserEmailsByRole(int roleId)
        {
            return _repository.GetUserEmailsByRole(roleId);
        }
    }
}



