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

        public async Task<AssetProfile> Update(UpdateAssetProfileDTO dto)
        {
            var assetProfileDto = _mapper.Map<AssetProfile>(dto);
            var assetProfile = _repository.GetById(dto.Id) ?? throw new Exception("AssetProfileId does not exist");

            if (assetProfile == null)
                throw new ArgumentNullException("Asset Profile not exist.");

            var mapper = _mapper.Map<AssetProfile>(dto);
            mapper.CreatedBy = assetProfile.Result.CreatedBy;
            mapper.CreatedAt = assetProfile.Result.CreatedAt;
            return await _repository.Update(mapper);
        }
    }
}
