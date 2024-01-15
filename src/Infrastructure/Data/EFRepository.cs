using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using FAIS.ApplicationCore.Entities.Security;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;

namespace FAIS.Infrastructure.Data
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EFRepository<EntityType, IdType> : IAsyncRepository<EntityType, IdType> where EntityType : BaseEntity<IdType>
    {
        protected readonly FAISContext _dbContext;

        public EFRepository(FAISContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EntityType>> ListAllAsync()
        {
            return await _dbContext.Set<EntityType>().ToListAsync();
        }

        public async Task<EntityType> AddAsync(EntityType entity)
        {
            try
            {
                _dbContext.Set<EntityType>().Add(entity);

                await _dbContext.SaveChangesAsync();

                return entity;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        
        }

        public async Task<EntityType> UpdateAsync(EntityType entity)
        {
            try
            {
                _dbContext.Attach(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return entity;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }

        }

        public async Task DeleteAsync(EntityType entity)
        {
            _dbContext.Set<EntityType>().Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<EntityType> GetByIdAsync(IdType id)
        {
            return await _dbContext.Set<EntityType>().FindAsync(id);
        }
    }
}