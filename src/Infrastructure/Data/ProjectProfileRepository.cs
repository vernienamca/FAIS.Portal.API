using DocumentFormat.OpenXml.Office2010.Excel;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class ProjectProfilesRepository : EFRepository<ProjectProfile, int>, IProjectProfileRepository
    {
        public ProjectProfilesRepository(FAISContext context) : base(context)
        {
        }

        public IReadOnlyCollection<ProjectProfileModel> Get()
        {
            var projectProfiles = (from prj in _dbContext.ProjectProfile.AsNoTracking().Include(x => x.ProjectProfileComponents)
                                   join opt in _dbContext.LibraryOptions.AsNoTracking() on prj.ProjStageSeq equals opt.Id into optX
                                   from opt in optX.DefaultIfEmpty()
                                   join opt2 in _dbContext.LibraryOptions.AsNoTracking() on prj.ProjClassSeq equals opt2.Id into opt2X
                                   from opt2 in opt2X.DefaultIfEmpty()
                                   orderby prj.Id descending
                                   select new ProjectProfileModel()
                                   {
                                       Id = prj.Id,
                                       ProjectName = prj.ProjectName,
                                       ProjStageSeq = prj.ProjStageSeq,
                                       ProjectStageName = opt.Description,
                                       ProjClassSeq = prj.ProjClassSeq,
                                       ProjectClassName = opt2.Description,
                                       NoOfComponentsCompleted = _dbContext.ProjectProfileComponents.AsNoTracking().Where(i => i.ProjectProfileId == prj.Id && i.CompletionDate != null).Count(),
                                       NoOfComponentsUnderConstruction = _dbContext.ProjectProfileComponents.AsNoTracking().Where(i => i.ProjectProfileId == prj.Id && i.CompletionDate == null).Count(),
                                       TpsrMonth = prj.TpsrMonth,
                                       LatestInspectionDate = null,
                                       TotalAmrCost = 0,
                                       RecordedAMR = 0,
                                       UnrecordedAMR = 0,
                                       Remarks = prj.Remarks
                                   }).ToList();

            return projectProfiles;
        }

        public ProjectProfileModel GetById(int id)
        {
            var projectProfile = (from prj in _dbContext.ProjectProfile.AsNoTracking().Include(x => x.ProjectProfileComponents)
                                    join opt in _dbContext.LibraryOptions.AsNoTracking() on prj.ProjStageSeq equals opt.Id into optX
                                    from opt in optX.DefaultIfEmpty()
                                    join opt2 in _dbContext.LibraryOptions.AsNoTracking() on prj.ProjClassSeq equals opt2.Id into opt2X
                                    from opt2 in opt2X.DefaultIfEmpty()
                                    join usr in _dbContext.Users.AsNoTracking() on prj.CreatedBy equals usr.Id
                                    join usrU in _dbContext.Users.AsNoTracking() on prj.UpdatedBy equals usrU.Id into usrUX
                                    from usrU in usrUX.DefaultIfEmpty()
                                  select new ProjectProfileModel()
                                   {
                                        Id = prj.Id,
                                        ProjectName = prj.ProjectName,
                                        ProjStageSeq = prj.ProjStageSeq,
                                        ProjectStageName = opt.Description,
                                        ProjClassSeq = prj.ProjClassSeq,
                                        ProjectClassName = opt2.Description,
                                        NoOfComponentsCompleted = _dbContext.ProjectProfileComponents.AsNoTracking().Where(i => i.ProjectProfileId == prj.Id && i.CompletionDate != null).Count(),
                                        NoOfComponentsUnderConstruction = _dbContext.ProjectProfileComponents.AsNoTracking().Where(i => i.ProjectProfileId == prj.Id && i.CompletionDate == null).Count(),
                                        TpsrMonth = prj.TpsrMonth,
                                        TotalAmrCost = 0,
                                        RecordedAMR = 0,
                                        UnrecordedAMR = 0,
                                        IsActive = prj.IsActive,
                                        UDF1 = prj.UDF1,
                                        UDF2 = prj.UDF2,
                                        UDF3 = prj.UDF3,
                                        Remarks = prj.Remarks,
                                        CreatedAt = prj.CreatedAt,
                                        CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                        UpdatedAt = prj.UpdatedAt,
                                        UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                        StatusDate = prj.StatusDate
                                  }).FirstOrDefault(x => x.Id == id);

            //if (projectProfile != null)
            //{
            //    var projectProfileComponents = _dbContext.ProjectProfileComponents.Where(t => t.ProjectProfileId == id && t.RemoveAt == null).ToList();
            //    projectProfile.ProjectProfileComponents = projectProfileComponents;

            //    return projectProfile;
            //}

            return projectProfile;
        }

        public async Task<ProjectProfile> Add(ProjectProfile projectProfile)
        {
            return await AddAsync(projectProfile);
        }

        public async Task<ProjectProfile> Update(ProjectProfile projectProfile)
        {
            return await UpdateAsync(projectProfile);
        }
    }
}