using Domain.Models;
using MCC.Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Models.General
{
    public class Organization : BasicModel
    {
        public Guid OrganizationID { get; set; } = Guid.Empty;
        /// <summary>
        /// Country identifier => In México is RFC
        /// </summary>
        public string CountryID { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public bool IsCompany { get; set; } = false;
        public Guid PersonID { get; set; } = Guid.Empty;
        public OrganizationStatus Status { get; set; } = OrganizationStatus.CREATED;


        #region FKs
        public virtual List<OrganizationRating>? FKOrganizationRating { get; set; } 
        public virtual List<ProfileToOrganizations>? FKProfileToOrganizations { get; set; } 
        public virtual List<PersonToOrganization>? FKPersonToOrganization { get; set; }

        #endregion

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <description>Created- Registered (profile, organization and person if required) and pending verification.</description>
        /// </item>
        /// <item>
        /// <description>Verified - Identity verified</description>
        /// </item>
        /// <item>
        /// <description>Blocked - Organization disabled for some reason</description>
        /// </item>
        /// <item>
        /// <description>Suspended - logical deletion of profile</description>
        /// </item>
        /// </list>
        /// </summary>
        public enum OrganizationStatus
        {
            CREATED = 1,
            VERIFIED = 2,
            BLOCKED = 3,
            SUSPENDED = 4,
        }
    }
}
