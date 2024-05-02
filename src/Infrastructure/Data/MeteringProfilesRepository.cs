using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class MeteringProfilesRepository : EFRepository<MeteringProfile, int>, IMeteringProfileRepository
    {
        public MeteringProfilesRepository(FAISContext context) : base(context)
        {
        }

        public IReadOnlyCollection<MeteringProfileModel> Get()
        {
            var meteringProfiles = (from metering in _dbContext.MeteringProfiles.AsNoTracking()
                                    join usr in _dbContext.Users.AsNoTracking() on metering.CreatedBy equals usr.Id
                                    join usrU in _dbContext.Users.AsNoTracking() on metering.UpdatedBy equals usrU.Id into usrUX
                                    from usrU in usrUX.DefaultIfEmpty()
                                    orderby metering.Id descending
                                    select new MeteringProfileModel()
                                    {
                                        Id = metering.Id,
                                        TransGrid = metering.TransGrid,
                                        DistrictSeq = metering.DistrictSeq,
                                        Customer = metering.Customer,
                                        MeteringPointName = metering.MeteringPointName,
                                        InstallationTypeSeq = metering.InstallationTypeSeq,
                                        FacilityLocationSeq = metering.FacilityLocationSeq,
                                        Remarks = metering.Remarks,
                                        AdRegionSeq = metering.AdRegionSeq,
                                        AdProvSeq = metering.AdProvSeq,
                                        AdMunSeq = metering.AdMunSeq,
                                        AdBrgySeq = metering.AdBrgySeq,
                                        IsActive = metering.IsActive,
                                        CreatedBy = metering.CreatedBy,
                                        CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                        CreatedAt = metering.CreatedAt,
                                        UpdatedBy = metering.UpdatedBy,
                                        UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                        UpdatedAt = metering.UpdatedAt
                                    }).ToList();

            return meteringProfiles;
        }

        public MeteringProfileModel GetById(int id)
        {
            var meteringProfile = (from metering in _dbContext.MeteringProfiles.AsNoTracking()
                                   join usr in _dbContext.Users.AsNoTracking() on metering.CreatedBy equals usr.Id
                                   join usrU in _dbContext.Users.AsNoTracking() on metering.UpdatedBy equals usrU.Id into usrUX
                                   from usrU in usrUX.DefaultIfEmpty()
                                   orderby metering.Id descending
                                   select new MeteringProfileModel()
                                   {
                                       Id = metering.Id,
                                       TransGrid = metering.TransGrid,
                                       DistrictSeq = metering.DistrictSeq,
                                       Customer = metering.Customer,
                                       MeteringPointName = metering.MeteringPointName,
                                       InstallationTypeSeq = metering.InstallationTypeSeq,
                                       FacilityLocationSeq = metering.FacilityLocationSeq,
                                       Remarks = metering.Remarks,
                                       AdRegionSeq = metering.AdRegionSeq,
                                       AdProvSeq = metering.AdProvSeq,
                                       AdMunSeq = metering.AdMunSeq,
                                       AdBrgySeq = metering.AdBrgySeq,
                                       IsActive = metering.IsActive,
                                       CreatedBy = metering.CreatedBy,
                                       CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                       CreatedAt = metering.CreatedAt,
                                       UpdatedBy = metering.UpdatedBy,
                                       UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                       UpdatedAt = metering.UpdatedAt
                                   }).FirstOrDefault(t => t.Id == id);

            return meteringProfile;
        }

        public async Task<MeteringProfile> Add(MeteringProfile meteringProfile)
        {
            return await AddAsync(meteringProfile);
        }

        public async Task<MeteringProfile> Update(MeteringProfile meteringProfile)
        {
            return await UpdateAsync(meteringProfile);
        }

        public IReadOnlyCollection<GenericDTO> GetRegions()
        {
            return new List<GenericDTO> {
                new GenericDTO { Id = 1, Description ="Region 1"},
                new GenericDTO { Id = 2, Description ="Region 2"},
                new GenericDTO { Id = 3, Description ="Region 3"},
                new GenericDTO { Id = 4, Description ="Region 4"},
                new GenericDTO { Id = 5, Description ="Region 5"}
            };
        }

        public IReadOnlyCollection<GenericDTO> GetProvices()
        {
            return new List<GenericDTO> {
                new GenericDTO { Id = 1, Description ="Cotabato"},
                new GenericDTO { Id = 2, Description ="Davao"},
                new GenericDTO { Id = 3, Description ="Zambales"},
                new GenericDTO { Id = 4, Description ="Rizal"},
                new GenericDTO { Id = 5, Description ="Mindoro"}
            };
        }

        public IReadOnlyCollection<GenericDTO> GetMunicipality()
        {
            return new List<GenericDTO> {
                new GenericDTO { Id = 1, Description ="Quezon City"},
                new GenericDTO { Id = 2, Description ="Angono"},
                new GenericDTO { Id = 3, Description ="Binangonan"},
                new GenericDTO { Id = 4, Description ="Tanay"},
                new GenericDTO { Id = 5, Description ="Baras"}
            };
        }

        public IReadOnlyCollection<GenericDTO> GetBarangay()
        {
            return new List<GenericDTO> {
                new GenericDTO { Id = 1, Description ="Sto. Nino"},
                new GenericDTO { Id = 2, Description ="Dolores"},
                new GenericDTO { Id = 3, Description ="San Juan"},
                new GenericDTO { Id = 4, Description ="Sto. Tomas"},
                new GenericDTO { Id = 5, Description ="Calawis"}
            };
        }
    }
}