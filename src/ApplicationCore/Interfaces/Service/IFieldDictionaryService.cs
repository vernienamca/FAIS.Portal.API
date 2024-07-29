using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IFieldDictionaryService
    {
        IReadOnlyCollection<FieldDictionaryModel> Get();
        Task<FieldDictionaryModel> GetById(int id);
        Task<FieldDictionary> Add(FieldDictionaryDTO dto);
        Task<FieldDictionary> Update(FieldDictionaryDTO dto);
    }
}
