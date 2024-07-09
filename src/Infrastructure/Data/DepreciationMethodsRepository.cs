using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class DepreciationMethodsRepository : EFRepository<DepreciationMethods, int>, IDepreciationMethodsRepository
    {
        public DepreciationMethodsRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<DepreciationMethods> Get()
        {
            return _dbContext.DepreciationMethods.AsNoTracking().ToList();
        }

        public async Task<DepreciationMethods> GetById(int id)
        {
            return await _dbContext.DepreciationMethods.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<DepreciationMethods> Add(DepreciationMethods dto)
        {
            return await AddAsync(dto);
        }

        public async Task<DepreciationMethods> Update(DepreciationMethods dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
