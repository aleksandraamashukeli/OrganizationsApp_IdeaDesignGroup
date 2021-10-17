using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Enums;
using Application.Common.Models.Organization;
namespace Application.Common.Models.Person
{
    public class GetPersonDTO
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
