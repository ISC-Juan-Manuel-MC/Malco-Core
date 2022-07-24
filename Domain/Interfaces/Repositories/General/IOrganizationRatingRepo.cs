using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Interfaces.Repositories.General
{
    internal interface IOrganizationRatingRepo<TOrganizationRating,TOrganizationID>
        :IAdd<TOrganizationRating>, IUpdate<TOrganizationRating>, ISearch<TOrganizationRating,TOrganizationID>, IDBTransactions
    {
    }
}
