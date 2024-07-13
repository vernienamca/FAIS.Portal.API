using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IFieldDictionaryRepository
    {
        IReadOnlyCollection<FieldDictionaryModel> Get();
        Task<FieldDictionaryModel> GetById(int id);
        Task<FieldDictionary> GetByTableId(int id);
        Task<FieldDictionary> Add(FieldDictionary dto);
        Task<FieldDictionary> Update(FieldDictionary dto);
    }
}
