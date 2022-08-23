
using Application.CommonBehaviour;
using MCC.Domain.Interfaces.Repositories.General;
using MCC.Domain.Models.General;

namespace Application.Services.General
{
    public class PersonService: BasicService
    {
        private readonly IPersonRepo<Person, Guid> repository;
        public PersonService(IPersonRepo<Person, Guid> personRepo)
        {
            repository = personRepo;
        }

        public Person Add(Person entity)
        {
            Validations.NonNullEntity<Person>(entity);
            Person newPerson = repository.Add(entity);
            repository.SendToSaveAllChanges();
            return newPerson;
        }

        public Person FindByName(string FirstName, string LastName)
        {
            return repository.FindByName(FirstName, LastName);
        }

        public Person FindById(Guid entityID)
        {
            Person entity = repository.Find(entityID);
            Validations.NonNullEntity<Person>(entity);
            return entity;
        }

        public List<Person> GetAll()
        {
            return repository.GetAll();
        }

        public void Update(Person entity)
        {
            Validations.NonNullEntity(entity);
            repository.Update(entity);
            repository.SendToSaveAllChanges();
        }

    }
}
