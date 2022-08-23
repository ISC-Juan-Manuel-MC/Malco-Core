using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CommonBehaviour;
using Application.Models.Security;
using Domain.Models.Security;

namespace Application.Models.Mappers.Security
{
    internal class VerificationPINMapper : IMapper<VerificationPIN, VerificationPINPublicModel>
    {
        public VerificationPINPublicModel GetApplicationEntity(VerificationPIN domainEntity)
        {
            return new VerificationPINPublicModel(
                domainEntity.ProfileID,
                InternalTools.ConvertPINToList(domainEntity.PIN),
                domainEntity.WasUsed
                );
        }

        public IEnumerable<VerificationPINPublicModel> GetApplicationEntity(IEnumerable<VerificationPIN> domainEntity)
        {
            List<VerificationPINPublicModel> PINs = new List<VerificationPINPublicModel>();

            foreach (VerificationPIN element in domainEntity)
            {
                PINs.Add(
                    new VerificationPINPublicModel(
                        element.ProfileID,
                        InternalTools.ConvertPINToList(element.PIN),
                        element.WasUsed
                        )
                    );
            }
    
            return PINs;
        }

        public VerificationPIN GetDomainEntity(VerificationPINPublicModel applicationEntity)
        {
            return new()
            {
                ProfileID = applicationEntity.ProfileID,
                PIN = InternalTools.ConvertPINToInteger(applicationEntity.PIN),
                WasUsed = false
            };
        }

    }
}
