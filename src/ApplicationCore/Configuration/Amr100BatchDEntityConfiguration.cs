using FAIS.ApplicationCore.Entities.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using FAIS.ApplicationCore.Entities.Structure;

namespace FAIS.ApplicationCore.Configuration
{
    public class Amr100BatchDEntityConfiguration : IEntityTypeConfiguration<Amr100BatchD>
    {
        public void Configure(EntityTypeBuilder<Amr100BatchD> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("AMR100_BATCH_D", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("AMR100_BATCH_D_SEQ");

            builder.Property(e => e.Amr100BatchSeq)
                .IsRequired()   
                .HasColumnName("AMR100_BATCH_SEQ");

            builder.Property(e => e.RoaSeq)
                .IsRequired()
                .HasColumnName("ROA_SEQ");

            builder.Property(e => e.FgLto)
                .IsRequired()
                .HasColumnName("FG_LTO");

            builder.Property(e => e.AmrLocation)
                .IsRequired(false)
                .HasColumnName("AMR_LOCATION");

            builder.Property(e => e.AmrWbsNo)
                .IsRequired(false)
                .HasColumnName("AMR_WBS_NO");

            builder.Property(e => e.AmrAssetNo)
                .IsRequired(false)
                .HasColumnName("AMR_ASSET_NO");

            builder.Property(e => e.AmrAsset)
                .IsRequired(false)
                .HasColumnName("AMR_ASSET");

            builder.Property(e => e.AmrProjectName)
                .IsRequired(false)
                .HasColumnName("AMR_PROJECT_NAME");

            builder.Property(e => e.AmrEconomicLife)
                .IsRequired()
                .HasColumnName("AMR_ECONOMIC_LIFE");

            builder.Property(e => e.AmrCost)
                .IsRequired()
                .HasColumnName("AMR_COST");

            builder.Property(e => e.AmrCompletionDate)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("AMR_COMPLETION_DATE");

            builder.Property(e => e.AmrAssetClass)
                .IsRequired()
                .HasColumnName("AMR_ASSET_CLASS");

            builder.Property(e => e.AmrReferenceNo)
                .IsRequired()
                .HasColumnName("AMR_REFERENCE_NO");

            builder.Property(e => e.Qty)
                .IsRequired()
                .HasColumnName("QTY");

            builder.Property(e => e.UDF1)
                .IsRequired(false)
                .HasColumnName("UDF1");

            builder.Property(e => e.UDF2)
                .IsRequired(false)
                .HasColumnName("UDF2");

            builder.Property(e => e.UDF3)
                .IsRequired(false)
                .HasColumnName("UDF3");

            builder.Property(e => e.IsReturnedToEncoder)
                .IsRequired(false)
                .HasColumnName("IS_RETURNED_TO_ENCODER");

            builder.Property(e => e.IsReturnedToAnalysis)
                .IsRequired(false)
                .HasColumnName("IS_RETURNED_TO_ANALYSIS");

            builder.Property(e => e.ProformaEntrySeq)
                .IsRequired(false)
                .HasColumnName("PROFORMA_ENTRY_SEQ");

            builder.Property(e => e.Remarks)
                .HasColumnName("REMARKS");

            builder.Property(e => e.StatusCodeLto)
                .IsRequired()
                .HasColumnName("STATUS_CODE_LTO");

            builder.Property(e => e.StatusDate)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("STATUS_DATE");

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

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("USER_MODIFIED");

        }
    }
}
