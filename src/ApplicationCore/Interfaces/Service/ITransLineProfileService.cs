using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface ITransLineProfileService
    {
        IReadOnlyCollection<TransLineProfileModel> Get();
        TransLineProfile GetById(int id);
        Task<TransLineProfile> Add(TransLineProfileDTO transLineProfileDTO);
        Task<TransLineProfile> Update(TransLineProfileDTO transLineProfileDTO);
    }
}
