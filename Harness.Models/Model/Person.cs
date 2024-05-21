using System.ComponentModel.DataAnnotations;

namespace Harness.Models.Model
{
    public class Person
    { 
        public int Id { get; set; }
        public string? name { get; set; }
        public int age { get; set; }
    }
}
