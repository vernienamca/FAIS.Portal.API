using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class CostCenterEntityConfiguration : IEntityTypeConfiguration<CostCenter>
    {
        public void Configure(EntityTypeBuilder<CostCenter> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToView("FAIS_CC_VIEW");

            builder.HasNoKey();

            builder.Property(e => e.FGCode)
                .HasColumnName("FG");

            builder.Property(e => e.MCNumber)
                .HasColumnName("MC_NO");

            builder.Property(e => e.LongName)
                .HasColumnName("LONGNAME");

            builder.Property(e => e.ShortName)
                .HasColumnName("SHORTNAME");
        }
    }
}
