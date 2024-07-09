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

        public IReadOnlyCollection<DefinedMethodFieldDictionary> Get()
        {
            return _dbContext.DefinedMethodFieldDictionaries.AsNoTracking().ToList();
        }

        public async Task<DefinedMethodFieldDictionary> GetById(int id)
        {
            return await _dbContext.DefinedMethodFieldDictionaries.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
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
