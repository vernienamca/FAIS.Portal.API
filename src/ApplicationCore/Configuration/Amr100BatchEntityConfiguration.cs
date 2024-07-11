using FAIS.ApplicationCore.Entities.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using FAIS.ApplicationCore.Entities.Structure;

namespace FAIS.ApplicationCore.Configuration
{
    public class Amr100BatchEntityConfiguration : IEntityTypeConfiguration<Amr100Batch>
    {
        public void Configure(EntityTypeBuilder<Amr100Batch> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("AMR100_BATCH", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("AMR100_BATCH_SEQ");

            builder.Property(e => e.ReportSeq)
                .IsRequired()   
                .HasColumnName("REPORT_SEQ");

            builder.Property(e => e.ReportFgLto)
                .IsRequired()
                .HasColumnName("REPORT_FG_LTO");

            builder.Property(e => e.ProjectSeq)
                .IsRequired()
                .HasColumnName("PROJECT_SEQ");

            builder.Property(e => e.ProjectComponentLto)
                .IsRequired()
                .HasColumnName("PROJECT_COMPONENT_LTO");

            builder.Property(e => e.Remarks)
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

            builder.Property(e => e.StatusCode)
                .IsRequired()
                .HasColumnName("STATUS_CODE");

            builder.Property(e => e.StatusDate)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("STATUS_DATE");

            builder.Property(e => e.AccStatusDate)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("ACC_STATUS_DATE");

            builder.Property(e => e.AssignedTo)
                .HasColumnType("datetime")
                .HasColumnName("ASSIGNED_TO");

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

            builder.Property(e => e.TotalAmrIssues)
                .IsRequired(false)
                .HasColumnName("NO_AMR_ISSUES");

            builder.Property(e => e.TotalReport)
                .IsRequired()
                .HasColumnName("REPORT_TOTAL");
        }
    }
}
