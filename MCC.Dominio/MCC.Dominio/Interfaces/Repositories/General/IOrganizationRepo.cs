using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Interfaces.Repositories.General
{
    public interface IOrganizationRepo<TOrganization, TOrganizationID>
        : IAdd<TOrganization>, IUpdate<TOrganization>, ISearch<TOrganization,TOrganizationID>, IDBTransactions
    {

    }
}
