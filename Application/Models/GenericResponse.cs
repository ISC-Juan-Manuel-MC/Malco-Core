using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class GenericResponse<TEntity>
    {
        public TEntity Payload;

        public GenericResponse(TEntity payload)
        {
            Payload = payload;
        }
    }
}
