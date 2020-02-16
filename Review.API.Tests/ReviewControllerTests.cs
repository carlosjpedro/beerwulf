using Review.API.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using Moq;
using Review.API.Controllers;
using Review.API.Exceptions;
using Review.API.Services;
using Xunit;
using Review.API.Entities;

namespace Review.API.Tests
{
    public class ReviewControllerTests
    {
        private readonly ReviewController _controller;
        private readonly Mock<IReviewManager> _reviewManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Fixture _fixture;

        public ReviewControllerTests()
        {
            _mapperMock = new Mock<IMapper>();
            _reviewManagerMock = new Mock<IReviewManager>();

            _controller = new ReviewController(_reviewManagerMock.Object,
                                               _mapperMock.Object);

            _fixture = new Fixture();
        }

        [Fact]
        public void PostingReview_Will_Fail_When_productIdIsNotConsistent()
        {
            var productReviewDto = new ProductReviewDto
            {
                ProductId = 2,
                Score = 2,
                Title = "MyTitle",
                Recommend = true,
                Comments = "Some Comments"
            };

            Assert.ThrowsAsync<InvalidRequestData>(
                () => _controller.Add(4, productReviewDto));
        }

        [Fact]
        public async Task PostingReview_Will_AddMappedReview()
        {
            var productReviewDto = _fixture.Create<ProductReviewDto>();
            var productReview = _fixture.Create<ProductReview>();

            _mapperMock
                .Setup(x => x.Map<ProductReview>(productReviewDto))
                .Returns(productReview);

            await _controller.Add(productReviewDto.ProductId.Value, productReviewDto);
            _reviewManagerMock.Verify(x => x.AddReview(productReview), Times.Once);
            _mapperMock.Verify(x => x.Map<ProductReview>(productReviewDto), Times.Once);
        }

        [Fact]
        public async Task GetReviews_Will_ReturnMappedReviews()
        {
            const int productId = 29;
            var productReviews = _fixture.CreateMany<ProductReview>(10);
            var productReviewDtos = _fixture.CreateMany<ProductReviewDto>(10);

            _reviewManagerMock
                .Setup(x => x.ProductReviews(productId))
                .ReturnsAsync(productReviews);
            _mapperMock
                .Setup(x => x.Map<IEnumerable<ProductReviewDto>>(productReviews))
                .Returns(productReviewDtos);

            var reviews = await _controller.GetReviews(productId);

            _reviewManagerMock.Verify(x => x.ProductReviews(productId), Times.Once);
            _mapperMock.Verify(x => x.Map<IEnumerable<ProductReviewDto>>(productReviews));

            Assert.Same(productReviewDtos, reviews);
        }

        [Fact]
        public async Task GetReviewsSummary_Will_ReturnMappedSummary()
        {
            const int productId = 40;
            var reviewSummary= _fixture.Create<ProductReviewSummary>();
            var reviewSummaryDto = _fixture.Create<ProductReviewSummaryDto>();

            _reviewManagerMock
                .Setup(x => x.ProductReviewSummary(productId))
                .ReturnsAsync(reviewSummary);
            _mapperMock
                .Setup(x => x.Map<ProductReviewSummaryDto>(reviewSummary))
                .Returns(reviewSummaryDto);

            var summary = await _controller.GetSummary(40);

            _reviewManagerMock.Verify(x => x.ProductReviewSummary(productId), Times.Once);
            _mapperMock.Verify(x => x.Map<ProductReviewSummaryDto>(reviewSummary));

            Assert.Same(reviewSummaryDto, summary);
        }
    }
}
