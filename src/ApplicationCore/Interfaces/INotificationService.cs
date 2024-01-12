using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface INotificationService
    {
        IQueryable<StringInterpolation> Get();
        StringInterpolation GetById(decimal id);
        Task<StringInterpolation> AddStringInterpolation(StringInterpolationDTO userDTO);
        Task<StringInterpolation> UpdateStringInterpolation(decimal id, StringInterpolationDTO userDTO);
    }
}
