using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ApplicationCore.Enumeration.LoginEnum;

namespace FAIS.ApplicationCore.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyCollection<RoleModel> Get()
        {
            return _repository.Get();
        }

        public Role GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<Role> Add(RoleDTO roleDto)
        {
            try
            {
                var role = new Role()
                {
                    Name = roleDto.Name,
                    Description = roleDto.Description,
                    IsActive = roleDto.IsActive,
                    StatusDate = DateTime.Now,
                    CreatedBy = roleDto.CreatedBy,
                    CreatedAt = DateTime.Now
                };

                return await _repository.Add(role);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Role> Update(int id)
        {
            var role = _repository.GetById(id);
            
            role.UpdatedAt = DateTime.Now;

            return await _repository.Update(role);
        }

        public List<Role> GetUserRolesById(int userId)
        {
            return _repository.GetUserRolesById(userId);
        }
    }
}
