using FAIS.ApplicationCore.Entities.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using FAIS.ApplicationCore.Entities.Structure;

namespace FAIS.ApplicationCore.Configuration
{
    public class TransmissionLineProfileEntityConfiguration : IEntityTypeConfiguration<TransmissionLineProfile>
    {
        public void Configure(EntityTypeBuilder<TransmissionLineProfile> builder)
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
                .IsRequired(false)
                .HasColumnName("ST");

            builder.Property(e => e.SP)
                .IsRequired(false)
                .HasColumnName("SP");

            builder.Property(e => e.CP)
                .IsRequired(false)
                .HasColumnName("CP");

            builder.Property(e => e.WP)
                .IsRequired(false)
                .HasColumnName("WP");

            builder.Property(e => e.SLWT)
                .IsRequired(false)
                .HasColumnName("SLWT");

            builder.Property(e => e.InstallationDate)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("INSTALLATION_DATE");

            builder.Property(e => e.RouteLength)
                .IsRequired(false)
                .HasColumnName("ROUTE_LENGTH");

            builder.Property(e => e.NoCircuitId)
                .IsRequired(false)
                .HasColumnName("NO_CIRCUIT_SEQ");

            builder.Property(e => e.CircuitLength)
                .IsRequired(false)
                .HasColumnName("CIRCUIT_LENGTH");

            builder.Property(e => e.NoConductor)
                .IsRequired(false)
                .HasColumnName("NO_CONDUCTOR");

            builder.Property(e => e.ConductorSize)
                .IsRequired(false)
                .HasMaxLength(50)
                .HasColumnName("CONDUCTOR_SIZE");

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

            builder.Property(e => e.IsActive)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnName("IS_ACTIVE");

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
