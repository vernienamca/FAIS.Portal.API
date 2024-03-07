using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class ProformaEntryEntityConfiguration : IEntityTypeConfiguration<ProformaEntry>
    {
        public void Configure(EntityTypeBuilder<ProformaEntry> builder) 
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("PROFORMA_ENTRIES_HEADER", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("PROFORMA_ENTRY_SEQ");

            builder.Property(e => e.TranTypeSeq)
                .IsRequired()
                .HasColumnName("TRAN_TYPE_SEQ");

            builder.Property(e => e.Description)
                .IsRequired(false)
                .HasColumnName("DESCRIPTION");

            builder.Property(e => e.IsActive)
                .IsRequired()
                .HasColumnName("IS_ACTIVE");

            builder.Property(e => e.StatusDate)
                .IsRequired()
                .HasColumnName("STATUS_DATE")
                .HasColumnType("datetime");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("USER_CREATED");

            builder.Property(e => e.UpdatedBy)
                .IsRequired(false)
                .HasColumnName("USER_MODIFIED");

            builder.Property(e => e.CreatedAt)
                 .IsRequired()
                 .HasColumnName("DATE_CREATED")
                 .HasColumnType("datetime");

            builder.Property(e => e.UpdatedAt)
                .IsRequired(false)
                .HasColumnName("DATE_MODIFIED")
                .HasColumnType("datetime");
        }
    }
}
