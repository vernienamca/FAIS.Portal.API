using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IStringInterpolationRepository
    {
        IReadOnlyCollection<StringInterpolationModel> Get();
        Task<StringInterpolation> GetById(int id);
        Task<StringInterpolation> Add(StringInterpolation interpolation);
        Task<StringInterpolation> Update(StringInterpolation interpolation);

    }
}
