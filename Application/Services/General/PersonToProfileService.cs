using MCC.Domain.Interfaces;
using MCC.Domain.Interfaces.Repositories.General;
using MCC.Domain.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.General
{
    public class PersonToProfileService
    {
        private readonly IPersonToProfileRepo<PersonToProfile, Guid, string> repository;

        public PersonToProfileService(IPersonToProfileRepo<PersonToProfile, Guid, string> assignationRepo)
        {
            repository = assignationRepo;
        }

        public void JoinPersonToProfile(Guid personID, string profileID)
        {
            if (!RelationshipAlreadyExists(personID, profileID))
            {
                PersonToProfile personToProfile = new()
                {
                    PersonID = personID,
                    ProfileID = profileID
                };

                repository.Add(personToProfile);
                repository.SendToSaveAllChanges();
            }
        }

        public bool RelationshipAlreadyExists(Guid personID, string profileID)
        {
            PersonToProfile personToProfile = repository.Find(personID, profileID);
            return personToProfile != null;
        }

        public IEnumerable<PersonToProfile> FindByPersonID(Guid personID)
        {
            return repository.FindByPersonID(personID);
        }

        public PersonToProfile FindByProfileID(string profileID)
        {
            return repository.FindByProfileID(profileID);
        }

    }
}
