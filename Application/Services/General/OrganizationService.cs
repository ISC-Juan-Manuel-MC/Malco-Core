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
    public class OrganizationService : BasicService
    {
        private readonly IOrganizationRepo<Organization, Guid> repository;

        public OrganizationService(IOrganizationRepo<Organization, Guid> organizationRepo)
        {
            repository = organizationRepo;
        }

        public Organization Add(Organization entity)
        {
            Validations.NonNullEntity<Organization>(entity);

            Organization newOrganization = repository.Add(entity);
            repository.SendToSaveAllChanges();
            return newOrganization;
        }

        public void Delete(Guid entityID)
        { 
            Organization entity = Find(entityID);
            entity.Status = Organization.OrganizationStatus.SUSPENDED;
            repository.Update(entity);
            repository.SendToSaveAllChanges();
        }

        public void Disabled(Guid entityID)
        {
            this.Delete(entityID);
        }
        public void Hide(Guid entityID)
        {
            Organization entity = Find(entityID);
            entity.Status = Organization.OrganizationStatus.BLOCKED;
            repository.Update(entity);
            repository.SendToSaveAllChanges();
        }

        public Organization Find(Guid entityID)
        {
            Organization entity = repository.Find(entityID);
            Validations.NonNullEntity<Organization>(entity);
            return entity;
        }

        public List<Organization> FindAll()
        {
            return repository.GetAll();
        }

        public void Update(Organization entity)
        {
            Validations.NonNullEntity(entity);
            repository.Update(entity);
            repository.SendToSaveAllChanges();
        }
    }
}
