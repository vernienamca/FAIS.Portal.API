using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class StringInterpolationRepository : EFRepository<StringInterpolation, int>, IStringInterpolationRepository
    {
        public StringInterpolationRepository(FAISContext context) : base(context){ }

        public IReadOnlyCollection<StringInterpolationModel> Get()
        {
            var interpolations = (from str in _dbContext.StringInterpolations.AsNoTracking()
                                  join usrC in _dbContext.Users.AsNoTracking() on str.CreatedBy equals usrC.Id
                                  join usrU in _dbContext.Users.AsNoTracking() on str.UpdatedBy equals usrU.Id into usrUX
                                  from usrU in usrUX.DefaultIfEmpty()
                                  select new StringInterpolationModel()
                                  {
                                      Id = str.Id,
                                      TransactionCode = str.TransactionCode,
                                      Description = str.Description,
                                      IsActive = str.IsActive,
                                      StatusDate = str.StatusDate,
                                      NotificationType = str.NotificationType,
                                      CreatedBy = $"{usrC.FirstName} {usrC.LastName}",
                                      CreatedAt = str.CreatedAt,
                                      UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                                      UpdatedAt = str.UpdatedAt,
                                      DateRemoved = str.DateRemoved
                                  }).Where(x => x.DateRemoved == null).ToList();

            return interpolations;
        }

        public async Task<StringInterpolation> GetById(int id)
        {
            return await _dbContext.StringInterpolations.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<StringInterpolation> Add(StringInterpolation interpolation)
        {
            return await AddAsync(interpolation);
        }

        public async Task<StringInterpolation> Update(StringInterpolation interpolation)
        {
            return await UpdateAsync(interpolation);
        }
    }
}
