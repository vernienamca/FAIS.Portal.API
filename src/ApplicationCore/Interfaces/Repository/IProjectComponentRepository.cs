using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IProjectComponentRepository
    {
        IReadOnlyCollection<ProjectComponent> Get();
        List<ProjectComponent> GetById(int id);
        Task<ProjectComponent> Add(ProjectComponent projectComponent);
        Task<ProjectComponent> Update(ProjectComponent projectComponent);
    }
}
