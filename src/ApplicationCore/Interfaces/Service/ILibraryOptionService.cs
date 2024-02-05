using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface ILibraryOptionService
    {
        IReadOnlyCollection<LibraryOptionModel> Get();
        LibraryOptionModel GetById(int id);

    }
}
