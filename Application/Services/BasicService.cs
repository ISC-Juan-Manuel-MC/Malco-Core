using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BasicService
    {
        public virtual void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public virtual bool TransactionIsInProgress()
        {
            throw new NotImplementedException();
        }

        public virtual void SendToSaveAllChanges()
        {
            throw new NotImplementedException();
        }

        public virtual void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public virtual void RollbackTransaction()
        {
            throw new NotImplementedException();
        }

        public virtual void CloseTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
