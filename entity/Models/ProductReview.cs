using System;
using System.Collections.Generic;

namespace entity.Models
{
    public partial class ProductReview
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ReviewerName { get; set; } = null!;
        public DateTime ReviewerDate { get; set; }
        public string ReviewerComment { get; set; } = null!;
    }
}
