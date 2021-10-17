using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Models.Organization;

namespace Application.Common.Models.Person
{
    public class CreatePersonDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public int PersonalId { get; set; }
        public DateTime BirthDay { get; set; }

        public CityEnum City { get; set; }

        public string PhoneNumber { get; set; }

    }
}
