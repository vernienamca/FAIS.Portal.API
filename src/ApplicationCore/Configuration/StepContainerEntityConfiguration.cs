using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class StepContainerEntityConfiguration : IEntityTypeConfiguration<StepContainer>
    {
        public void Configure(EntityTypeBuilder<StepContainer> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("DM_STEP", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("DM_STEP_SEQ");

            builder.Property(e => e.DefinedMethodId)
                .IsRequired()
                .HasColumnName("DEF_METHOD_SEQ");

            builder.Property(e => e.ParentId)
                .IsRequired()
                .HasColumnName("PARENT_SEQ");

            builder.Property(e => e.SortOrder)
                .IsRequired()
                .HasColumnName("SORT_ORDER");

            builder.Property(e => e.StepType)
                .IsRequired()
                .HasColumnName("STEP_TYPE");

            builder.Property(e => e.FieldDictionaryId)
                .IsRequired(false)
                .HasColumnName("FIELD_DICT_SEQ");

            builder.Property(e => e.IsElse)
                .IsRequired()
                .HasColumnName("IS_ELSE")
                .HasMaxLength(1);

            builder.Property(e => e.Value)
                .IsRequired(false)
                .HasMaxLength(350)
                .HasColumnName("VALUE");

            builder.Property(e => e.Comments)
                .IsRequired(false)
                .HasMaxLength(200)
                .HasColumnName("COMMENTS");

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