﻿using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
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
                         join pst in _dbContext.LibraryOptions.AsNoTracking() on usr.PositionId equals pst.Id into pstX
                         from pst in pstX.DefaultIfEmpty()
                         join div in _dbContext.LibraryOptions.AsNoTracking() on usr.DivisionId equals div.Id into divX
                         from div in divX.DefaultIfEmpty()
                         join ofg in _dbContext.LibraryOptions.AsNoTracking() on usr.OupFgId equals ofg.Id into ofgX
                         from ofg in ofgX.DefaultIfEmpty()
                         orderby usr.Id descending
                         select new UserModel()
                         {
                            Id = usr.Id,
                            FirstName = usr.FirstName,
                            LastName = usr.LastName,
                            UserName = usr.UserName,
                            Position = usr.PositionId,
                            PositionDescription = pst.Description,
                            Division = usr.DivisionId.Value,
                            DivisionDescription = div.Description,
                            OUFG = ofg.Description,
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

        public IReadOnlyCollection<int> GetUserTAFgs(int userId)
        {
            return _dbContext.UserTAFGs.Where(x => x.UserId == userId).Select(t => t.TAFGId).ToList();
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
                                        IsUpdate = per.IsUpdate == 'Y',
                                        Sequence = mod.Sequence.Value
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
                                       IsActive = rol.IsActive == 'Y' ? urr.IsActive == 'Y' : false,
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

        public void SetTAFGs(int userId, IReadOnlyCollection<int> userTAFGs)
        {
            var tafgs = _dbContext.UserTAFGs.Where(x => x.UserId == userId).ToList();

            var tafgsToRemove = (from ufg in tafgs
                                 join tfg in _dbContext.UserTAFGs.Where(x => x.UserId == userId) on ufg.TAFGId equals tfg.TAFGId
                                 where !userTAFGs.Contains(ufg.TAFGId)
                                 select tfg).ToList();

            if (tafgsToRemove.Any())
                base._dbContext.UserTAFGs.RemoveRange(tafgsToRemove);

            var tafgToAdd = userTAFGs.Where(tafg => !tafgs.Any(ufg => ufg.TAFGId == tafg)).Select(tafg => new UserTAFG
            {
                UserId = userId,
                TAFGId = tafg,
                IsActive = 'Y',
                StatusDate = DateTime.Now,
                CreatedBy = 1,
                CreatedAt = DateTime.Now
            }).ToList();

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
