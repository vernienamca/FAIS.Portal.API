using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class ProjectProfileEntityConfiguration : IEntityTypeConfiguration<ProjectProfile>
    {

        public void Configure(EntityTypeBuilder<ProjectProfile> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("PROJECT_PROFILE", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("PROJECT_SEQ");

            builder.Property(e => e.ProjectName)
                .IsRequired()
                .HasColumnName("PROJECT_NAME");

            builder.Property(e => e.ProjectStageSeq)
                .HasColumnName("PROJECT_STAGE_SEQ");

            builder.Property(e => e.Remarks)
                .IsRequired(false)
                .HasColumnName("REMARKS");

            builder.Property(e => e.ProjClassSeq)
                .IsRequired()
                .HasColumnName("PROJ_CLASS_SEQ");

            builder.Property(e => e.TpsrMonth)
                .IsRequired()
                .HasColumnName("TPSR_MONTH");

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
