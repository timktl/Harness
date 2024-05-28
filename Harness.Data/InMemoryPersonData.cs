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
                new Person { Id = 1, Name = "Timothy Kuek", Age = 34 },
                new Person { Id = 2, Name = "John Scully", Age = 35 },
                new Person { Id = 3, Name = "Patrick Knight", Age = 33}
            };
        }

        public Person Add(Person newperson)
        {
            persons.Add(newperson);
            newperson.Id = persons.Max(person => person.Id) + 1;
            return newperson;
        }
    }
}
