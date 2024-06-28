using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.DTOs.Structure;
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
        IReadOnlyCollection<Amr100BatchModel> GetAmr100Batch();
        Task<AmrModel> GetById(int id);
        Task<Amr100BatchModel> GetAmr100BatchById(int id);
        byte[] ExportAmrLogs();
        Task<Amr> Add(AddAmrDTO dto);
        Task<Amr> Update(UpdateAmrDTO dto);
        Task<Amr> UpdateEncoding(int id);
        Task<Amr100Batch> AddAmr100Batch(AddAmr100BatchDTO dto);
        Task<Amr100Batch> UpdateAmr100Batch(UpdateAmr100BatchDTO dto);
    }
}
