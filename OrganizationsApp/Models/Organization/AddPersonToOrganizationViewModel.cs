using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationsApp.Models.Organization
{
    public class AddPersonToOrganizationViewModel
    {
        [Required]
        public int PersonId { get; set; }

        [Required]
        public int OrganizationId { get; set; }
    }
}
