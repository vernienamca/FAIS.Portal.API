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
        private readonly INotificationRepository _repository;
        private readonly IMapper _mapper;

        public NotificationService(INotificationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<StringInterpolationModel> GetIntepolations()
        {
            return _repository.GetIntepolations();
        }

        public IReadOnlyCollection<TemplateModel> GetNotificationTemplates()
        {
            return _repository.GetNotificationTemplates();
        }

        public async Task<Template> GetTemplateById(int id)
        {
            return await _repository.GetTemplateById(id);
        }

        public async Task<StringInterpolation> GetInterpolationById(int id)
        {
            return await _repository.GetInterpolationById(id);
        }

        public async Task<StringInterpolation> AddStringInterpolation(AddStringInterpolationDTO dto)
        {
            var interpolationDto = _mapper.Map<StringInterpolation>(dto);
            return await _repository.AddStringInterpolation(interpolationDto);
        }

        public async Task<StringInterpolation> UpdateStringInterpolation(StringInterpolationDTO dto)
        {
            var interpolationDto = _mapper.Map<StringInterpolation>(dto);
            return await _repository.UpdateStringInterpolation(interpolationDto);
        }
    }
}
