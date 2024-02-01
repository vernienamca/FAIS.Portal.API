using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IProformaEntriesService
    {
        ProformaEntries GetById(int id);
        Task<ProformaEntries> Update(UpdateProformaEntriesDTO proformaEntriesDto);
    }
}
