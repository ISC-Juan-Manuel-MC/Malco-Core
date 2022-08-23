using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Models;

namespace Application.Errors
{
    internal class EntityNotExistError : Exception
    {
        public readonly string EntityName;

        public EntityNotExistError(string entityName) : base(
            "Entity (" + entityName + ") Not Exist", 
            new ArgumentNullException()
            )
        {
            EntityName = entityName;
        }
    }
}
