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
        public EntityNotExistError() : base("Entity Not Exist", new ArgumentNullException())
        {
        }
    }
}
