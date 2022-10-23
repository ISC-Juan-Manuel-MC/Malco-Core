using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.CommonBehaviour;
using Application.Models.General;
using Application.Models.Mappers.General;
using Application.Models.Security;
using Application.Services.General;
using Application.Services.Security;
using MCC.Domain.Interfaces.Repositories.General;
using MCC.Domain.Interfaces.Repositories.Security;
using MCC.Domain.Models.General;
using MCC.Domain.Models.Security;

namespace Application.Services.UserCases
{
    public class RegistrationService: BasicService
    {
        private readonly ActivityLogService Log;
        private readonly PersonToProfileService PersonToProfileService;
        private readonly PersonService PersonService;
        private readonly ProfileService ProfileService;
        private readonly ProfileMapper ProfileMapper;
        private readonly PersonMapper PeopleMapper;

        public RegistrationService(
            IActivityLogRepo<ActivityLog, Guid> activityLogRepo,
            IPersonToProfileRepo<PersonToProfile, Guid, String> personToProfileRepo,
            IPersonRepo<Person, Guid> personRepo,
            IProfileRepo<Profile, String> profileRepo
        )
        {
            Log = new ActivityLogService(activityLogRepo);
            PersonToProfileService = new PersonToProfileService(personToProfileRepo);
            PersonService = new PersonService(personRepo);
            ProfileService = new ProfileService(profileRepo);
            ProfileMapper = new ProfileMapper();
            PeopleMapper = new PersonMapper();
        }

        private Person GetNewPersonEntityByData(string firstName,
            string lastName,
            string cellphone,
            string gender,
            DateOnly birthday
            )
        {
            return new()
            {
                FirstName = firstName,
                LastName = lastName,
                Cellphone = cellphone,
                Gender = InternalTools.GetEnumerationValue<Person.PersonGender>(
                    gender,
                    Person.PersonGender.Other
                    ),
                Birthday = birthday
            };
        }

        private Profile GetNewProfileEntityByData(string email,
            string password,
            Person NewPerson
            )
        {
            return new()
            {
                ProfileID = email,
                Password = password,
                DisplayName = InternalTools.GetFullName(NewPerson.FirstName, NewPerson.LastName)
            };
        }

        /// <summary>
        /// Function responsible for adding a new person and a new profile to the system,
        /// it also automatically creates the relationship between profile and person.
        /// </summary>
        /// <param name="jwt"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="cellphone"></param>
        /// <param name="gender"></param>
        /// <param name="birthday"></param>
        /// <returns>
        /// ProfilePublicModel or ExistingEntityError
        /// </returns>
        public ProfilePublicModel Registration(
            JWTModel jwt,
            string email, 
            string password, 
            string firstName, 
            string lastName, 
            string cellphone, 
            string gender, 
            DateOnly birthday)
        {
            Person NewPerson = GetNewPersonEntityByData(firstName, lastName, cellphone, gender, birthday);
            Profile NewProfile = GetNewProfileEntityByData(email, password, NewPerson);

            try
            {
                Validations.EntityExist(ProfileService.FindByID(NewProfile.ProfileID));
                Person? oldPerson = PersonService.FindByName(NewPerson.FirstName, NewPerson.LastName);

                ProfileService.BeginTransaction();

                if (oldPerson != null)
                {
                    NewPerson.PersonID = oldPerson.PersonID;
                    NewPerson.FKActivityLog = Log.MODIFICATION(
                        oldPerson.ActivityLogID,
                        email,
                        "This person created another profile");
                    PersonService.Update(NewPerson);
                }
                else
                {
                    NewPerson.FKActivityLog = Log.CREATION(jwt.OrganizationID, jwt.AppID, new Guid(Views.REGISTRATION), email);
                    NewPerson = PersonService.Add(NewPerson);
                }

                NewProfile.FKActivityLog = Log.CREATION(
                    jwt.OrganizationID, 
                    jwt.AppID, 
                    new Guid(Views.REGISTRATION), 
                    email,
                    NewPerson.FKActivityLog.Comments);
                NewProfile.Password = InternalTools.Encrypt("encryption Key", NewProfile.Password);
                NewProfile = ProfileService.Add(NewProfile);
                PersonToProfileService.JoinPersonToProfile(NewPerson.PersonID, NewProfile.ProfileID);
                //Join to organization

                ProfileService.CommitTransaction();

                return ProfileMapper.GetApplicationEntity(
                    NewProfile,
                    PeopleMapper.GetApplicationEntity(NewPerson)
                    );
            }
            catch (Exception)
            {
                
                ProfileService.RollbackTransaction();
                throw;
            }
            finally
            {
                ProfileService.CloseTransaction();
            }
        }

    }
}
