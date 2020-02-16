using Microsoft.EntityFrameworkCore;
using Review.API.Entities;

namespace Review.API.Repositories
{
    public class ProductReviewDbContext : DbContext
    {
        public ProductReviewDbContext(DbContextOptions<ProductReviewDbContext> options) : base(options) { }

        public DbSet<ProductReview> ProductReviews { get; set; }
    }
}

