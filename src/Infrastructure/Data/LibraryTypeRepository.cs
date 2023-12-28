using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class LibraryTypeRepository : EFRepository<LibraryType, int>, ILibraryTypeRepository
    {
        public LibraryTypeRepository(FAISContext context) : base(context)
        {
        }

        public IQueryable<LibraryType> Get()
        {
            return _dbContext.LibraryTypes;
        }

        public LibraryType GetById(decimal id)
        {
            return _dbContext.LibraryTypes.Where(t => t.Id == id).ToList()[0];
        }

        public List<string> GetLibraryNamesByCode(string libraryCode)
        {
            return _dbContext.LibraryTypes.Where(l => l.Code == libraryCode).Select(l => l.Description).Distinct().ToList();
        }

        public async Task<LibraryType> GetPositionIdByName(string positionName)
        {
            return await _dbContext.LibraryTypes.FirstOrDefaultAsync(lt => lt.Name == positionName);
        }

    }
}
