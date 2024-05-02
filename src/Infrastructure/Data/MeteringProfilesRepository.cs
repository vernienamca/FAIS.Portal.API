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
                                    join library_type in _dbContext.LibraryTypes.AsNoTracking() on metering.InstallationTypeSeq equals library_type.Id into library_typeUX
                                    from library_type in library_typeUX.DefaultIfEmpty()
                                    join meteringType in _dbContext.LibraryTypes.AsNoTracking() on metering.MeteringClass equals meteringType.Id into meteringTypeUX
                                    from meteringType in meteringTypeUX.DefaultIfEmpty()
                                    join transmissionGrid in _dbContext.LibraryTypes.AsNoTracking() on metering.MeteringClass equals transmissionGrid.Id into transmissionGridUX
                                    from transmissionGrid in transmissionGridUX.DefaultIfEmpty()
                                    join district in _dbContext.LibraryTypes.AsNoTracking() on metering.MeteringClass equals district.Id into districtUX
                                    from district in districtUX.DefaultIfEmpty()
                                    join facility in _dbContext.LibraryTypes.AsNoTracking() on metering.MeteringClass equals facility.Id into facilityUX
                                    from facility in facilityUX.DefaultIfEmpty()
                                    orderby metering.Id descending
                                    select new MeteringProfileModel()
                                    {
                                        Id = metering.Id,
                                        TransGrid = metering.TransGrid,
                                        TransGridDescription = transmissionGrid.Description,
                                        DistrictSeq = metering.DistrictSeq,
                                        DistrictDescription = district.Description,
                                        Customer = metering.Customer,
                                        MeteringPointName = metering.MeteringPointName,
                                        MeteringClassDescription = meteringType.Description,
                                        InstallationTypeDescription = library_type.Description,
                                        InstallationTypeSeq = metering.InstallationTypeSeq,
                                        FacilityLocationSeq = metering.FacilityLocationSeq,
                                        FacilityLocationDescription = facility.Description,
                                        Remarks = metering.Remarks,
                                        UDF1 = metering.UDF1,
                                        UDF2 = metering.UDF2,
                                        UDF3 = metering.UDF3,
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
                                   join library_type in _dbContext.LibraryTypes.AsNoTracking() on metering.InstallationTypeSeq equals library_type.Id into library_typeUX
                                   from library_type in library_typeUX.DefaultIfEmpty()
                                   join meteringType in _dbContext.LibraryTypes.AsNoTracking() on metering.MeteringClass equals meteringType.Id into meteringTypeUX
                                   from meteringType in meteringTypeUX.DefaultIfEmpty()
                                   join transmissionGrid in _dbContext.LibraryTypes.AsNoTracking() on metering.MeteringClass equals transmissionGrid.Id into transmissionGridUX
                                   from transmissionGrid in transmissionGridUX.DefaultIfEmpty()
                                   join district in _dbContext.LibraryTypes.AsNoTracking() on metering.MeteringClass equals district.Id into districtUX
                                   from district in districtUX.DefaultIfEmpty()
                                   join facility in _dbContext.LibraryTypes.AsNoTracking() on metering.MeteringClass equals facility.Id into facilityUX
                                   from facility in facilityUX.DefaultIfEmpty()
                                   orderby metering.Id descending
                                   select new MeteringProfileModel()
                                   {
                                       Id = metering.Id,
                                       TransGrid = metering.TransGrid,
                                       TransGridDescription = transmissionGrid.Description,
                                       DistrictSeq = metering.DistrictSeq,
                                       DistrictDescription = district.Description,
                                       Customer = metering.Customer,
                                       MeteringPointName = metering.MeteringPointName,
                                       MeteringClassDescription = meteringType.Description,
                                       InstallationTypeDescription = library_type.Description,
                                       InstallationTypeSeq = metering.InstallationTypeSeq,
                                       FacilityLocationSeq = metering.FacilityLocationSeq,
                                       FacilityLocationDescription = facility.Description,
                                       Remarks = metering.Remarks,
                                       UDF1 = metering.UDF1,
                                       UDF2 = metering.UDF2,
                                       UDF3 = metering.UDF3,
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