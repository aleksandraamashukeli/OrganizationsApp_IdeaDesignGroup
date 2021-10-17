using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Models.Person;
namespace Application.Common.Models.Organization
{
    public class GetOrganizationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string Activitie { get; set; }

        public virtual ICollection<GetPersonDTO> People { get; set; }
    }
}
