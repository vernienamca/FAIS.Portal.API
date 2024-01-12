using FAIS.ApplicationCore.Entities.Security;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface INotificationRepository
    {
        IQueryable<StringInterpolation> Get();
        StringInterpolation GetById(decimal id);
        Task<StringInterpolation> Add(StringInterpolation stringInterpolation);
        Task<StringInterpolation> Update(StringInterpolation stringInterpolation);
    }
}
