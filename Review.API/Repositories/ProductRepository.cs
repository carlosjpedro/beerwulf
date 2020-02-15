using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Review.API.Services.Model;

namespace Review.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Product> GetProduct(int productId)
        {
            return _dbContext.Products.SingleOrDefaultAsync(x => x.ProductId == productId);
        }
    }
}

