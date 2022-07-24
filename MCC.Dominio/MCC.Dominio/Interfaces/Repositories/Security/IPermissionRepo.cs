using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Interfaces.Repositories.Security
{
    public interface IPermissionRepo<TPermission, TViewID, TFuctionID>
        : IAdd<TPermission>, IUpdate<TPermission>, ISearchWith2Keys<TPermission, TViewID, TFuctionID>, IDelete<TPermission>, IDBTransactions
    {
    }
}
