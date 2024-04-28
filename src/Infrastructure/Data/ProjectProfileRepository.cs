using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class ProjectProfileRepository : EFRepository<ProjectProfile, int>, IProjectProfileRepository
    {
        public ProjectProfileRepository(FAISContext context) : base(context)
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

                var projectComponents = _dbContext.ProjectComponent.Where(t => t.ProjectSeq == id && t.DeletedAt == null).ToList();
                projectProfile.ProjectComponentsDTO = projectComponents;

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
