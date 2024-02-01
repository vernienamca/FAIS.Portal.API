using FAIS.ApplicationCore.Configuration;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Versions> Versions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            if (builder == null)
                return;

            builder.ApplyConfiguration(new AuditLogEntityConfiguration());
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
    }

}