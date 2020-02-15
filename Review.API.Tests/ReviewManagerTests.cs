using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Review.API.Services;
using Review.API.Services.Model;

namespace Review.API.Tests
{
    public class ReviewManagerTests
    {
        private readonly IReviewManager _reviewManager = new ReviewManager();
        private Fixture _fixture;

        public ReviewManagerTests()
        {
            _fixture = new Fixture();
        }
        public async Task AddReview_Fails_When_Product_Does_Not_Exist()
        {
            var productReview = _fixture
                .Build<ProductReview>()
                .With(x=> x.)

            _reviewManager
        }
    }
}
