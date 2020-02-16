using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Review.API.Dtos;
using Review.API.Entities;
using Review.API.Exceptions;
using Review.API.Services;

namespace Review.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private const string InvalidProductIdMessage =
            "ProductId provided in url must be the same as the one in the request body.";

        private readonly IReviewManager _reviewManager;
        private readonly IMapper _mapper;

        public ReviewController(IReviewManager reviewManager, IMapper mapper)
        {
            _reviewManager = reviewManager;
            _mapper = mapper;
        }

        [HttpGet("{productId}")]
        public async Task<IEnumerable<ProductReviewDto>> GetReviews(int productId)
        {
            var productReviews = await _reviewManager.ProductReviews(productId);
            return _mapper.Map<IEnumerable<ProductReviewDto>>(productReviews);
        }

        [HttpGet]
        [Route("summary/{productId}")]
        public async Task<ProductReviewSummaryDto> GetSummary(int productId)
        {
            var reviewSummary = await _reviewManager.ProductReviewSummary(productId);
            return _mapper.Map<ProductReviewSummaryDto>(reviewSummary);
        }


        [HttpPost]
        [Route("/{productId}")]
        public async Task Add(int productId, ProductReviewDto reviewDto)
        {
            if (productId != reviewDto.ProductId)
            {
                throw new InvalidRequestData(InvalidProductIdMessage);
            }
            var review = _mapper.Map<ProductReview>(reviewDto);
            await _reviewManager.AddReview(review);
        }
    }


}
