using FAIS.ApplicationCore.DTOs;
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
            var plantInfos = (from pnt in _dbContext.PlantInformation.AsNoTracking()
                             join usr in _dbContext.Users.AsNoTracking() on pnt.CreatedBy equals usr.Id
                             join usrU in _dbContext.Users.AsNoTracking() on pnt.UpdatedBy equals usrU.Id into usrUX 
                             from usrU in usrUX.DefaultIfEmpty()
                             join trs in _dbContext.LibraryOptions.AsNoTracking() on pnt.TransGrid equals trs.Id into trsX 
                             from trs in trsX.DefaultIfEmpty()
                             join dis in _dbContext.LibraryOptions.AsNoTracking() on pnt.DistrictId equals dis.Id into disX 
                             from dis in disX.DefaultIfEmpty()
                             orderby pnt.CreatedAt descending
                             select new PlantInformationModel()
                             {
                                 PlantCode = pnt.PlantCode,
                                 SubstationName = pnt.SubstationName,
                                 SubstationNameOld = pnt.SubstationNameOld,
                                 TransGrid = pnt.TransGrid,
                                 TransGridDescription = trs.Description,
                                 DistrictId = pnt.DistrictId,
                                 DistrictName = dis.Description,
                                 GmapCoord = pnt.GmapCoord,
                                 CommissionDate = pnt.CommissionDate,
                                 IsActive = pnt.IsActive,
                                 CreatedBy = pnt.CreatedBy,
                                 CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                 CreatedAt = pnt.CreatedAt,
                                 UpdatedBy = pnt.UpdatedBy,
                                 UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                 UpdatedAt = pnt.UpdatedAt
                             }).ToList();

            return plantInfos;
        }

        public PlantInformationModel GetById(string id)
        {
            var plantInfo = (from pnt in _dbContext.PlantInformation.AsNoTracking()
                             join usr in _dbContext.Users.AsNoTracking() on pnt.CreatedBy equals usr.Id
                             join usrU in _dbContext.Users.AsNoTracking() on pnt.UpdatedBy equals usrU.Id into usrUX
                             from usrU in usrUX.DefaultIfEmpty()
                             orderby pnt.CreatedAt descending
                             select new PlantInformationModel()
                             {
                                 PlantCode = pnt.PlantCode,
                                 SubstationName = pnt.SubstationName,
                                 SubstationNameOld = pnt.SubstationNameOld,
                                 TransGrid = pnt.TransGrid,
                                 TransGridDescription = string.Empty,
                                 DistrictId = pnt.DistrictId,
                                 DistrictName = string.Empty,
                                 GmapCoord = pnt.GmapCoord,
                                 CommissionDate = pnt.CommissionDate,
                                 IsActive = pnt.IsActive,
                                 ClassId = pnt.ClassId,
                                 MtdId = pnt.MtdId,
                                 UDF1 = pnt.UDF1,
                                 UDF2 = pnt.UDF2,
                                 UDF3 = pnt.UDF3,
                                 RegionId = pnt.RegionId,
                                 ProvId = pnt.ProvId,
                                 MunId = pnt.MunId,
                                 BrgyId = pnt.BrgyId,
                                 StatusDate = pnt.StatusDate,
                                 CreatedBy = pnt.CreatedBy,
                                 CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                 CreatedAt = pnt.CreatedAt,
                                 UpdatedBy = pnt.UpdatedBy,
                                 UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                 UpdatedAt = pnt.UpdatedAt
                             }).FirstOrDefault(t => t.PlantCode == id);

            if (plantInfo != null)
            {
                plantInfo.Details = (from pid in _dbContext.PlantInformationDetails
                                     orderby pid.CreatedAt descending
                                     select new PlantInformationDetailModel()
                                     {
                                         Id = pid.Id,
                                         PlantCode = pid.PlantCode,
                                         CostCenterType = pid.CostCenter,
                                         CostCenterNo = pid.CostCenterNo,
                                         RemovedAt = pid.RemovedAt,
                                         UpdatedAt = pid.UpdatedAt
                                     }).Where(x => x.PlantCode == id && !x.RemovedAt.HasValue).ToList();
            }

            return plantInfo;
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
