using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MCC.Domain.Models.Security;
using MCC.Domain.Interfaces.Repositories.Security;
using Infrastructure.DataAccess.Contexts;

namespace Infrastructure.DataAccess.Repositories.Security
{
    public class ActivityLogRepo : IActivityLogRepo<ActivityLog, Guid>
    {
        MCCContext Db;

        public ActivityLogRepo(MCCContext _db)
        {
            this.Db = _db;
        }

        public void BeginTransaction()
        {
            Db.Database.BeginTransaction();
        }

        public void CloseTransaction()
        {
            if (TransactionIsInProgress())
            {
                Db.Database.CurrentTransaction.Dispose();
            }
        }

        public void CommitTransaction()
        {
            Db.Database.CommitTransaction();
        }

        public ActivityLog? Find(Guid entityID)
        {
            return Db.ActivityLog.Where(e => e.ActivityLogID == entityID).FirstOrDefault();
        }
        
        public List<ActivityLog> GetAll()
        {
            return Db.ActivityLog.ToList();
        }

        public void RollbackTransaction()
        {
            Db.Database.RollbackTransaction();
        }

        public void SendToSaveAllChanges()
        {
            Db.SaveChanges();
        }

        public bool TransactionIsInProgress()
        {
            return Db.Database.CurrentTransaction != null;
        }

        private ActivityLog? GetActivityLogAdjusted( Guid ActivityLogID, ActivityLog.Types ActivityLogTypeID)
        {
            ActivityLog? entity = Find(ActivityLogID);
            if (entity != null)
            {
                entity.ActivityLogTypeID = ActivityLogTypeID;
                entity.ActivityLogIDReference = entity.ActivityLogID;
            }

            return entity;
        }

        private void Update(ActivityLog entity)
        {
            ActivityLog? OldEntity = Find(entity.ActivityLogID);
            if (OldEntity != null)
            {
                OldEntity.ActivityLogTypeID = entity.ActivityLogTypeID;
                OldEntity.ActivityLogIDReference = entity.ActivityLogIDReference;
                OldEntity.ActivityLogID = Guid.NewGuid();
                Db.ActivityLog.Update(entity);
            }
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
            Db.ActivityLog.Add(entity);
            return entity;
        }

        public ActivityLog? DELETION(Guid LogID, string ProfileID)
        {
            ActivityLog? entity = GetActivityLogAdjusted(LogID, ActivityLog.Types.DELETION);
            if (entity != null)
            {
                entity.ProfileID = ProfileID;
                this.Update(entity);
            }

            return entity;
        }

        public ActivityLog? LOGIN(Guid LogID, string ProfileID)
        {
            ActivityLog? entity = GetActivityLogAdjusted(LogID, ActivityLog.Types.LOGIN);
            if (entity != null)
            {
                entity.ProfileID = ProfileID;
                this.Update(entity);
            }

            return entity;
        }

        public ActivityLog? LOGOUT(Guid LogID, string ProfileID)
        {
            ActivityLog? entity = GetActivityLogAdjusted(LogID, ActivityLog.Types.LOGOUT);
            if (entity != null)
            {
                entity.ProfileID = ProfileID;
                this.Update(entity);
            }

            return entity;
        }

        public ActivityLog? MODIFICATION(Guid LogID, string ProfileID)
        {
            ActivityLog? entity = GetActivityLogAdjusted(LogID, ActivityLog.Types.MODIFICATION);
            if (entity != null)
            {
                entity.ProfileID = ProfileID;
                this.Update(entity);
            }

            return entity;
        }

    }
}
