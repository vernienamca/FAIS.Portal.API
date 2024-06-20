using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IAmrService
    {
        IReadOnlyCollection<AmrModel> Get();
        Task<AmrModel> GetById(int id);
        byte[] ExportAmrLogs();
        Task<Amr> Add(AddAmrDTO dto);
        Task<Amr> Update(UpdateAmrDTO dto);
    }
}
