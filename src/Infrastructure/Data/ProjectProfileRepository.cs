using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace FAIS.Infrastructure.Data
{
    public class ProjectProfilesRepository : EFRepository<ProjectProfile, int>, IProjectProfileRepository
    {
        public ProjectProfilesRepository(FAISContext context) : base(context){}
        public IReadOnlyCollection<ProjectProfile> Get()
        {
            return _dbContext.ProjectProfile.ToList();
        }
    }
}
