using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Models.General
{
    public class OrganizationRating
    {
        public Guid OrganizationRatingID { get; set; } = Guid.Empty;
        public Guid OrganizationID { get; set; } = Guid.Empty;
        public int Rating { get; set; } = 0;
        public bool Excluded { get; set; } = false;

        #region FKs
        public virtual Organization? FKOrganization { get; set; } 

        #endregion
    }
}
