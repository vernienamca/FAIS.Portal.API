using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IReadOnlyCollection<ProjectProfileModel> Get()
        {
            return _repository.Get();
        }

        public ProjectProfileModel GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<ProjectProfile> Add(AddProjectProfileDTO projectProfileDTO)
        {
            try
            {
                var projectProfile = _mapper.Map<ProjectProfile>(projectProfileDTO);
                var projectProfileComponents = _mapper.Map<List<ProjectProfileComponent>>(projectProfileDTO.ProjectProfileComponentsDTO);

                var projectProfileResult = await _repository.Add(projectProfile);

                if (projectProfileDTO.ProjectProfileComponentsDTO != null && projectProfileDTO.ProjectProfileComponentsDTO.Any())
                {
                    foreach (var component in projectProfileDTO.ProjectProfileComponentsDTO)
                    {
                        await _componentsRepository.Add(new ProjectProfileComponent { 
                            ProjectProfileId = projectProfileResult.Id,
                            ComponentName = component.ComponentName,
                            Details = component.Details,
                            ProjectStageSeq = component.ProjectStageSeq,
                            TransmissionGridSeq = component.TransmissionGridSeq,
                            StartDate = component.StartDate,
                            TargetDate = component.TargetDate,
                            CompletionDate = component.CompletionDate,
                            InspectionDate = component.InspectionDate,
                            InitialAMRMonth = component.InitialAMRMonth,
                            CreatedBy = projectProfile.CreatedBy,
                            CreatedAt = DateTime.Now,

                        });
                    }
                }
                return projectProfileResult;
            }
            catch (Exception)
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<ProjectProfile> Update(ProjectProfileDTO projectProfileDTO)
        {
            try
            {
                var projectProfile = _repository.GetById(projectProfileDTO.Id) ?? throw new Exception("Project Profile Id does not exist");

                if (projectProfile == null)
                    throw new ArgumentNullException("Project Profile not exist.");

                if (projectProfile.IsActive != projectProfileDTO.IsActive)
                    projectProfileDTO.StatusDate = DateTime.Now;
                                
                var mapper = _mapper.Map<ProjectProfile>(projectProfileDTO);
                var projectProfileComponents = _mapper.Map<List<ProjectProfileComponent>>(projectProfileDTO.ProjectProfileComponentsDTO);

                var result = await _repository.Update(mapper);

                if (projectProfileDTO.ProjectProfileComponentsDTO != null && projectProfileDTO.ProjectProfileComponentsDTO.Any())
                {
                    int[] componentUniqueIds = projectProfileDTO.ProjectProfileComponentsDTO.Select(s => s.Id ?? 0).ToArray();
                    var detailsToRemove = _componentsRepository.GetById(projectProfileDTO.Id).Where(t => !componentUniqueIds.Any(a => t.Id == a));

                    foreach (var item in detailsToRemove)
                    {
                        var component = await _componentsRepository.GetDetails(item.Id);

                        component.RemoveAt = DateTime.Now;
                        await _componentsRepository.Update(component);
                    }

                    foreach (var item in projectProfileDTO.ProjectProfileComponentsDTO)
                    {
                        if (item.Id.HasValue)
                        {
                            var component = await _componentsRepository.GetDetails(item.Id.Value);

                            if (component.ComponentName != item.ComponentName || component.ProjectStageSeq != item.ProjectStageSeq || component.TransmissionGridSeq != item.TransmissionGridSeq)
                            {
                                component.ComponentName = item.ComponentName;
                                component.Details = item.Details;
                                component.ProjectStageSeq = item.ProjectStageSeq;
                                component.TransmissionGridSeq = item.TransmissionGridSeq;
                                component.StartDate = item.StartDate;
                                component.TargetDate = item.TargetDate;
                                component.CompletionDate = item.CompletionDate;

                                component.UpdatedBy = result.UpdatedBy;
                                component.UpdatedAt = DateTime.Now;
                                await _componentsRepository.Update(component);
                            }
                        }
                        else
                        {
                            await _componentsRepository.Add(new ProjectProfileComponent
                            {
                                ProjectProfileId = projectProfileDTO.Id,
                                ComponentName = item.ComponentName,
                                Details = item.Details,
                                ProjectStageSeq = item.ProjectStageSeq,
                                TransmissionGridSeq = item.TransmissionGridSeq,
                                StartDate = item.StartDate,
                                TargetDate = item.TargetDate,
                                CompletionDate = item.CompletionDate,
                                CreatedAt = DateTime.Now,
                                CreatedBy = (int)projectProfileDTO.UpdatedBy
                            });
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw new ArgumentNullException();
            }
        }
    }
}