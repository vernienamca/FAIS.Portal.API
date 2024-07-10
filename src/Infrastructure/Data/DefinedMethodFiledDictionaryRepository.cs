using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class DefinedMethodFiledDictionaryRepository : EFRepository<DefinedMethodFieldDictionary, int>, IDefinedMethodFieldDictionaryRepository
    {
        public DefinedMethodFiledDictionaryRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<DefinedMethodFieldDictionaryModel> Get()
        {
            var ret = (from dmf in _dbContext.DefinedMethodFieldDictionaries.AsNoTracking()
                       join usr in _dbContext.Users.AsNoTracking() on dmf.CreatedBy equals usr.Id
                       join usrU in _dbContext.Users.AsNoTracking() on dmf.UpdatedBy equals usrU.Id into usrUX
                       from usrU in usrUX.DefaultIfEmpty()
                       orderby dmf.Id descending
                       select new DefinedMethodFieldDictionaryModel()
                       {
                           Id = dmf.Id,
                           DefinedMethodId = dmf.DefinedMethodId,
                           FieldDictionaryId = dmf.FieldDictionaryId,
                           Description = dmf.Description,
                           CreatedAt = dmf.CreatedAt,
                           UpdatedBy = dmf.UpdatedBy,
                           RemovedAt = dmf.RemovedAt,
                           CreatedBy = dmf.CreatedBy,
                           UpdatedAt = dmf.UpdatedAt,

                       }).ToList();
            return ret;
        }

        public async Task<DefinedMethodFieldDictionaryModel> GetById(int id)
        {
            var ret = (from dmf in _dbContext.DefinedMethodFieldDictionaries.AsNoTracking()
                       join usr in _dbContext.Users.AsNoTracking() on dmf.CreatedBy equals usr.Id
                       join usrU in _dbContext.Users.AsNoTracking() on dmf.UpdatedBy equals usrU.Id into usrUX
                       from usrU in usrUX.DefaultIfEmpty()
                       orderby dmf.Id descending
                       select new DefinedMethodFieldDictionaryModel()
                       {
                           Id = dmf.Id,
                           DefinedMethodId = dmf.DefinedMethodId,
                           FieldDictionaryId = dmf.FieldDictionaryId,
                           Description = dmf.Description,
                           CreatedAt = dmf.CreatedAt,
                           UpdatedBy = dmf.UpdatedBy,
                           RemovedAt = dmf.RemovedAt,
                           CreatedBy = dmf.CreatedBy,
                           UpdatedAt = dmf.UpdatedAt,

                       }).FirstOrDefaultAsync(t => t.Id == id);
            return await ret;
        }

        public async Task<DefinedMethodFieldDictionary> Add(DefinedMethodFieldDictionary dto)
        {
            return await AddAsync(dto);
        }

        public async Task<DefinedMethodFieldDictionary> Update(DefinedMethodFieldDictionary dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
