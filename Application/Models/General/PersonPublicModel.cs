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
        readonly public Guid PersonID;
        readonly public string FirstName;
        readonly public string LastName;
        readonly public string FullName;
        readonly public string Cellphone;
        readonly public string Gender;
        readonly public DateOnly Birthday;

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
