using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IProformaEntryDetailsRepository
    {
        IReadOnlyCollection<ProformaEntryDetail> Get();
        List<ProformaEntryDetail> GetById(int id);
        Task<ProformaEntryDetail> Add(ProformaEntryDetail proformaDetail);
        Task<ProformaEntryDetail> Update(ProformaEntryDetail proformaDetail);
    }
}
