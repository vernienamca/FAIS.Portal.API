using FAIS.ApplicationCore.Entities.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using FAIS.ApplicationCore.Entities.Structure;

namespace FAIS.ApplicationCore.Configuration
{
    public class Amr100BatchStatHistoryEntityConfiguration : IEntityTypeConfiguration<Amr100BatchStatHistory>
    {
        public void Configure(EntityTypeBuilder<Amr100BatchStatHistory> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("AMR100_BATCHSTATHISTORY", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("AMR100_BATCHSTAT_SEQ");

            builder.Property(e => e.Amr100BatchSeq)
                .IsRequired()   
                .HasColumnName("AMR100_BATCH_SEQ");

            builder.Property(e => e.StatusCodeLto)
                .IsRequired()
                .HasColumnName("STATUS_CODE_LTO");

            builder.Property(e => e.StatusDate)
                .IsRequired()
                .HasColumnName("STATUS_DATE");

            builder.Property(e => e.StatusRemarks)
                .IsRequired(false)
                .HasColumnName("STATUS_REMARKS");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("USER_CREATED");
           
        }
    }
}
