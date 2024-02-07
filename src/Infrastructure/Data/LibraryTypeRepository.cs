using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
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

        public IReadOnlyCollection<LibraryTypeModel> Get()
        {
            var libraryTypes = (from lib in _dbContext.LibraryTypes.AsNoTracking()
                                  join usrC in _dbContext.Users.AsNoTracking() on lib.CreatedBy equals usrC.Id
                                  join usrU in _dbContext.Users.AsNoTracking() on lib.UpdatedBy equals usrU.Id into usrUX
                                  from usrU in usrUX.DefaultIfEmpty()
                                  select new LibraryTypeModel()
                                  {
                                      Id = lib.Id,
                                      Name = lib.Name,
                                      Code = lib.Code,
                                      Description = lib.Description,
                                      IsActive = lib.IsActive,
                                      StatusDate = lib.StatusDate,
                                      CreatedBy = $"{usrC.FirstName} {usrC.LastName}",
                                      CreatedAt = lib.CreatedAt,
                                      UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                                      UpdatedAt = lib.UpdatedAt
                                  }).ToList();

            return libraryTypes;
        }

        public LibraryType GetById(int id)
        {
            return _dbContext.LibraryTypes.FirstOrDefault(o => o.Id == id);
        }

        public LibraryType GetPositionIdByName(string positionName)
        {
            return _dbContext.LibraryTypes.FirstOrDefault(lt => lt.Name == positionName);
        }

        public LibraryType GetLibraryTypeIdByCode(string description)
        {
            return _dbContext.LibraryTypes.AsNoTracking().FirstOrDefault(lt => lt.Description == description);
        }
        public async Task<LibraryType> Add(LibraryType libraryType)
        {
            return await AddAsync(libraryType);
        }

        public async Task<LibraryType> Update(LibraryType libraryType)
        {
            return await UpdateAsync(libraryType);
        }

        public IReadOnlyCollection<string> GetLibraryCodesById(int id, string libraryCode)
        {
            var userTafgId = _dbContext.UserTAFGs.Where(t => t.UserId == id).Select(s => s.TAFGId);
            var libraryTypeCodeId = _dbContext.LibraryTypes .Where(t => userTafgId.Contains(t.Id) && t.Code == libraryCode).Select(t => t.Id);
            var libraryTypeDescriptions = _dbContext.LibraryTypes.Where(t => libraryTypeCodeId.Contains(t.Id)).Select(t => t.Description);
            var oupFgIds = _dbContext.Users.Where(t => t.Id == id && t.OupFgId != null) .Select(s => s.OupFgId);
            var oupFgCodeDescriptions = _dbContext.LibraryTypes.Where(t => oupFgIds.Contains(t.Id) && t.Code == libraryCode) .Select(t => t.Description).Distinct();
            var combinedList = libraryTypeDescriptions.Concat(oupFgCodeDescriptions).ToList();

            return combinedList;
        }
        public IReadOnlyCollection<string> GetLibrarybyCodes(string libraryCode)
        {
            List<string> libraryTypeDescriptions = _dbContext.LibraryTypes.AsNoTracking().Where(t => t.Code == libraryCode).Select(t => t.Description).ToList();
            return libraryTypeDescriptions;
        }

    }
}
