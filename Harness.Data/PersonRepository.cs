﻿using Harness.Data.Interface;
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

        public PersonRepository(HarnessDbContext _context)
        {
            this._context = _context;
        }

        public async Task<Person> GetPersonById(int id)
        {
            return _context.Person.Find(id);
        }

        public async Task<Person> AddPerson(Person person)
        {
            _context.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<Person> UpdatePerson(Person updatedPerson)
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
            }
            return updatedPerson;
        }

        public async Task<Person> DeletePerson(int id)
        {
            var person = await GetPersonById(id);
            if (person != null)
            {   
                _context.Person.Remove(person);
                await _context.SaveChangesAsync();
                return person;
            }
            return person;
        }
    }
}
