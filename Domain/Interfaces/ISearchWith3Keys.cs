using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Interfaces
{
    public interface ISearchWith3Keys<TEntity, EntityID1, EntityID2, EntityID3>
    {
        TEntity? Find(EntityID1 entityID1, EntityID2 entityID2, EntityID3 entityID3);
        List<TEntity> GetAll();
    }
}
