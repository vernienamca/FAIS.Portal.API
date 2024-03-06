using FAIS.ApplicationCore.Entities;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface ITransLineProfileRepository
    {
        IReadOnlyCollection<TransLineProfileModel> Get();
        TransLineProfile GetById(int id);
        Task<TransLineProfile> Add(TransLineProfile transLineProfile);
        Task<TransLineProfile> Update(TransLineProfile transLineProfile);
    }
}
