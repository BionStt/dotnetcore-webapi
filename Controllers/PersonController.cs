using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> GetPeople()
        {
            return await _context.People
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }
        
        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDTO>> GetPerson(long id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return ItemToDTO(person);
        }
        
        /// <summary>
        /// Creates a person.
        /// </summary>
        /// <response code="201">Returns the newly created person</response>
        /// <response code="400">If the person is null</response>     
        [HttpPost]
        public async Task<ActionResult<PersonDTO>> CreatePerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetPerson),
                new { id = person.Id },
                ItemToDTO(person));
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(long id, PersonDTO personDTO)
        {
            if (id != personDTO.Id)
            {
                return BadRequest();
            }

            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            person.FirstName = personDTO.FirstName;
            person.LastName = personDTO.LastName;
            person.DateOfBirth = personDTO.DateOfBirth;
            person.Gender = personDTO.Gender;

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
        public async Task<ActionResult<PersonDTO>> DeletePerson(long id)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return ItemToDTO(person);
        }

        private bool PersonExists(long id)
        {
            return _context.People.Any(e => e.Id == id);
        }

        private static PersonDTO ItemToDTO(Person person) =>
        new PersonDTO
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            DateOfBirth = person.DateOfBirth,
            Gender = person.Gender
        }; 
    }
}
