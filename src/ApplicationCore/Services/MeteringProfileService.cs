﻿using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class MeteringProfileService : IMeteringProfileService
    {
        private readonly IMeteringProfileRepository _repository;
        private readonly IMapper _mapper;

        public MeteringProfileService(IMeteringProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<MeteringProfileModel> Get()
        {
            return _repository.Get();
        }

        public MeteringProfileModel GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<MeteringProfile> Add(MeteringProfileDTO dto)
        {
            var meteringProfile = _mapper.Map<MeteringProfile>(dto);
            return await _repository.Add(meteringProfile);
        }

        public async Task<MeteringProfile> Update(MeteringProfileDTO dto)
        {
            var meteringProfile = _mapper.Map<MeteringProfile>(dto);

            meteringProfile.CreatedBy = dto.CreatedBy;
            meteringProfile.CreatedAt = dto.CreatedAt;

            return await _repository.Update(meteringProfile);
        }

        public IReadOnlyCollection<GenericDTO> GetRegions()
        {
            return _repository.GetRegions();
        }

        public IReadOnlyCollection<GenericDTO> GetProvices()
        {
            return _repository.GetProvices();
        }

        public IReadOnlyCollection<GenericDTO> GetMunicipality()
        {
            return _repository.GetMunicipality();
        }

        public IReadOnlyCollection<GenericDTO> GetBarangay()
        {
            return _repository.GetBarangay();
        }
    }
}