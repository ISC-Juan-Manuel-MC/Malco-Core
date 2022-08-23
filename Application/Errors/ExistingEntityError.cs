using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Errors
{
    public class ExistingEntityError : Exception
    {
        public readonly string EntityName;

        public ExistingEntityError(string entityName) : base(
            "The entity " + entityName + " already exists", 
            new InvalidOperationException()
            )
        {
            EntityName = entityName;
        }

    }
}
