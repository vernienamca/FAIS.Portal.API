using FAIS.ApplicationCore.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class AuditLogEntityConfiguration : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("AUDIT_LOGS", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("AUDIT_LOG_SEQ");

            builder.Property(e => e.ModuleSeq)
                .IsRequired()
                .HasColumnName("MODULE_SEQ");

            builder.Property(e => e.Activity)
                .IsRequired(false)
                .HasColumnName("ACTIVITY")
                .HasMaxLength(350);

            builder.Property(e => e.OldValues)
                .IsRequired(false)
                .HasColumnName("OLD_VALUES")
                .HasMaxLength(350);

            builder.Property(e => e.NewValues)
                .IsRequired(false)
                .HasColumnName("NEW_VALUES")
                .HasMaxLength(350);

            builder.Property(e => e.IpAddress)
                .IsRequired()
                .HasColumnName("IP_ADDRESS")
                .HasMaxLength(20);

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("USER_CREATED");

            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("DATE_CREATED");
        }
    }
}
