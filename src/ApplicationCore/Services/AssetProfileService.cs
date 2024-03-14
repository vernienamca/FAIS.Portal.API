using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAIS.ApplicationCore.Services
{
    public class AssetProfileService : IAssetProfileService
    {
        private readonly IAssetProfileRepository _repository;

        public AssetProfileService(IAssetProfileRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyCollection<AssetProfileModel> Get()
        {
            return _repository.Get();
        }
    }
}
