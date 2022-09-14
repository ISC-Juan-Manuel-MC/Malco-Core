using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MCC.Domain.Models.General;
using MCC.Domain.Interfaces.Repositories.General;
using Application.CommonBehaviour;

namespace Application.Services.General
{
    public class ProfileService : BasicService
    {
        private readonly IProfileRepo<Profile, String> repository;

        public ProfileService(IProfileRepo<Profile, String> profileRepo)
        {
            repository = profileRepo;
        }

        public Profile Add(Profile entity)
        {
            Validations.NonNullEntity<Profile>(entity);
            Profile newPerson = repository.Add(entity);
            repository.SendToSaveAllChanges();
            return newPerson;
        }

      
        public Profile? FindByID(string entityID)
        {
            return repository.Find(entityID);
        }

        public List<Profile> GetAll()
        {
            return repository.GetAll();
        }

        public void Update(Profile entity)
        {
            Validations.NonNullEntity(entity);
            repository.Update(entity);
            repository.SendToSaveAllChanges();
        }

        public void Suspend(string entityID)
        {
            Profile entity = FindByID(entityID);
            entity.Status = Profile.ProfileStatus.SUSPENDED;
            Update(entity);
        }

        public void Block(string entityID)
        {
            Profile entity = FindByID(entityID);
            entity.Status = Profile.ProfileStatus.BLOCKED;
            Update(entity);
        }

        public override void BeginTransaction()
        {
            repository.BeginTransaction();
        }

        public override bool TransactionIsInProgress()
        {
            return repository.TransactionIsInProgress();
        }

        public override void SendToSaveAllChanges()
        {
            repository.SendToSaveAllChanges();
        }

        public override void CommitTransaction()
        {
            repository.CommitTransaction();
        }

        public override void RollbackTransaction()
        {
            repository.RollbackTransaction();
        }

        public override void CloseTransaction()
        {
            repository.CloseTransaction();
        }
    }
}
