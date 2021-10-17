using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.FirstName).IsRequired();
            builder.Property(o => o.LastName).IsRequired();
            builder.Property(o => o.BirthDay).IsRequired();
            builder.Property(o => o.PersonalId).IsRequired();
            builder.Property(o => o.PhoneNumber).IsRequired();

            builder.Property(o => o.Gender).IsRequired();
            builder.Property(o => o.City).IsRequired();
        }
    }
}
