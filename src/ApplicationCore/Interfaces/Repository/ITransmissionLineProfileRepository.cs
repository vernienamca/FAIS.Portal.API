using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface ITransmissionLineProfileRepository
    {
        IReadOnlyCollection<TransmissionLineProfileModel> Get();
        Task<TransmissionLineProfileModel> GetById(int id);
        Task<TransmissionLineProfile> Add(TransmissionLineProfile transProfile);
        Task<TransmissionLineProfile> Update(TransmissionLineProfile transProfile);
    }
}
