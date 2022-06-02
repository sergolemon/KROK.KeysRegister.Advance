using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntitiesConfiguration
{
    internal class AuditoryTypeConfiguration : IEntityTypeConfiguration<AuditoryTypeEntity>
    {
        public void Configure(EntityTypeBuilder<AuditoryTypeEntity> builder)
        {
            builder.HasIndex(entity => entity.Name).IsUnique();
            builder.Property(entity => entity.Name).HasMaxLength(60);
        }
    }
}
