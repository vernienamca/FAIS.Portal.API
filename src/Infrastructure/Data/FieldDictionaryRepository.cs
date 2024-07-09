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

        public IReadOnlyCollection<FieldDictionary> Get()
        {
            return _dbContext.FieldDictionaries.AsNoTracking().ToList();
        }

        public async Task<FieldDictionary> GetById(int id)
        {
            return await _dbContext.FieldDictionaries.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
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
