using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.General
{
    public class ProfilePublicModel
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Status { get; set; }

        public PersonPublicModel Person { get; set; }
        public List<OrganizationPublicModel> Organizations { get; set; }

        public ProfilePublicModel(string email, string displayName, string status, PersonPublicModel person)
        {
            Email = email;
            DisplayName = displayName;
            Status = status;
            Person = person;
            Organizations = new List<OrganizationPublicModel>();
        }

        public ProfilePublicModel(string email, string displayName, string status, PersonPublicModel person, List<OrganizationPublicModel> organizations)
        {
            Email = email;
            DisplayName = displayName;
            Status = status;
            Person = person;
            Organizations = organizations;
        }
    }
}
