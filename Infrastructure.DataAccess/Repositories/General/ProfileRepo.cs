using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MCC.Domain.Models.General;
using MCC.Domain.Interfaces.Repositories.General;
using Infrastructure.DataAccess.Contexts;

namespace Infrastructure.DataAccess.Repositories.General
{
    public class ProfileRepo : IProfileRepo<Profile, String>
    {
        MCCContext Db;

        private ProfileRepo(MCCContext _db)
        {
            this.Db = _db;
        }

        public Profile Add(Profile entity)
        {
            Db.Profile.Add(entity);
            return entity;
        }

        public void BeginTransaction()
        {
            Db.Database.BeginTransaction();
        }

        public void CloseTransaction()
        {
            Db.Database.CurrentTransaction.Dispose();
        }

        public void CommitTransaction()
        {
            Db.Database.CommitTransaction();
        }

        public void Delete(String entityID)
        {
            Profile? oldProfile = Find(entityID);
            if (oldProfile != null)
            {
                Db.Profile.Remove(oldProfile);
            }
        }

        public void Disabled(String entityID)
        {
            Profile? oldProfile = Find(entityID);
            if (oldProfile != null)
            {
                oldProfile.Status = Profile.ProfileStatus.BLOCKED;
                Update(oldProfile);
            }
        }

        public Profile? Find(String entityID)
        {
            return Db.Profile.Where(e => e.ProfileID == entityID).FirstOrDefault();
        }

        public List<Profile> GetAll()
        {
            return Db.Profile.ToList();
        }

        public void Hide(String entityID)
        {
            Profile? oldProfile = Find(entityID);
            if (oldProfile != null)
            {
                oldProfile.Status = Profile.ProfileStatus.SUSPENDED;
                Update(oldProfile);
            }
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

        public void Update(Profile entity)
        {
            Profile? OldEntity = Find(entity.ProfileID);
            if (OldEntity != null)
            {
                OldEntity.DisplayName = entity.DisplayName;
                OldEntity.Password = entity.Password;
                //Activity log pending
                Db.Profile.Update(entity);
            }
        }
    }
}
