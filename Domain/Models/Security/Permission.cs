using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Models.Security
{
    public class Permission
    {
        public Guid ViewId { get; set; } = Guid.Empty;
        public Guid FunctionID { get; set; } = Guid.Empty;
        public bool IsEnabled { get; set; } = true;

    }
}
