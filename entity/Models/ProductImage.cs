using System;
using System.Collections.Generic;

namespace entity.Models
{
    public partial class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductImagePath { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
