using LinkShortener.Model;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Database
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Link> Links { get; set; }
    }
}
