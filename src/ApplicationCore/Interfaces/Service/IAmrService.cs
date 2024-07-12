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
        IReadOnlyCollection<Amr100BatchStatHistoryModel> GetAmr100BatchStatHistory();
        Task<AmrModel> GetById(int id);
        Task<Amr100BatchModel> GetAmr100BatchById(int id);
        Task<Amr100BatchDModel> GetAmr100BatchDById(int id);
        Task<Amr100BatchDbdModel> GetAmr100BatchDbdById(int id);
        Task <IReadOnlyCollection<Amr100BatchStatHistoryModel>> GetAmr100BatchStatHistoryById(int batchId);
        byte[] ExportAmrLogs();
        Task<Amr> Add(AmrDTO dto);
        Task<Amr> Update(AmrDTO dto);
        Task<Amr> UpdateEncoding(int id);
        Task<Amr100Batch> AddAmr100Batch(Amr100BatchDTO dto);
        Task<Amr100Batch> UpdateAmr100Batch(Amr100BatchDTO dto);
        Task<Amr100BatchD> AddAmr100BatchD(Amr100BatchDDTO dto);
        Task<Amr100BatchD> UpdateAmr100BatchD(Amr100BatchDDTO dto); 
        Task<Amr100BatchDbd> AddAmr100BatchDbd(Amr100BatchDbdDTO dto);
        Task<Amr100BatchDbd> UpdateAmr100BatchDbd(Amr100BatchDbdDTO dto);
        Task<Amr100BatchStatHistory> AddAmr100BatchStatHistory(Amr100BatchStatHistoryDTO dto);
        Task<Amr100BatchD> ResetQuantity();
    }
}