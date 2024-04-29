using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IProjectProfileComponentService
    {
        IReadOnlyCollection<ProjectProfileComponent> Get();

        List<ProjectProfileComponent> GetById(int id);

        Task<ProjectProfileComponent> Add(ProjectProfileComponentDTO projectProfileComponentDTO);
    }
}