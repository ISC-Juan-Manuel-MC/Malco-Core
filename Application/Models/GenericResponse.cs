using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    internal class GenericResponse<TEntity>
    {
        readonly public TEntity Payload;

        public GenericResponse(TEntity payload)
        {
            Payload = payload;
        }
    }
}
