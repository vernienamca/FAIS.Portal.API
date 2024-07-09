using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class DefinedTablesRepository : EFRepository<DefinedTables, int>, IDefinedTablesRepository
    {
        public DefinedTablesRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<DefinedTables> Get()
        {
            return _dbContext.DefinedTables.AsNoTracking().ToList();
        }

        public async Task<DefinedTables> GetById(int id)
        {
            return await _dbContext.DefinedTables.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<DefinedTables> Add(DefinedTables dto)
        {
            return await AddAsync(dto);
        }

        public async Task<DefinedTables> Update(DefinedTables dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
