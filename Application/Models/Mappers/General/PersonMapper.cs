using Application.CommonBehaviour;
using Application.Models.General;
using MCC.Domain.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MCC.Domain.Models.General.Person;

namespace Application.Models.Mappers.General
{
    internal class PersonMapper : IMapper<Person, PersonPublicModel>
    {
        public PersonPublicModel GetApplicationEntity(Person origin)
        {
            return new PersonPublicModel(
                origin.PersonID, 
                origin.FirstName, 
                origin.LastName,
                origin.Cellphone,
                InternalTools.GetStringEnumerationValue(origin.Gender),
                origin.Birthday);
        }

        public Person GetDomainEntity(PersonPublicModel destination)
        {
            return new Person()
            {
                PersonID = destination.PersonID,
                FirstName = destination.FirstName,
                LastName = destination.LastName,
                Cellphone = destination.Cellphone,
                Gender = InternalTools.GetEnumerationValue<PersonGender>(destination.Gender, PersonGender.Other),
                Birthday = destination.Birthday
            };
        }
    }
}
