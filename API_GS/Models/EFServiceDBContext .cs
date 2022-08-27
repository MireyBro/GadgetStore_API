using Microsoft.EntityFrameworkCore;

namespace API_GS.Models
{
    public class EFServiceDBContext : DbContext
    {
        public EFServiceDBContext(DbContextOptions<EFServiceDBContext> options)
            : base(options)
        {
        }

        public DbSet<ServiceItem> ServiceItems { get; set; }
    }
}
