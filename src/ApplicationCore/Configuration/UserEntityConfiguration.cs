using FAIS.ApplicationCore.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("USERS", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("USER_SEQ");

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("FIRST_NAME")
                .HasMaxLength(35);

            builder.Property(e => e.MiddleName)
                .IsRequired(false)
                .HasMaxLength(35)
                .HasColumnName("MIDDLE_NAME");

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("LAST_NAME")
                .HasMaxLength(35);

            builder.Property(e => e.EmployeeNumber)
                .IsRequired(false)
                .HasColumnName("EMP_NO")
                .HasMaxLength(7);

            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("USERNAME");

            builder.Property(e => e.PositionId)
                .IsRequired()
                .HasColumnName("POSITION_SEQ");

            builder.Property(e => e.DivisionId)
                .IsRequired(false)
                .HasColumnName("DIVISION_SEQ");

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("PASSWORD");

            builder.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .HasColumnName("EMAIL_ADDRESS");

            builder.Property(e => e.MobileNumber)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("MOBILE_NO");

            builder.Property(e => e.OupFgId)
                .IsRequired(false)
                .HasColumnName("OUP_FG_SEQ");

            builder.Property(e => e.Photo)
                .IsRequired(false)
                .HasMaxLength(250)
                .HasColumnName("PHOTO");

            builder.Property(e => e.SessionId)
                .IsRequired(false)
                .HasMaxLength(250)
                .HasColumnName("SESSION_SEQ");

            builder.Property(e => e.SignInAttempts)
                .IsRequired()
                .HasColumnName("SIGNIN_ATTEMPTS");

            builder.Property(e => e.StatusCode)
                .IsRequired()
                .HasColumnName("STATUS_CODE");

            builder.Property(e => e.StatusDate)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("STATUS_DATE");

            builder.Property(e => e.DateExpired)
                .IsRequired(false)
                .HasColumnType("datetime")
                .HasColumnName("DATE_EXPIRED");

            builder.Property(e => e.TempKey)
                .IsRequired(false)
                .HasMaxLength(250)
                .HasColumnName("TEMP_KEY");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("USER_CREATED");

            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("DATE_CREATED");

            builder.Property(e => e.UpdatedBy)
                .IsRequired(false)
                .HasColumnName("USER_MODIFIED");

            builder.Property(e => e.UpdatedAt)
                .IsRequired(false)
                .HasColumnType("datetime")
                .HasColumnName("DATE_MODIFIED");
        }
    }
}
