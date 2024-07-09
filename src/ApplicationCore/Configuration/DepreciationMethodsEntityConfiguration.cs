using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class DepreciationMethodsEntityConfiguration : IEntityTypeConfiguration<DepreciationMethods>
    {
        public void Configure(EntityTypeBuilder<DepreciationMethods> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("DEF_METHODS", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("DEF_METHOD_SEQ");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("NAME");

            builder.Property(e => e.Description)
                .IsRequired(false)
                .HasMaxLength(200)
                .HasColumnName("DESCRIPTION");

            builder.Property(e => e.StartDate)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("START_DATE");

            builder.Property(e => e.EndDate)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("END_DATE");

            builder.Property(e => e.BusinessProcessId)
                .IsRequired(false)
                .HasColumnName("BUS_PROCESS_SEQ");

            builder.Property(e => e.IsSingleTransaction)
                .IsRequired()
                .HasColumnName("IS_SINGLE_TRANS")
                .HasMaxLength(1);

            builder.Property(e => e.FinalResultId)
                .IsRequired()
                .HasColumnName("FIN_RESULT_SEQ");

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