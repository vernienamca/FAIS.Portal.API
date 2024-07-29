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
    public class StepContainerService : IStepContainerService
    {
        private readonly IStepContatinerRepository _repository;
        private readonly IMapper _mapper;

        public StepContainerService(IStepContatinerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<StepContainerModel> Get()
        {
            return _repository.Get();
        }

        public async Task<StepContainerModel> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<StepContainer> Add(StepContainerDTO dto)
        {
            try
            {
                var mapper = _mapper.Map<StepContainer>(dto);
                return await _repository.Add(mapper);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StepContainer> Update(StepContainerDTO dto)
        {
            try
            {
                var stepContainer = _repository.GetById(dto.Id) ?? throw new Exception("Step Container Id does not exist");

                if (stepContainer.Result == null)
                    throw new ArgumentNullException("Step Container not exist.");

                var mapper = _mapper.Map<StepContainer>(dto);
                mapper.CreatedBy = stepContainer.Result.CreatedBy;
                mapper.CreatedAt = stepContainer.Result.CreatedAt;
                return await _repository.Update(mapper);
            }
            catch (Exception ex) 
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
