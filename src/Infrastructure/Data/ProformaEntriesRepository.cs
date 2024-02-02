using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class ProformaEntriesRepository : EFRepository<ProformaEntries, int>, IProformaEntriesRepository
    {
        public ProformaEntriesRepository(FAISContext context) : base(context)
        {
        }
        public IReadOnlyCollection<ProformaEntries> Get()
        {
            return _dbContext.ProformaEntries.ToList();
        }

        public ProformaEntries GetById(int id)
        {
            return _dbContext.ProformaEntries.FirstOrDefault(t => t.Id == id);
        }
        public async Task<ProformaEntries> Add(ProformaEntries proforma)
        {
            return await AddAsync(proforma);
        }

        public async Task<ProformaEntries> Update(ProformaEntries proforma)
        {
            return await UpdateAsync(proforma);
        }
    }
}
