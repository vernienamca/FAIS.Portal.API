using DocumentFormat.OpenXml.Vml.Office;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class ProformaEntriesRepository : EFRepository<ProformaEntry, int>, IProformaEntriesRepository
    {
        public ProformaEntriesRepository(FAISContext context) : base(context)
        {
        }

        public IReadOnlyCollection<ProformaEntry> Get()
        {
            return _dbContext.ProformaEntries.ToList();
        }

        public ProformaEntry GetById(int id)
        {
            var proformaEntry = _dbContext.ProformaEntries.FirstOrDefault(t => t.Id == id);
            return proformaEntry;
 
        }

        public async Task<ProformaEntry> Add(ProformaEntry proforma)
        {
            return await AddAsync(proforma);
        }

        public async Task<ProformaEntry> Update(ProformaEntry proforma)
        {
            return await UpdateAsync(proforma);
        }

        public async Task Delete(int id)
        {
            var result = _dbContext.ProformaEntries.FirstOrDefault(res => res.Id == id);

            await DeleteAsync(result);
        }
    }
}