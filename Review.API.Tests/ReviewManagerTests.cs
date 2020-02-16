using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using Review.API.Entities;
using Review.API.Exceptions;
using Review.API.Repositories;
using Review.API.Services;
using Xunit;

namespace Review.API.Tests
{
    public class ReviewManagerTests
    {
        private readonly IReviewManager _reviewManager;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IReviewRepository> _reviewRepositoryMock;
        private readonly Fixture _fixture;

        public ReviewManagerTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _reviewRepositoryMock = new Mock<IReviewRepository>();
            _fixture = new Fixture();
            _reviewManager = new ReviewManager(_productRepositoryMock.Object,
            _reviewRepositoryMock.Object);
        }

        [Fact]
        public async Task AddReview_Fails_When_Product_Does_Not_Exist()
        {
            const int productId = 432;
            var productReview = new ProductReview(
                productId, 30,
                "my review", "great product",
                true);

            await Assert.ThrowsAsync<ProductNotFound>(() => _reviewManager.AddReview(productReview));
        }

        [Fact]
        public async Task AddReview_Will_Add_Product_To_Repostiory()
        {
            const int productId = 65;
            var productReview = new ProductReview(
                productId, 30,
                "my review", "great product",
                true);

            _productRepositoryMock
                    .Setup(x => x.GetProduct(productId))
                    .ReturnsAsync(new Product(productId, "deafult product"));

            await _reviewManager.AddReview(productReview);

            _reviewRepositoryMock.Verify(x => x.AddReview(productReview), Times.Once);
        }

        [Fact]
        public async Task GetReviews_Fails_When_Product_Does_Not_Exist()
        {
            const int productId = 235;
            await Assert.ThrowsAsync<ProductNotFound>(() => _reviewManager.ProductReviews(productId));
        }

        [Fact]
        public async Task GetReviews_Returns_Collection_From_Repository()
        {
            const int productId = 290;
            var product = _fixture.Create<Product>();
            var productReviews = _fixture.CreateMany<ProductReview>(12);

            _productRepositoryMock
                .Setup(x => x.GetProduct(productId))
                .ReturnsAsync(product);

            _reviewRepositoryMock
                .Setup(x => x.GetReviews(productId))
                .ReturnsAsync(productReviews);

            var reviews = await _reviewManager.ProductReviews(productId);

            Assert.Same(productReviews, reviews);
        }

        [Fact]
        public async Task GetReviewSummary_Fails_When_Product_Does_Not_Exist()
        {
            const int productId = 235;
            await Assert.ThrowsAsync<ProductNotFound>(() => _reviewManager.ProductReviewSummary(productId));
        }

        [Fact]
        public async Task GetReviewSummary_Returns_Empty_Summary_When_No_Reviews_Exist()
        {
            const int productId = 290;
            var product = _fixture.Create<Product>();
            var expectedReview = new ProductReviewSummary(productId, 0, 0);

            _productRepositoryMock
                .Setup(x => x.GetProduct(productId))
                .ReturnsAsync(product);

            _reviewRepositoryMock
                .Setup(x => x.GetReviews(productId))
                .ReturnsAsync(Enumerable.Empty<ProductReview>());

            var reviewSummary = await _reviewManager.ProductReviewSummary(productId);

            Assert.Equal(expectedReview, reviewSummary);
        }

        [Fact]
        public async Task GetReviewSummary_Returns_Calculated_Summary()
        {
            const int productId = 33;
            var product = _fixture.Create<Product>();

            var expectedReview = new ProductReviewSummary(productId, 3.0m, 0.5m);

            _productRepositoryMock
                .Setup(x => x.GetProduct(productId))
                .ReturnsAsync(product);

            _reviewRepositoryMock.Setup(x => x.GetReviews(productId))
            .ReturnsAsync(new List<ProductReview>{
                    new ProductReview(productId, 4, "product", "comment", true),
                    new ProductReview(productId, 2, "another product", "another comment", false),
            });

            var reviewSummary = await _reviewManager.ProductReviewSummary(productId);

            Assert.Equal(expectedReview, reviewSummary);

        }
    }
}
