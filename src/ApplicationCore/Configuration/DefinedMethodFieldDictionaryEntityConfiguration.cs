using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class DefinedMethodFieldDictionaryEntityConfiguration : IEntityTypeConfiguration<DefinedMethodFieldDictionary>
    {
        public void Configure(EntityTypeBuilder<DefinedMethodFieldDictionary> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("DM_FIELDDICT", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("DM_FIELDDICT_SEQ");

            builder.Property(e => e.DefinedMethodId)
                .IsRequired()
                .HasColumnName("DEF_METHOD_SEQ");

            builder.Property(e => e.FieldDictionaryId)
                .IsRequired()
                .HasColumnName("FIELD_DICT_SEQ");

            builder.Property(e => e.Description)
                .IsRequired(false)
                .HasMaxLength(200)
                .HasColumnName("DESCRIPTION");

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

            builder.Property(e => e.DateRemoved)
                .IsRequired(false)
                .HasColumnType("datetime")
                .HasColumnName("DATE_REMOVED");
        }
    }
}