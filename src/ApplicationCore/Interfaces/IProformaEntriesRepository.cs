using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IProformaEntriesRepository
    {
        IReadOnlyCollection<ProformaEntries> Get();
        ProformaEntries GetById(int id);
        Task<ProformaEntries> Add(ProformaEntries proforma);
        Task<ProformaEntries> Update(ProformaEntries proforma);
    }
}
