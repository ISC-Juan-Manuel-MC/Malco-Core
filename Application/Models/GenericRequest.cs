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
        readonly public Guid AppID;
        readonly public Guid OrganizationID;
        readonly public String ProfileID;
        #endregion

        readonly public TEntity Data;


        public GenericRequest(Guid appID, Guid organizationID, string profileID, TEntity data)
        {
            AppID = appID;
            OrganizationID = organizationID;
            ProfileID = profileID;
            Data = data;
        }
    }
}
