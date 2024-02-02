using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class ProformaEntriesService : IProformaEntriesService
    {
        private readonly IProformaEntriesRepository _repository;
        private readonly IMapper _mapper;

        public ProformaEntriesService(IProformaEntriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<ProformaEntries> Get() {
            return _repository.Get();
        }

        public ProformaEntries GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<ProformaEntries> Add(ProformaEntriesDTO proformaEntriesDTO)
        {
            var proformaEntries = _mapper.Map<ProformaEntries>(proformaEntriesDTO);

            return await _repository.Add(proformaEntries);
        }

        public async Task<ProformaEntries> Update(UpdateProformaEntriesDTO proformaEntriesDTO)
        {
            var proformaEntries = _mapper.Map<ProformaEntries>(proformaEntriesDTO);
            
            return await _repository.Update(proformaEntries);
        }
    }
}
