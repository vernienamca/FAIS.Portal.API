﻿using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class LibraryTypeRepository : EFRepository<LibraryType, int>, ILibraryTypeRepository
    {
        public LibraryTypeRepository(FAISContext context) : base(context)
        {
        }

        public IReadOnlyCollection<LibraryTypeModel> Get()
        {
            var libraryTypes = (from lib in _dbContext.LibraryTypes.AsNoTracking()
                                  join usrC in _dbContext.Users.AsNoTracking() on lib.CreatedBy equals usrC.Id
                                  join usrU in _dbContext.Users.AsNoTracking() on lib.UpdatedBy equals usrU.Id into usrUX
                                  from usrU in usrUX.DefaultIfEmpty()
                                  orderby lib.CreatedAt descending
                                  select new LibraryTypeModel()
                                  {
                                      Id = lib.Id,
                                      Name = lib.Name,
                                      Code = lib.Code,
                                      Description = lib.Description,
                                      IsActive = lib.IsActive,
                                      StatusDate = lib.StatusDate,
                                      CreatedBy = $"{usrC.FirstName} {usrC.LastName}",
                                      CreatedAt = lib.CreatedAt,
                                      UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                                      UpdatedAt = lib.UpdatedAt
                                  }).AsNoTracking().ToList();

            return libraryTypes;
        }

        public async Task<LibraryType> GetById(int id)
        {
            return await _dbContext.LibraryTypes.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
        }

        public LibraryType GetPositionIdByName(string positionName)
        {
            return _dbContext.LibraryTypes.AsNoTracking().FirstOrDefault(lt => lt.Name == positionName);
        }

        public LibraryType GetLibraryTypeIdByCode(string description)
        {
            return _dbContext.LibraryTypes.AsNoTracking().FirstOrDefault(lt => lt.Description == description);
        }

        public async Task<LibraryType> Add(LibraryType libraryType)
        {
            return await AddAsync(libraryType);
        }

        public async Task<LibraryType> Update(LibraryType libraryType)
        {
            return await UpdateAsync(libraryType);
        }

        public async Task<LibraryType> GetByCode(string code)
        {
            return await _dbContext.LibraryTypes.FirstOrDefaultAsync(t => t.Code == code);
        }
    }
}
