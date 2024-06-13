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
    public class AmrService : IAmrService
    {
        private readonly IAmrRepository _repository;
        private readonly IMapper _mapper;

        public AmrService(IAmrRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<AmrModel> Get()
        {
            return _repository.Get();
        }

        public async Task<AmrModel> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Amr> Add(AddAmrDTO dto)
        {
            var amrDto = _mapper.Map<Amr>(dto);
            return await _repository.Add(amrDto);
        }

        public async Task<Amr> Update(UpdateAmrDTO dto)
        {
            var amr = _repository.GetById(dto.Id) ?? throw new Exception("Amr Id does not exist");

            if (amr == null)
                throw new ArgumentNullException("Amr not exist.");

            var mapper = _mapper.Map<Amr>(dto);
            mapper.CreatedBy = amr.Result.CreatedBy;
            mapper.CreatedAt = amr.Result.CreatedAt;
            return await _repository.Update(mapper);
        }
    }
}
