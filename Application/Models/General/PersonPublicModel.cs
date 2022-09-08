using Application.CommonBehaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.General
{
    public class PersonPublicModel
    {
        public Guid PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Cellphone { get; set; }
        public string Gender { get; set; }
        public DateOnly Birthday { get; set; }

        public PersonPublicModel(Guid personID, string firstName, string lastName, string cellphone, string gender, DateOnly birthday)
        {
            PersonID = personID;
            FirstName = firstName;
            LastName = lastName;
            Cellphone = cellphone;
            Gender = gender;
            Birthday = birthday;

            FullName = InternalTools.GetFullName(FirstName, LastName);
        }

    }
}
