﻿using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface ITemplateRepository
    {
        IReadOnlyCollection<TemplateModel> Get();
        Task<TemplateModel> GetById(int id);
        Task<Template> Add(Template interpolation);
        Task<Template> Update(Template interpolation);
        Task<Template> Delete(int id);

    }
}
