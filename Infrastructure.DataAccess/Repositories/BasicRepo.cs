using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Repositories
{
    internal class BasicRepo <TEntity>
    {
        protected bool SaveHistory(TEntity entity)
        {
            return entity == null ? false : (entity.GetType() == typeof(BasicModel));
        }
    }
}
