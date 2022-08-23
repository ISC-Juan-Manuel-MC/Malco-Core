using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Errors
{
    public class ExpiredVerificationCodeError : Exception
    {

        public ExpiredVerificationCodeError(int verificationCode) : base(
            "The Verification Code " + verificationCode + " is expired",
            new InvalidOperationException()
            )
        {
        }

    }
}
