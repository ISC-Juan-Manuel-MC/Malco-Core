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
    public class PersonToOrganizationRepo : IPersonToOrganizationRepo<PersonToOrganization,Guid,Guid>
    {
        MCCContext Db;

        private PersonToOrganizationRepo(MCCContext _db)
        {
            this.Db = _db;
        }

        public PersonToOrganization Add(PersonToOrganization entity)
        {
            Db.PersonToOrganization.Add(entity);
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

        public PersonToOrganization? Find(Guid entityID1, Guid entityID2)
        {
            return Db.PersonToOrganization
                .Where(e => e.PersonID == entityID1 && e.OrganizationID ==entityID2)
                .FirstOrDefault();
        }

        public List<PersonToOrganization> GetAll()
        {
            return Db.PersonToOrganization.ToList();
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
