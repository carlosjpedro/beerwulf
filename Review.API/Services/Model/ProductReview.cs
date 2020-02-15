using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace Review.API.Services.Model
{
    public class ProductReview
    {
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

        public int Id { get; }

        public int ProductId { get; }

        public int Score { get; }

        public string Title { get; }

        public string Comments { get; }

        public bool Recommend { get; }
    }
}
