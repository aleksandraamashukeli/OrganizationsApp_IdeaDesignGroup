using System.Collections.Generic;

namespace Domain.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Address { get; set; }

        public string Activitie { get; set; }

        public virtual ICollection<OrganizationPerson> OrganizationPeople { get; set; }
    }
}
