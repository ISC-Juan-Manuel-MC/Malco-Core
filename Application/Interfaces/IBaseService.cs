using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MCC.Domain.Interfaces;


namespace Application.Interfaces
{
    public interface IBaseService<TEntity,TEntityID>
        : IAdd<TEntity>, IUpdate<TEntity>, ISearch<TEntity,TEntityID>, IDelete<TEntityID>
    {
    }
}
