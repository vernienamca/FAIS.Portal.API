
using FAIS.ApplicationCore.AuditTrail;
using FAIS.ApplicationCore.Configuration;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public partial class FAISContext : DbContext
    {
        public FAISContext(DbContextOptions<FAISContext> options) 
            : base(options)
        {
        }

        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<LibraryOptions> LibraryOptions { get; set; }
        public DbSet<LibraryType> LibraryTypes { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<StringInterpolation> StringInterpolations { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<LoginHistory> LoginHistory { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserTAFG> UserTAFGs { get; set; }
        public DbSet<ProformaEntries> ProformaEntries { get; set; }
        public DbSet<CostCenter> CostCenters { get; set; }
        public DbSet<Versions> Versions { get; set; }
        public DbSet<ChartOfAccounts> ChartOfAccounts { get; set; }
        public DbSet<ChartOfAccountDetails> ChartOfAccountDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            if (builder == null)
                return;

            builder.ApplyConfiguration(new AuditLogEntityConfiguration());
            builder.ApplyConfiguration(new CostCenterEntityConfiguration());
            builder.ApplyConfiguration(new ChartOfAccountsEntityConfiguration());
            builder.ApplyConfiguration(new ChartOfAccountDetailsEntityConfiguration());
            builder.ApplyConfiguration(new LibraryOptionsEntityConfiguration());
            builder.ApplyConfiguration(new LibraryTypeEntityConfiguration());
            builder.ApplyConfiguration(new LoginHistoryEntityConfiguration());
            builder.ApplyConfiguration(new ModuleEntityConfiguration());
            builder.ApplyConfiguration(new RoleEntityConfiguration());
            builder.ApplyConfiguration(new RolePermissionEntityConfiguration());
            builder.ApplyConfiguration(new SettingsEntityConfiguration());
            builder.ApplyConfiguration(new StringInterpolationEntityConfiguration());
            builder.ApplyConfiguration(new TemplateEntityConfiguration());
            builder.ApplyConfiguration(new UserEntityConfiguration());
            builder.ApplyConfiguration(new UserRoleEntityConfiguration());
            builder.ApplyConfiguration(new UserTAFGEntityConfiguration());
            builder.ApplyConfiguration(new ProformaEntriesEntityConfiguration());
            builder.ApplyConfiguration(new VersionEntityConfiguration());

            OnModelCreatingPartial(builder);
        }

        partial void OnModelCreatingPartial(ModelBuilder builder);

        //public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        //{
        //    IEnumerable<AuditEntry> entityAudits = OnBeforeSaveChanges();
        //    int result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        //    await OnAfterSaveChangesAsync(entityAudits);

        //    return result;
        //}

        public virtual async Task<int> SaveChangesAsync(int? userId = null)
        {
            IEnumerable<AuditEntry> entityAudits = OnBeforeSaveChanges(userId);
            int result = await base.SaveChangesAsync();
            await OnAfterSaveChangesAsync(entityAudits);

            return result;
        }

        private IEnumerable<AuditEntry> OnBeforeSaveChanges(int? userId)
        {
            ChangeTracker.DetectChanges();

            List<AuditEntry> auditEntries = new List<AuditEntry>();
            foreach(EntityEntry entry in ChangeTracker.Entries())
            {
                if (!entry.ShouldBeAudited())
                {
                    continue;
                }

                auditEntries.Add(new AuditEntry(entry, userId));
            }

            BeginTrackingAuditEntries(auditEntries);

            return auditEntries;
        }

        private async Task OnAfterSaveChangesAsync(IEnumerable<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count() == 0)
                return;

            await BeginTrackingAuditEntriesAsync(auditEntries);

            await base.SaveChangesAsync();
        }

        private void BeginTrackingAuditEntries(IEnumerable<AuditEntry> auditEntries)
        {
            foreach (var auditEntry in auditEntries)
            {
                //auditEntry.Update();
                Add(auditEntry.ToAuditLog());
            }
        }

        private async Task BeginTrackingAuditEntriesAsync(IEnumerable<AuditEntry> auditEntries)
        {
            foreach(var auditEntry in auditEntries) 
            {
                //auditEntry.Update();
                Add(auditEntry.ToAuditLog());
            }
        }
    }
}