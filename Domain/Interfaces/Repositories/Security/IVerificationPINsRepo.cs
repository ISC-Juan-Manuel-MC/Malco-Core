using MCC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.Security
{
    public interface IVerificationPINsRepo<TVerificationPIN,TProfileID, TPIN>
        : IAdd<TVerificationPIN>, IUpdate<TVerificationPIN>, ISearchWith2Keys<TVerificationPIN,TProfileID,TPIN>, IDelete<TProfileID>, IDBTransactions
    {
        IEnumerable<TVerificationPIN> FindByProfileID(TProfileID profileID);

    }
}
