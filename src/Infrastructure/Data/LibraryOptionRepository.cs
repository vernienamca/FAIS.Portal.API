using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using DocumentFormat.OpenXml.Office.Word;
using FAIS.ApplicationCore.Entities.Security;

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
                                     UDF1 = lo.UDF1,
                                     UDF2 = lo.UDF2,
                                     UDF3 = lo.UDF3,
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

        public IReadOnlyCollection<DropdownModel> GetDropdownValues(string[] code)
        {
            var parentValues = (from lo in _dbContext.LibraryOptions.AsNoTracking()
                                join prt in _dbContext.LibraryTypes.AsNoTracking() on lo.LibraryTypeId equals prt.Id
                                where code.Contains(prt.Code)
                                select new DropdownModel()
                                {
                                    LibraryTypeId = lo.LibraryTypeId,
                                    LibraryTypeName = prt.Name,
                                    Description = prt.Description,
                                    DropdownCode = prt.Code,
                                    DependentCode = lo.Code,
                                    ParentValue = lo.Description,
                                    ParentId = lo.Id,
                                    ChildValues = (from lt in _dbContext.LibraryTypes.AsNoTracking()
                                                   where lt.Code == lo.Code
                                                   join lo2 in _dbContext.LibraryOptions.AsNoTracking() on lt.Id equals lo2.LibraryTypeId
                                                   select new ChildValueModel 
                                                   {
                                                       Id = lo2.Id,
                                                       Description = lo2.Description,
                                                       Remark = lo2.Remarks
                                                   })
                                                   .ToList()
                                })
                                .ToList();

            return parentValues;
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