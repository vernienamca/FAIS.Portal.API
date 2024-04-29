using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IProjectProfileRepository
    {
        IReadOnlyCollection<ProjectProfile> Get();
    }
}
