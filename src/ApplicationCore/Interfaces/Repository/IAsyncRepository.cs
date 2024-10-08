﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IAsyncRepository<EntityType, IdType> where EntityType : BaseEntity<IdType>
    {
        Task<List<EntityType>> ListAllAsync();
        Task<EntityType> AddAsync(EntityType entity);
        Task<EntityType> UpdateAsync(EntityType entity);
        Task DeleteAsync(EntityType entity);
        Task BulkUpdateAsync(List<EntityType> entities);
        Task BulkInsertAsync(List<EntityType> entities);
        Task DeleteRangeAsync(List<EntityType> entities);
        Task UpdateRangeAsync(List<EntityType> entities);
        Task InsertRangeAsync(List<EntityType> entities);
    }
}



