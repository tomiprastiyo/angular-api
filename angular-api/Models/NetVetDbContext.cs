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
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }
}
