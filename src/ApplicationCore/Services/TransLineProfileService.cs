using FAIS.ApplicationCore.Entities;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.Services
{
    public class TransLineProfileService : ITransLineProfileService
    {
        private readonly ITransLineProfileRepository _repository;

        public TransLineProfileService(ITransLineProfileRepository repository) => _repository = repository;

        public IReadOnlyCollection<TransLineProfileModel> Get()
        {
            return _repository.Get();
        }

        public TransLineProfile GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
