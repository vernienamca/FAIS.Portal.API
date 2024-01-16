using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _repository;

        public ModuleService(IModuleRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyCollection<ModuleModel> Get()
        {
            return _repository.Get();
        }

        public Module GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<Module> Add(ModuleDTO moduleDto)
        {
            var module = new Module()
            {
                Name = moduleDto.Name,
                Description = moduleDto.Description,
                Url = moduleDto.Url,
                IsActive = moduleDto.IsActive,
                StatusDate = moduleDto.StatusDate,
                CreatedBy = moduleDto.CreatedBy,
                CreatedAt = DateTime.Now
            };

            return await _repository.Add(module);
        }

        public async Task<Module> Update(int id)
        {
            var module = _repository.GetById(id);

            module.UpdatedAt = DateTime.Now;

            return await _repository.Update(module);
        }
    }
}
