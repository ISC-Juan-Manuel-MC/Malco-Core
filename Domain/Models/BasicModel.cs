using MCC.Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BasicModel
    {
        public Guid ActivityLogID { get; set; } = Guid.Empty;

        #region FKs
        public virtual ActivityLog? FKActivityLog { get; set; }
        #endregion


    }
}
