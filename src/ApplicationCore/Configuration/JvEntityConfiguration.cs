using FAIS.ApplicationCore.Entities.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using FAIS.ApplicationCore.Entities.Structure;

namespace FAIS.ApplicationCore.Configuration
{
    public class JvEntityConfiguration : IEntityTypeConfiguration<Jv>
    {
        public void Configure(EntityTypeBuilder<Jv> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("JV", "FAIS");

            builder.HasKey(e => e.No);

            builder.Property(e => e.No)
                .IsRequired()
                .HasColumnName("NO");

            builder.Property(e => e.StatusCodeLto)
                .IsRequired()   
                .HasColumnName("STATUS_CODE_LTO");

            builder.Property(e => e.StatusDate)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("STATUS_DATE");

            builder.Property(e => e.PreparedBy)
                .IsRequired()
                .HasColumnName("PREPARED_BY");

            builder.Property(e => e.ReviewedBy)
                .IsRequired(false)
                .HasColumnName("REVIEWED_BY");

            builder.Property(e => e.ApprovedBy)
                .IsRequired(false)
                .HasColumnName("APPROVED_BY");

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

        }
    }
}
