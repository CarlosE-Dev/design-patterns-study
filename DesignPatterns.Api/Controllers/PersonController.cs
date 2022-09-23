using DesignPatterns.Domain.Interfaces;
using DesignPatterns.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesignPatterns.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(_personRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var person = _personRepository.GetById(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost("")]
        public IActionResult Create([FromBody] Person person)
        {
            var entity = _personRepository.GetById(person.Id);
            if (entity != null)
                return Conflict();

            _personRepository.Create(person);

            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }

        [HttpPut("")]
        public IActionResult Update(Guid id, [FromBody] Person person)
        {
            var entity = _personRepository.GetById(id);
            if (entity == null)
                return NotFound();

            _personRepository.Update(id, person);

            return NoContent();
        }

        [HttpDelete("")]
        public IActionResult Delete(Guid id)
        {
            var person = _personRepository.GetById(id);
            if (person == null)
                return NotFound();

            _personRepository.Delete(person);

            return NoContent();
        }
    }
}
