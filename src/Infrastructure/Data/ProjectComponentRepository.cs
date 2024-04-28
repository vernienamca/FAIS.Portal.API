using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using FAIS.ApplicationCore.Interfaces.Repository;

namespace FAIS.Infrastructure.Data
{
    public class ProjectComponentRepository : EFRepository<ProjectComponent, int>, IProjectComponentRepository
    {
        public ProjectComponentRepository(FAISContext context) : base(context)
        {
        }
        public IReadOnlyCollection<ProjectComponent> Get()
        {
            return _dbContext.ProjectComponent.ToList();
        }

        public List<ProjectComponent> GetById(int id)
        {
            return _dbContext.ProjectComponent.Where(t => t.ProjectSeq == id).AsNoTracking().ToList();
        }
        public async Task<ProjectComponent> Add(ProjectComponent projectComponent)
        {
            return await AddAsync(projectComponent);
        }

        public async Task<ProjectComponent> Update(ProjectComponent projectComponent)
        {
            return await UpdateAsync(projectComponent);
        }
    }
}
