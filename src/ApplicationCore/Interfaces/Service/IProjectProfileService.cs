using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IProjectProfileService
    {
        IReadOnlyCollection<ProjectProfile> Get();

        ProjectProfile GetById(int id);

        Task<ProjectProfile> Add(ProjectProfileDTO projectProfileDTO);
        //Task<ProformaEntry> Update(ProformaEntryDTO proformaEntryDTO);
    }
}