using Harness.Data.Interface;
using Harness.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harness.Data
{
    public class InMemoryPersonData 
    {
        List<Person> persons;

        public InMemoryPersonData() 
        {
            persons = new List<Person>()
            {
                new Person { Id = 1, name = "Timothy Kuek", age = 34 },
                new Person { Id = 2, name = "John Scully", age = 35 },
                new Person { Id = 3, name = "Patrick Knight", age = 33}
            };
        }

        public Person Add(Person newperson)
        {
            persons.Add(newperson);
            newperson.Id = persons.Max(person => person.Id) + 1;
            return newperson;
        }

        public Person GetById(int id)
        {
            return persons.SingleOrDefault(r => r.Id == id);
        }
    }
}
