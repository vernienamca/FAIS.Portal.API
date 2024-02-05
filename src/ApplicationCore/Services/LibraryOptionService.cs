using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace FAIS.ApplicationCore.Services
{
    public class LibraryOptionService : ILibraryOptionService
    {
        private readonly ILibraryOptionRepository _repository;

        public LibraryOptionService(ILibraryOptionRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyCollection<LibraryOptionModel> Get()
        {
            return _repository.GetAll();
        }

        public LibraryOptionModel GetById(int id)
        {
            return _repository.GetAll().Where(x=>x.Id == id).FirstOrDefault();
        }
    }
}
