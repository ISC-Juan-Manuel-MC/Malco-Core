using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Interfaces
{
    public interface ISearch<TEntity,EntityID>
    {
        TEntity Find(EntityID entityID);
        List<TEntity> FindAll();
    }
}
