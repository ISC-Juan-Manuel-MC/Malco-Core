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
        public Guid ProfileID { get; set; } = Guid.Empty;

        #region FKs
        public Organization FKOrganization { get; set; } = new Organization();
        public Profile FKProfile { get; set; } = new Profile();
        #endregion
    }
}
