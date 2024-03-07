using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Entities;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class TransLineProfileService : ITransLineProfileService
    {
        private readonly ITransLineProfileRepository _repository;
        private readonly IMapper _mapper;

        public TransLineProfileService(ITransLineProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TransLineProfile> Add(TransLineProfileDTO transLineProfileDTO)
        {
            var transLine = _mapper.Map<TransLineProfile>(transLineProfileDTO);
            return await _repository.Add(transLine);
        }

        public IReadOnlyCollection<TransLineProfileModel> Get()
        {
            return _repository.Get();
        }

        public TransLineProfile GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<TransLineProfile> Update(TransLineProfileDTO transLineProfileDTO)
        {
            var transLine = _mapper.Map<TransLineProfile>(transLineProfileDTO);
            return await _repository.Update(transLine);
        }
    }
}
