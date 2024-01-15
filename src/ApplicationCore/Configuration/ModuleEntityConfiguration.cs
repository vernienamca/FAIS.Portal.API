using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class ModuleEntityConfiguration : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("MODULES", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("MODULE_SEQ");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("MODULE_NAME")
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .IsRequired(false)
                .HasColumnName("MODULE_DESCRIPTION")
                .HasMaxLength(250);

            builder.Property(e => e.Url)
                .IsRequired()
                .HasColumnName("URL")
                .HasMaxLength(200);

            builder.Property(e => e.Icon)
                .IsRequired(false)
                .HasMaxLength(25)
                .HasColumnName("ICON");

            builder.Property(e => e.GroupName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("GROUP_NAME");

            builder.Property(e => e.Sequence)
                .IsRequired(false)
                .HasColumnName("SEQUENCE");

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
