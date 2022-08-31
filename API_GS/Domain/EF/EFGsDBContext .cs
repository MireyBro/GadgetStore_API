using API_GS.Models;
using Microsoft.EntityFrameworkCore;

namespace API_GS.Domain.EF
{
    public class EFGsDBContext : DbContext
    {
        public EFGsDBContext(DbContextOptions<EFGsDBContext> options)
            : base(options)
        {
        }

        public DbSet<ShopItem> ShopItems { get; set; }
        
    }
}
