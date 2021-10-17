using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrganizationsApp.Models.Person;

namespace OrganizationsApp.Models.Organization
{
    public class GetOrganizationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string Activitie { get; set; }
    }
}
