using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Review.API.Services.Model;

namespace Review.API.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ProductReviewDbContext _dbContext;

        public ReviewRepository(ProductReviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddReview(ProductReview productReview)
        {
            await _dbContext.ProductReviews.AddAsync(productReview);
            await _dbContext.SaveChangesAsync();

        }
        public async Task<IEnumerable<ProductReview>> GetReviews(int productId)
        {
            return await _dbContext.ProductReviews.Where(x => x.ProductId == productId).ToListAsync();
        }
    }
}

