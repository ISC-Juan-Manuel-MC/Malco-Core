using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Models.Security
{
    public class SecurityRol
    {
        public Guid SecurityRolID { get; set; } = Guid.Empty;
        public String Name { get; set; } = String.Empty;
        public bool IsEnabled { get; set; } = true;
    }
}
