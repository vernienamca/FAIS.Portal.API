using FAIS.ApplicationCore.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class LoginHistoryEntityConfiguration : IEntityTypeConfiguration<LoginHistory>
    {
        public void Configure(EntityTypeBuilder<LoginHistory> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("LOGIN_HISTORY", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("LOGIN_HIS_SEQ");

            builder.Property(e => e.UserId)
                 .IsRequired(false)
                 .HasColumnName("USER_SEQ");

            builder.Property(e => e.Username)
                .IsRequired()
                .HasColumnName("USERNAME")
                .HasMaxLength(20);

            builder.Property(e => e.IsFailed)
                .IsRequired()
                .HasColumnName("IS_FAILED")
                .HasMaxLength(200);

            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("DATE_CREATED");
        }
    }
}
