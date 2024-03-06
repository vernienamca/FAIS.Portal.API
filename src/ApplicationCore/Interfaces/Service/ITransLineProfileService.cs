using FAIS.ApplicationCore.Entities;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface ITransLineProfileService
    {
        IReadOnlyCollection<TransLineProfileModel> Get();
        TransLineProfile GetById(int id);
    }
}
