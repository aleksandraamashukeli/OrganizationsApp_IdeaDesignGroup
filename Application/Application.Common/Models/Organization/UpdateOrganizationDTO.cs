﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models.Organization
{
    public class UpdateOrganizationDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string Activitie { get; set; }
    }
}
