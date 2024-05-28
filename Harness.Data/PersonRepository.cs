using Harness.Data.Interface;
using Harness.Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harness.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly HarnessDbContext _context;

        public PersonRepository(HarnessDbContext context)
        {
            _context = context;
        }

        public async Task<Person?> GetPersonById(int id)
        {
            return await _context.Person.FindAsync(id);
        }

        public async Task AddPerson(Person person)
        {
            await _context.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePerson(Person updatedPerson)
        {
            var trackedPerson = await GetPersonById(updatedPerson.Id);
            if (trackedPerson != null)
            {
                _context.Entry(trackedPerson).CurrentValues.SetValues(updatedPerson);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Attach(updatedPerson);
                _context.Entry(updatedPerson).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePerson(int id)
        {
            var person = await GetPersonById(id);
            if (person != null)
            {   
                _context.Person.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
    }
}
