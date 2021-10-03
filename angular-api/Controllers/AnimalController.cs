using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using angular_api.Models;
using Microsoft.EntityFrameworkCore;

namespace angular_api.Controllers
{
    [Produces("application/json")]
    [Route("api/Animal")]
    public class AnimalController : Controller
    {
        private readonly NetVetDbContext _context;

        public AnimalController(NetVetDbContext context)
        {
            _context = context;
        }

        // GET: api/Animal
        [HttpGet]
        public IEnumerable<Animal> GetAnimal()
        {
            return _context.Animals;
        }

        // GET: api/Animal/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimal([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var animal = await _context.Animals.SingleOrDefaultAsync(m => m.AnimalId == id);

            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        // PUT: api/Animal/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal([FromRoute] Guid id, [FromBody] Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != animal.AnimalId)
            {
                return BadRequest();
            }

            _context.Entry(animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Animal
        [HttpPost]
        public async Task<IActionResult> PostAnimal([FromBody] Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            animal.AnimalId = Guid.NewGuid();

            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimal", new { animalid = animal.AnimalId }, animal);
        }

        // DELETE: api/Animal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var animal = await _context.Animals.SingleOrDefaultAsync(m => m.AnimalId == id);
            if (animal == null)
            {
                return NotFound();
            }

            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();

            return Ok(animal);
        }

        private bool AnimalExists(Guid id)
        {
            return _context.Animals.Any(e => e.AnimalId == id);
        }
    }
}
