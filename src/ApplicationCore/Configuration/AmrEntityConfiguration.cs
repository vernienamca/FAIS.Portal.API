using FAIS.ApplicationCore.Entities.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using FAIS.ApplicationCore.Entities.Structure;

namespace FAIS.ApplicationCore.Configuration
{
    public class AmrEntityConfiguration : IEntityTypeConfiguration<Amr>
    {
        public void Configure(EntityTypeBuilder<Amr> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("AMR", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("REPORT_SEQ");

            builder.Property(e => e.AmrYm)
                .IsRequired()   
                .HasColumnName("AMR_YM");

            builder.Property(e => e.DateReceivedTransco)
                .IsRequired()
                .HasColumnName("DATE_RECEIVED_TRANSCO");

            builder.Property(e => e.DateReceivedArmPmd)
                .IsRequired()
                .HasColumnName("DATE_RECEIVED_ARMPMD");

            builder.Property(e => e.DateSentEncoding)
                .IsRequired(false)
                .HasColumnName("DATE_SENT_ENCODING");

            builder.Property(e => e.NoOfBinders)
                .HasColumnName("NO_OF_BINDERS");

            builder.Property(e => e.UDF1)
                .IsRequired(false)
                .HasColumnName("UDF1");

            builder.Property(e => e.UDF2)
                .IsRequired(false)
                .HasColumnName("UDF2");

            builder.Property(e => e.UDF3)
                .IsRequired(false)
                .HasColumnName("UDF3");

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
