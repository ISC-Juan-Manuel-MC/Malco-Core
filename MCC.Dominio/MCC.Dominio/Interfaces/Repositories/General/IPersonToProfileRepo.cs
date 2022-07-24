using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Interfaces.Repositories.General
{
    public interface IPersonToProfileRepo<TPersonToProfile, TPersonID, TProfileID>
        : IAdd<TPersonToProfile>, IUpdate<TPersonToProfile>, ISearchWith2Keys<TPersonToProfile, TPersonID, TProfileID>, IDBTransactions
    {
    }
}
