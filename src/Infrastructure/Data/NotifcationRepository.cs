using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System.Linq;

namespace FAIS.Infrastructure.Data
{
    public class NotifcationRepository : EFRepository<StringInterpolation, decimal>, INotificationRepository
    {
        public NotifcationRepository(FAISContext context) : base(context)
        {
        }

        public IQueryable<StringInterpolation> Get()
        {
            // take latest 100 records only.
            return _dbContext.StringInterpolations.OrderByDescending(o => o.CreatedAt).Take(100);
        }

        public StringInterpolation GetById(decimal id)
        {
            return _dbContext.StringInterpolations.Where(t => t.Id == id).ToList()[0];
        }
    }
}
