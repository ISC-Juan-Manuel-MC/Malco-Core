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
    public class OrganizationRatingRepo : IOrganizationRatingRepo<OrganizationRating, Guid>
    {
        MCCContext Db;

        private OrganizationRatingRepo(MCCContext _db)
        {
            this.Db = _db;
        }

        public OrganizationRating Add(OrganizationRating entity)
        {
            entity.OrganizationRatingID = Guid.NewGuid();
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

        public OrganizationRating? Find(Guid entityID)
        {
            return Db.OrganizationRating.Where(rating => rating.OrganizationRatingID == entityID).FirstOrDefault();
        }

        public List<OrganizationRating> GetAll()
        {
            return Db.OrganizationRating.ToList();
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

        public void Update(OrganizationRating entity)
        {
            OrganizationRating? OldEntity = Find(entity.OrganizationRatingID);
            if (OldEntity != null)
            {
                OldEntity.Rating = entity.Rating;
                OldEntity.Excluded = entity.Excluded;
            }
        }
    }
}
