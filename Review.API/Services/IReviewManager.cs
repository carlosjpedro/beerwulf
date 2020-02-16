using System.Collections.Generic;
using System.Threading.Tasks;
using Review.API.Entities;

namespace Review.API.Services
{
    public interface IReviewManager
    {
        Task<IEnumerable<ProductReview>> ProductReviews(int productId);
        Task AddReview(ProductReview review);
        Task<ProductReviewSummary> ProductReviewSummary(int productId);
    }
}
