using System.Collections.Generic;
using System.Threading.Tasks;
using Review.API.Entities;

namespace Review.API.Repositories
{
    public interface IReviewRepository
    {
        Task AddReview(ProductReview productReview);
        Task<IEnumerable<ProductReview>> GetReviews(int productId);
    }
}

