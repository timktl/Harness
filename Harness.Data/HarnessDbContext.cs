using Harness.Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harness.Data
{
    public class HarnessDbContext : DbContext
    {
        public HarnessDbContext(DbContextOptions<HarnessDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Incident> Incidents { get; set; }
    }
}
