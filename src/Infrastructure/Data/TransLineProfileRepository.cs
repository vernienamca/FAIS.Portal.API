using FAIS.ApplicationCore.Entities;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class TransLineProfileRepository : EFRepository<TransLineProfile, int>, ITransLineProfileRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransLineProfileRepository"/> class.
        /// </summary>
        public TransLineProfileRepository(FAISContext context) : base(context) { }

        public async Task<TransLineProfile> Add(TransLineProfile transLineProfile)
        {
            return await AddAsync(transLineProfile);
        }

        public IReadOnlyCollection<TransLineProfileModel> Get()
        {
            var transLineProfiles = (from cc in _dbContext.TransLineProfiles.AsNoTracking()
                               join usr in _dbContext.Users.AsNoTracking() on cc.CreatedBy equals usr.Id
                               orderby cc.Id descending
                               select new TransLineProfileModel()
                               {
                                   Id = cc.Id,
                                   InstallationYear = cc.InstallationYear,
                                   LineStretch = cc.LineStretch,
                                   NoOfCircuit = cc.NoOfCircuit,
                                   RouteLength = cc.RouteLength,
                                   StatusDate = cc.StatusDate,
                                   TotalStructures = cc.TotalStructures,
                                   VoltageId = cc.VoltageId,
                                   IsActive = cc.IsActive == "Y",
                                   CreatedBy = $"{usr.FirstName} {usr.LastName}",
                                   CreatedAt = cc.CreatedAt
                               }).ToList();

            return transLineProfiles;
        }

        public TransLineProfile GetById(int id)
        {
            return _dbContext.TransLineProfiles.FirstOrDefault(t => t.Id == id);
        }

        public async Task<TransLineProfile> Update(TransLineProfile transLineProfile)
        {
            return await UpdateAsync(transLineProfile);
        }
    }
}
