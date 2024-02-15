using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IStringInterpolationRepository _interpolationRepository;
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;

        public NotificationService(IStringInterpolationRepository interpolationRepository, ITemplateRepository templateRepository, IMapper mapper)
        {
            _interpolationRepository = interpolationRepository;
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<StringInterpolationModel> GetIntepolations()
        {
            return _interpolationRepository.Get();
        }

        public IReadOnlyCollection<TemplateModel> GetNotificationTemplates()
        {
            return _templateRepository.Get();
        }

        public async Task<Template> GetTemplateById(int id)
        {
            return await _templateRepository.GetById(id);
        }

        public async Task<StringInterpolation> GetInterpolationById(int id)
        {
            return await _interpolationRepository.GetById(id);
        }

        public async Task<StringInterpolation> AddStringInterpolation(AddStringInterpolationDTO dto)
        {
            var interpolationDto = _mapper.Map<StringInterpolation>(dto);
            return await _interpolationRepository.Add(interpolationDto);
        }

        public async Task<StringInterpolation> UpdateStringInterpolation(StringInterpolationDTO dto)
        {
            var interpolationDto = _mapper.Map<StringInterpolation>(dto);
            return await _interpolationRepository.Update(interpolationDto);
        }

        public async Task<Template> AddTemplate(AddTemplateDto dto)
        {
            var templateDto = _mapper.Map<Template>(dto);
            return await _templateRepository.Add(templateDto);
        }

        public async Task<Template> UpdateTemplate(TemplateDto dto)
        {
            var templateDto = _mapper.Map<Template>(dto);
            return await _templateRepository.Update(templateDto);
        }
    }
}
