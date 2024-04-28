using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class ProjectComponentEntityConfiguration : IEntityTypeConfiguration<ProjectComponent>
    {
        public void Configure(EntityTypeBuilder<ProjectComponent> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("PROJECT_COMPONENT", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("PROJECTCOMP_SEQ");

            builder.Property(e => e.ProjectSeq)
                .IsRequired()
                .HasColumnName("PROJECT_SEQ");

            builder.Property(e => e.ProjectComponentSeq)
                .IsRequired()
                .HasColumnName("PROJECT_COMPONENT_SEQ");

            builder.Property(e => e.ProjectStageSeq)
                .IsRequired()
                .HasColumnName("PROJECT_STAGE_SEQ");

            builder.Property(e => e.TransGridSeq)
                .IsRequired()
                .HasColumnName("TRANS_GRID_SEQ");

            builder.Property(e => e.StartDate)
                .IsRequired()
                .HasColumnName("START_DATE")
                .HasColumnType("datetime");

            builder.Property(e => e.TargetDate)
                .IsRequired()
                .HasColumnName("TARGET_DATE")
                .HasColumnType("datetime");

            builder.Property(e => e.CompletionDate)
                .IsRequired()
                .HasColumnName("COMPLETION_DATE")
                .HasColumnType("datetime");

            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasColumnName("DATE_CREATED")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedAt)
                .IsRequired(false)
                .HasColumnName("DATE_MODIFIED")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .IsRequired(false)
                .HasColumnName("DATE_REMOVED")
                .HasColumnType("datetime");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("USER_CREATED");

            builder.Property(e => e.UpdatedBy)
                .IsRequired(false)
                .HasColumnName("USER_MODIFIED");
        }
    }
}
