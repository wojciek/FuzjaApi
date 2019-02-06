using FuzjaApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FuzjaApi.Infrastructure
{
    public class FuzjaApiDbContext : DbContext
    {
        public FuzjaApiDbContext(DbContextOptions<FuzjaApiDbContext> options)
            : base(options)
        { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
