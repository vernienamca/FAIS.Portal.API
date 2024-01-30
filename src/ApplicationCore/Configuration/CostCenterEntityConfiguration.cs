using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class CostCenterEntityConfiguration : IEntityTypeConfiguration<CostCenter>
    {
        public void Configure(EntityTypeBuilder<CostCenter> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("COST_CENTER", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("COST_CENTER_SEQ");

            builder.Property(e => e.FGCode)
                .IsRequired()
                .HasColumnName("FG_CODE")
                .HasMaxLength(5);

            builder.Property(e => e.Number)
               .IsRequired()
               .HasColumnName("COST_CENTER_NUMBER");

            builder.Property(e => e.Name)
             .IsRequired()
             .HasColumnName("COST_CENTER_NAME")
             .HasMaxLength(50);

            builder.Property(e => e.ShortName)
             .IsRequired()
             .HasColumnName("SHORT_NAME")
             .HasMaxLength(50);

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
