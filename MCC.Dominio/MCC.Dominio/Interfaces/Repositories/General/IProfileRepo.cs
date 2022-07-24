using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Interfaces.Repositories.General
{
    public interface IProfileRepo<TProfile, TProfileID>
        : IAdd<TProfile>, IUpdate<TProfile>, ISearch<TProfile, TProfileID>, IDelete<TProfileID>, IDBTransactions
    {
    }
}
