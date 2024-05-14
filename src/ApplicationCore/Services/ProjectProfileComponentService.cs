using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class ProjectProfileComponentService : IProjectProfileComponentService
    {
        private readonly IProjectProfileComponentsRepository _repository;
        private readonly IMapper _mapper;

        public ProjectProfileComponentService(IProjectProfileComponentsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<ProjectProfileComponent> Get()
        {
            return _repository.Get();
        }

        public List<ProjectProfileComponent> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<ProjectProfileComponent> Add(ProjectProfileComponentDTO projectProfileComponentDTO)
        {
            var projectProfileComponent = _mapper.Map<ProjectProfileComponent>(projectProfileComponentDTO);

            return await _repository.Add(projectProfileComponent);
        }
    }
}