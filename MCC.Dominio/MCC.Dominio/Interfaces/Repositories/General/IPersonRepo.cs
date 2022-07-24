using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Interfaces.Repositories.General
{
    public interface IPersonRepo<TPerson,TPersonID>
        :IAdd<TPerson>, IUpdate<TPerson>, ISearch<TPerson,TPersonID>, IDBTransactions
    {
    }
}
