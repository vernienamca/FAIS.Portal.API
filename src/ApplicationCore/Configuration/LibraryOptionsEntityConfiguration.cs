using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class LibraryOptionsEntityConfiguration : IEntityTypeConfiguration<LibraryOptions>
    {
        public void Configure(EntityTypeBuilder<LibraryOptions> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("LIBRARY_TYPE_OPTIONS", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("LIB_TYPE_OPT_SEQ");

            builder.Property(e => e.LibraryTypeId)
                .IsRequired()
                .HasColumnName("LIB_TYPE_SEQ");

            builder.Property(e => e.Code)
                .IsRequired(false)
                .HasColumnName("LIB_TYPE_OPT_CODE")
                .HasMaxLength(10);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("LIB_TYPE_CODE")
                .HasMaxLength(250);

            builder.Property(e => e.Remarks)
                .IsRequired(false)
                .HasColumnName("REMARKS")
                .HasMaxLength(250);

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
