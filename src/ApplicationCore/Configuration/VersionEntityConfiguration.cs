using FAIS.ApplicationCore.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class VersionEntityConfiguration : IEntityTypeConfiguration<Versions>
    {
        public void Configure(EntityTypeBuilder<Versions> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));


            builder.ToTable("VERSION", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("VERSION_SEQ");

            builder.Property(e => e.VersionNo)
               .IsRequired()
               .HasColumnName("VERSION_NO");

            builder.Property(e => e.VersionDate)
               .IsRequired()
               .HasColumnName("VERSION_DATE");

            builder.Property(e => e.Amendment)
               .IsRequired()
               .HasColumnName("AMENDMENT");

            builder.Property(e => e.CreatedAt)
               .IsRequired()
               .HasColumnName("DATE_CREATED");

            builder.Property(e => e.CreatedBy)
               .IsRequired()
               .HasColumnName("USER_CREATED");

            builder.Property(e => e.UpdatedAt)
               .IsRequired()
               .HasColumnName("DATE_MODIFIED");

            builder.Property(e => e.UpdatedBy)
               .IsRequired()
               .HasColumnName("USER_MODIFIED");
        }
    }
}
