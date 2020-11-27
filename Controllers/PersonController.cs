using LightQuery.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonContext _context;
        private readonly ILogger<PersonController> _logger;

        public PersonController(PersonContext context, ILogger<PersonController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [AsyncLightQuery(forcePagination: true, defaultPageSize: 5)]
        public IActionResult GetPeople()
        {
            var people = _context.People.OrderBy(p => Guid.NewGuid());
            return Ok(people);
        }
        
        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(long id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }
        
        /// <summary>
        /// Creates a person.
        /// </summary>
        /// <response code="201">Returns the newly created person</response>
        /// <response code="400">If the person is null</response>     
        [HttpPost]
        public async Task<ActionResult<Person>> CreatePerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetPerson),
                new { id = person.Id },
                person
            );
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(long id, Person _person)
        {
            if (id != _person.Id)
            {
                return BadRequest();
            }

            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            person.FirstName = _person.FirstName;
            person.LastName = _person.LastName;
            person.DateOfBirth = _person.DateOfBirth;
            person.Gender = _person.Gender;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!PersonExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific Person.
        /// </summary>
        /// <param name="id"></param> 
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(long id)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return person;
        }

        private bool PersonExists(long id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}
