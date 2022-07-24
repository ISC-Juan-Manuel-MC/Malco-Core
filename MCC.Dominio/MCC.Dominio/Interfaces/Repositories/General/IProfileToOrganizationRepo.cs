using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Interfaces.Repositories.General
{
    public interface IProfileToOrganizationRepo<TProfileToOrganization, TProfile, TOrganizationID>
        : IAdd<TProfileToOrganization>, IUpdate<TProfileToOrganization>, ISearchWith2Keys<TProfileToOrganization, TProfile, TOrganizationID>, IDBTransactions
    {
    }
}
