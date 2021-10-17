using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Enums;
using OrganizationsApp.Models.Organization;

namespace OrganizationsApp.Models.Person
{
    public class GetPersonViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public string PersonalId { get; set; }
        public DateTime BirthDay { get; set; }

        public CityEnum City { get; set; }

        public int PhoneNumber { get; set; }
    }
}
