using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Enums;

namespace OrganizationsApp.Models.Person
{
    public class DeletePersonViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public GenderEnum Gender { get; set; }

        [Required]
        public string PersonalId { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        [Required]
        public CityEnum City { get; set; }

        [Required]
        public int PhoneNumber { get; set; }
    }
}
