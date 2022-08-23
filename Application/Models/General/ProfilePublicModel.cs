using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.General
{
    public class ProfilePublicModel
    {
        readonly public string Email;
        readonly public string DisplayName;
        readonly public string Status;

        readonly public PersonPublicModel Person;
        readonly public List<OrganizationPublicModel> Organizations;

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
