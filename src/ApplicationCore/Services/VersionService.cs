using AutoMapper;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Spreadsheet;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class VersionService : IVersionService
    {
        private readonly IVersionsRepository _repository;

        public VersionService(IVersionsRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyCollection<VersionModel> Get()
        {
            return _repository.Get();
        }

        public async Task<Versions> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Versions> Add(AddVersionDTO versionDTO)
        {
            var version = new Versions()
            {
                VersionNo = versionDTO.VersionNo,
                VersionDate = DateTime.Now,
                Amendment = versionDTO.Amendment,
                CreatedBy = versionDTO.CreatedBy,
                CreatedAt = DateTime.Now
            };

            return await _repository.Add(version);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

    }
}
