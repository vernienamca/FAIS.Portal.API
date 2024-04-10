
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IMeteringProfileService
    {
        IReadOnlyCollection<MeteringProfile> Get();
        Task<MeteringProfile> Add(MeteringProfileDTO dto);
        Task<MeteringProfile> Update(MeteringProfileDTO dto);
    }
}
