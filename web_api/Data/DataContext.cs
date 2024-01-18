using Microsoft.EntityFrameworkCore;

namespace web_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }
        public DbSet<Entities.Employee> Employee { get; set; }
        public DbSet<Entities.WorkPlace> WorkPlace{ get; set; }

    }
}
