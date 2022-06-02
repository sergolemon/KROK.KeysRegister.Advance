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
    internal class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.Property(entity => entity.FirstName).HasMaxLength(30);
            builder.Property(entity => entity.LastName).HasMaxLength(30);
            builder.Property(entity => entity.Patronymic).HasMaxLength(30);
        }
    }
}
