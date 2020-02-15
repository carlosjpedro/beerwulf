using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Review.API.Services.Model
{
    public class ProductReview
    {
        private ProductReview() { }

        public ProductReview(int productId, int score, string title, string comments, bool recommend)
        {
            ProductId = productId;
            Score = score;
            Title = title;
            Comments = comments;
            Recommend = recommend;
        }

        public ProductReview(int id, int productId, int score, string title, string comments, bool recommend)
            : this(productId, score, title, comments, recommend)
        {
            Id = id;
        }

        [Key]
        public int Id { get; private set; }

        public int ProductId { get; private set; }

        public int Score { get; private set; }

        public string Title { get; private set; }

        public string Comments { get; private set; }

        public bool Recommend { get; private set; }
    }

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

    public class Product
    {
        private Product() { }
        [Key]
        public int ProductId { get; private set; }
        public string Name { get; private set; }

        public Product(int productId, string name)
        {
            ProductId = productId;
            Name = name;
        }
    }
}
