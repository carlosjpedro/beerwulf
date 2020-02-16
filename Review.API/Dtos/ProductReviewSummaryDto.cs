namespace Review.API.Dtos
{
    public class ProductReviewSummaryDto
    {        
        public int ProductId { get;set;}
        
        public decimal AvgScore { get; set;}
        
        public decimal Recommend { get; set;}
    }
}
