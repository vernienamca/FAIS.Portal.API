using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class BusinessProcessEntityConfiguration : IEntityTypeConfiguration<BusinessProcess>
    {
        public void Configure(EntityTypeBuilder<BusinessProcess> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("BUS_PROCESS", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("BUS_PROCESS_SEQ");

            builder.Property(e => e.BusinessProcessName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("BUS_PROCESS_NAME");

            builder.Property(e => e.Description)
                .IsRequired(false)
                .HasMaxLength(200)
                .HasColumnName("DESCRIPTION");

            builder.Property(e => e.IsActive)
                .IsRequired()
                .HasColumnName("IS_ACTIVE")
                .HasMaxLength(1);

            builder.Property(e => e.StatusDate)
                .IsRequired()
                .HasColumnType("datetime")
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