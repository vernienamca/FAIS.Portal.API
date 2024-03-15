using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class AssetProfileService : IAssetProfileService
    {
        private readonly IAssetProfileRepository _repository;
        private readonly IMapper _mapper;

        public AssetProfileService(IAssetProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<AssetProfileModel> Get()
        {
            return _repository.Get();
        }

        public async Task<AssetProfileModel> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<AssetProfile> Add(AddAssetProfileDTO dto)
        {
            var assetProfileDto = _mapper.Map<AssetProfile>(dto);
            return await _repository.Add(assetProfileDto);
        }

        public async Task<AssetProfile> Update(AssetProfileDTO dto)
        {
            var assetProfileDto = _mapper.Map<AssetProfile>(dto);
            return await _repository.Update(assetProfileDto);
        }
    }
}
