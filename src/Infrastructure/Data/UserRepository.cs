using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class UserRepository : EFRepository<User, int>, IUserRepository
    {
        public UserRepository(FAISContext context) : base(context)
        {
        }

        public IReadOnlyCollection<UserModel> Get()
        {
            var users = (from usr in _dbContext.Users.AsNoTracking()
                         join pst in _dbContext.LibraryTypes.Where(x => x.Code == "PST").AsNoTracking() on usr.PositionId equals pst.Id into pstX
                         from pst in pstX.DefaultIfEmpty()
                         join div in _dbContext.LibraryTypes.Where(x => x.Code == "DIV").AsNoTracking() on usr.DivisionId equals div.Id into divX
                         from div in divX.DefaultIfEmpty()
                         join ofg in _dbContext.LibraryTypes.Where(t => t.Code == "OUFG").AsNoTracking() on usr.OupFgId equals ofg.Id into ofgX
                         from ofg in ofgX.DefaultIfEmpty()
                         orderby usr.Id descending
                         select new UserModel()
                         {
                            Id = usr.Id,
                            FirstName = usr.FirstName,
                            LastName = usr.LastName,
                            UserName = usr.UserName,
                            Position = pst.Name,
                            Division = div.Name,
                            TAFGs = _dbContext.UserTAFGs.Where(x => x.UserId == usr.Id).AsNoTracking().Join(_dbContext.LibraryTypes.AsNoTracking(), fgs => fgs.TAFGId, lib => lib.Id,
                                (fgs, lib) => new { fgs, lib }).Select(t => t.lib.Name).ToList(),
                            OUFG = ofg.Name,
                            Status = usr.StatusCode,
                            Photo = usr.Photo
                         }).ToList();

            return users;   
        }

        public async Task<User> GetByUserName(string userName)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(t => t.UserName == userName);
        }

        public async Task<User> GetByTempKey(string tempKey)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(t => t.TempKey == tempKey);
        }

        public async Task<User> GetByEmailAddress(string emailAddress)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(t => t.EmailAddress == emailAddress);
        }

        public async Task<User> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<PermissionModel>> GetPermissions(int id)
        {
            List<int> roleIds = await _dbContext.UserRoles.Where(t => t.UserId == id).Select(s => s.RoleId).ToListAsync();

            var permissions = await (from per in _dbContext.RolePermissions.AsNoTracking()
                                    join mod in _dbContext.Modules.AsNoTracking() on per.ModuleId equals mod.Id
                                    where mod.IsActive == 'Y' && roleIds.Contains(per.RoleId)
                                    orderby mod.Sequence, mod.Id
                                    select new PermissionModel()
                                    {
                                        Id = per.Id,
                                        RoleId = per.RoleId,
                                        ModuleId = mod.Id,
                                        ModuleName = mod.Name,
                                        Url = mod.Url,
                                        Icon = mod.Icon,
                                        GroupName = mod.GroupName,
                                        IsCreate = per.IsCreate == 'Y',
                                        IsRead = per.IsRead == 'Y',
                                        IsUpdate = per.IsUpdate == 'Y'
                                    }).ToListAsync();
            return permissions;
        }

        public async Task<List<UserRoleModel>> GetUserRoles(int userId)
        {
            var userRoles = await (from urr in _dbContext.UserRoles.AsNoTracking()
                                   join rol in _dbContext.Roles.AsNoTracking() on urr.RoleId equals rol.Id
                                   join usrC in _dbContext.Users.AsNoTracking() on urr.CreatedBy equals usrC.Id into usrCX
                                   from usrC in usrCX.DefaultIfEmpty()
                                   where urr.UserId == userId
                                   orderby urr.CreatedAt
                                   select new UserRoleModel()
                                   {
                                       Id = rol.Id,
                                       UserRoleId = urr.Id,
                                       Name = rol.Name,
                                       Description = rol.Description,
                                       IsActive = urr.IsActive == 'Y',
                                       StatusDate = urr.IsActive == 'Y' ? urr.StatusDate.ToString() : string.Empty,
                                       CreatedBy = urr.CreatedBy,
                                       CreatedAt = urr.CreatedAt
                                   }).ToListAsync();

            return userRoles;
        }

        public async Task<User> Add(User test)
        {
            return await AddAsync(test);
        }

        public async Task<User> Update(User user)
        {
            return await UpdateAsync(user);
        }

        public void SetUserRoles(int userId, IReadOnlyCollection<UserRoleDTO> userRoles)
        {
            List<UserRole> userRoleToAdd = new List<UserRole>();

            foreach (var role in userRoles)
            {
                if (role.IsNew)
                {
                    userRoleToAdd.Add(new UserRole()
                    {
                        Id = 0,
                        UserId = userId,
                        RoleId = role.Id,
                        IsActive = role.IsActive ? 'Y' : 'N',
                        StatusDate = role.StatusDate,
                        CreatedBy = role.CreatedBy,
                        CreatedAt = DateTime.Now
                    });
                } 
                else
                {
                    var data = _dbContext.UserRoles.FirstOrDefault(t => t.UserId == userId && t.Id == role.UserRoleId);

                    if ((data.IsActive == 'Y') != role.IsActive)
                    {
                        data.IsActive = role.IsActive ? 'Y' : 'N';
                        data.StatusDate = DateTime.Now;
                        data.UpdatedBy = role.UpdatedBy;
                        data.UpdatedAt = DateTime.Now;
                    }
                }
            }

            if (userRoleToAdd.Any())
                base._dbContext.UserRoles.AddRange(userRoleToAdd);
           
            _dbContext.SaveChanges();
        }

        public void SetTAFGs(int userId, IReadOnlyCollection<string> userTAFGs)
        {
            IReadOnlyCollection<UserTAFGModel> tafgs = (from ufg in _dbContext.UserTAFGs.Where(x => x.UserId == userId).AsNoTracking()
                                                        join lib in _dbContext.LibraryTypes.Where(x => x.Code == "TAFG").AsNoTracking() on ufg.TAFGId equals lib.Id
                                                        select new UserTAFGModel
                                                        {
                                                            TAFGId = ufg.TAFGId,
                                                            TAFGName = lib.Name
                                                        }).ToList();

            var tafgsToRemove = (from ufg in tafgs
                                 join tfg in _dbContext.UserTAFGs.Where(x => x.UserId == userId).AsNoTracking() on ufg.TAFGId equals tfg.TAFGId
                                 where !userTAFGs.Select(s => s).Contains(ufg.TAFGName)
                                 select new UserTAFG
                                 {
                                     Id = tfg.Id,
                                     UserId = tfg.UserId,
                                     TAFGId = tfg.TAFGId,
                                     IsActive = tfg.IsActive,
                                     StatusDate = tfg.StatusDate,
                                     CreatedBy = tfg.CreatedBy,
                                     CreatedAt = tfg.CreatedAt,
                                     UpdatedAt = tfg.UpdatedAt,
                                     UpdatedBy = tfg.UpdatedBy
                                 }).ToList();

            if (tafgsToRemove.Any())
                base._dbContext.UserTAFGs.RemoveRange(tafgsToRemove);

            List<UserTAFG> tafgToAdd = new List<UserTAFG>();

            foreach (string tafg in userTAFGs)
            {
                var libraryType = _dbContext.LibraryTypes.FirstOrDefault(t => t.Code == "TAFG" && t.Description == tafg);

                if (!tafgs.Select(s => s.TAFGName).Contains(tafg))
                {
                    tafgToAdd.Add(new UserTAFG()
                    {
                        UserId = userId,
                        TAFGId = libraryType.Id,
                        IsActive = 'Y',
                        StatusDate = DateTime.Now,
                        CreatedBy = 1,
                        CreatedAt = DateTime.Now
                    });
                }
            }

            if (tafgToAdd.Any())
                base._dbContext.UserTAFGs.AddRange(tafgToAdd);

            _dbContext.SaveChanges();
        }

        public async Task<int> GetLastUserId() 
        {
            var lastUserId = await _dbContext.Users.MaxAsync(u => (int?)u.Id) ?? 0;
            return lastUserId;
        }

        public async Task AddTAFGs(IReadOnlyCollection<UserTAFG> userTAFGs)
        {
            foreach (var userTAFG in userTAFGs)
            {
                if (_dbContext.Entry(userTAFG).IsKeySet)
                {
                    _dbContext.Entry(userTAFG).State = EntityState.Detached;
                }
            }
            await _dbContext.UserTAFGs.AddRangeAsync(userTAFGs);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> WriteFile(IFormFile file, string directory)
        {
            if (file == null)
            {
                return string.Empty;
            }

            string filename = file.FileName;
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), directory);

            var exactpath = Path.Combine(filepath, filename);
            using (var stream = new FileStream(exactpath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filename;
        }
    }
}
