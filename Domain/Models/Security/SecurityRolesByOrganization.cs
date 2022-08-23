﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Models.Security
{
    public class SecurityRolesByOrganization : BasicModel
    {
        public SecurityRolesByOrganization() : base()
        {
        }

        public Guid SecurityRolID { get; set; } = Guid.Empty;
        public String Name { get; set; } = String.Empty;
        public bool IsEnabled { get; set; } = true;
        public Guid OrganizationID { get; set; } = Guid.Empty;
    }
}
