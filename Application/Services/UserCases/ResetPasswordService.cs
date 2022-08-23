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
using Domain.Interfaces.Repositories.Security;
using Domain.Models.Security;
using MCC.Domain.Interfaces.Repositories.General;
using MCC.Domain.Models.General;
using Application.Errors;

namespace Application.Services.UserCases
{
    public class ResetPasswordService
    {
        private readonly ProfileService ProfileService;
        private readonly VerificationPINsService VerificationPINsService;
        private readonly ProfileMapper ProfileMapper;

        public ResetPasswordService(
            IProfileRepo<Profile, String> profileRepo,
            IVerificationPINsRepo<VerificationPIN, String, int> verificationPINRepo)
        {
            ProfileService = new ProfileService(profileRepo);
            VerificationPINsService = new VerificationPINsService(verificationPINRepo);
            ProfileMapper = new ProfileMapper();
        }

        /// <summary>
        /// Password reset step #1: Create, save and return a PIN as a verification code related to profile.
        /// The PIN have a one minute to expired.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>
        /// VerificationPINPublicModel 
        /// </returns>
        /// <exception cref="EntityNotExistError"></exception>
        public VerificationPINPublicModel GetVerificationCode(string email)
        {
            Profile profile = ProfileService.FindByID(email);
            int newPIN = InternalTools.GetNewPIN();
            return VerificationPINsService.SaveOrUpdatePIN(profile.ProfileID, newPIN);
        }

        /// <summary>
        /// Password reset step #2: Check if the PIN (verification code) has not expired
        /// </summary>
        /// <param name="email"></param>
        /// <param name="PIN"></param>
        /// <returns>
        ///  VerificationPINPublicModel
        ///  </returns>
        /// <exception cref="EntityNotExistError"></exception>
        /// <exception cref="ExpiredVerificationCodeError"></exception>
        public VerificationPINPublicModel VerifyCodeToResetPassword(string email, int PIN)
        {
            return VerificationPINsService.VerifyPIN(email, PIN);
        }

        /// <summary>
        /// Password Reset Step #3: Encrypt and Update Profile Password
        /// </summary>
        /// <param name="profileID"></param>
        /// <param name="newPassword"></param>
        /// <returns>
        /// ProfilePublicModel
        /// </returns>
        /// <exception cref="EntityNotExistError"></exception>
        public ProfilePublicModel ResetPassword(string profileID, string newPassword)
        {
            Profile entity = ProfileService.FindByID(profileID);
            entity.Password = InternalTools.Encrypt("encryption Key", newPassword);
            ProfileService.Update(entity);
            return ProfileMapper.GetApplicationEntity(entity);
        }
    }
}
