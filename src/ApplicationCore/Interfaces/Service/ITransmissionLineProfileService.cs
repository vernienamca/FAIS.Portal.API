using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface ITransmissionLineProfileService
    {
        IReadOnlyCollection<TransmissionLineProfileModel> Get();
        Task<TransmissionLineProfileModel> GetById(int id);
        Task<TransmissionLineProfile> Add(AddTransmissionLineProfileDTO transProfileDto);
        Task<TransmissionLineProfile> Update(UpdateTransmissionLineProfileDTO transProfileDto);
    }
}
