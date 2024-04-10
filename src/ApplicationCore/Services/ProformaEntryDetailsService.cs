using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class ProformaEntryDetailsService : IProformaEntryDetailsService
    {
        private readonly IProformaEntryDetailsRepository _repository;
        private readonly IMapper _mapper;

        public ProformaEntryDetailsService(IProformaEntryDetailsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<ProformaEntryDetail> Get() {
            return _repository.Get();
        }

        public List<ProformaEntryDetail> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<ProformaEntryDetail> Add(ProformaEntryDetailDTO proformaEntriesDTO)
        {
            var proformaEntries = _mapper.Map<ProformaEntryDetail>(proformaEntriesDTO);

            return await _repository.Add(proformaEntries);
        }

        //public async Task<ProformaEntryDetail> Update(UpdateProformaEntriesDTO proformaEntriesDTO)
        //{
        //    var proformaEntries = _mapper.Map<ProformaEntryDetail>(proformaEntriesDTO);
            
        //    return await _repository.Update(proformaEntries);
        //}
    }
}
