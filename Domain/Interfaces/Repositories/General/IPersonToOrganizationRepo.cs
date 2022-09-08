using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Interfaces.Repositories.General
{
    public interface IPersonToOrganizationRepo<TPersonToOrganization, TPersonID, TOrganizationID>
        : IAdd<TPersonToOrganization>, ISearchWith2Keys<TPersonToOrganization, TPersonID, TOrganizationID>, IDBTransactions
    {
    }
}
