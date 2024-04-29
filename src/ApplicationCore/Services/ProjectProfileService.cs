using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.Services
{
    public class ProjectProfileService : IProjectProfileService
    {
        private readonly IProjectProfileRepository _repository;
        public ProjectProfileService(IProjectProfileRepository repository)
        {
            _repository = repository;
        }
        public IReadOnlyCollection<ProjectProfile> Get()
        {
            return _repository.Get();
        }
    }
}
