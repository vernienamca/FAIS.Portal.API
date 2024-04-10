using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IProformaEntryDetailsService
    {
        IReadOnlyCollection<ProformaEntryDetail> Get();
        Task<ProformaEntryDetail> Add(ProformaEntryDetailDTO proformaEntriesDetailDTO);
    }
}
