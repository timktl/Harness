using Harness.Data;
using Harness.Models.Model;
using Harness.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Harness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(int id)
        {
            var person = await _personService.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            await _personService.AddPerson(person);
            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Person person)
        {
            if (person == null || person.Id != id)
            {
                return BadRequest();
            }

            var existingPerson = await _personService.GetPersonById(id);
            if (existingPerson == null)
            {
                return NotFound();
            }

            await _personService.UpdatePerson(person);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _personService.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }

            await _personService.DeletePerson(id);
            return NoContent();
        }
    }
}
