using DocumentFormat.OpenXml.Vml.Office;
using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class TemplateEntityConfiguration : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("TEMPLATES", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("TEMPLATE_SEQ");

            builder.Property(e => e.Subject)
                .HasMaxLength(250)
                .HasColumnName("SUBJECT");

            builder.Property(e => e.Content)
                .HasMaxLength(500)
                .HasColumnName("CONTENT");

            builder.Property(e => e.Receiver)
                .HasMaxLength(250)
                .HasColumnName("RECEIVER");

            builder.Property(e => e.NotificationType)
                .HasMaxLength(50)
                .HasColumnName("NOTIFICATION_TYPE");

            builder.Property(e => e.IsActive)
                .HasMaxLength(1)
                .HasColumnName("IS_ACTIVE");

            builder.Property(e => e.StatusDate)
                .HasColumnName("STATUS_DATE")
                .HasColumnType("datetime");

            builder.Property(e => e.NotificationType)
                .HasMaxLength(50)
                .HasColumnName("NOTIFICATION_TYPE");

            builder.Property(e => e.CreatedBy)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USER_CREATED");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("DATE_CREATED");

            builder.Property(e => e.UpdatedBy)
                .HasColumnType("NUMBER")
                .HasColumnName("USER_MODIFIED");

            builder.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("DATE_MODIFIED");
        }
    }
}
