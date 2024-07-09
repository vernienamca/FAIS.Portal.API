using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class DefinedTableColumnsEntityConfiguration : IEntityTypeConfiguration<DefinedTableColumns>
    {
        public void Configure(EntityTypeBuilder<DefinedTableColumns> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("DEPEX_TCOLS", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("DEPEX_TCOLS_SEQ");

            builder.Property(e => e.DefinedTableId)
                .IsRequired(false)
                .HasColumnName("DEPEX_TABLES_SEQ");

            builder.Property(e => e.ColumName)
                .IsRequired(false)
                .HasMaxLength(50)
                .HasColumnName("COLUMN_NAME");

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