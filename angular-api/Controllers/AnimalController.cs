using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using angular_api.Models;

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
    }
}
