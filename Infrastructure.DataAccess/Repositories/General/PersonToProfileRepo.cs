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
    public class PersonToProfileRepo : IPersonToProfileRepo<PersonToProfile,Guid,String>
    {
        MCCContext Db;

        public PersonToProfileRepo(MCCContext _db)
        {
            this.Db = _db;
        }

        public PersonToProfile Add(PersonToProfile entity)
        {
            Db.PersonToProfile.Add(entity);
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

        public PersonToProfile? Find(Guid entityID1, string entityID2)
        {
            return Db.PersonToProfile
                .Where(e => e.PersonID == entityID1 && e.ProfileID == entityID2)
                .FirstOrDefault();
        }

        public IEnumerable<PersonToProfile> FindByPersonID(Guid personID)
        {
            return Db.PersonToProfile
                .Where(e => e.PersonID == personID)
                .ToList();
        }

        public PersonToProfile? FindByProfileID(string profileID)
        {
            return Db.PersonToProfile
                .Where(e => e.ProfileID == profileID)
                .FirstOrDefault();
        }

        public List<PersonToProfile> GetAll()
        {
            return Db.PersonToProfile.ToList();
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

    }
}
