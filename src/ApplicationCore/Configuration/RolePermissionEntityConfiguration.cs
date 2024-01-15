using FAIS.ApplicationCore.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class RolePermissionEntityConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("ROLE_PERMISSIONS", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("ROLE_PER_SEQ");

            builder.Property(e => e.RoleId)
                .IsRequired()
                .HasColumnName("ROLE_SEQ");

            builder.Property(e => e.ModuleId)
                .IsRequired()
                .HasColumnName("MODULE_SEQ");

            builder.Property(e => e.IsCreate)
                .IsRequired()
                .HasColumnName("P_CREATE")
                .HasMaxLength(1);

            builder.Property(e => e.IsRead)
                .IsRequired()
                .HasColumnName("P_READ")
                .HasMaxLength(1);

            builder.Property(e => e.IsUpdate)
                .IsRequired()
                .HasColumnName("P_UPDATE")
                .HasMaxLength(1);

            builder.Property(e => e.DateRemoved)
                .IsRequired(false)
                .HasColumnType("datetime")
                .HasColumnName("DATE_REMOVED");

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
