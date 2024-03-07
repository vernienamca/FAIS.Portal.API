using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class ProformaEntriesEntityConfiguration : IEntityTypeConfiguration<ProformaEntries>
    {
        public void Configure(EntityTypeBuilder<ProformaEntries> builder) 
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("PROFORMA_ENTRIES", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("PROFORMA_ENTRY_SEQ");

            builder.Property(e => e.AYyyy)
                .IsRequired(false)
                .HasColumnName("A_YYYY")
                .HasMaxLength(1);

            builder.Property(e => e.CostCenter)
                .IsRequired(false)
                .HasColumnName("COST_CENTER")               
                .HasMaxLength(1);

            builder.Property(e => e.Credit)
                .IsRequired(false)
                .HasColumnName("CREDIT")                
                .HasMaxLength(1);

            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasColumnName("DATE_CREATED")                
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedAt)
                .IsRequired(false)
                .HasColumnName("DATE_MODIFIED")                
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .IsRequired(false)
                .HasColumnName("DATE_REMOVED")                
                .HasColumnType("datetime");

            builder.Property(e => e.Dce)
                .IsRequired(false)
                .HasColumnName("DCE")                
                .HasMaxLength(10);

            builder.Property(e => e.Debit)
                .IsRequired(false)
                .HasColumnName("DEBIT")                
                .HasMaxLength(1);

            builder.Property(e => e.FaisRefNo)
                .IsRequired()
                .HasColumnName("FAIS_REF_NO")
                .HasMaxLength(1);

            builder.Property(e => e.Fg)
                .IsRequired(false)
                .HasColumnName("FG")                
                .HasMaxLength(1);

            builder.Property(e => e.GlNo)
                .IsRequired(false)
                .HasColumnName("GL_NO");

            builder.Property(e => e.Nature)
                .IsRequired(false)
                .HasColumnName("NATURE")                
                .HasMaxLength(50);

            builder.Property(e => e.OtherCode)
                .IsRequired(false)
                .HasColumnName("OTHER_CODE")                
                .HasMaxLength(5);

            builder.Property(e => e.PlantCode)
                .IsRequired(false)
                .HasColumnName("PLANT_CODE")                
                .HasMaxLength(50);

            builder.Property(e => e.Prefix)
                .IsRequired(false)
                .HasColumnName("PREFIX")                
                .HasMaxLength(2);

            builder.Property(e => e.RcaGl)
                .IsRequired()
                .HasColumnName("RCA_GL");                

            builder.Property(e => e.RefBillNo)
                .IsRequired(false)
                .HasColumnName("REF_BILL_NO")                
                .HasMaxLength(50);

            builder.Property(e => e.Sl)
                .IsRequired(false)
                .HasColumnName("SL");

            builder.Property(e => e.Sort)
                .IsRequired(false)
                .HasColumnName("SORT");

            builder.Property(e => e.Source)
                .IsRequired(false)
                .HasColumnName("SOURCE")                
                .HasMaxLength(50);

            builder.Property(e => e.TranDate)
                .IsRequired(false)
                .HasColumnName("TRAN_DATE")                
                .HasMaxLength(1);

            builder.Property(e => e.TranTypeSeq)
                .IsRequired()
                .HasColumnName("TRAN_TYPE_SEQ");                

            builder.Property(e => e.Udf1)
                .IsRequired(false)
                .HasColumnName("UDF1")
                .HasMaxLength(50);

            builder.Property(e => e.Udf2)
                .IsRequired(false)
                .HasColumnName("UDF2")                
                .HasMaxLength(50);

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("USER_CREATED");

            builder.Property(e => e.UpdatedBy)
                .IsRequired(false)
                .HasColumnName("USER_MODIFIED");                

            builder.Property(e => e.Wo)
                .IsRequired(false)
                .HasColumnName("WO")                
                .HasMaxLength(50);

            builder.Property(e => e.YmPosted)
                .IsRequired(false)
                .HasColumnName("YM_POSTED")                
                .HasMaxLength(1);
        }
    }
}
