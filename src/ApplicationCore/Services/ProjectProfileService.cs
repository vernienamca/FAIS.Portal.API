using AutoMapper;
using FAIS.ApplicationCore.BusinessRules;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
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
        private readonly IProjectComponentRepository _componentRepository;
        private readonly IMapper _mapper;

        public ProjectProfileService(IProjectProfileRepository repository, IProjectComponentRepository componentRepository, IMapper mapper)
        {
            _repository = repository;
            _componentRepository = componentRepository;
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
            projectProfile.ProjectComponentsDTO = null;
            var projectComponents = _mapper.Map<List<ProjectComponent>>(projectProfileDTO.ProjectComponentsDTO);

            var projectProfileResult = await _repository.Add(projectProfile);

            //Check project profile components
            if (projectComponents != null)
            {
                foreach (var component in projectComponents)
                {
                    component.ProjectSeq = projectProfileResult.Id;
                    await _componentRepository.Add(component);
                }
            }
            return projectProfileResult;
        }

        public async Task<ProjectProfile> Update(ProjectProfileDTO projectProfileDTO)
        {
            var projectProfile = _mapper.Map<ProjectProfile>(projectProfileDTO);
            var projectComponents = _mapper.Map<List<ProjectComponent>>(projectProfileDTO.ProjectComponentsDTO);


            var projectProfileResult = await _repository.Update(projectProfile);

            if (projectProfileResult != null)
            {
                var components = _componentRepository.GetById(projectProfile.Id);
                if (components != null)
                {
                    if (components.Count > 0 && components.Count != projectComponents.Count)
                    {
                        foreach (var component in components.Where(o => !projectComponents.Select(a => a.Id).Contains(o.Id)))
                        {
                            if (component.DeletedAt == null)
                            {
                                component.DeletedAt = DateTime.Now;
                                await _componentRepository.Update(component);
                            }
                        }
                    }
                }

                if (projectComponents != null && projectComponents.Count > 0)
                {
                    foreach (var item in projectComponents)
                    {
                        if (item.Id > 0)
                        {
                            await _componentRepository.Update(item);
                        }
                        else
                        {
                            item.ProjectSeq = projectProfileResult.Id;
                            await _componentRepository.Add(item);
                        }
                    }
                }
            }
            return projectProfileResult;
        }
    }
}
