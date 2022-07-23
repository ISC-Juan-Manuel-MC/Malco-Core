using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Models.Security
{
    public class SecurityGrant
    {
        public Guid SecurityRolID { get; set; } = Guid.Empty;
        public Guid ViewID { get; set; } = Guid.Empty;
        public Guid FunctionID { get; set; } = Guid.Empty;
    }
}
