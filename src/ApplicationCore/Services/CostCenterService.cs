using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Interfaces.Services;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.Services
{
    public class CostCenterService : ICostCenterService
    {
        private readonly ICostCenterRepository _repository;

        public CostCenterService(ICostCenterRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyCollection<CostCenterModel> Get()
        {
            return _repository.Get();
        }

        public CostCenter GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
