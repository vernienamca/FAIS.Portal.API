using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IProformaEntriesService
    {
        IReadOnlyCollection<ProformaEntry> Get();

        ProformaEntry GetById(int id);

        Task<ProformaEntry> Add(ProformaEntryDTO proformaEntryDTO);

        Task<ProformaEntry> Update(ProformaEntryDTO proformaEntryDTO);

        Task Delete(int id);
        IReadOnlyCollection<ProformaEntryDetail> GetDetailById(int id);
    }
}