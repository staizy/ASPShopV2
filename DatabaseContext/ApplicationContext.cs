using ASPShopV2.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPShopV2.DatabaseContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInfo> ProductsInfo { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
