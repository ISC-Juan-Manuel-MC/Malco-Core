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
    public class OrganizationRepo : IOrganizationRepo<Organization, Guid>
    {
        MCCContext Db;

        private OrganizationRepo(MCCContext _db)
        {
            this.Db = _db;

        }

        public Organization Add(Organization entity)
        {
            entity.OrganizationID = Guid.NewGuid();
            entity.ActivityLogID = entity.FKActivityLog.ActivityLogID;
            Db.Organization.Add(entity);
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

        public Organization? Find(Guid entityID)
        {
            return Db.Organization.Where(e => e.OrganizationID == entityID).FirstOrDefault();
        }

        public List<Organization> GetAll()
        {
            return Db.Organization.ToList();
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

        public void Update(Organization entity)
        {
            Organization? oldProfile = Find(entity.OrganizationID);
            if (oldProfile != null)
            {
                oldProfile.Name = entity.Name;
                oldProfile.IsCompany = entity.IsCompany;
                oldProfile.PersonID = entity.PersonID;
                oldProfile.Status = entity.Status;
                oldProfile.ActivityLogID = entity.ActivityLogID;
                Db.Organization.Update(entity);
            }
        }
    }
}
