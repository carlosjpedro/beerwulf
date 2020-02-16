using System;
using System.ComponentModel.DataAnnotations;

namespace Review.API.Entities
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

        [Key]
        public int Id { get; private set; }

        public int ProductId { get; private set; }

        public int Score { get; private set; }

        public string Title { get; private set; }

        public string Comments { get; private set; }

        public bool Recommend { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is ProductReview review &&
                   Id == review.Id &&
                   ProductId == review.ProductId &&
                   Score == review.Score &&
                   Title == review.Title &&
                   Comments == review.Comments &&
                   Recommend == review.Recommend;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, ProductId, Score, Title, Comments, Recommend);
        }
    }
}
