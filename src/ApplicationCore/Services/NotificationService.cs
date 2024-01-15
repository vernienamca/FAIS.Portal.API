using ArrayToExcel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
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
        public async Task<List<StringInterpolation>> GetStringInterpolation()
        {
            return await _repository.GetStringInterpolation();
        }

        public async Task<StringInterpolation> GetStringInterpolationById(decimal id)
        {
            return await _repository.GetStringInterpolationById(id);
        }

        public async Task<StringInterpolation> AddStringInterpolation(StringInterpolationDTO stringInterpolationDTO)
        {

            var stringInterpolation = new StringInterpolation()
            {
                TransactionCode = stringInterpolationDTO.TransactionCode,
                TransactionDescription = stringInterpolationDTO.TransactionDescription,
                NotificationType = stringInterpolationDTO.NotificationType,
                IsActive = stringInterpolationDTO.IsActive,
                StatusDate = stringInterpolationDTO.StatusDate,
                CreatedBy = stringInterpolationDTO.CreatedBy,
                CreatedAt = DateTime.Now,
                UpdatedBy = stringInterpolationDTO?.UpdatedBy,
                UpdatedAt = DateTime.Now
            };
            return await _repository.AddStringInterpolation(stringInterpolation);
        }

        public async Task<StringInterpolation> UpdateStringInterpolation(decimal id, StringInterpolationDTO stringInterpolationDTO)
        {
            var stringInterpolation = _repository.GetStringInterpolationById(id);

            //if (stringInterpolation != null)
            //{
            //    stringInterpolation.Id = id;
            //    if (!string.IsNullOrEmpty(stringInterpolationDTO.TransactionCode))
            //    {
            //        stringInterpolation.TransactionCode = stringInterpolationDTO.TransactionCode;
            //    }
            //    if (!string.IsNullOrEmpty(stringInterpolationDTO.TransactionDescription))
            //    {
            //        stringInterpolation.TransactionDescription = stringInterpolationDTO.TransactionDescription;
            //    }
            //    if (!string.IsNullOrEmpty(stringInterpolation.NotificationType))
            //    {
            //        stringInterpolation.NotificationType = stringInterpolationDTO.NotificationType;
            //    }

            //    if (stringInterpolation.IsActive != stringInterpolationDTO.IsActive)
            //    {
            //        stringInterpolation.IsActive = stringInterpolationDTO.IsActive;
            //        stringInterpolation.StatusDate = DateTime.Now;
            //    }

            //    stringInterpolation.UpdatedBy = stringInterpolationDTO.UpdatedBy;

            //    return await _repository.Update(stringInterpolation);
            //}
            return null;
        }
        #endregion

        #region ALERTS
        public async Task<List<Alerts>> GetAlerts()
        {
            return await _repository.GetAlerts();
        }

        public async Task<Alerts> GetAlertsById(decimal id)
        {
            return await _repository.GetAlertsById(id);
        }
        #endregion
    }
}
