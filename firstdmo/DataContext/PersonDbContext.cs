using firstdemo.Models;
using Microsoft.EntityFrameworkCore;

namespace firstdemo.DataContext
{
    public class PersonDbContext:DbContext
    {
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }
        public DbSet<Person> People { get; set; }
    }
}
