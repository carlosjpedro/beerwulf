using Review.API.Dtos;
using System;
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

    public class ReviewManager: IReviewManager
    {
        public Task<IEnumerable<ProductReview>> ProductReviews(int productId)
        {
            throw new NotImplementedException();
        }

        public Task AddReview(ProductReview review)
        {
            throw new NotImplementedException();
        }

        public Task<ProductReviewSummary> ProductReviewSummary(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
