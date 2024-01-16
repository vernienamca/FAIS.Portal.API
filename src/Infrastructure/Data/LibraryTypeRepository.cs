using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class LibraryTypeRepository : EFRepository<LibraryType, int>, ILibraryTypeRepository
    {
        public LibraryTypeRepository(FAISContext context) : base(context)
        {
        }

        public IQueryable<LibraryType> Get()
        {
            return _dbContext.LibraryTypes.AsNoTracking();
        }

        public LibraryType GetById(int id)
        {
            return _dbContext.LibraryTypes.FirstOrDefault(t => t.Id == id);
        }

        public async Task<LibraryType> Add(LibraryType libraryType)
        {
            return await AddAsync(libraryType);
        }

        public async Task<LibraryType> Update(LibraryType libraryType)
        {
            return await UpdateAsync(libraryType);
        }
    }
}
