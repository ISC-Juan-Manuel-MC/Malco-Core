using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Interfaces.Repositories.General
{
    public interface IPersonToProfileRepo<TPersonToProfile, TPersonID, TProfileID>
        : IAdd<TPersonToProfile>, IUpdate<TPersonToProfile>, ISearchWith2Keys<TPersonToProfile, TPersonID, TProfileID>, IDBTransactions
    {
        IEnumerable<TPersonToProfile> FindByPersonID(TPersonID personID);
        TPersonToProfile FindByProfileID(TProfileID profileID);

    }
}
