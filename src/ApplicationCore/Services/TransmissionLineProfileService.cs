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
    }
}
