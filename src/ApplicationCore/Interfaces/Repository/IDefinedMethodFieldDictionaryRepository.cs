using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IDefinedMethodFieldDictionaryRepository
    {
        IReadOnlyCollection<DefinedMethodFieldDictionary> Get();
        Task<DefinedMethodFieldDictionary> GetById(int id);
        Task<DefinedMethodFieldDictionary> Add(DefinedMethodFieldDictionary dto);
        Task<DefinedMethodFieldDictionary> Update(DefinedMethodFieldDictionary dto);
    }
}
