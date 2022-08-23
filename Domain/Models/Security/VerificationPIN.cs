using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Security
{
    public class VerificationPIN : BasicModel
    {
        public VerificationPIN() : base()
        {
        }

        public string ProfileID { get; set; } = string.Empty;
        public int PIN { get; set; } = 0;
        public DateTime StartDatetime { get; set; } = DateTime.Now;
        public DateTime EndDatetime { get; set; } = DateTime.Now;
        public bool WasUsed { get; set; } = false;

    }
}
