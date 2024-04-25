using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IProjectProfileService
    {
        IReadOnlyCollection<ProjectProfile> Get();
    }
}
