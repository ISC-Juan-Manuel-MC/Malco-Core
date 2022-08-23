using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Errors
{
    internal class UserOrPasswordIncorrectError : Exception
    {
        public UserOrPasswordIncorrectError() : base(
            "User Or Password Incorrect",
            new InvalidOperationException()
            )
        {
        }
    }
}
