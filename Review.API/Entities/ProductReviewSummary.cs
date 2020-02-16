using System;

namespace Review.API.Entities
{
    public class ProductReviewSummary
    {
        public int ProductId { get; }
        public decimal AvgScore { get; }
        public decimal Recommend { get; }
        public ProductReviewSummary(int productId, decimal avgScore, decimal recommend)
        {
            ProductId = productId;
            AvgScore = avgScore;
            Recommend = recommend;
        }

        public override bool Equals(object obj)
        {
            return obj is ProductReviewSummary summary &&
                   ProductId == summary.ProductId &&
                   AvgScore == summary.AvgScore &&
                   Recommend == summary.Recommend;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductId, AvgScore, Recommend);
        }
    }
}
