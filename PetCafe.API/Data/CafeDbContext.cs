using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PetCafe.API.Data
{
    public class CafeDbContext : DbContext
    {
        public CafeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Cafe> Cafes { get; set; }
    }
}
