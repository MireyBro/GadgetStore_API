using Microsoft.EntityFrameworkCore;

namespace API_GS.Models
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options)
            : base(options)
        {
        }

        public DbSet<ServiceItems> TodoItems { get; set; }
    }
}
