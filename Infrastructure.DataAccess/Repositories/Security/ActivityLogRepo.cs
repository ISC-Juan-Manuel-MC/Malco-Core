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

        public ActivityLog Add(ActivityLog entity)
        {
            Db.ActivityLog.Add(entity);
            return entity;
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

        public void Update(ActivityLog entity)
        {
            ActivityLog? OldEntity = Find(entity.ActivityLogID);
            if (OldEntity != null)
            {
                OldEntity.ActivityLogTypeID = entity.ActivityLogTypeID;
                OldEntity.ActivityLogIDReference = entity.ActivityLogID;
                OldEntity.ActivityLogID = Guid.NewGuid();
                Db.ActivityLog.Update(entity);
            }
        }

    }
}
