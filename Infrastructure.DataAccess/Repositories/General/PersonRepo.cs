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
            Person? OldEntity = Find(entity.PersonID);
            if (OldEntity != null)
            {
                OldEntity.FirstName = entity.FirstName;
                OldEntity.LastName = entity.LastName;
                OldEntity.Birthday = entity.Birthday;
                OldEntity.Cellphone = entity.Cellphone;
                //Activity log pending
                Db.Person.Update(entity);
            }
        }
    }
}
