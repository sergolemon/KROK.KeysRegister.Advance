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
    internal class KeyConfiguration : IEntityTypeConfiguration<KeyEntity>
    {
        public void Configure(EntityTypeBuilder<KeyEntity> builder)
        {
            builder.HasIndex(entity => entity.Name).IsUnique();
            builder.Property(entity => entity.Name).HasMaxLength(30);
        }
    }
}
