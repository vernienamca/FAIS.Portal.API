using FAIS.ApplicationCore.Entities.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using FAIS.ApplicationCore.Entities.Structure;

namespace FAIS.ApplicationCore.Configuration
{
    public class AssetProfileEntityConfiguration : IEntityTypeConfiguration<AssetProfile>
    {
        public void Configure(EntityTypeBuilder<AssetProfile> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("ASSET_PROFILES", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("ASSET_SEQ");

            builder.Property(e => e.Name)
                .IsRequired()   
                .HasColumnName("ASSET_NAME");

            builder.Property(e => e.AssetCategoryId)
                .IsRequired()
                .HasColumnName("ASSET_CATEGORY_SEQ");

            builder.Property(e => e.AssetClassId)
                .IsRequired()
                .HasColumnName("ASSET_CLASS_SEQ");

            builder.Property(e => e.Description)
                .IsRequired(false)
                .HasColumnName("DESCRIPTION");

            builder.Property(e => e.RcaGLId)
                .IsRequired()
                .HasColumnName("RCA_GL_SEQ");

            builder.Property(e => e.RcaSLId)
                .IsRequired()
                .HasColumnName("SL_NO_SEQ");

            builder.Property(e => e.CostCenter)
                .IsRequired()
                .HasColumnName("COST_CENTER");

            builder.Property(e => e.AssetType)
                .IsRequired()
                .HasColumnName("ASSET_TYPE");

            builder.Property(e => e.EconomicLife)
                .IsRequired(false)
                .HasColumnName("ECONOMIC_LIFE");

            builder.Property(e => e.ResidualLife)
                .IsRequired(false)
                .HasColumnName("RESIDUAL_LIFE");

            builder.Property(e => e.UDF1)
                .IsRequired(false)
                .HasColumnName("UDF1");

            builder.Property(e => e.UDF2)
                .IsRequired(false)
                .HasColumnName("UDF2");

            builder.Property(e => e.UDF3)
                .IsRequired(false)
                .HasColumnName("UDF3");

            builder.Property(e => e.IsActive)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnName("IS_ACTIVE");

            builder.Property(e => e.StatusDate)
                .IsRequired()
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
