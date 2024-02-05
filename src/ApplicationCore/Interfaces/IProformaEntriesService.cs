using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IProformaEntriesService
    {
        IReadOnlyCollection<ProformaEntries> Get();
        ProformaEntries GetById(int id);
        Task<ProformaEntries> Add(ProformaEntriesDTO proformaEntriesDTO);
        Task<ProformaEntries> Update(UpdateProformaEntriesDTO proformaEntriesDto);
    }
}
