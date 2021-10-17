using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Enums;
using System;
using Infrastructure.EF.Configurations;

namespace Infrastructure.EF
{
    public class DBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public DbSet<OrganizationPerson> OrganizationPeople { get; set; }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().HasData(
                new Person { Id= 1, FirstName = "Giorgi", LastName = "Wiklauri",Gender =GenderEnum.Male,PersonalId= "01011091123",BirthDay= DateTime.Parse("1997-03-14 00:00"),City= CityEnum.Tbilisi,PhoneNumber=599451710 }
            );


            modelBuilder.Entity<Organization>().HasData(
                new Organization
                {
                    Id=1,
                    Name="Apple",
                    Activitie="IT Company",
                    Address = "California,USA"
                });

            modelBuilder.ApplyConfiguration<Person>(new PersonConfiguration());
            modelBuilder.ApplyConfiguration<Organization>(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration<OrganizationPerson>(new OrganizationPersonConfiguration());
        }
    }
}
