﻿using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class LibraryOptionsEntityConfiguration : IEntityTypeConfiguration<LibraryOptions>
    {
        public void Configure(EntityTypeBuilder<LibraryOptions> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToTable("LIBRARY_TYPE_OPTIONS", "FAIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("LIB_TYPE_OPT_SEQ");

            builder.Property(e => e.LibraryTypeId)
                .IsRequired()
                .HasColumnName("LIB_TYPE_SEQ");

            builder.Property(e => e.Code)
                .IsRequired(false)
                .HasColumnName("LIB_TYPE_OPT_CODE")
                .HasMaxLength(10);

            builder.Property(e => e.Description)
                  .HasMaxLength(200)
                  .IsRequired(true)
                  .HasColumnName("LIB_TYPE_OPT_DESC");

            builder.Property(e => e.Remarks)
                .IsRequired(false)
                .HasColumnName("REMARKS")
                .HasMaxLength(250);

            builder.Property(e => e.Ranking)
                 .IsRequired(false)
                 .HasColumnName("RANKING");

            builder.Property(e => e.UDF1)
                  .IsRequired(false)
                  .HasColumnName("UDF1")
                  .HasMaxLength(250);

            builder.Property(e => e.UDF2)
                  .IsRequired(false)
                  .HasColumnName("UDF2")
                  .HasMaxLength(250);

            builder.Property(e => e.UDF3)
                  .IsRequired(false)
                  .HasColumnName("UDF3")
                  .HasMaxLength(250);

            builder.Property(e => e.IsActive)
                .IsRequired()
                .HasColumnName("IS_ACTIVE")
                .HasMaxLength(1);

            builder.Property(e => e.StatusDate)
                .IsRequired()
                .HasColumnType("datetime")
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