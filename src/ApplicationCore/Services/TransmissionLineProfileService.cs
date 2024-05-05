using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class TransmissionLineProfileService : ITransmissionLineProfileService
    {
        private readonly ITransmissionLineProfileRepository _repository;
        private readonly IMapper _mapper;

        public TransmissionLineProfileService(ITransmissionLineProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<TransmissionLineProfileModel> Get()
        {
            return _repository.Get();
        }

        public async Task<TransmissionLineProfileModel> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<TransmissionLineProfile> Add(AddTransmissionLineProfileDTO dto)
        {
            var transDto = _mapper.Map<TransmissionLineProfile>(dto);
            return await _repository.Add(transDto);
        }

        public async Task<TransmissionLineProfile> Update(UpdateTransmissionLineProfileDTO dto)
        {
            var transProfile = _repository.GetById(dto.Id) ?? throw new Exception("Transmission Line Profile Id does not exist");

            if (transProfile == null)
                throw new ArgumentNullException("Transmission Line Profile not exist.");

            var mapper = _mapper.Map<TransmissionLineProfile>(dto);
            mapper.CreatedBy = transProfile.Result.CreatedBy;
            mapper.CreatedAt = transProfile.Result.CreatedAt;
            return await _repository.Update(mapper);
        }
    }
}
