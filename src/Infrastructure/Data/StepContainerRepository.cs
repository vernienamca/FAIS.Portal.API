using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class StepContainerRepository : EFRepository<StepContainer, int>, IStepContatinerRepository
    {
        public StepContainerRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<StepContainer> Get()
        {
            return _dbContext.StepContainers.AsNoTracking().ToList();
        }

        public async Task<StepContainer> GetById(int id)
        {
            return await _dbContext.StepContainers.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<StepContainer> Add(StepContainer dto)
        {
            return await AddAsync(dto);
        }

        public async Task<StepContainer> Update(StepContainer dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
