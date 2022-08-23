using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.General
{
    public class OrganizationPublicModel
    {
        readonly public Guid OrganizationID;
        readonly public string CountryID;
        readonly public string Name;
        readonly public Boolean IsCompany;
        readonly public string Status;

        public OrganizationPublicModel(Guid organizationID, string countryID, string name, bool isCompany, string status)
        {
            OrganizationID = organizationID;
            CountryID = countryID;
            Name = name;
            IsCompany = isCompany;
            Status = status;
        }
    }
}
