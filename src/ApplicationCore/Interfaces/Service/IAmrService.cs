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
        IReadOnlyCollection<Amr100BatchDbdModel> GetAmr100BatchDbd(int amrBatchSeq, int reportSeq, string yearMonth);
        IReadOnlyCollection<Amr100BatchStatHistoryModel> GetAmr100BatchStatHistory();
        Task<AmrModel> GetById(int id);
        Task<Amr100BatchModel> GetAmr100BatchById(int id);
        Task<Amr100BatchDModel> GetAmr100BatchDById(int id);
        Task<Amr100BatchDbdModel> GetAmr100BatchDbdById(int id);
        Task <IReadOnlyCollection<Amr100BatchStatHistoryModel>> GetAmr100BatchStatHistoryById(int batchId);
        byte[] ExportAmrLogs();
        byte[] ExportAmrBatchDLogs();
        Task<Amr> Add(AddAmrDTO dto);
        Task<Amr> Update(UpdateAmrDTO dto);
        Task<Amr> UpdateEncoding(int id);
        Task<Amr100Batch> AddAmr100Batch(AddAmr100BatchDTO dto);
        Task<Amr100Batch> UpdateAmr100Batch(UpdateAmr100BatchDTO dto);
        Task<Amr100BatchD> AddAmr100BatchD(AddAmr100BatchDDTO dto);
        Task<List<Amr100BatchD>> SaveChanges(List<Amr100BatchDDTO> dtos);
        Task<Amr100BatchD> UpdateAmr100BatchD(UpdateAmr100BatchDDTO dto); 
        Task<Amr100BatchDbd> AddAmr100BatchDbd(AddAmr100BatchDbdDTO dto);
        Task<Amr100BatchDbd> UpdateAmr100BatchDbd(UpdateAmr100BatchDbdDTO dto);
        Task<List<Amr100BatchDbd>> UpdateRows(List<UpdateAmr100BatchDbdDTO> dtos);
        Task<Amr100BatchStatHistory> AddAmr100BatchStatHistory(Amr100BatchStatHistoryDTO dto);
        Task<Amr100BatchD> ResetQuantity(int amrBatchDSeq);
        Task<Amr100BatchD> BreakRow(int id);
        Task<List<Amr100BatchD>> BreakMultipleRows(int amrBatchDSeq);
        Task<Amr100BatchD> RemoveBreak(int id);
        Task<Amr100Batch> NewAssetApproval(int id);
        Task<Amr100Batch> ReturnToAnalyst(AmrTransactionsDTO dto);
        Task<Amr100Batch> ForReview(int id);
    }
}