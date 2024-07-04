﻿using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IAmr100BatchDRepository
    {
        IReadOnlyCollection<Amr100BatchDModel> Get();
        Task<Amr100BatchDModel> GetById(int id);
        Task<Amr100BatchD> Add(Amr100BatchD amr);
        Task<Amr100BatchD> Update(Amr100BatchD amr);
    }
}
