using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.CommonBehaviour;
using Application.Errors;
using Application.Models.General;
using Application.Models.Mappers.General;
using Application.Services.General;
using MCC.Domain.Interfaces.Repositories.General;
using MCC.Domain.Models.General;

namespace Application.Services.UserCases
{
    public class LoginService
    {
        private readonly ProfileService ProfileService;
        private readonly PersonToProfileService PersonToProfileService;
        private readonly PersonService PersonService;

        private readonly ProfileMapper ProfileMapper;
        private readonly PersonMapper PeopleMapper;

        public LoginService(
           IProfileRepo<Profile, String> profileRepo,
           IPersonToProfileRepo<PersonToProfile, Guid, String> personToProfileRepo,
           IPersonRepo<Person, Guid> personRepo
           )
        {
            ProfileService = new ProfileService(profileRepo);
            PersonToProfileService = new PersonToProfileService(personToProfileRepo);
            PersonService = new PersonService(personRepo);

            ProfileMapper = new ProfileMapper();
            PeopleMapper = new PersonMapper();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>ProfilePublicModel</returns>
        /// <exception cref="EntityNotExistError"></exception>
        /// <exception cref="UserOrPasswordIncorrectError"></exception>
        public ProfilePublicModel Login(string email, string password)
        {
            Profile? Profile = ProfileService.FindByID(email);
            string EncryptedPassword = InternalTools.Encrypt("encryption Key", password);

            if(Profile != null)
            {
                if (Profile.Password.Equals(EncryptedPassword))
                {
                    PersonToProfile relationship = PersonToProfileService.FindByProfileID(Profile.ProfileID);
                    Person Person = PersonService.FindById(relationship.PersonID);

                    return ProfileMapper.GetApplicationEntity(
                            Profile,
                            PeopleMapper.GetApplicationEntity(Person)
                            );
                }
                else
                {
                    throw new UserOrPasswordIncorrectError();
                }
            }
            else
            {
                throw new EntityNotExistError("Profile");
            }
            
        }
    }
}
