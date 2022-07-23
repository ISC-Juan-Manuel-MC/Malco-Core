using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Models.Security
{
    public class LicenseType
    {
        public Guid LicenseTypeID { get; set; } = Guid.Empty;
        public String Name { get; set; } = String.Empty;
        public int NumberOfMonths { get; set; } = 0;
    }
}
