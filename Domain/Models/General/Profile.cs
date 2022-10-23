using Domain.Models;
using MCC.Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Models.General
{
    public class Profile: BasicModel
    {
        /// <summary>
        /// Is the registered email account
        /// </summary>
        public string ProfileID { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string DisplayName { get; set; } = String.Empty;
        public ProfileStatus Status { get; set; } = ProfileStatus.CREATED;

        #region FKs
        public virtual List<ProfileToOrganizations>? FKProfileToOrganizations { get; set; }
        public virtual PersonToProfile? FKPersonToProfile { get; set; }
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
        public enum ProfileStatus
        {
            CREATED = 1,
            VERIFIED = 2,
            BLOCKED = 3,
            SUSPENDED = 4,
        }
    }
}
