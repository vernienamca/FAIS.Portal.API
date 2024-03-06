using FAIS.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class TransLineProfileEntityConfiguration : IEntityTypeConfiguration<TransLineProfile>
    {
        public void Configure(EntityTypeBuilder<TransLineProfile> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("TRANS_LINE_PROFILES", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("TRANS_LINE_SEQ");

            builder.Property(e => e.LineStretch)
               .IsRequired()
               .HasColumnName("LINE_STRETCH");

            builder.Property(e => e.VoltageId)
                .IsRequired()
                .HasColumnName("VOLTAGE_SEQ");

            builder.Property(e => e.ST)
                .IsRequired()
                .HasColumnName("ST");

            builder.Property(e => e.SP)
                .IsRequired()
                .HasColumnName("SP");

            builder.Property(e => e.CP)
                .IsRequired()
                .HasColumnName("CP");

            builder.Property(e => e.WP)
                .IsRequired()
                .HasColumnName("WP");

            builder.Property(e => e.IsActive)
               .IsRequired()
               .HasColumnName("IS_ACTIVE");

            builder.Property(e => e.StatusDate)
                .IsRequired()
                .HasColumnName("STATUS_DATE");

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
