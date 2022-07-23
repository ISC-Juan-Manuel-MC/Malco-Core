using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Interfaces
{
    public interface IDBTransactions
    {
        void BeginTransaction();
        void SendToSaveAllChanges();
        void CommitTransaction();
        void RollbackTransaction();
        void CloseTransaction();
    }
}
