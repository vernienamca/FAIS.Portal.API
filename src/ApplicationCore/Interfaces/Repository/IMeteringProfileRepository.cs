using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IMeteringProfileRepository
    {
        IReadOnlyCollection<MeteringProfileModel> Get();

        MeteringProfileModel GetById(int id);

        Task<MeteringProfile> Add(MeteringProfile meteringType);

        Task<MeteringProfile> Update(MeteringProfile meteringType);

        IReadOnlyCollection<GenericDTO> GetRegions();

        IReadOnlyCollection<GenericDTO> GetProvices();

        IReadOnlyCollection<GenericDTO> GetMunicipality();

        IReadOnlyCollection<GenericDTO> GetBarangay();
    }
}