using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class ChartOfAccountsEntityConfiguration : IEntityTypeConfiguration<ChartOfAccounts>
    {
        public void Configure(EntityTypeBuilder<ChartOfAccounts> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("CHART_OF_ACCOUNTS_H", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("CHART_ACC_SEQ");

            builder.Property(e => e.AcountGroup)
                .IsRequired()
                .HasColumnName("ACCOUNT_GROUP");

            builder.Property(e => e.SubAcountGroup)
                .IsRequired()
                .HasColumnName("SUB_ACCOUNT_GROUP");

            builder.Property(e => e.RcaGL)
                .IsRequired()
                .HasColumnName("RCA_GL");

            builder.Property(e => e.RcaSL)
                .IsRequired()
                .HasColumnName("RCA_SL");

            builder.Property(e => e.RcaLedgerTitle)
                .IsRequired()
                .HasColumnName("RCA_LEDGER_TITLE");

            builder.Property(e => e.IsActive)
                .IsRequired()
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
