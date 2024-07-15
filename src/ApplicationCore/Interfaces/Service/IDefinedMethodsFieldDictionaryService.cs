using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IDefinedMethodsFieldDictionaryService
    {
        IReadOnlyCollection<DefinedMethodsFieldDictionaryModel> Get();
        Task<DefinedMethodsFieldDictionaryModel> GetById(int id);
        Task<DefinedMethodsFieldDictionary> Add(DefinedMethodsFieldDictionaryDTO dto);
        Task<DefinedMethodsFieldDictionary> Update(DefinedMethodsFieldDictionaryDTO dto);
    }
}
