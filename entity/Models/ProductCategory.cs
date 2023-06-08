using System;
using System.Collections.Generic;

namespace entity.Models
{
    public partial class ProductCategory
    {
        public string Id { get; set; } = null!;
        public string ProductCategoryName { get; set; } = null!;
        public string ProductCategoryDescription { get; set; } = null!;
    }
}
