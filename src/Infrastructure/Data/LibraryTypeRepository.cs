using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using System.Collections.Generic;
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

        public List<string> GetLibraryCodesById(int id, string libraryCode)
        {
            List<string> combinedList = new List<string>();

            List<int> userTafgId = _dbContext.UserTAFGs .Where(t => t.UserId == id).Select(s => s.TAFGId).ToList();
            var libraryTypeCodeId = _dbContext.LibraryTypes.Where(t => userTafgId.Contains(t.Id) && t.Code == libraryCode).Select(t => t.Id).ToList();
            combinedList.AddRange(_dbContext.LibraryTypes.Where(t => libraryTypeCodeId.Contains(t.Id)).Select(t => t.Description).ToList());

            var oupFgIds = _dbContext.Users.Where(t => t.Id == id && t.OupFgId != null).Select(s => s.OupFgId);
            var OupFgCodeID = _dbContext.LibraryTypes.Where(t => oupFgIds.Contains(t.Id) && t.Code == libraryCode).Select(t => t.Id).ToList();
            combinedList.AddRange(_dbContext.LibraryTypes.Where(t => OupFgCodeID.Contains(t.Id)).Select(t => t.Description).Distinct().ToList());

            return combinedList;
        }


    }
}
