using Microsoft.EntityFrameworkCore;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;

namespace FAIS.Infrastructure.Data
{
    public class FAISContext : DbContext
    {
        public FAISContext(DbContextOptions<FAISContext> options) : base(options)
        {
        }
       
        public DbSet<Module> Modules { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Module>(entity =>
            {
                entity.ToTable("MODULES", "TRANSCO");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MODULE_SEQ");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("MODULE_NAME");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("MODULE_DESCRIPTION");

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .HasColumnName("URL");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .HasColumnName("IS_ACTIVE");

                entity.Property(e => e.StatusDate)
                    .HasColumnName("STATUS_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("USER_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("DATE_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("USER_MODIFIED")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("DATE_MODIFIED")
                    .HasColumnType("datetime");
            });

            builder.Entity<Settings>(entity =>
            {
                entity.ToTable("SETTINGS", "TRANSCO");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SETTING_SEQ");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(150)
                    .HasColumnName("COMPANY_NAME");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("PHONE_NO");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .HasColumnName("EMAIL_ADDRESS");

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .HasColumnName("WEBSITE");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.MinPasswordLength)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_PASSWORD_LENGTH");

                entity.Property(e => e.MinSpecialCharacters)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_SPECIAL_CHARS");

                entity.Property(e => e.PasswordExpiry)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_SPECIAL_CHARS");

                entity.Property(e => e.IdleTime)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_SPECIAL_CHARS");

                entity.Property(e => e.EnforcePasswordHistory)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_SPECIAL_CHARS");

                entity.Property(e => e.MaxSignOnAttempts)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_SPECIAL_CHARS");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("USER_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("DATE_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("USER_MODIFIED")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("DATE_MODIFIED")
                    .HasColumnType("datetime");
            });

            builder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLES", "TRANSCO");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLE_SEQ");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("ROLE_NAME");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("ROLE_DESCRIPTION");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .HasColumnName("IS_ACTIVE");

                entity.Property(e => e.StatusDate)
                    .HasColumnName("STATUS_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("USER_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("DATE_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("USER_MODIFIED")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("DATE_MODIFIED")
                    .HasColumnType("datetime");
            });

            builder.Entity<User>(entity =>
            {
                entity.ToTable("USERS", "TRANSCO");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_SEQ");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(35)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(35)
                    .HasColumnName("MIDDLE_NAME");

                entity.Property(e => e.LastName)
                    .HasMaxLength(35)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(7)
                    .HasColumnName("EMP_NO");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .HasColumnName("USERNAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .HasColumnName("EMAIL_ADDRESS");

                entity.Property(e => e.MobileNumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MOBILE_NO");
            });
        }
    }
}
