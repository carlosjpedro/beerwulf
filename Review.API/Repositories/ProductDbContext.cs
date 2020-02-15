using Microsoft.EntityFrameworkCore;
using Review.API.Services.Model;

namespace Review.API.Repositories
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        { }
        public DbSet<Product> Products { get; set; }
    }
}

