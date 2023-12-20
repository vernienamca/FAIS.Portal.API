using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<LibraryType> LibraryTypes { get; set; }
        public virtual DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Module>(entity =>
            {
                entity.ToTable("MODULES", "FAIS");

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
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_CREATED");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_CREATED");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_MODIFIED");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_MODIFIED");
            });

            builder.Entity<Settings>(entity =>
            {
                entity.ToTable("SETTINGS", "FAIS");

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
                    .HasColumnName("PASSWORD_EXPIRY");

                entity.Property(e => e.IdleTime)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDLE_TIME");

                entity.Property(e => e.EnforcePasswordHistory)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ENFORCE_PASSWORD_HISTORY");

                entity.Property(e => e.MaxSignOnAttempts)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_SIGN_ATTEMPTS");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_CREATED");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_CREATED");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_MODIFIED");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_MODIFIED");
            });

            builder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLES", "FAIS");

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
                   .HasColumnType("NUMBER")
                   .HasColumnName("USER_CREATED");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_CREATED");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_MODIFIED");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_MODIFIED");
            });

            builder.Entity<User>(entity =>
            {
                entity.ToTable("USERS", "FAIS");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_SEQ");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(35)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(35)
                    .IsRequired(false)
                    .HasColumnName("MIDDLE_NAME");

                entity.Property(e => e.LastName)
                    .HasMaxLength(35)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(7)
                    .IsRequired(false)
                    .HasColumnName("EMP_NO");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .HasColumnName("USERNAME");

                entity.Property(e => e.PositionId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("POSITION_SEQ");

                entity.Property(e => e.DivisionId)
                   .HasColumnType("NUMBER")
                   .IsRequired(false)
                   .HasColumnName("DIVISION_SEQ");

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .HasColumnName("EMAIL_ADDRESS");

                entity.Property(e => e.MobileNumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MOBILE_NO");

                entity.Property(e => e.OupFgId)
                    .HasColumnType("NUMBER")
                    .IsRequired(false)
                    .HasColumnName("OUP_FG_SEQ");

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsRequired(false)
                    .HasColumnName("PHOTO");

                entity.Property(e => e.SessionId)
                    .HasColumnType("NUMBER")
                    .IsRequired(false)
                    .HasColumnName("SESSION_SEQ");

                entity.Property(e => e.SignInAttempts)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SIGNIN_ATTEMPTS");

                entity.Property(e => e.StatusCode)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STATUS_CODE");

                entity.Property(e => e.StatusDate)
                    .HasColumnType("datetime")
                    .HasColumnName("STATUS_DATE");

                entity.Property(e => e.DateExpired)
                    .HasColumnType("datetime")
                    .IsRequired(false)
                    .HasColumnName("DATE_EXPIRED");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_CREATED");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_CREATED");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("NUMBER")
                    .IsRequired(false)
                    .HasColumnName("USER_MODIFIED");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .IsRequired(false)
                    .HasColumnName("DATE_MODIFIED");

                entity.Property(e => e.TempKey)
                    .HasMaxLength(250)
                    .IsRequired(false)
                    .HasColumnName("TEMP_KEY");
            });

            builder.Entity<LibraryType>(entity =>
            {
                entity.ToTable("LIBRARY_TYPES", "FAIS");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LIB_TYPE_SEQ");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("LIB_TYPE_NAME");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("LIB_TYPE_CODE");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsRequired(false)
                    .HasColumnName("LIB_TYPE_DESC");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .HasColumnName("IS_ACTIVE");

                entity.Property(e => e.StatusDate)
                    .HasColumnName("STATUS_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_CREATED");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_CREATED");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("NUMBER")
                    .IsRequired(false)
                    .HasColumnName("USER_MODIFIED");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .IsRequired(false)
                    .HasColumnName("DATE_MODIFIED");
            });

            builder.Entity<AuditLog>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("AUDIT_LOGS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("AUDIT_LOG_SEQ");

                entity.Property(e => e.Activity)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_CREATED")
                    .HasDefaultValueSql("systimestamp\n   ");

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IP_ADDRESS");

                entity.Property(e => e.ModuleSeq)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MODULE_SEQ");

                entity.Property(e => e.NewValues)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("NEW_VALUES");

                entity.Property(e => e.OldValues)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("OLD_VALUES");

                entity.Property(e => e.UserCreated)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_CREATED");
            });
        }
    }
}
