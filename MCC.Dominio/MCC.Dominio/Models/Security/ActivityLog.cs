using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Models.Security
{
    public class ActivityLog
    {
        public Guid ActivityLogID { get; set; } = Guid.Empty;
        public Types ActivityLogTypeID { get; set; }
        public Guid AppID { get; set; } = Guid.Empty;
        public Guid OrganizationID { get; set; } = Guid.Empty;
        public string ProfileID { get; set; } = String.Empty;
        public DateTime ActivityDatetime { get; set; } = DateTime.Now;
        public Guid ViewID { get; set; } = Guid.Empty;
        public Guid? ActivityLogIDReference { get; set; } = null;
        public string? Comments { get; set; } = null;

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <description>Creation</description>
        /// </item>
        /// <item>
        /// <description>Modification</description>
        /// </item>
        /// <item>
        /// <description>Deletion</description>
        /// </item>
        /// <item>
        /// <description>Login</description>
        /// </item>
        /// <item>
        /// <description>Logout</description>
        /// </item>
        /// </list>
        /// </summary>
        public enum Types
        {
            CREATION = 1,
            MODIFICATION = 2,
            DELETION = 3,
            LOGIN = 4,
            LOGOUT = 5,
        }
    }
}
