using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IProjectProfileRepository
    {
        IReadOnlyCollection<ProjectProfileModel> Get();

        ProjectProfileModel GetById(int id);

        Task<ProjectProfile> Add(ProjectProfile projectProfile);

        Task<ProjectProfile> Update(ProjectProfile projectProfile);
    }
}