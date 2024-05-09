using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using DocumentFormat.OpenXml.Office.Word;

namespace FAIS.Infrastructure.Data
{
    public class LibraryOptionRepository : EFRepository<LibraryOptions, int>, ILibraryOptionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryOptionRepository"/> class.
        /// </summary>
        public LibraryOptionRepository(FAISContext context) : base(context)
        {
        }

        public IReadOnlyCollection<LibraryOptionModel> GetAll()
        {
            var libraryOption = (from lo in _dbContext.LibraryOptions.AsNoTracking()
                                 join lto in _dbContext.LibraryTypes.AsNoTracking() on lo.LibraryTypeId equals lto.Id
                                 join usrC in _dbContext.Users.AsNoTracking() on lo.CreatedBy equals usrC.Id
                                 join usrU in _dbContext.Users.AsNoTracking() on lo.UpdatedBy equals usrU.Id into usrUX
                                 from usrU in usrUX.DefaultIfEmpty()
                                 orderby lo.Id descending
                                 select new LibraryOptionModel()
                                 {
                                     Id = lo.Id,
                                     LibraryTypeId = lo.LibraryTypeId,
                                     LibraryTypeName = lto.Name,
                                     Code = lo.Code,
                                     Description = lo.Description,
                                     IsActive = lo.IsActive,
                                     Remark = lo.Remarks,
                                     Ranking = lo.Ranking.Value,
                                     StatusDate = lo.StatusDate,
                                     CreatedBy = lo.CreatedBy,
                                     CreatedByName = $"{usrC.FirstName} {usrC.LastName}",
                                     CreatedAt = lo.CreatedAt,
                                     UpdatedAt = lo.UpdatedAt,
                                     UpdatedBy = lo.UpdatedBy,
                                     UpdatedByName = lo.UpdatedBy.HasValue ? $"{usrU.FirstName} {usrU.LastName}" : ""
                                 }).ToList();

            return libraryOption;
        }

        public async Task Delete(int libraryOptionid)
        {
            var result = _dbContext.LibraryOptions.FirstOrDefault(res => res.Id == libraryOptionid);

            await DeleteAsync(result);
        }

        public async Task<LibraryOptions> Add(LibraryOptions libraryOptionType)
        {
            return await AddAsync(libraryOptionType);
        }

        public async Task<LibraryOptions> Update(LibraryOptions libraryOptionType)
        {
            return await UpdateAsync(libraryOptionType);
        }
    }
}