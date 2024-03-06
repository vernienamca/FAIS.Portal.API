using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IAssetProfileService
    {
        IReadOnlyCollection<AssetProfileModel> Get();
    }
}
