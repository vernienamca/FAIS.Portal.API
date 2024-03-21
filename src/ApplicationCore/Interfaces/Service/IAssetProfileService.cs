using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IAssetProfileService
    {
        IReadOnlyCollection<AssetProfileModel> Get();
        Task<AssetProfileModel> GetById(int id);
        Task<AssetProfile> Add(AddAssetProfileDTO assetProfileDTO);
        Task<AssetProfile> Update(AssetProfileDTO assetProfile);
    }
}
