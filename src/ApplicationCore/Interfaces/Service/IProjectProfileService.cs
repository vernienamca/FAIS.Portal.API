using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IProjectProfileService
    {
        IReadOnlyCollection<ProjectProfileModel> Get();

        ProjectProfileModel GetById(int id);

        Task<ProjectProfile> Add(AddProjectProfileDTO projectProfileDTO);

        Task<ProjectProfile> Update(ProjectProfileDTO projectProfileDTO);
    }
}