using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Interfaces.Repositories.Security
{
    public interface ISecurityGrantRepo<TSecurityGrant, TSecurityRolID, TViewID, TFunctionID>
        : IAdd<TSecurityGrant>, IUpdate<TSecurityGrant>, ISearchWith3Keys<TSecurityGrant, TSecurityRolID, TViewID, TFunctionID>, IDBTransactions
    {
    }
}
