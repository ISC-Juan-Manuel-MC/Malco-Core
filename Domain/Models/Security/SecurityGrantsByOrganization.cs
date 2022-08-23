using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Models.Security
{
    public class SecurityGrantsByOrganization : BasicModel
    {
        public SecurityGrantsByOrganization() : base()
        {
        }

        public Guid SecurityRolID { get; set; } = Guid.Empty;
        public Guid ViewID { get; set; } = Guid.Empty;
        public Guid FunctionID { get; set; } = Guid.Empty;
        public Guid OrganizationID { get; set; } = Guid.Empty;
    }
}
