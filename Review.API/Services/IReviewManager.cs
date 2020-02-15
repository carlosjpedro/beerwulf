using Review.API.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Review.API.Services.Model;

namespace Review.API.Services
{
    public interface IReviewManager
    {
        Task<IEnumerable<ProductReview>> ProductReviews(int productId);
        Task AddReview(ProductReview review);
        Task<ProductReviewSummary> ProductReviewSummary(int productId);
    }
}
