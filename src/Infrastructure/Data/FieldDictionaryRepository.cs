using DocumentFormat.OpenXml.Wordprocessing;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class FieldDictionaryRepository : EFRepository<FieldDictionary, int>, IFieldDictionaryRepository
    {
        public FieldDictionaryRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<FieldDictionaryModel> Get()
        {
            var ret = (from fd in _dbContext.FieldDictionaries.AsNoTracking()
                        join usr in _dbContext.Users.AsNoTracking() on fd.CreatedBy equals usr.Id
                        join usrU in _dbContext.Users.AsNoTracking() on fd.UpdatedBy equals usrU.Id into usrUX
                        from usrU in usrUX.DefaultIfEmpty()
                        orderby fd.Id descending
                        select new FieldDictionaryModel()
                        {
                            Id = fd.Id,
                            BusinessProcessId = fd.BusinessProcessId,
                            FieldName = fd.FieldName,
                            TableId = fd.TableId,
                            ColumnId = fd.ColumnId,
                            IsActive = fd.IsActive,
                            StatusDate = fd.StatusDate,
                            Description = fd.Description,
                            CreatedAt = fd.CreatedAt,
                            UpdatedAt = fd.UpdatedAt,
                            CreatedBy = fd.CreatedBy,
                            UpdatedBy = fd.UpdatedBy,

                        }). ToList();
            return ret;
        }

        public async Task<FieldDictionaryModel> GetById(int id)
        {
            var ret = (from fd in _dbContext.FieldDictionaries.AsNoTracking()
                       join usr in _dbContext.Users.AsNoTracking() on fd.CreatedBy equals usr.Id
                       join usrU in _dbContext.Users.AsNoTracking() on fd.UpdatedBy equals usrU.Id into usrUX
                       from usrU in usrUX.DefaultIfEmpty()
                       orderby fd.Id descending
                       select new FieldDictionaryModel()
                       {
                           Id = fd.Id,
                           BusinessProcessId = fd.BusinessProcessId,
                           FieldName = fd.FieldName,
                           TableId = fd.TableId,
                           ColumnId = fd.ColumnId,
                           IsActive = fd.IsActive,
                           StatusDate = fd.StatusDate,
                           Description = fd.Description,
                           CreatedAt = fd.CreatedAt,
                           UpdatedAt = fd.UpdatedAt,
                           CreatedBy = fd.CreatedBy,
                           UpdatedBy = fd.UpdatedBy,
                          
                       }).FirstOrDefaultAsync(t => t.Id == id);
            return await ret;
        }

        public async Task<FieldDictionary> GetByTableId(int id)
        {
            return await _dbContext.FieldDictionaries.FirstOrDefaultAsync(d => d.IsActive == 'Y' && d.TableId == id);
        }

        public async Task<FieldDictionary> GetByColumnId(int id)
        {
            return await _dbContext.FieldDictionaries.FirstOrDefaultAsync(d => d.IsActive == 'Y' && d.ColumnId == id);
        }

        public async Task<FieldDictionary> Add(FieldDictionary dto)
        {
            return await AddAsync(dto);
        }

        public async Task<FieldDictionary> Update(FieldDictionary dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
