using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

    public class ProductReviewSummaryDto
    {
    }
}
