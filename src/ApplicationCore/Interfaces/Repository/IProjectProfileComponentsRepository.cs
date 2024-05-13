using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IProjectProfileComponentsRepository
    {
        IReadOnlyCollection<ProjectProfileComponent> Get();

        List<ProjectProfileComponent> GetById(int id);

        Task<ProjectProfileComponent> Add(ProjectProfileComponent projectProfileComponent);

        Task<ProjectProfileComponent> Update(ProjectProfileComponent projectProfileComponent);
    }
}