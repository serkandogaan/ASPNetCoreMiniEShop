using System;
using System.Collections.Generic;

namespace entity.Models
{
    public partial class ProductColor
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductColor1 { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
