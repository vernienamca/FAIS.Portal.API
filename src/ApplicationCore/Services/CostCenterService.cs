using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Interfaces.Services;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class CostCenterService : ICostCenterService
    {
        private readonly ICostCenterRepository _repository;

        public CostCenterService(ICostCenterRepository repository) => _repository = repository;

        public async Task<CostCenter> Add(CostCenterDTO costCenterDTO)
        {
            var costCenter = new CostCenter()
            {
                Name = costCenterDTO.Name,
                FGCode = costCenterDTO.FGCode,
                Number = costCenterDTO.Number,
                ShortName = costCenterDTO.ShortName,
                CreatedBy = costCenterDTO.CreatedBy,
                CreatedAt = DateTime.Now
            };

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
            var costCenter = _repository.GetById(costCenterDTO.Id);

            costCenter.FGCode = costCenterDTO.FGCode;
            costCenter.Name = costCenterDTO.Name;
            costCenter.Number = costCenterDTO.Number;
            costCenter.ShortName = costCenterDTO.ShortName;

            //costCenter.UpdatedBy = costCenterDTO.UpdatedBy;
            //costCenter.UpdatedAt = DateTime.Now;

            return await _repository.Update(costCenter);
        }
    }
}
