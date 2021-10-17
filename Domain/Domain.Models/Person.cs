using Domain.Models.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Person 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public string PersonalId { get; set; }
        public DateTime BirthDay { get; set; }

        public CityEnum City { get; set; }

        public int PhoneNumber { get; set; }

        public virtual ICollection<OrganizationPerson> OrganizationPeople { get; set; }
    }
}
