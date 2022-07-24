using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Interfaces.Repositories.Security
{
    public interface ILicenseTypeRepo<TLicenseType, TLicenseTypeID>
        : IAdd<TLicenseType>, IUpdate<TLicenseType>, ISearch<TLicenseType, TLicenseTypeID>, IDBTransactions
    {
    }
}
