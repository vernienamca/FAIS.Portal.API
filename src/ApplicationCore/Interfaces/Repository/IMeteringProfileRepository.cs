using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IMeteringProfileRepository
    {
        IReadOnlyCollection<MeteringProfile> Get();
        MeteringProfile GetById(int id);
        Task<MeteringProfile> Add(MeteringProfile meteringType);
        Task<MeteringProfile> Update(MeteringProfile meteringType);
    }
}
