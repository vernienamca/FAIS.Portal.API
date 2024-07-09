using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IAmr100BatchRepository
    {
        IReadOnlyCollection<Amr100BatchModel> Get(int reportSeqId, string yearMonth);

        Task<Amr100BatchModel> GetById(int id);
        Task<Amr100Batch> Add(Amr100Batch amr);
        Task<Amr100Batch> Update(Amr100Batch amr);
    }
}
