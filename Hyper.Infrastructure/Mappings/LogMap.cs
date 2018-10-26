﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hyper.Domain.Models;

namespace Hyper.Persistence.Mappings
{
    public class LogMap
    {
        public LogMap(EntityTypeBuilder<Log> entityBuilder)
        {
            // Key
            entityBuilder.HasKey(t => t.Id);

            // Properties
            entityBuilder.Property(t => t.Id)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            entityBuilder.Property(t => t.ModelName)
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            entityBuilder.Property(t => t.ActionName)
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            entityBuilder.Property(t => t.ModelJson)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            entityBuilder.Property(t => t.CreationTime)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
