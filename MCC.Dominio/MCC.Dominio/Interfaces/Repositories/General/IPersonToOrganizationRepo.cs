﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Interfaces.Repositories.General
{
    internal interface IPersonToOrganizationRepo<TPersonToOrganization, TPersonID, TOrganizationID>
        : IAdd<TPersonToOrganization>, IUpdate<TPersonToOrganization>, ISearchWith2Keys<TPersonToOrganization, TPersonID, TOrganizationID>, IDBTransactions
    {
    }
}
