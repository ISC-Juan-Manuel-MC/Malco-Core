using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Interfaces.Repositories.Security
{
    public interface IActivityLogRepo<TActivityLog, TActivityLogID>
        : ISearch<TActivityLog, TActivityLogID>, IDBTransactions
    {
        TActivityLog CREATION(Guid OrganizationID, Guid AppID, Guid ViewID, string ProfileID);
        TActivityLog? MODIFICATION(TActivityLogID LogID, string ProfileID);
        TActivityLog? DELETION(TActivityLogID LogID, string ProfileID);
        TActivityLog? LOGIN(TActivityLogID LogID, string ProfileID);
        TActivityLog? LOGOUT(TActivityLogID LogID, string ProfileID);
    }
}
