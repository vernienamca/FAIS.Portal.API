using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class PlantInformationDetailsRepository : EFRepository<PlantInformationDetails, int>, IPlantInformationDetailsRepository
    {
        public PlantInformationDetailsRepository(FAISContext context) : base(context){ }

        public IReadOnlyCollection<PlantInformationDetailModel> Get()
        {
            var piDetail = (from pi in _dbContext.PlantInformationDetails.AsNoTracking()
                                join cc in _dbContext.CostCenters.AsNoTracking() on pi.CostCenter.ToString() equals cc.MCNumber into ccX from cc in ccX.DefaultIfEmpty()
                                join usr in _dbContext.Users.AsNoTracking() on pi.CreatedBy equals usr.Id
                                join usrU in _dbContext.Users.AsNoTracking() on pi.UpdatedBy equals usrU.Id into usrUX from usrU in usrUX.DefaultIfEmpty()
                                orderby pi.CreatedAt descending
                                select new PlantInformationDetailModel()
                                {
                                    Id = pi.Id,
                                    PlantCode = pi.PlantCode,
                                    CostCenterType = pi.CostCenter,
                                    RemovedAt = pi.RemovedAt,
                                    CreatedBy = pi.CreatedBy,
                                    CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                    CreatedAt = pi.CreatedAt,
                                    UpdatedBy = pi.UpdatedBy,
                                    UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                    UpdatedAt = pi.UpdatedAt
                                }).ToList();
            return piDetail;
        }

        public async Task<PlantInformationDetailModel> GetById(int id)
        {
            var piDetail = (from pi in _dbContext.PlantInformationDetails.AsNoTracking()
                             join cc in _dbContext.CostCenters.AsNoTracking() on pi.CostCenter.ToString() equals cc.MCNumber into ccX
                             from cc in ccX.DefaultIfEmpty()
                             join usr in _dbContext.Users.AsNoTracking() on pi.CreatedBy equals usr.Id
                             join usrU in _dbContext.Users.AsNoTracking() on pi.UpdatedBy equals usrU.Id into usrUX
                             from usrU in usrUX.DefaultIfEmpty()
                             orderby pi.CreatedAt descending
                             select new PlantInformationDetailModel()
                             {
                                 Id = pi.Id,
                                 PlantCode = pi.PlantCode,
                                 CostCenterType = pi.CostCenter,
                                 RemovedAt = pi.RemovedAt,
                                 CreatedBy = pi.CreatedBy,
                                 CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                 CreatedAt = pi.CreatedAt,
                                 UpdatedBy = pi.UpdatedBy,
                                 UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                 UpdatedAt = pi.UpdatedAt
                             }).FirstOrDefaultAsync(t => t.Id == id);

            return await piDetail;
        }

        public IReadOnlyCollection<PlantInformationDetails> GetByPlantCode(string code)
        {
            return _dbContext.PlantInformationDetails.AsNoTracking().Where(t => t.PlantCode == code).ToList();
        }

        public async Task<PlantInformationDetails> GetDetails(int id)
        {
            return await _dbContext.PlantInformationDetails.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PlantInformationDetails> Add(PlantInformationDetails dto)
        {
            return await AddAsync(dto);
        }

        public async Task<PlantInformationDetails> Update(PlantInformationDetails dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
