using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Errors;

namespace Application.CommonBehaviour
{
    internal class Validations
    {
        public static void NonNullEntity<TEntity>(TEntity entity)
        {
            if (entity == null)
            {
                throw new EntityNotExistError(typeof(TEntity).Name);
            }
        }

        public static void EntityExist<TEntity>(TEntity entity)
        {
            if (entity != null)
            {
                throw new ExistingEntityError(typeof(TEntity).Name);
            }
        }
    }
}
