using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IAssetProfileRepository
    {
        IReadOnlyCollection<AssetProfileModel> Get();
        Task<AssetProfileModel> GetById(int id);
        Task<AssetProfile> Add(AssetProfile assetProfile);
        Task<AssetProfile> Update(AssetProfile assetProfile);
    }
}
