using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Interfaces
{
    public interface ISearchWith4Keys<TEntity, EntityID1, EntityID2, EntityID3, EntityID4>
    {
        TEntity Find(EntityID1 entityID1, EntityID2 entityID2, EntityID3 entityID3, EntityID4 entityID4);
        List<TEntity> FindAll();
    }
}
