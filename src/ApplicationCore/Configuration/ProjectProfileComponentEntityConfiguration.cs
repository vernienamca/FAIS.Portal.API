using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class ProjectProfileComponentEntityConfiguration : IEntityTypeConfiguration<ProjectProfileComponent>
    {
        public void Configure(EntityTypeBuilder<ProjectProfileComponent> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("PROJECT_PROFILE_COMPONENTS", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("PROFILE_COMP_SEQ");

            builder.Property(e => e.ProjectProfileId)
                    .IsRequired()
                    .HasColumnName("PROFILE_SEQ");

            builder.Property(e => e.Details)
                    .IsRequired(false)
                    .HasColumnName("PROJECT_COMP_DETAILS");

            builder.Property(e => e.ComponentName)
                    .IsRequired(false)
                    .HasColumnName("NAME");

            builder.Property(e => e.ProjectStageSeq)
                    .IsRequired(false)
                    .HasColumnName("PROJECT_STAGE_SEQ");

            builder.Property(e => e.TransmissionGridSeq)
                    .IsRequired(false)
                    .HasColumnName("TRANS_GRID_SEQ");

            builder.Property(e => e.StartDate)
                    .IsRequired(false)
                    .HasColumnName("START_DATE")
                    .HasColumnType("datetime");

            builder.Property(e => e.TargetDate)
                    .IsRequired(false)
                    .HasColumnName("TARGET_DATE")
                    .HasColumnType("datetime");

            builder.Property(e => e.CompletionDate)
                    .IsRequired(false)
                    .HasColumnName("COMPLETION_DATE")
                    .HasColumnType("datetime");

            builder.Property(e => e.InspectionDate)
                    .IsRequired(false)
                    .HasColumnName("INSPECTION_DATE")
                    .HasColumnType("datetime");

            builder.Property(e => e.InitialAMRMonth)
                    .IsRequired(false)
                    .HasColumnName("INITIAL_AMR_MONTH")
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

            builder.Property(e => e.RemoveAt)
                    .IsRequired(false)
                    .HasColumnName("DATE_REMOVED")
                    .HasColumnType("datetime");
        }
    }
}