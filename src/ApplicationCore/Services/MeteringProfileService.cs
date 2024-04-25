using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class MeteringProfileService : IMeteringProfileService
    {
        private readonly IMeteringProfileRepository _repository;
        private readonly IMapper _mapper;
        public MeteringProfileService(IMeteringProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IReadOnlyCollection<MeteringProfile> Get()
        {
            return _repository.Get();
        }
        public MeteringProfile GetById(int id)
        {
            return _repository.GetById(id);
        }
        public async Task<MeteringProfile> Add(MeteringProfileDTO dto)
        {
            var meteringProfile = _mapper.Map<MeteringProfile>(dto);
            return await _repository.Add(meteringProfile);
        }
        public async Task<MeteringProfile> Update(MeteringProfileDTO dto)
        {
            var meteringProfile = _mapper.Map<MeteringProfile>(dto);
            return await _repository.Update(meteringProfile);
        }
    }
}
