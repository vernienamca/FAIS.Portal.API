using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IProjectProfileRepository
    {
        IReadOnlyCollection<ProjectProfile> Get();
        ProjectProfile GetById(int id);
        Task<ProjectProfile> Add(ProjectProfile projectProfile);
        Task<ProjectProfile> Update(ProjectProfile projectProfile);
    }
}
