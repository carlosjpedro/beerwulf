using System;
using System.ComponentModel.DataAnnotations;

namespace Review.API.Dtos
{
    public class ProductReviewDto
    {
        /// <summary>
        /// Unique Identifier for product review
        /// </summary>
        [Required]
        public int? ProductId { get; set; }

        /// <summary>
        /// Numeric representation of review
        /// </summary>
        [Required]
        [Range(1, 5)]
        public int? Score { get; set; }

        /// <summary>
        /// Review title
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        /// <summary>
        /// Review text body
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Comments { get; set; }

        /// <summary>
        /// Would costumer recommend product to friends?
        /// </summary>
        [Required]
        public bool? Recommend { get; set; }
    }
}
