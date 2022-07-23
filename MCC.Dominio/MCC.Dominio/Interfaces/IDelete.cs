﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Interfaces
{
    public interface IDelete<TEntityID>
    {
        void Delete(TEntityID entityID);
    }
}
