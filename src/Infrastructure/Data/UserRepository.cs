using DocumentFormat.OpenXml.Office2010.Excel;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class UserRepository : EFRepository<Users, int>, IUserRepository
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

        public async Task<Users> GetByUserName(string userName)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(t => t.UserName == userName);
        }

        public async Task<Users> GetByTempKey(string tempKey)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(t => t.TempKey == tempKey);
        }

        public async Task<Users> GetByEmailAddress(string emailAddress)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(t => t.EmailAddress == emailAddress);
        }

        public async Task<Users> GetById(int id)
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

        public async Task<Users> Add(Users test)
        {
            return await AddAsync(test);
        }

        public async Task<Users> Update(Users test)
        {
            return await UpdateAsync(test);
        }
    }
}
