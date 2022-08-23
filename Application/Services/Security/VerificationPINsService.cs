using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CommonBehaviour;
using Application.Errors;
using Application.Models.Mappers.Security;
using Application.Models.Security;
using Domain.Interfaces.Repositories.Security;
using Domain.Models.Security;

namespace Application.Services.Security
{
    public class VerificationPINsService: BasicService
    {
        private readonly IVerificationPINsRepo<VerificationPIN, String, int> repository;
        private readonly VerificationPINMapper Mapper;

        public VerificationPINsService(IVerificationPINsRepo<VerificationPIN, String, int> verificationPINRepo)
        {
            repository = verificationPINRepo;
            Mapper = new VerificationPINMapper();
        }

        public IEnumerable<VerificationPINPublicModel> GetAllPINs(string profileID)
        {
            return Mapper.GetApplicationEntity(repository.FindByProfileID(profileID));
        }

        public VerificationPINPublicModel FindPIN(string profileID, int PIN)
        {
            VerificationPIN entity = repository.Find(profileID, PIN);
            Validations.NonNullEntity(entity);
            return Mapper.GetApplicationEntity(entity);
        }

        public VerificationPINPublicModel SaveOrUpdatePIN(string profileID, int PIN)
        {
            DateTime now = InternalTools.GetDateTimeNow();
            VerificationPIN entity = repository.Find(profileID, PIN);

            if (entity == null)
            {
                entity = new()
                {
                    ProfileID = profileID,
                    PIN = PIN,
                };

                AdjustExpirationDates(now, ref entity);
                repository.Add(entity);
            } else
            {
                AdjustExpirationDates(now, ref entity);
                repository.Update(entity);
            }

            repository.SendToSaveAllChanges();
            return Mapper.GetApplicationEntity(entity);
        }

        private void AdjustExpirationDates(DateTime now, ref VerificationPIN entity)
        {
            int ExpirationTimeInMinutes = 1;
            entity.StartDatetime = now;
            entity.EndDatetime = now.AddMinutes(ExpirationTimeInMinutes);
            entity.WasUsed = false;
        }

        public VerificationPINPublicModel VerifyPIN(string profileID, int PIN)
        {
            VerificationPIN entity = repository.Find(profileID, PIN);
            Validations.NonNullEntity(entity);

            DateTime now = InternalTools.GetDateTimeNow();
            if (InternalTools.DatetimeBetweenDates(now, entity.StartDatetime, entity.EndDatetime))
            {
                repository.Disabled(entity.ProfileID);

                entity.WasUsed = true;

                repository.Update(entity);
                repository.SendToSaveAllChanges();
            } else
            {
                throw new ExpiredVerificationCodeError(PIN);
            }

            return Mapper.GetApplicationEntity(entity);
        }

    }
}
