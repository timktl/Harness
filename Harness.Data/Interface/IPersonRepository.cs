using Harness.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harness.Data.Interface
{
    public interface IPersonRepository
    {
        Task<Person> GetPersonById(int id);
        Task<Person> AddPerson(Person person);
        Task<Person> UpdatePerson(Person person);
        Task<Person> DeletePerson(int id);
    }
}
