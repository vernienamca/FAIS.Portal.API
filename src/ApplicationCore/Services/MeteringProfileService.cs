using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAIS.ApplicationCore.Services
{
    public class MeteringProfileService : IMeteringProfileService
    {
        private readonly IMeteringProfileRepository _repository;

        public MeteringProfileService(IMeteringProfileRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyCollection<MeteringProfile> Get()
        {
            return _repository.Get();
        }
    }
}
