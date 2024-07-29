using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class BusinessProcessService : IBusinessProcessService
    {
        private readonly IBusinessProcessRepository _repository;
        private readonly IDepreciationMethodsRepository _depreciationRepository;
        private readonly IMapper _mapper;

        public BusinessProcessService(IBusinessProcessRepository repository
            , IDepreciationMethodsRepository depreciationRepository
            , IMapper mapper)
        {
            _repository = repository;
            _depreciationRepository = depreciationRepository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<BusinessProcessModel> Get()
        {
            return _repository.Get();
        }

        public async Task<BusinessProcessModel> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<BusinessProcess> Add(BusinessProcessDTO dto)
        {
            var businessProcessDto = _mapper.Map<BusinessProcess>(dto);

            return await _repository.Add(businessProcessDto);
        }

        public async Task<BusinessProcess> Update(BusinessProcessDTO dto)
        {
            try
            {
                var businessProcess = _repository.GetById(dto.Id) ?? throw new Exception("Business Process Id does not exist");

                if (businessProcess.Result == null)
                    throw new ArgumentNullException("Business Process not exist.");

                dto.UpdatedAt = DateTime.Now;
                if (businessProcess.Result.IsActive != dto.IsActive)
                {
                    if(_depreciationRepository.GetByBusinessProcessId(dto.Id).Result != null)
                        throw new ArgumentException("Business Process is in use by Define Methods.");
                    dto.StatusDate = DateTime.Now;
                }
                var mapper = _mapper.Map<BusinessProcess>(dto);
                mapper.CreatedBy = businessProcess.Result.CreatedBy;
                mapper.CreatedAt = businessProcess.Result.CreatedAt;
                return await _repository.Update(mapper);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
