using BulkyBooks.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBooks.Data
{
    public class BulkyBookDbContext:DbContext
    {
        public BulkyBookDbContext(DbContextOptions<BulkyBookDbContext> options) : base(options) { }
        
        public DbSet<Category> Categories { get; set; }
    }
}
