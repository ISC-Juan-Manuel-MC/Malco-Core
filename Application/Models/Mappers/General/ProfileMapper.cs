using Application.CommonBehaviour;
using Application.Models.General;
using MCC.Domain.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Mappers.General
{
    internal class ProfileMapper : IMapper<Profile, ProfilePublicModel>
    {
        public ProfilePublicModel GetApplicationEntity(Profile origin)
        {
            return new ProfilePublicModel(
                origin.ProfileID,
                origin.DisplayName,
                InternalTools.GetStringEnumerationValue(origin.Status),
                null
                );
        }

        public Profile GetDomainEntity(ProfilePublicModel destination)
        {
            return new Profile()
            {
                ProfileID = destination.Email,
                DisplayName = destination.DisplayName,
                Status = InternalTools.GetEnumerationValue(destination.Status, Profile.ProfileStatus.VERIFIED)
            };
        }

        public ProfilePublicModel GetApplicationEntity(Profile origin, PersonPublicModel person)
        {
            return new ProfilePublicModel(
                origin.ProfileID,
                origin.DisplayName,
                InternalTools.GetStringEnumerationValue(origin.Status),
                person,
                new List<OrganizationPublicModel>()
                );
        }

        public ProfilePublicModel GetApplicationEntity(Profile origin, PersonPublicModel person, OrganizationPublicModel organizations)
        {
            return new ProfilePublicModel(
                origin.ProfileID,
                origin.DisplayName,
                InternalTools.GetStringEnumerationValue(origin.Status),
                person,
                new List<OrganizationPublicModel> { organizations }
                );
        }

        public ProfilePublicModel GetApplicationEntity(Profile origin, PersonPublicModel person, List<OrganizationPublicModel> organizations)
        {
            return new ProfilePublicModel(
                origin.ProfileID,
                origin.DisplayName,
                InternalTools.GetStringEnumerationValue(origin.Status),
                person,
                organizations
                );
        }
    }
}
