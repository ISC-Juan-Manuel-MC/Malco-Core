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
    internal class OrganizationMapper : IMapper<Organization, OrganizationPublicModel>
    {
        public OrganizationPublicModel GetApplicationEntity(Organization origin)
        {
            return new OrganizationPublicModel(
                origin.OrganizationID, 
                origin.CountryID, 
                origin.Name, 
                origin.IsCompany, 
                InternalTools.GetStringEnumerationValue(origin.Status));
        }

        public Organization GetDomainEntity(OrganizationPublicModel destination)
        {
            return new Organization()
            {
                OrganizationID = destination.OrganizationID,
                CountryID = destination.CountryID,
                Name = destination.Name,
                IsCompany = destination.IsCompany,
                Status = InternalTools.GetEnumerationValue(destination.Status, Organization.OrganizationStatus.CREATED),
            };
        }
    }
}
