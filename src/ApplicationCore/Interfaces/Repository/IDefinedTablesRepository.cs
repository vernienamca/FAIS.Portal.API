﻿using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IDefinedTablesRepository
    {
        IReadOnlyCollection<DefinedTablesModel> Get();
        Task<DefinedTablesModel> GetById(int id);
        Task<DefinedTables> Add(DefinedTables dto);
        Task<DefinedTables> Update(DefinedTables dto);
    }
}
