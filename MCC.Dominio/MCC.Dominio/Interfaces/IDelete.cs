using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Interfaces
{
    public interface IDelete<TEntityID>
    {
        /// <summary>
        /// Remove item from Database
        /// </summary>
        /// <param name="entityID"></param>
        void Delete(TEntityID entityID);
        /// <summary>
        /// Change flag "IsEnabled" to display like a not available
        /// </summary>
        /// <param name="entityID"></param>
        void Disabled(TEntityID entityID);
        /// <summary>
        /// Logic deletion
        /// </summary>
        /// <param name="entityID"></param>
        void Hide(TEntityID entityID);
    }
}
