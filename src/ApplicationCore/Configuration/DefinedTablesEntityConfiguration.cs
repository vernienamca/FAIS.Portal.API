using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class DefinedTablesEntityConfiguration : IEntityTypeConfiguration<DefinedTables>
    {
        public void Configure(EntityTypeBuilder<DefinedTables> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("DEPEX_TABLES", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("DEPEX_TABLES_SEQ");

            builder.Property(e => e.BusinessProcessId)
                .IsRequired(false)
                .HasColumnName("BUS_PROCESS_SEQ");

            builder.Property(e => e.TableName)
                .IsRequired(false)
                .HasMaxLength(50)
                .HasColumnName("TABLE_NAME");

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