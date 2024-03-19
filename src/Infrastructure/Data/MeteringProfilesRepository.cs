using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Interfaces.Repository;
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
        public IReadOnlyCollection<MeteringProfile> Get()
        {
            return _dbContext.MeteringProfiles.ToList();
        }

        public MeteringProfile GetById(int id)
        {
            var meteringProfile = _dbContext.MeteringProfiles.FirstOrDefault(t => t.Id == id);

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
    }
}
