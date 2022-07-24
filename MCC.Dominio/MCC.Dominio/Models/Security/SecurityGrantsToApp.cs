using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Models.Security
{
    public class SecurityGrantsToApp
    {
        public Guid AppID { get; set; } = Guid.Empty;
        public Guid SecurityRolID { get; set; } = Guid.Empty;
        public Guid ViewID { get; set; } = Guid.Empty;
        public Guid FunctionID { get; set; } = Guid.Empty;
        public Guid ActivityLogID { get; set; } = Guid.Empty;
    }
}
