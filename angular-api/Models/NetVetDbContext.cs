using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using angular_api.Models;
using Microsoft.EntityFrameworkCore;

namespace angular_api.Models
{
    public class NetVetDbContext : DbContext
    {
        public NetVetDbContext(DbContextOptions<NetVetDbContext> options)
            : base(options)
        {
        }
        public DbSet<Animal> Animals { get; set; }
    }
}
