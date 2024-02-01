using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Interfaces.Services;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class CostCenterService : ICostCenterService
    {
        private readonly ICostCenterRepository _repository;
        private readonly IMapper _mapper;

        public CostCenterService(ICostCenterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CostCenter> Add(CostCenterDTO costCenterDTO)
        {
            var costCenter = _mapper.Map<CostCenter>(costCenterDTO);
            return await _repository.Add(costCenter);
        }

        public IReadOnlyCollection<CostCenterModel> Get()
        {
            return _repository.Get();
        }

        public CostCenter GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<CostCenter> Update(CostCenterDTO costCenterDTO)
        {
            var costCenter = _mapper.Map<CostCenter>(costCenterDTO);
            return await _repository.Update(costCenter);
        }
    }
}
