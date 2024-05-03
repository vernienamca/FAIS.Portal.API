using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class TransmissionLineProfileRepository : EFRepository<TransmissionLineProfile, int>, ITransmissionLineProfileRepository
    {
        public TransmissionLineProfileRepository(FAISContext context) : base(context){}

        public IReadOnlyCollection<TransmissionLineProfileModel> Get()
        {
            var transProfile = (from trns in _dbContext.TransmissionLineProfile.AsNoTracking()
                                join usr in _dbContext.Users.AsNoTracking() on trns.CreatedBy equals usr.Id
                                join usrU in _dbContext.Users.AsNoTracking() on trns.UpdatedBy equals usrU.Id into usrUX from usrU in usrUX.DefaultIfEmpty()
                                orderby trns.Id descending
                                select new TransmissionLineProfileModel()
                                {
                                    Id = trns.Id,
                                    LineStretch = trns.LineStretch,
                                    VoltageId = trns.VoltageId,
                                    ST = trns.ST,
                                    SP = trns.SP,
                                    CP = trns.CP,
                                    WP = trns.WP,
                                    SLWT = trns.SLWT,
                                    InstallationDate = trns.InstallationDate,
                                    RouteLength = trns.RouteLength,
                                    NoCircuitId = trns.NoCircuitId,
                                    CircuitLength = trns.CircuitLength,
                                    NoConductor = trns.NoConductor,
                                    ConductorSize = trns.ConductorSize,
                                    Remarks = trns.Remarks,
                                    UDF1 = trns.UDF1,
                                    UDF2 = trns.UDF2,
                                    UDF3 = trns.UDF3,
                                    CreatedBy = trns.CreatedBy,
                                    CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                    CreatedAt = trns.CreatedAt,
                                    UpdatedBy = trns.UpdatedBy,
                                    UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                    UpdatedAt = trns.UpdatedAt
                                }).ToList();
            return transProfile;
        }

        public async Task<TransmissionLineProfileModel> GetById(int id)
        {
            var transProfile = (from trns in _dbContext.TransmissionLineProfile.AsNoTracking()
                                join usr in _dbContext.Users.AsNoTracking() on trns.CreatedBy equals usr.Id
                                join usrU in _dbContext.Users.AsNoTracking() on trns.UpdatedBy equals usrU.Id into usrUX
                                from usrU in usrUX.DefaultIfEmpty()
                                orderby trns.Id descending
                                select new TransmissionLineProfileModel()
                                {
                                    Id = trns.Id,
                                    LineStretch = trns.LineStretch,
                                    VoltageId = trns.VoltageId,
                                    ST = trns.ST,
                                    SP = trns.SP,
                                    CP = trns.CP,
                                    WP = trns.WP,
                                    SLWT = trns.SLWT,
                                    InstallationDate = trns.InstallationDate,
                                    RouteLength = trns.RouteLength,
                                    NoCircuitId = trns.NoCircuitId,
                                    CircuitLength = trns.CircuitLength,
                                    NoConductor = trns.NoConductor,
                                    ConductorSize = trns.ConductorSize,
                                    Remarks = trns.Remarks,
                                    UDF1 = trns.UDF1,
                                    UDF2 = trns.UDF2,
                                    UDF3 = trns.UDF3,
                                    CreatedBy = trns.CreatedBy,
                                    CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                    CreatedAt = trns.CreatedAt,
                                    UpdatedBy = trns.UpdatedBy,
                                    UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                    UpdatedAt = trns.UpdatedAt
                                }).FirstOrDefaultAsync(t => t.Id == id);
            return await transProfile;
        }

        public async Task<TransmissionLineProfile> Add(TransmissionLineProfile transProfile)
        {
            return await AddAsync(transProfile);
        }

        public async Task<TransmissionLineProfile> Update(TransmissionLineProfile transProfile)
        {
            return await UpdateAsync(transProfile);
        }
    }
}
