using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Interfaces.Repositories.General
{
    internal interface IOrganizationRatingRepo<TOrganizationRating,TOrganizationID>
        :IAdd<TOrganizationRating>, IUpdate<TOrganizationRating>, ISearch<TOrganizationRating,TOrganizationID>, IDBTransactions
    {
    }
}
