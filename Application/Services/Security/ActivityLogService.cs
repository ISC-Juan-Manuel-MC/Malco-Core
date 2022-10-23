using MCC.Domain.Interfaces.Repositories.Security;
using MCC.Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Security
{
    public class ActivityLogService : BasicService
    {
        private readonly IActivityLogRepo<ActivityLog, Guid> repository;

        public ActivityLogService(IActivityLogRepo<ActivityLog, Guid> profileRepo)
        {
            repository = profileRepo;
        }

        private ActivityLog? GetActivityLogAdjusted(Guid ActivityLogID, ActivityLog.Types ActivityLogTypeID)
        {
            ActivityLog? entity = repository.Find(ActivityLogID);
            if (entity == null)
            {
                entity = new ActivityLog();
            }

            entity.ActivityLogTypeID = ActivityLogTypeID;
            entity.ActivityLogIDReference = entity.ActivityLogID;

            return entity;
        }

        public ActivityLog CREATION(Guid OrganizationID, Guid AppID, Guid ViewID, string ProfileID)
        {
            ActivityLog entity = new ActivityLog
            {
                ActivityLogID = Guid.NewGuid(),
                ActivityLogTypeID = ActivityLog.Types.CREATION,
                OrganizationID = OrganizationID,
                AppID = AppID,
                ViewID = ViewID,
                ProfileID = ProfileID
            };
            repository.Add(entity);
            return entity;
        }

        public ActivityLog? DELETION(Guid LogID, string ProfileID)
        {
            ActivityLog? entity = GetActivityLogAdjusted(LogID, ActivityLog.Types.DELETION);
            if (entity != null)
            {
                entity.ProfileID = ProfileID;
                repository.Update(entity);
            }

            return entity;
        }

        public ActivityLog? LOGIN(Guid LogID, string ProfileID)
        {
            ActivityLog? entity = GetActivityLogAdjusted(LogID, ActivityLog.Types.LOGIN);
            if (entity != null)
            {
                entity.ProfileID = ProfileID;
                repository.Update(entity);
            }

            return entity;
        }

        public ActivityLog? LOGOUT(Guid LogID, string ProfileID)
        {
            ActivityLog? entity = GetActivityLogAdjusted(LogID, ActivityLog.Types.LOGOUT);
            if (entity != null)
            {
                entity.ProfileID = ProfileID;
                repository.Update(entity);
            }

            return entity;
        }

        public ActivityLog? MODIFICATION(Guid LogID, string ProfileID)
        {
            ActivityLog? entity = GetActivityLogAdjusted(LogID, ActivityLog.Types.MODIFICATION);
            if (entity != null)
            {
                entity.ProfileID = ProfileID;
                repository.Update(entity);
            }

            return entity;
        }

    }
}
