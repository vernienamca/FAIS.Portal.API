using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class StepContainerRepository : EFRepository<StepContainer, int>, IStepContatinerRepository
    {
        public StepContainerRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<StepContainerModel> Get()
        {
            var ret = (from sc in _dbContext.StepContainers.AsNoTracking()
                       join usr in _dbContext.Users.AsNoTracking() on sc.CreatedBy equals usr.Id
                       join usrU in _dbContext.Users.AsNoTracking() on sc.UpdatedBy equals usrU.Id into usrUX
                       from usrU in usrUX.DefaultIfEmpty()
                       orderby sc.Id descending
                       select new StepContainerModel()
                       {
                           Id = sc.Id,
                           DefinedMethodId = sc.DefinedMethodId,
                           ParentId = sc.ParentId,
                           SortOrder = sc.SortOrder,
                           StepType = sc.StepType,
                           FieldDictionaryId = sc.FieldDictionaryId,
                           IsElse = sc.IsElse,
                           Value = sc.Value,
                           Comments = sc.Comments,
                           CreatedBy = sc.CreatedBy,
                           CreatedAt = sc.CreatedAt,
                           UpdatedBy = sc.UpdatedBy,
                           UpdatedAt = sc.UpdatedAt,
                           RemovedAt = sc.RemovedAt,

                       }).ToList();
            return ret;
        }

        public async Task<StepContainerModel> GetById(int id)
        {
            var ret = (from sc in _dbContext.StepContainers.AsNoTracking()
                    join usr in _dbContext.Users.AsNoTracking() on sc.CreatedBy equals usr.Id
                    join usrU in _dbContext.Users.AsNoTracking() on sc.UpdatedBy equals usrU.Id into usrUX
                    from usrU in usrUX.DefaultIfEmpty()
                    orderby sc.Id descending
                    select new StepContainerModel()
                   {
                        Id = sc.Id,
                        DefinedMethodId = sc.DefinedMethodId,
                        ParentId = sc.ParentId,
                        SortOrder = sc.SortOrder,
                        StepType = sc.StepType,
                        FieldDictionaryId = sc.FieldDictionaryId,
                        IsElse = sc.IsElse,
                        Value = sc.Value,
                        Comments = sc.Comments,
                        CreatedBy = sc.CreatedBy,
                        CreatedAt = sc.CreatedAt,
                        UpdatedBy = sc.UpdatedBy,
                        UpdatedAt = sc.UpdatedAt,
                        RemovedAt = sc.RemovedAt,

                     }).FirstOrDefaultAsync(t => t.Id == id);
            return await ret;
        }

        public async Task<StepContainer> Add(StepContainer dto)
        {
            return await AddAsync(dto);
        }

        public async Task<StepContainer> Update(StepContainer dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
