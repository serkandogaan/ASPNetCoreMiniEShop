using entity.Context;
using services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Concrete.EntityFramework
{
    public class EFDatabaseService : IDatabaseService
    {
        public DatabaseContext _db;
        public IBasketService _IBasketService;
        public IProductService _ProductService;
        public IProductCategoryService _ProductCategoryService;
        public IUserService _UserService;
        public IProductReviewService _ProductReviewService;
        public IProductImageService _ProductImageService;
        public IProductColorService _ProductColorService;
        public IProductSizeService _ProductSizeService;
        public ISizeService _SizeService;
        public IColorService _ColorService;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EFDatabaseService(DatabaseContext db)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _db = db;
        }

        public IColorService ColorService
        {
            get
            {
                return _ColorService ?? (_ColorService = new EFColorService(_db));
            }
        }

        public ISizeService SizeService
        {
            get
            {
                return _SizeService ?? (_SizeService = new EFSizeService(_db));
            }
        }

        public IProductSizeService ProductSizeService
        {
            get
            {
                return _ProductSizeService ?? (_ProductSizeService = new EFProductSizeService(_db));
            }
        }

        public IProductColorService ProductColorService
        {
            get 
            {
                return _ProductColorService ?? (_ProductColorService = new EFProductColorService(_db)); 
            }
        }

        public IProductImageService ProductImageService
        {
            get
            {
                return _ProductImageService ?? (_ProductImageService = new EFProductImageService(_db));
            }
        }
        public IBasketService BasketService
        {
            get
            {
                return _IBasketService ?? (_IBasketService = new EFBasketService(_db));
            }
        }
        public IProductCategoryService ProductCategoryService
        {
            get
            {
                return _ProductCategoryService ?? (_ProductCategoryService = new EFProductCategoryService(_db));
            }
        }

        public IProductService ProductService
        {
            get
            {
                return _ProductService ?? (_ProductService = new EFProductService(_db));
            }
        }

        public IUserService UserService
        {
            get
            {
                return _UserService ?? (_UserService = new EFUserService(_db));
            }
        }

        public IProductReviewService ProductReviewService
        {
            get
            {
                return _ProductReviewService ?? (_ProductReviewService = new EFProductReviewService(_db));
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
