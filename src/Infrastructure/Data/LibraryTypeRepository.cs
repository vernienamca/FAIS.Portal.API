using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using System.Linq;

namespace FAIS.Infrastructure.Data
{
    public class LibraryTypeRepository : EFRepository<LibraryType, int>, ILibraryTypeRepository
    {
        public LibraryTypeRepository(FAISContext context) : base(context)
        {
        }

        public IQueryable<LibraryType> Get()
        {
            return _dbContext.LibraryTypes;
        }

        public LibraryType GetById(decimal id)
        {
            return _dbContext.LibraryTypes.Where(t => t.Id == id).ToList()[0];
        }
    }
}
