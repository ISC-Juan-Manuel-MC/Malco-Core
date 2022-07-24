using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Interfaces.Repositories.Security
{
    public interface ISecurityGrantsToAppsRepo<TSecurityGrantsToApps, TAppID, TSecurityRolID, TViewID, TFunctionID>
        : IAdd<TSecurityGrantsToApps>, IUpdate<TSecurityGrantsToApps>,
          ISearchWith4Keys<TSecurityGrantsToApps, TAppID, TSecurityRolID, TViewID, TFunctionID>, IDBTransactions
    {
    }
}
