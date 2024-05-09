using AutoMapper;
using DocumentFormat.OpenXml.Wordprocessing;
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

        public async Task<TemplateModel> GetTemplateById(int id)
        {
            return await _templateRepository.GetById(id);
        }

        public async Task<StringInterpolation> GetInterpolationById(int id)
        {
            return await _interpolationRepository.GetById(id);
        }

        public async Task<StringInterpolation> AddInterpolation(AddStringInterpolationDTO dto)
        {
            var stringInterpolationDto = _mapper.Map<StringInterpolation>(dto);
            return await _interpolationRepository.Add(stringInterpolationDto);
        }

        public async Task<Template> AddTemplate(AddTemplateDTO dto)
        {
            var template = _mapper.Map<Template>(dto);
            return await _templateRepository.Add(template);
        }

        public async Task<StringInterpolation> UpdateStringInterpolation(UpdateStringInterpolationDTO dto)
        {
            var stringInterpolation = _interpolationRepository.GetById(dto.Id) ?? throw new Exception("StringInterpolationId does not exist");

            if (stringInterpolation == null)
                throw new ArgumentNullException("String Interpolation not exist.");

            var mapper = _mapper.Map<StringInterpolation>(dto);
            mapper.CreatedBy = stringInterpolation.Result.CreatedBy;
            mapper.CreatedAt = stringInterpolation.Result.CreatedAt;
            return await _interpolationRepository.Update(mapper);
        }

        public async Task<StringInterpolation> DeleteStringInterpolation(int id)
        {
            var stringInterpolation = _interpolationRepository.GetById(id) ?? throw new Exception("StringInterpolationId does not exist");

            if (stringInterpolation == null)
                throw new ArgumentNullException("String Interpolation not exist.");

            stringInterpolation.Result.DateRemoved = DateTime.Now;
            return await _interpolationRepository.Update(stringInterpolation.Result);
        }

        public async Task<Template> UpdateTemplate(UpdateTemplateDTO dto)
        {
            var template = _templateRepository.GetById(dto.Id) ?? throw new Exception("NotificationTemplateId does not exist");

            if (template == null)
                throw new ArgumentNullException("Notification Template not exist.");

            var mapper = _mapper.Map<Template>(dto);
            mapper.CreatedBy = template.Result.CreatedBy;
            mapper.CreatedAt = template.Result.CreatedAt;
            return await _templateRepository.Update(mapper);
        }
    }
}
