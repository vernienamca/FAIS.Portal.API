using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class SettingsEntityConfiguration : IEntityTypeConfiguration<Settings>
    {
        public void Configure(EntityTypeBuilder<Settings> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("SETTINGS", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("SETTING_SEQ");

            builder.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("COMPANY_NAME");

            builder.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("PHONE_NO");

            builder.Property(e => e.EmailAddress)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("EMAIL_ADDRESS");

            builder.Property(e => e.Website)
                .IsRequired(false)
                .HasMaxLength(100)
                .HasColumnName("WEBSITE");

            builder.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("ADDRESS");

            builder.Property(e => e.SMTPFromEmail)
                .IsRequired(false)
                .HasMaxLength(50)
                .HasColumnName("SMTP_FROM_EMAIL");

            builder.Property(e => e.SMTPPassword)
                .IsRequired(false)
                .HasMaxLength(150)
                .HasColumnName("SMTP_PASSWORD");

            builder.Property(e => e.SMTPServerName)
                .IsRequired(false)
                .HasMaxLength(50)
                .HasColumnName("SMTP_SERVER_NAME");

            builder.Property(e => e.SMTPPort)
                .IsRequired(false)
                .HasColumnName("SMTP_PORT");

            builder.Property(e => e.SMTPEnableSSL)
                .IsRequired(false)
                .HasMaxLength(1)
                .HasColumnName("SMTP_ENABLE_SSL");

            builder.Property(e => e.SMTPDisplayName)
                .IsRequired(false)
                .HasMaxLength(150)
                .HasColumnName("SMTP_DISPLAY_NAME");

            builder.Property(e => e.MinPasswordLength)
                .IsRequired()
                .HasColumnName("MIN_PASSWORD_LENGTH");

            builder.Property(e => e.MinSpecialCharacters)
                .IsRequired()
                .HasColumnName("MIN_SPECIAL_CHARS");

            builder.Property(e => e.PasswordExpiry)
                .IsRequired()
                .HasColumnName("PASSWORD_EXPIRY");

            builder.Property(e => e.IdleTime)
                .IsRequired()
                .HasColumnName("IDLE_TIME");

            builder.Property(e => e.EnforcePasswordHistory)
                .IsRequired()
                .HasColumnName("ENFORCE_PASSWORD_HISTORY");

            builder.Property(e => e.MaxSignOnAttempts)
                .IsRequired()
                .HasColumnName("MAX_SIGN_ATTEMPTS");

            builder.Property(e => e.BaseUrl)
                .IsRequired(false)
                .HasMaxLength(150)
                .HasColumnName("BASE_URL");

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
