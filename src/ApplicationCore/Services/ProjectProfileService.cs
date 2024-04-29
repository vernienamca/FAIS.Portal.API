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
    public class ProjectProfileService : IProjectProfileService
    {
        private readonly IProjectProfileRepository _repository;
        private readonly IProjectProfileComponentsRepository _componentsRepository;
        private readonly IMapper _mapper;

        public ProjectProfileService(IProjectProfileRepository repository, IProjectProfileComponentsRepository componentsRepository, IMapper mapper)
        {
            _repository = repository;
            _componentsRepository = componentsRepository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<ProjectProfile> Get()
        {
            return _repository.Get();
        }

        public ProjectProfile GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<ProjectProfile> Add(ProjectProfileDTO projectProfileDTO)
        {
            var projectProfile = _mapper.Map<ProjectProfile>(projectProfileDTO);
            var projectProfileComponents = _mapper.Map<List<ProjectProfileComponent>>(projectProfileDTO.ProjectProfileComponentsDTO);

            var projectProfileResult = await _repository.Add(projectProfile);

            //Check proforma entry details
            if (projectProfileComponents != null)
            {
                foreach (var component in projectProfileComponents)
                {
                    component.ProjectProfileSeq = projectProfileResult.Id;
                    await _componentsRepository.Add(component);
                }
            }
            return projectProfileResult;
        }
    }
}