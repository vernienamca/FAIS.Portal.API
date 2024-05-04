using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
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

            ////Check project profile details
            if (projectProfileComponents != null)
            {
                foreach (var component in projectProfileComponents)
                {
                    component.ProjectProfileId = projectProfileResult.Id;
                    await _componentsRepository.Add(component);
                }
            }
            return projectProfileResult;
        }

        public async Task<ProjectProfile> Update(ProjectProfileDTO projectProfileDTO)
        {
            var projectProfile = _mapper.Map<ProjectProfile>(projectProfileDTO);
            var projectProfileComponents = _mapper.Map<List<ProjectProfileComponent>>(projectProfileDTO.ProjectProfileComponentsDTO);

            var projectProfileResult = await _repository.Update(projectProfile);

            if (projectProfileResult != null)
            {
                var components = _componentsRepository.GetById(projectProfileResult.Id);
                if (components != null)
                {
                    if (components.Count > 0 && components.Count != projectProfileComponents.Count)
                    {
                        foreach (var component in components.Where(o => !projectProfileComponents.Select(a => a.Id).Contains(o.Id)))
                        {
                            if (component.RemoveAt == null)
                            {
                                component.RemoveAt = DateTime.Now;
                                await _componentsRepository.Update(component);
                            }
                        }
                    }
                }

                if (projectProfileComponents != null && projectProfileComponents.Count > 0)
                {
                    foreach (var item in projectProfileComponents)
                    {
                        if (item.Id > 0)
                        {
                            await _componentsRepository.Update(item);
                        }
                        else
                        {
                            item.ProjectProfileId = projectProfileResult.Id;
                            await _componentsRepository.Add(item);
                        }
                    }
                }
            }
            return projectProfileResult;
        }
    }
}