using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IMeteringProfileService
    {
        IReadOnlyCollection<MeteringProfile> Get();

        MeteringProfile GetById(int id);

        Task<MeteringProfile> Add(MeteringProfileDTO dto);

        Task<MeteringProfile> Update(MeteringProfileDTO dto);

        IReadOnlyCollection<GenericDTO> GetRegions();

        IReadOnlyCollection<GenericDTO> GetProvices();

        IReadOnlyCollection<GenericDTO> GetMunicipality();

        IReadOnlyCollection<GenericDTO> GetBarangay();
    }
}