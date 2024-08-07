using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class DepreciationMethodsRepository : EFRepository<DepreciationMethods, int>, IDepreciationMethodsRepository
    {
        public DepreciationMethodsRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<DepreciationMethodsModel> Get()
        {
            var ret = (from dm in _dbContext.DepreciationMethods.AsNoTracking()
                       join bp in _dbContext.BusinessProcess.AsNoTracking() on dm.BusinessProcessId equals bp.Id
                       join usr in _dbContext.Users.AsNoTracking() on dm.CreatedBy equals usr.Id
                       join usrU in _dbContext.Users.AsNoTracking() on dm.UpdatedBy equals usrU.Id into usrUX
                       from usrU in usrUX.DefaultIfEmpty()
                       orderby dm.Id descending
                       select new DepreciationMethodsModel()
                       {
                           Id = dm.Id,
                           Name = dm.Name,
                           Description = dm.Description,
                           StartDate = dm.StartDate,
                           EndDate = dm.EndDate,
                           BusinessProcessId = dm.BusinessProcessId,
                           BusinessProcessName = bp.BusinessProcessName,
                           IsSingleTransaction = dm.IsSingleTransaction,
                           FinalResultId = dm.FinalResultId,
                           IsActive = dm.IsActive,
                           StatusDate = dm.StatusDate,
                           CreatedAt = dm.CreatedAt,
                           UpdatedBy = dm.UpdatedBy,
                           UpdatedAt = dm.UpdatedAt,
                          
                       }).ToList();
            return ret;
        }

        public async Task<DepreciationMethodsModel> GetById(int id)
        {
            var ret = (from dm in _dbContext.DepreciationMethods.AsNoTracking()
                       join usr in _dbContext.Users.AsNoTracking() on dm.CreatedBy equals usr.Id
                       join usrU in _dbContext.Users.AsNoTracking() on dm.UpdatedBy equals usrU.Id into usrUX
                       from usrU in usrUX.DefaultIfEmpty()
                       orderby dm.Id descending
                       select new DepreciationMethodsModel()
                       {
                           Id = dm.Id,
                           Name = dm.Name,
                           Description = dm.Description,
                           StartDate = dm.StartDate,
                           EndDate = dm.EndDate,
                           BusinessProcessId = dm.BusinessProcessId,
                           IsSingleTransaction = dm.IsSingleTransaction,
                           FinalResultId = dm.FinalResultId,
                           IsActive = dm.IsActive,
                           StatusDate = dm.StatusDate,
                           CreatedAt = dm.CreatedAt,
                           UpdatedBy = dm.UpdatedBy,
                           UpdatedAt = dm.UpdatedAt

                       }).FirstOrDefaultAsync(t => t.Id == id);

            var stepContainers = (from sc in _dbContext.StepContainers.AsNoTracking()
                                  join fd in _dbContext.FieldDictionaries.AsNoTracking() on sc.FieldDictionaryId equals fd.Id into fdX
                                  from fd in fdX.DefaultIfEmpty()
                                  orderby sc.Id
                                  select new StepContainerModel()
                                  {
                                      Id = sc.Id,
                                      DefinedMethodId = sc.DefinedMethodId,
                                      FieldDictionaryId = sc.FieldDictionaryId,
                                      FieldDictionaryDescription = fd.Description,
                                      ParentId = sc.ParentId,
                                      SortOrder = sc.SortOrder,
                                      StepType = sc.StepType,
                                      IsElse = sc.IsElse,
                                      Value = sc.Value,
                                      Comments = sc.Comments,
                                      ChildStepContainer = GetChildren(_dbContext.StepContainers.AsNoTracking().ToList(), sc.Id)
                                  }).Where(x => x.DefinedMethodId == id).ToList();

            ret.Result.StepContainerModels = stepContainers;

            return await ret;
        }

        private static List<StepContainerModel> GetChildren(List<StepContainer> steps, int parentId)
        {
            return steps
                    .Where(sc => sc.ParentId == parentId)
                    .Select(sc => new StepContainerModel
                    {
                        Id = sc.Id,
                        DefinedMethodId = sc.DefinedMethodId,
                        FieldDictionaryId = sc.FieldDictionaryId,
                        //FieldDictionaryDescription = fd.Description,
                        ParentId = sc.ParentId,
                        SortOrder = sc.SortOrder,
                        StepType = sc.StepType,
                        IsElse = sc.IsElse,
                        Value = sc.Value,
                        Comments = sc.Comments,
                        ChildStepContainer = GetChildren(steps, sc.Id)
                    }).ToList();
        }

        public async Task<DepreciationMethods> GetByBusinessProcessId(int id)
        { 
            return await _dbContext.DepreciationMethods.FirstOrDefaultAsync(d => d.BusinessProcessId == id);
        }

        public async Task<DepreciationMethods> Add(DepreciationMethods dto)
        {
            return await AddAsync(dto);
        }

        public async Task<DepreciationMethods> Update(DepreciationMethods dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
