using Harness.Data.Interface;
using Harness.Models.Model;
using Microsoft.Data.SqlClient;
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
            try
            {
                var person = await _context.Person.FindAsync(id);
                if (person == null)
                {
                    throw new KeyNotFoundException($"Person with Id {id} not found.");
                }
                return person;
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while retrieving Person.", ex);
            }
        }

        public async Task AddPerson(Person person)
        {
            try
            {
                await _context.AddAsync(person);
                await _context.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while creating Person.", ex);
            }
        }

        public async Task UpdatePerson(Person updatedPerson)
        {
            try
            {
                var trackedPerson = await GetPersonById(updatedPerson.Id);
                if (trackedPerson != null)
                {
                    _context.Entry(trackedPerson).CurrentValues.SetValues(updatedPerson);
                    await _context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while Updating Person.", ex);
            }
        }

        public async Task DeletePerson(int id)
        {
            try
            {
                var person = await GetPersonById(id);
                if (person != null)
                {
                    _context.Person.Remove(person);
                    await _context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while Deleting Person.", ex);
            }
        }
    }
}
