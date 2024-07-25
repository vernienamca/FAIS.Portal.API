using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IDefinedMethodsFieldDictionaryRepository
    {
        IReadOnlyCollection<DefinedMethodsFieldDictionaryModel> Get();
        Task<DefinedMethodsFieldDictionaryModel> GetById(int id);
        Task<DefinedMethodsFieldDictionary> Add(DefinedMethodsFieldDictionary dto);
        Task<DefinedMethodsFieldDictionary> Update(DefinedMethodsFieldDictionary dto);
    }
}
