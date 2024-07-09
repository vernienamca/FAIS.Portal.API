using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class DefinedTableColumnsRepository : EFRepository<DefinedTableColumns, int>, IDefinedTableColumnsRepository
    {
        public DefinedTableColumnsRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<DefinedTableColumns> Get()
        {
            return _dbContext.DefinedTableColumns.AsNoTracking().ToList();
        }

        public async Task<DefinedTableColumns> GetById(int id)
        {
            return await _dbContext.DefinedTableColumns.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<DefinedTableColumns> Add(DefinedTableColumns dto)
        {
            return await AddAsync(dto);
        }

        public async Task<DefinedTableColumns> Update(DefinedTableColumns dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
