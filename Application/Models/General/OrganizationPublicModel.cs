using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.General
{
    public class OrganizationPublicModel
    {
        public Guid OrganizationID { get; set; }
        public string CountryID { get; set; }
        public string Name { get; set; }
        public Boolean IsCompany { get; set; }
        public string Status { get; set; }

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
