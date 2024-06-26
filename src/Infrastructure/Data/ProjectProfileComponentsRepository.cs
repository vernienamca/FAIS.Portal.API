using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class ProjectProfileComponentsRepository : EFRepository<ProjectProfileComponent, int>, IProjectProfileComponentsRepository
    {
        public ProjectProfileComponentsRepository(FAISContext context) : base(context)
        {
        }

        public IReadOnlyCollection<ProjectProfileComponent> Get()
        {
            return _dbContext.ProjectProfileComponents.ToList();
        }

        public List<ProjectProfileComponent> GetById(int id)
        {
            return _dbContext.ProjectProfileComponents.Where(t => t.ProjectProfileId == id).AsNoTracking().ToList();
        }

        public async Task<ProjectProfileComponent> GetDetails(int id)
        {
            return await _dbContext.ProjectProfileComponents.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProjectProfileComponent> Add(ProjectProfileComponent projectProfileComponent)
        {
            return await AddAsync(projectProfileComponent);
        }

        public async Task<ProjectProfileComponent> Update(ProjectProfileComponent projectProfileComponent)
        {
            return await UpdateAsync(projectProfileComponent);
        }
    }
}