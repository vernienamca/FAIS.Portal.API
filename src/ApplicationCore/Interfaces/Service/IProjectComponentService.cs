using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IProjectComponentService
    {
        IReadOnlyCollection<ProjectComponent> Get();
        List<ProjectComponent> GetById(int id);
        Task<ProjectComponent> Add(ProjectComponentDTO projectComponentDTO);
        //Task<ProjectComponent> Update(ProjectComponentDTO projectComponentDTO);
    }
}
