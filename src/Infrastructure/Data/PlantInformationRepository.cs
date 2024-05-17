using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class PlantInformationRepository : EFRepository<PlantInformation, string>, IPlantInformationRepository
    {
        public PlantInformationRepository(FAISContext context) : base(context){ }

        public IReadOnlyCollection<PlantInformationModel> Get()
        {
            var plantInfo = (from pi in _dbContext.PlantInformation.AsNoTracking()
                                join usr in _dbContext.Users.AsNoTracking() on pi.CreatedBy equals usr.Id
                                join usrU in _dbContext.Users.AsNoTracking() on pi.UpdatedBy equals usrU.Id into usrUX from usrU in usrUX.DefaultIfEmpty()
                                orderby pi.CreatedAt descending
                                select new PlantInformationModel()
                                {
                                    PlantCode = pi.PlantCode,
                                    SubstationName = pi.SubstationName,
                                    SubstationNameOld = pi.SubstationNameOld,
                                    TransGrid = pi.TransGrid,
                                    TransGridDescription = string.Empty,
                                    DistrictId = pi.DistrictId,
                                    DistrictName = string.Empty,
                                    GmapCoord = pi.GmapCoord,
                                    CommissionDate = pi.CommissionDate,
                                    IsActive = pi.IsActive,

                                    CreatedBy = pi.CreatedBy,
                                    CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                    CreatedAt = pi.CreatedAt,
                                    UpdatedBy = pi.UpdatedBy,
                                    UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                    UpdatedAt = pi.UpdatedAt
                                }).ToList();
            return plantInfo;
        }

        public async Task<PlantInformationModel> GetByCode(string plantCode)
        {
            var plantInfo = (from pi in _dbContext.PlantInformation.AsNoTracking()
                             join usr in _dbContext.Users.AsNoTracking() on pi.CreatedBy equals usr.Id
                             join usrU in _dbContext.Users.AsNoTracking() on pi.UpdatedBy equals usrU.Id into usrUX
                             from usrU in usrUX.DefaultIfEmpty()
                             orderby pi.CreatedAt descending
                             select new PlantInformationModel()
                             {
                                 PlantCode = pi.PlantCode,
                                 SubstationName = pi.SubstationName,
                                 SubstationNameOld = pi.SubstationNameOld,
                                 TransGrid = pi.TransGrid,
                                 TransGridDescription = string.Empty,
                                 DistrictId = pi.DistrictId,
                                 DistrictName = string.Empty,
                                 GmapCoord = pi.GmapCoord,
                                 CommissionDate = pi.CommissionDate,
                                 IsActive = pi.IsActive,

                                 ClassId = pi.ClassId,
                                 MtdId = pi.MtdId,
                                 UDF1 = pi.UDF1,
                                 UDF2 = pi.UDF2,
                                 UDF3 = pi.UDF3,
                                 RegionId = pi.RegionId,
                                 ProvId = pi.ProvId,
                                 MunId = pi.MunId,
                                 BrgyId = pi.BrgyId,
                                 StatusDate = pi.StatusDate,

                                 CreatedBy = pi.CreatedBy,
                                 CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                 CreatedAt = pi.CreatedAt,
                                 UpdatedBy = pi.UpdatedBy,
                                 UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                 UpdatedAt = pi.UpdatedAt
                             }).FirstOrDefaultAsync(t => t.PlantCode == plantCode);

            return await plantInfo;
        }

        public async Task<PlantInformation> Add(PlantInformation dto)
        {
            return await AddAsync(dto);
        }

        public async Task<PlantInformation> Update(PlantInformation dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
