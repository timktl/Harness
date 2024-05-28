using Harness.Data;
using Harness.Models.Dto;
using Harness.Models.Model;
using Harness.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
        public async Task<ActionResult<PersonDto>> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var personDto = await _personService.GetPersonById(id);
            if (personDto == null)
            {
                return NotFound();
            }

            return Ok(personDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody, Required] PersonDto personDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _personService.AddPerson(personDto);
            return CreatedAtAction(nameof(GetById), new { id = personDto.Id }, personDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonDto personDto)
        {
            if (personDto == null || personDto.Id != id || personDto.Id == 0)
            {
                return BadRequest();
            }

            var existingPerson = await _personService.GetPersonById(id);
            if (existingPerson == null)
            {
                return NotFound();
            }

            await _personService.UpdatePerson(personDto);
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