using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class ProjectProfilesRepository : EFRepository<ProjectProfile, int>, IProjectProfileRepository
    {
        public ProjectProfilesRepository(FAISContext context) : base(context)
        {
        }

        public IReadOnlyCollection<ProjectProfile> Get()
        {
            return _dbContext.ProjectProfile.ToList();
        }

        public ProjectProfile GetById(int id)
        {
            var projectProfile = _dbContext.ProjectProfile.FirstOrDefault(t => t.Id == id);

            if (projectProfile != null)
            {
                var projectProfileComponents = _dbContext.ProjectProfileComponents.Where(t => t.ProjectProfileId == id).ToList();
                projectProfile.ProjectProfileComponents = projectProfileComponents;

                return projectProfile;
            }

            return null;
        }

        public async Task<ProjectProfile> Add(ProjectProfile projectProfile)
        {
            return await AddAsync(projectProfile);
        }

        public async Task<ProjectProfile> Update(ProjectProfile projectProfile)
        {
            return await UpdateAsync(projectProfile);
        }
    }
}