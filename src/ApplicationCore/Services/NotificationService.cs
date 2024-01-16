using ArrayToExcel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;

        public NotificationService(INotificationRepository repository)
        {
            _repository = repository;
        }

        #region STRING_INTERPOLATION
        public async Task<List<StringInterpolationModel>> GetStringInterpolations()
        {
            

            return await _repository.GetStringInterpolation();
        }

        public async Task<StringInterpolation> GetStringInterpolationById(int id)
        {
            return await _repository.GetStringInterpolationById(id);
        }

        #endregion

        #region TEMPLATES
        public async Task<List<TemplateModel>> GetTemplates()
        {
            return await _repository.GetTemplates();
        }

        public async Task<Template> GetTemplateById(int id)
        {
            return await _repository.GetTemplateById(id);
        }
        #endregion
    }
}
