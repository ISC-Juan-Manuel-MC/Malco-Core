using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Security
{
    public class VerificationPINPublicModel
    {
        public string ProfileID { get; set; } = String.Empty;
        public List<int> PIN { get; set; } = new List<int>();
        public bool WasUsed { get; set; } = false;

        public VerificationPINPublicModel(string profileID, List<int> _PIN, bool wasUsed)
        {
            ProfileID = profileID;
            PIN = _PIN;
            WasUsed = wasUsed;
        }

    }
}
