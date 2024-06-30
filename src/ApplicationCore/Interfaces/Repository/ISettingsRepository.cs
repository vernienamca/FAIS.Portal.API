using DocumentFormat.OpenXml.Office2010.ExcelAc;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface ISettingsRepository
    {
        IQueryable<Settings> Get();
        Settings GetById(int id);
        Task <IReadOnlyCollection<EmailModel>> GetRecipients(int settingsId);
        Task<Settings> Add(Settings settings);
        Task<Settings> Update(Settings settings);
    }
}
