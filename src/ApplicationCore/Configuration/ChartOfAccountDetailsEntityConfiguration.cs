using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class ChartOfAccountDetailsEntityConfiguration : IEntityTypeConfiguration<ChartOfAccountDetails>
    {
        public void Configure(EntityTypeBuilder<ChartOfAccountDetails> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("CHART_OF_ACCOUNTS_D", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("CHART_ACC_DET_SEQ");

            builder.Property(e => e.ChartOfAccountsId)
                .IsRequired()
                .HasColumnName("CHART_ACC_SEQ");

            builder.Property(e => e.GL)
                .IsRequired()
                .HasColumnName("GL");

            builder.Property(e => e.SL)
                .IsRequired()
                .HasColumnName("SL");

            builder.Property(e => e.LedgerTitle)
                .IsRequired()
                .HasColumnName("LEDGER_TITLE");

            builder.Property(e => e.DateRemoved)
                .IsRequired(false)
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
