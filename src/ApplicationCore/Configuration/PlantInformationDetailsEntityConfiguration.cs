using FAIS.ApplicationCore.Entities.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using FAIS.ApplicationCore.Entities.Structure;

namespace FAIS.ApplicationCore.Configuration
{
    public class PlantInformationDetailsEntityConfiguration : IEntityTypeConfiguration<PlantInformationDetails>
    {
        public void Configure(EntityTypeBuilder<PlantInformationDetails> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("PLANT_INFORMATION_DETAILS", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("PLANT_INFO_DET_SEQ");

            builder.Property(e => e.PlantCode)
                .IsRequired()   
                .HasColumnName("PLANT_CODE");

            builder.Property(e => e.CostCenter)
                .IsRequired()
                .HasColumnName("COST_CENTER");

            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("DATE_CREATED");

            builder.Property(e => e.UpdatedAt)
                .IsRequired(false)
                .HasColumnType("datetime")
                .HasColumnName("DATE_MODIFIED");

            builder.Property(e => e.RemovedAt)
                .IsRequired(false)
                .HasColumnType("datetime")
                .HasColumnName("DATE_REMOVED");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("USER_CREATED");

            builder.Property(e => e.UpdatedBy)
                .IsRequired(false)
                .HasColumnName("USER_MODIFIED");

            builder.Property(e => e.CostCenterTypeLto)
                .IsRequired(false)
                .HasColumnName("COST_CENTER_TYPE_LTO");
        }
    }
}
