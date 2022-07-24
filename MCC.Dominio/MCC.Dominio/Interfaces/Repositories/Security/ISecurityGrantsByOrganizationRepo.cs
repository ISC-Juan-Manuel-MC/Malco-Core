using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Interfaces.Repositories.Security
{
    public interface ISecurityGrantsByOrganizationRepo<TSecurityGrantsByOrganization, TSecurityRolID, TViewID, TFunctionID, TOrganizationID>
        : IAdd<TSecurityGrantsByOrganization>, IUpdate<TSecurityGrantsByOrganization>, 
          ISearchWith4Keys<TSecurityGrantsByOrganization, TSecurityRolID, TViewID, TFunctionID, TOrganizationID>, IDBTransactions
    {
    }
}
