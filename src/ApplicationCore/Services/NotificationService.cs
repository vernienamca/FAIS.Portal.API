﻿using ArrayToExcel;
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
        public IReadOnlyCollection<StringInterpolationModel> GetStringInterpolations()
        {
            return _repository.GetStringInterpolation();
        }
        public async Task<StringInterpolation> GetStringInterpolationById(int id)
        {
            return await _repository.GetStringInterpolationById(id);
        }
        public IReadOnlyCollection<TemplateModel> GetNotificationTemplates()
        {
            return _repository.GetNotificationTemplates();
        }
        public async Task<Template> GetTemplateById(int id)
        {
            return await _repository.GetTemplateById(id);
        }
    }
}
