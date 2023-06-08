using System;
using System.Collections.Generic;

namespace entity.Models
{
    public partial class Product
    {
        public Product()
        {
            Baskets = new HashSet<Basket>();
            ProductColors = new HashSet<ProductColor>();
            ProductImages = new HashSet<ProductImage>();
            ProductSizes = new HashSet<ProductSize>();
        }

        public int Id { get; set; }
        public string ProductCategory { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public int ProductPrice { get; set; }
        public string ProductSize { get; set; } = null!;
        public string ProductColor { get; set; } = null!;

        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<ProductColor> ProductColors { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductSize> ProductSizes { get; set; }
    }
}
