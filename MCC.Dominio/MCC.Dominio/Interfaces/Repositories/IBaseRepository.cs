using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TEntityID>
        : IAdd<TEntity>, IUpdate<TEntity>, IDelete<TEntityID>, ISearch<TEntity,TEntityID>, IDBTransactions
    {

    }
}
