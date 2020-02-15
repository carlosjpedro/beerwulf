using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Review.API.Exceptions;
using Review.API.Repositories;
using Review.API.Services.Model;

namespace Review.API.Services
{
    public class ReviewManager : IReviewManager
    {
        private readonly IProductRepository _productRepository;
        private readonly IReviewRepository _reviewRepository;

        public ReviewManager(IProductRepository productRepository, IReviewRepository reviewRepository)
        {
            _productRepository = productRepository;
            _reviewRepository = reviewRepository;
        }
        public async Task<IEnumerable<ProductReview>> ProductReviews(int productId)
        {
            var product = await _productRepository.GetProduct(productId);
            if (product == null) throw new ProductNotFound(productId);

            return await _reviewRepository.GetReviews(productId);
        }

        public async Task AddReview(ProductReview review)
        {
            var product = await _productRepository.GetProduct(review.ProductId);
            if (product == null) throw new ProductNotFound(review.ProductId);

            await _reviewRepository.AddReview(review);
        }

        public async Task<ProductReviewSummary> ProductReviewSummary(int productId)
        {
            var product = await _productRepository.GetProduct(productId);
            if (product == null) throw new ProductNotFound(productId);

            var reviews = (await _reviewRepository.GetReviews(productId)).ToList();

            if (reviews.Count == 0)
                return new ProductReviewSummary(productId, 0, 0);

            return new ProductReviewSummary(productId, (decimal)reviews.Average(x => x.Score), reviews.Count(x => x.Recommend) / (decimal)reviews.Count);
        }
    }
}
