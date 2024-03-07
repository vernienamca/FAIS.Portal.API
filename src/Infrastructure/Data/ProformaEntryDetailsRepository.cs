using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class ProformaEntryDetailsRepository : EFRepository<ProformaEntryDetail, int>, IProformaEntryDetailsRepository
    {
        public ProformaEntryDetailsRepository(FAISContext context) : base(context)
        {
        }
        public IReadOnlyCollection<ProformaEntryDetail> Get()
        {
            return _dbContext.ProformaEntryDetails.ToList();
        }

        public List<ProformaEntryDetail> GetById(int id)
        {
            return _dbContext.ProformaEntryDetails.Where(t => t.ProformaEntryId == id).AsNoTracking().ToList();
        }
        public async Task<ProformaEntryDetail> Add(ProformaEntryDetail proformaDetail)
        {
            return await AddAsync(proformaDetail);
        }

        public async Task<ProformaEntryDetail> Update(ProformaEntryDetail proformaDetail)
        {
            return await UpdateAsync(proformaDetail);
        }
    }
}
