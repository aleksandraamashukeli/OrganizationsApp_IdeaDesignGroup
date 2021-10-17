using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class OrganizationPerson
    {

        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
