﻿using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IAmr100BatchDbdRepository
    {
        IReadOnlyCollection<Amr100BatchDbdModel> Get(int amrBatchSeq, int reportSeq, string yearMonth);
        Task<Amr100BatchDbdModel> GetById(int id);
        Task<Amr100BatchDbd> Add(Amr100BatchDbd amr);
        Task<Amr100BatchDbd> Update(Amr100BatchDbd amr);
        Task BulkInsert(List<Amr100BatchDbd> amrs, BulkConfig bulkconfig);
        Task BulkUpdate(List<Amr100BatchDbd> amrs, BulkConfig bulkConfig);
        Task BulkDelete(List<Amr100BatchDbd> amrs, BulkConfig bulkConfig);
        Task<List<Amr100BatchDbd>> InsertMultipleRecords(List<Amr100BatchDbd> amr);
        Task<List<Amr100BatchDbd>> RemoveMultipleRecords(List<Amr100BatchDbd> amr);
        IQueryable<Amr100BatchDbd> GetAll();
    }
}
