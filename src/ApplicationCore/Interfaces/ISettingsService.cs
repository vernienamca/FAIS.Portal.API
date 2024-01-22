using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface ISettingsService
    {
        IQueryable<Settings> Get();
        Settings GetById(int id);
        Task<Settings> Update(int id);
        Task<Settings> UpdateSmtpById(UpdateSmtpRequestDTO updateSmtpRequestDTO);
    }
}
