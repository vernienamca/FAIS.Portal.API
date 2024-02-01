using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using FAIS.Infrastructure.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class ProformaEntriesRepository : EFRepository<ProformaEntries, int>, IProformaEntriesRepository
    {
        public ProformaEntriesRepository(FAISContext context) : base(context)
        {
        }

        public ProformaEntries GetById(int id)
        {
            return _dbContext.ProformaEntries.FirstOrDefault(t => t.Id == id);
        }

        public async Task<ProformaEntries> Update(ProformaEntries proforma)
        {
            return await UpdateAsync(proforma);
        }
    }
}
