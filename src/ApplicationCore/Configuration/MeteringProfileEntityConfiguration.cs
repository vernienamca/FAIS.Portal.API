using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAIS.ApplicationCore.Configuration
{
    public class MeteringProfileEntityConfiguration : IEntityTypeConfiguration<MeteringProfile>
    {
        public void Configure(EntityTypeBuilder<MeteringProfile> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("METERING_PROFILES", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("METERING_SEQ");

            builder.Property(e => e.TransGrid)
                .IsRequired()
                .HasColumnName("TRANS_GRID");

            builder.Property(e => e.DistrictSeq)
                .IsRequired()
                .HasColumnName("DISTRICT_SEQ");

            builder.Property(e => e.Customer)
                .IsRequired()
                .HasColumnName("CUSTOMER");

            builder.Property(e => e.MeteringPointName)
                .IsRequired()
                .HasColumnName("METERING_POINT_NAME");

            builder.Property(e => e.MeteringClass)
                .IsRequired()
                .HasColumnName("METERING_CLASS_SEQ");

            builder.Property(e => e.InstallationTypeSeq)
                .IsRequired()
                .HasColumnName("INSTALLATION_TYPE_SEQ");

            builder.Property(e => e.FacilityLocationSeq)
                .IsRequired()
                .HasColumnName("FACILITY_LOCATION_SEQ");

            builder.Property(e => e.LineSegment)
                .IsRequired(false)
                .HasColumnName("LINE_SEGMENT");

            builder.Property(e => e.Remarks)
                .IsRequired(false)
                .HasColumnName("REMARKS");

            builder.Property(e => e.UDF1)
                .IsRequired(false)
                .HasColumnName("UDF1");

            builder.Property(e => e.UDF2)
                .IsRequired(false)
                .HasColumnName("UDF2");

            builder.Property(e => e.UDF3)
                .IsRequired(false)
                .HasColumnName("UDF3");

            builder.Property(e => e.AdRegionSeq)
                .IsRequired(false)
                .HasColumnName("AD_REGION_SEQ");

            builder.Property(e => e.AdProvSeq)
                .IsRequired(false)
                .HasColumnName("AD_PROV_SEQ");

            builder.Property(e => e.AdMunSeq)
                .IsRequired(false)
                .HasColumnName("AD_MUN_SEQ");

            builder.Property(e => e.AdBrgySeq)
                .IsRequired(false)
                .HasColumnName("AD_BRGY_SEQ");

            builder.Property(e => e.IsActive)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnName("IS_ACTIVE");

            builder.Property(e => e.StatusDate)
                .IsRequired()
                .HasColumnName("STATUS_DATE")
                .HasColumnType("datetime");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("USER_CREATED");

            builder.Property(e => e.UpdatedBy)
                .IsRequired(false)
                .HasColumnName("USER_MODIFIED");

            builder.Property(e => e.CreatedAt)
                 .IsRequired()
                 .HasColumnName("DATE_CREATED")
                 .HasColumnType("datetime");

            builder.Property(e => e.UpdatedAt)
                .IsRequired(false)
                .HasColumnName("DATE_MODIFIED")
                .HasColumnType("datetime");
        }
    }
}