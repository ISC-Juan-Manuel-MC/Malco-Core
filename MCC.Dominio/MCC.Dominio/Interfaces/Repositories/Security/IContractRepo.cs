﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Interfaces.Repositories.Security
{
    public interface IContractRepo<TContract, TContractID>
        : IBaseRepository<TContract, TContractID>
    {
    }
}
