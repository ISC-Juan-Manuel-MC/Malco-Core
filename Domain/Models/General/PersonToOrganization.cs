using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Models.General
{
    public class PersonToOrganization
    {
        public Guid OrganizationID { get; set; } = Guid.Empty;
        public Guid PersonID { get; set; } = Guid.Empty;

        #region FKs
        public Organization FKOrganization { get; set; } = new Organization();
        public Person FKPerson { get; set; } = new Person();
        #endregion
    }
}
