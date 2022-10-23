using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Models.General
{
    public class ProfileToOrganizations
    {
        public Guid OrganizationID { get; set; } = Guid.Empty;
        public String ProfileID { get; set; } = string.Empty;

        #region FKs
        public virtual Organization? FKOrganization { get; set; }
        public virtual Profile? FKProfile { get; set; }
        #endregion
    }
}
