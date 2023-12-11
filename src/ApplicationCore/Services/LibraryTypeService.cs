using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using System.Linq;

namespace FAIS.ApplicationCore.Services
{
    public class LibraryTypeService : ILibraryTypeService
    {
        private readonly ILibraryTypeRepository _repository;

        public LibraryTypeService(ILibraryTypeRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<LibraryType> Get()
        {
            return _repository.Get();
        }

        public LibraryType GetById(decimal id)
        {
            return _repository.GetById(id);
        }
    }
}
