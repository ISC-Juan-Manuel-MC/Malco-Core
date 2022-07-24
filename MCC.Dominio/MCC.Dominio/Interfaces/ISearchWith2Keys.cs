using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Interfaces
{
    public interface ISearchWith2Keys<TEntity, EntityID1, EntityID2>
    {
        TEntity Find(EntityID1 entityID1, EntityID2 entityID2);
        List<TEntity> FindAll();
    }
}
