using FAIS.ApplicationCore.Entities.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using FAIS.ApplicationCore.Entities.Structure;

namespace FAIS.ApplicationCore.Configuration
{
    public class PlantInformationEntityConfiguration : IEntityTypeConfiguration<PlantInformation>
    {
        public void Configure(EntityTypeBuilder<PlantInformation> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("PLANT_INFORMATION", "FAIS");

            builder.HasKey(e => e.PlantCode);

            builder.Property(e => e.PlantCode)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("PLANT_CODE");

            builder.Property(e => e.SubstationName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("SUBSTATION_NAME");

            builder.Property(e => e.SubstationNameOld)
                .IsRequired(false)
                .HasMaxLength(100)
                .HasColumnName("SUBSTATION_NAME_OLD");

            builder.Property(e => e.ClassId)
                .IsRequired(false)
                .HasColumnName("CLASS_SEQ");

            builder.Property(e => e.TransGrid)
                .HasColumnName("TRANS_GRID");

            builder.Property(e => e.DistrictId)
                .IsRequired()
                .HasColumnName("DISTRICT_SEQ");

            builder.Property(e => e.MtdId)
                .HasColumnName("MTD_SEQ");

            builder.Property(e => e.GmapCoord)
                .IsRequired(false)
                .HasColumnName("GMAP_COORD");

            builder.Property(e => e.CommissionDate)
                .IsRequired()
                .HasColumnName("COMM_DATE");

            builder.Property(e => e.UDF1)
                .IsRequired(false)
                .HasMaxLength(250)
                .HasColumnName("UDF1");

            builder.Property(e => e.UDF2)
                .IsRequired(false)
                .HasMaxLength(250)
                .HasColumnName("UDF2");

            builder.Property(e => e.UDF3)
                .IsRequired(false)
                .HasMaxLength(250)
                .HasColumnName("UDF3");

            builder.Property(e => e.RegionId)
                .HasColumnName("REGION_SEQ");

            builder.Property(e => e.ProvId)
                .HasColumnName("PROV_SEQ");

            builder.Property(e => e.MunId)
                .HasColumnName("MUN_SEQ");

            builder.Property(e => e.BrgyId)
                .HasColumnName("BRGY_SEQ");

            builder.Property(e => e.IsActive)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnName("IS_ACTIVE");

            builder.Property(e => e.StatusDate)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("STATUS_DATE");

            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("DATE_CREATED");

            builder.Property(e => e.UpdatedAt)
                .IsRequired(false)
                .HasColumnType("datetime")
                .HasColumnName("DATE_MODIFIED");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("USER_CREATED");

            builder.Property(e => e.UpdatedBy)
                .IsRequired(false)
                .HasColumnName("USER_MODIFIED");

        }
    }
}
