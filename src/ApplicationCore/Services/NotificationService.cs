using ArrayToExcel;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public IQueryable<StringInterpolation> Get()
        {
            return _repository.Get();
        }

        public StringInterpolation GetById(decimal id)
        {
            return _repository.GetById(id);
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
            return await _repository.Add(stringInterpolation);
        }

        public async Task<StringInterpolation> UpdateStringInterpolation(decimal id, StringInterpolationDTO stringInterpolationDTO)
        {
            var stringInterpolation = _repository.GetById(id);

            if (stringInterpolation != null)
            {
                stringInterpolation.Id = id;
                if (!string.IsNullOrEmpty(stringInterpolationDTO.TransactionCode))
                {
                    stringInterpolation.TransactionCode = stringInterpolationDTO.TransactionCode;
                }
                if (!string.IsNullOrEmpty(stringInterpolationDTO.TransactionDescription))
                {
                    stringInterpolation.TransactionDescription = stringInterpolationDTO.TransactionDescription;
                }
                if (!string.IsNullOrEmpty(stringInterpolation.NotificationType))
                {
                    stringInterpolation.NotificationType = stringInterpolationDTO.NotificationType;
                }

                if (stringInterpolation.IsActive != stringInterpolationDTO.IsActive)
                {
                    stringInterpolation.IsActive = stringInterpolationDTO.IsActive;
                    stringInterpolation.StatusDate = DateTime.Now;
                }
               
                stringInterpolation.UpdatedBy = stringInterpolationDTO.UpdatedBy;

                return await _repository.Update(stringInterpolation);
            }
            return null;
        }
    }
}
