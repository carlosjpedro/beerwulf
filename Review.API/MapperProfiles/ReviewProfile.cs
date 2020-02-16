using AutoMapper;
using Review.API.Dtos;
using Review.API.Entities;

namespace Review.API.MapperProfiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ProductReviewDto, ProductReview>()
            .ConstructUsing(x => new ProductReview(x.ProductId.Value,
                                                   x.Score.Value,
                                                   x.Title,
                                                   x.Comments,
                                                   x.Recommend.Value)).ReverseMap();


            CreateMap<ProductReviewSummary, ProductReviewSummaryDto>();
        }
    }
}