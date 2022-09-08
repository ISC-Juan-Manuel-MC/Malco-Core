using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class GenericRequest<TEntity>
    {
        #region Cambiar a header
        public Guid AppID { get; set; }
        public Guid OrganizationID { get; set; }
        public String ProfileID { get; set; }
        #endregion

        public TEntity Data { get; set; }

    }
}
