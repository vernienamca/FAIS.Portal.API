using DocumentFormat.OpenXml.Office2010.Excel;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                         join div in _dbContext.LibraryTypes.Where(x => x.Code == "DIV").AsNoTracking() on usr.DivisionId equals div.Id
                         join ofg in _dbContext.LibraryTypes.Where(t => t.Code == "OUFG").AsNoTracking() on usr.OupFgId equals ofg.Id
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
                            Status = usr.StatusCode
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

        public async Task<User> Add(User test)
        {
            return await AddAsync(test);
        }
        public async Task<User> Update(User user)
        {
            return await UpdateAsync(user);
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
            string filename = "";
                filename = file.FileName;
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
