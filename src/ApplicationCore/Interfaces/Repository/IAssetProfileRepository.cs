using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IAssetProfileRepository
    {
        IReadOnlyCollection<AssetProfileModel> Get();
    }
}
