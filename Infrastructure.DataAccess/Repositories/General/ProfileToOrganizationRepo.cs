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
    public class ProfileToOrganizationRepo : IProfileToOrganizationRepo<ProfileToOrganizations, String, Guid>
    {
        MCCContext Db;

        private ProfileToOrganizationRepo(MCCContext _db)
        {
            this.Db = _db;
        }

        public ProfileToOrganizations Add(ProfileToOrganizations entity)
        {
            Db.Add(entity);
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

        public ProfileToOrganizations? Find(string entityID1, Guid entityID2)
        {
            return Db.ProfileToOrganizations
                .Where(e => e.ProfileID.Equals(entityID1) && e.OrganizationID == entityID2)
                .FirstOrDefault();
        }

        public List<ProfileToOrganizations> GetAll()
        {
            return Db.ProfileToOrganizations.ToList();
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
