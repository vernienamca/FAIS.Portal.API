using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class BusinessProcessRepository : EFRepository<BusinessProcess, int>, IBusinessProcessRepository
    {
        public BusinessProcessRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<BusinessProcess> Get()
        {
            return _dbContext.BusinessProcess.AsNoTracking().ToList();
        }

        public async Task<BusinessProcess> GetById(int id)
        {
            return await _dbContext.BusinessProcess.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<BusinessProcess> Add(BusinessProcess dto)
        {
            return await AddAsync(dto);
        }

        public async Task<BusinessProcess> Update(BusinessProcess dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
