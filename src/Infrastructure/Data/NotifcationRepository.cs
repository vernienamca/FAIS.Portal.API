using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class NotifcationRepository : EFRepository<StringInterpolation, decimal>, INotificationRepository
    {
        public NotifcationRepository(FAISContext context) : base(context)
        {
        }

        public IQueryable<StringInterpolation> Get()
        {
            return _dbContext.StringInterpolations.OrderByDescending(o => o.CreatedAt).Take(100);
        }

        public StringInterpolation GetById(decimal id)
        {
            return _dbContext.StringInterpolations.Where(t => t.Id == id).ToList()[0];
        }
        public async Task<StringInterpolation> Add(StringInterpolation stringInterpolation)
        {
            return await AddAsync(stringInterpolation);
        }

        public async Task<StringInterpolation> Update(StringInterpolation stringInterpolation)
        {
            return await UpdateAsync(stringInterpolation);
        }
    }
}
