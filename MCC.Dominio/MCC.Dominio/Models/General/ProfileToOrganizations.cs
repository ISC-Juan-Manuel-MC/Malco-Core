﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Models.General
{
    public class ProfileToOrganizations
    {
        public Guid OrganizationID { get; set; } = Guid.Empty;
        public Guid ProfileID { get; set; } = Guid.Empty;
    }
}
