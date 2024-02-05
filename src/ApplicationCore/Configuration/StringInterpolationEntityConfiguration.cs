using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class StringInterpolationEntityConfiguration : IEntityTypeConfiguration<StringInterpolation>
    {
        public void Configure(EntityTypeBuilder<StringInterpolation> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("STRING_INTERPOLATIONS", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("STRING_INTERPOLATION_SEQ");

            builder.Property(e => e.TransactionCode)
                .HasMaxLength(250)
                .HasColumnName("TRANSACTION_CODE");

            builder.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("TRANSACTION_DESCRIPTION");

            builder.Property(e => e.IsActive)
                .HasMaxLength(1)
                .HasColumnName("IS_ACTIVE");

            builder.Property(e => e.StatusDate)
                .HasColumnName("STATUS_DATE")
                .HasColumnType("datetime");

            builder.Property(e => e.NotificationType)
                .HasMaxLength(50)
                .HasColumnName("NOTIFICATION_TYPE");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("USER_CREATED");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("DATE_CREATED");

            builder.Property(e => e.UpdatedBy)
                .IsRequired(false)
                .HasColumnName("USER_MODIFIED");

            builder.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("DATE_MODIFIED");
        }
    }
}
