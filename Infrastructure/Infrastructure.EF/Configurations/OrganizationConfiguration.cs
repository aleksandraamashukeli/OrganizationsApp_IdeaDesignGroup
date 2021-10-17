using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configurations
{
    class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Activitie).IsRequired();
            builder.Property(o => o.Address).IsRequired();
            builder.Property(o => o.Name).IsRequired();
        }
    }
}
