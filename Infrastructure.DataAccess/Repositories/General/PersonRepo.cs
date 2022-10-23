using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MCC.Domain.Models.General;
using MCC.Domain.Interfaces.Repositories.General;
using Infrastructure.DataAccess.Contexts;
using Infrastructure.DataAccess.Repositories.Security;

namespace Infrastructure.DataAccess.Repositories.General
{
    public class PersonRepo : IPersonRepo<Person, Guid>
    {
        MCCContext Db;

        public PersonRepo(MCCContext _db)
        {
            this.Db = _db;
        }

        public Person Add(Person entity)
        {
            entity.PersonID = Guid.NewGuid();
            entity.ActivityLogID = entity.FKActivityLog.ActivityLogID;
            Db.Person.Add(entity);
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

        public Person? Find(Guid entityID)
        {
            return Db.Person.Where(e => e.PersonID == entityID).FirstOrDefault();
        }

        public Person? FindByName(string FirstName, string LastName)
        {
            return Db.Person
                .Where(e => e.FirstName == FirstName && e.LastName == LastName)
                .FirstOrDefault();
        }

        public List<Person> GetAll()
        {
            return Db.Person.ToList();
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

        public void Update(Person entity)
        {
            Person? oldProfile = Find(entity.PersonID);
            if (oldProfile != null)
            {
                oldProfile.FirstName = entity.FirstName;
                oldProfile.LastName = entity.LastName;
                oldProfile.Birthday = entity.Birthday;
                oldProfile.Cellphone = entity.Cellphone;
                oldProfile.ActivityLogID = entity.FKActivityLog.ActivityLogID;
                Db.Person.Update(oldProfile);
            }
        }
    }
}
