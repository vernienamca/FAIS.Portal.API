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
        IReadOnlyCollection<Amr100BatchModel> GetAmr100Batch(int id, string yearMonth);
        IReadOnlyCollection<Amr100BatchDModel> GetAmr100BatchD(int amrBatchSeq, int reportSeq, string yearMonth);
        IReadOnlyCollection<Amr100BatchDbdModel> GetAmr100BatchDbd();
        Task<AmrModel> GetById(int id);
        Task<Amr100BatchModel> GetAmr100BatchById(int id);
        Task<Amr100BatchDModel> GetAmr100BatchDById(int id);
        Task<Amr100BatchDbdModel> GetAmr100BatchDbdById(int id);
        byte[] ExportAmrLogs();
        Task<Amr> Add(AddAmrDTO dto);
        Task<Amr> Update(UpdateAmrDTO dto);
        Task<Amr> UpdateEncoding(int id);
        Task<Amr100Batch> AddAmr100Batch(AddAmr100BatchDTO dto);
        Task<Amr100Batch> UpdateAmr100Batch(UpdateAmr100BatchDTO dto);
        Task<Amr100BatchD> AddAmr100BatchD(AddAmr100BatchDDTO dto);
        Task<Amr100BatchD> UpdateAmr100BatchD(UpdateAmr100BatchDDTO dto); 
        Task<Amr100BatchDbd> AddAmr100BatchDbd(AddAmr100BatchDbdDTO dto);
        Task<Amr100BatchDbd> UpdateAmr100BatchDbd(UpdateAmr100BatchDbdDTO dto);
    }
}