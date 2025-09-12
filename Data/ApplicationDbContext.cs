using Microsoft.EntityFrameworkCore;
using MyTradePrototype.Models;

namespace MyTradePrototype.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Trade> Trades { get; set; }
        
        //public DbSet<Customer> Customers { get; set; }  // ileride eklenebilir
    }
}
