using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Abstract
{
    public interface IDatabaseService : IDisposable
    {
        IBasketService BasketService { get; }
        IProductCategoryService ProductCategoryService { get; }
        IProductService ProductService { get; }
        IUserService UserService { get; }
        IProductReviewService ProductReviewService { get; }
        IProductImageService ProductImageService { get; }
        IProductColorService ProductColorService { get; }
        IProductSizeService ProductSizeService { get; }
        IColorService ColorService { get; }
        ISizeService SizeService { get; }
    }
}
