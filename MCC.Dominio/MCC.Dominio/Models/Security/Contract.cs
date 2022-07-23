using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Models.Security
{
    public class Contract
    {
        public Guid ContractID { get; set; } = Guid.Empty;
        public Guid LicenseID { get; set; } = Guid.Empty;
        public Guid AppID { get; set; } = Guid.Empty;
        public Guid OrganizationID { get; set; } = Guid.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly EndDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public ContractStatus Status { get; set; } = ContractStatus.VALID;
        public Guid ActivityLogID { get; set; } = Guid.Empty;


        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <description>Valid - Contract in progress</description>
        /// </item>
        /// <item>
        /// <description>Completed - Dates Completed</description>
        /// </item>
        /// <item>
        /// <description>Suspended - Disabled due to non-compliance/some reason</description>
        /// </item>
        /// <item>
        /// <description>Canceled - Finished but not due to compliance with dates</description>
        /// </item>
        /// </list>
        /// </summary>
        public enum ContractStatus
        {
            VALID = 1,
            COMPLETED = 2,
            SUSPENDED = 3,
            CANCELED = 4,
        }
    }
}
