using FAIS.ApplicationCore.Entities.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using FAIS.ApplicationCore.Entities.Structure;

namespace FAIS.ApplicationCore.Configuration
{
    public class Amr100BatchDbdEntityConfiguration : IEntityTypeConfiguration<Amr100BatchDbd>
    {
        public void Configure(EntityTypeBuilder<Amr100BatchDbd> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("AMR100_BATCH_DBD", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("AMR100_BATCH_DBD_SEQ");

            builder.Property(e => e.Amr100BatchDSeq)
                .IsRequired()   
                .HasColumnName("AMR100_BATCH_D_SEQ");

            builder.Property(e => e.AmrSeq)
                .IsRequired()
                .HasColumnName("AMR_SEQ");

            builder.Property(e => e.NewAsset)
                .IsRequired()
                .HasColumnName("NEW_ASSET");

            builder.Property(e => e.ArSeq)
                .HasColumnName("AR_SEQ");

            builder.Property(e => e.AmrAssetSeq)
                .IsRequired()
                .HasColumnName("AMR_ASSET_SEQ");

            builder.Property(e => e.WithIssues)
                .IsRequired()
                .HasColumnName("WITH_ISSUES");

            builder.Property(e => e.AllocatedCost)
                .IsRequired()
                .HasColumnName("ALLOCATED_COST");

            builder.Property(e => e.Remarks)
                .IsRequired(false)
                .HasColumnName("REMARKS");

            builder.Property(e => e.NgcpAssetId)
                .IsRequired(false)
                .HasColumnName("NGCP_ASSET_ID");

            builder.Property(e => e.TransactionDetails)
                .IsRequired(false)
                .HasColumnName("TRANSACTION_DETAILS");

            builder.Property(e => e.TransactionDesc)
                .IsRequired(false)
                .HasColumnName("TRANSACTION_DESC");

            builder.Property(e => e.LineSegment)
                .IsRequired(false)
                .HasColumnName("LINE_SEGMENT");

            builder.Property(e => e.UDF1)
                .IsRequired(false)
                .HasColumnName("UDF1");

            builder.Property(e => e.UDF2)
                .IsRequired(false)
                .HasColumnName("UDF2");

            builder.Property(e => e.UDF3)
                .IsRequired(false)
                .HasColumnName("UDF3");

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
                .HasColumnName("USER_MODIFIED");

           
        }
    }
}
