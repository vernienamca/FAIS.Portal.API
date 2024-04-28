using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class ProjectComponentService : IProjectComponentService
    {
        private readonly IProjectComponentRepository _repository;
        private readonly IMapper _mapper;

        public ProjectComponentService(IProjectComponentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<ProjectComponent> Get() {
            return _repository.Get();
        }

        public List<ProjectComponent> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<ProjectComponent> Add(ProjectComponentDTO projectComponentDTO)
        {
            var projectComponent = _mapper.Map<ProjectComponent>(projectComponentDTO);

            return await _repository.Add(projectComponent);
        }

        //public async Task<ProjectComponent> Update(ProjectComponentDTO projectComponentDTO)
        //{
        //    var projectComponent = _mapper.Map<ProjectComponent>(projectComponentDTO);

        //    return await _repository.Update(projectComponent);
        //}
    }
}
