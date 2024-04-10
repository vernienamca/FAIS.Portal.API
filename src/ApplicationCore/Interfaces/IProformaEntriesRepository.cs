using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IProformaEntriesRepository
    {
        IReadOnlyCollection<ProformaEntry> Get();
        ProformaEntry GetById(int id);
        Task<ProformaEntry> Add(ProformaEntry proforma);
        Task<ProformaEntry> Update(ProformaEntry proforma);
    }
}
