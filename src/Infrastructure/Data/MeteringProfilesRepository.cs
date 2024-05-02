using FAIS.ApplicationCore.DTOs.Structure;
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