using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configurations
{
    class OrganizationPersonConfiguration : IEntityTypeConfiguration<OrganizationPerson>
    {
        public void Configure(EntityTypeBuilder<OrganizationPerson> builder)
        {
            builder.HasKey(o => new { o.OrganizationId, o.PersonId });
            builder
                .HasOne( o=> o.Person)
                .WithMany(b => b.OrganizationPeople)
                .HasForeignKey(bc => bc.PersonId);
            builder
                .HasOne(bc => bc.Organization)
                .WithMany(c => c.OrganizationPeople)
                .HasForeignKey(o => o.OrganizationId);
        }
    }
}
