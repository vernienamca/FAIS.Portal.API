using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class AssetProfileRepository : EFRepository<AssetProfile, int>, IAssetProfileRepository
    {
        public AssetProfileRepository(FAISContext context) : base(context) 
        {
        }

        public IReadOnlyCollection<AssetProfileModel> Get()
        {
            var assetProfile = (from prf in _dbContext.AssetProfile.AsNoTracking()
                                join usr in _dbContext.Users.AsNoTracking() on prf.CreatedBy equals usr.Id
                                join usrU in _dbContext.Users.AsNoTracking() on prf.UpdatedBy equals usrU.Id into usrUX from usrU in usrUX.DefaultIfEmpty()
                                join opt in _dbContext.LibraryTypes.AsNoTracking() on prf.AssetCategoryId equals opt.Id into optX from opt in optX.DefaultIfEmpty()
                                join ch in _dbContext.ChartOfAccounts.AsNoTracking() on prf.RcaSLId equals ch.Id into chX from ch in chX.DefaultIfEmpty()
                                orderby prf.Id descending
                                select new AssetProfileModel()
                                {
                                    Id = prf.Id,
                                    Name = prf.Name,
                                    Category = opt.Description,
                                    StatusDate = opt.StatusDate,
                                    Description = prf.Description,
                                    RcaGLId = prf.RcaGLId,
                                    RCASLId = ch.RcaSL,
                                    AssetClass = prf.AssetClassId ?? 0,
                                    CostCenter = prf.CostCenter ?? 0,
                                    IsActive = prf.IsActive,
                                    EconomicLife = prf.EconomicLife,
                                    ResidualLife= prf.ResidualLife,
                                    UDF1 = prf.UDF1,
                                    UDF2 = prf.UDF2,
                                    UDF3 = prf.UDF3,
                                    CreatedBy = prf.CreatedBy,
                                    CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                    CreatedAt = prf.CreatedAt,
                                    UpdatedBy = prf.UpdatedBy,
                                    UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                    UpdatedAt = prf.UpdatedAt
                                }).ToList();
            return assetProfile;
        }

        public async Task<AssetProfileModel> GetById(int id)
        {
            var assetProfile = (from prf in _dbContext.AssetProfile.AsNoTracking()
                                         join usr in _dbContext.Users.AsNoTracking() on prf.CreatedBy equals usr.Id
                                         join usrU in _dbContext.Users.AsNoTracking() on prf.UpdatedBy equals usrU.Id into usrUX
                                         from usrU in usrUX.DefaultIfEmpty()
                                         join opt in _dbContext.LibraryTypes.AsNoTracking() on prf.AssetCategoryId equals opt.Id into optX
                                         from opt in optX.DefaultIfEmpty()
                                         join ch in _dbContext.ChartOfAccounts.AsNoTracking() on prf.RcaSLId equals ch.Id into chX
                                         from ch in chX.DefaultIfEmpty()
                                         orderby prf.Id descending
                                         select new AssetProfileModel()
                                         {
                                             Id = prf.Id,
                                             Name = prf.Name,
                                             Category = opt.Description,
                                             CategoryId = prf.AssetCategoryId,
                                             StatusDate = prf.StatusDate,
                                             Description = prf.Description,
                                             RcaGLId = prf.RcaGLId,
                                             RCASLId = prf.RcaSLId,
                                             AssetClass = prf.AssetClassId ?? 0,
                                             CostCenter = prf.CostCenter ?? 0,
                                             AssetType = prf.AssetType,
                                             IsActive = prf.IsActive,
                                             EconomicLife = prf.EconomicLife,
                                             ResidualLife = prf.ResidualLife,
                                             UDF1 = prf.UDF1,
                                             UDF2 = prf.UDF2,
                                             UDF3 = prf.UDF3,
                                             CreatedBy = prf.CreatedBy,
                                             CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                             CreatedAt = prf.CreatedAt,
                                             UpdatedAt = prf.UpdatedAt,
                                             UpdatedByName = $"{usrU.FirstName} {usrU.LastName}"
                                         }).FirstOrDefaultAsync(t => t.Id == id);
            return await assetProfile;
        }

        public async Task<AssetProfile> Add(AssetProfile assetProfile)
        {
            return await AddAsync(assetProfile);
        }

        public async Task<AssetProfile> Update(AssetProfile assetProfile)
        {
            return await UpdateAsync(assetProfile);
        }
    }
}
