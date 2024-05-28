using Harness.Data.Interface;
using Harness.Models.Model;
using Harness.Services.Interface;
using System;

namespace Harness.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> GetPersonById(int id)
        {
            var person = await _personRepository.GetPersonById(id);
            return person;
        }

        public async Task<Person?> AddPerson(Person person)
        {
            if (person == null)
            {
                return null;
            }
            else
            {
                var addedPerson = await _personRepository.AddPerson(person);
                return addedPerson;
            }
        }

        public async Task<Person?> UpdatePerson(Person person)
        {
            if (person == null)
            {
                return null;
            }
            else
            {
                var updatedPerson = await _personRepository.UpdatePerson(person);
                return updatedPerson;
            }
        }
        public async Task<Person?> DeletePerson(int id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                var deletedPerson = await _personRepository.DeletePerson(id);
                return deletedPerson;
            }
        }

    }
}
