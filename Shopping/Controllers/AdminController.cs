using entity.Models;
using Microsoft.AspNetCore.Mvc;
using services.Abstract;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Shopping.Controllers
{
    public class AdminController : Controller
    {
        public IDatabaseService _dbs;
        public AdminController(IDatabaseService dbs)
        {
            _dbs = dbs;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("urunler/urun-listesi")]
        public IActionResult ListProduct()
        {
            var ProductList = _dbs.ProductService.GetAll();
            return View(ProductList);
        }

        [Route("kategoriler/kategori-listesi")]
        public IActionResult ListProductCategory()
        {
            var ProductCategoryList = _dbs.ProductCategoryService.GetAll();
            return View(ProductCategoryList);
        }

        [HttpGet]

        [Route("urun-ekle")]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]

        public IActionResult AddProduct(Product Product, List<IFormFile> imageFile)
        {
            Product.ProductDescription = "aaa";
            _dbs.ProductService.Add(Product);

            var Colors = Product.ProductColor;
            string[] ColorArray = Colors.Split(',');

            foreach (var ProductColors in ColorArray)
            {
                ProductColor productColor = new ProductColor();
                productColor.ProductId = Product.Id;
                productColor.ProductColor1 = ProductColors;
                _dbs.ProductColorService.Add(productColor);
            }

            var Size = Product.ProductSize;
            string[] SizeArray = Size.Split(',');

            foreach (var ProductSize in SizeArray)
            {
                ProductSize productSize = new ProductSize();
                productSize.ProductId = Product.Id;
                productSize.ProductSize1 = ProductSize;
                _dbs.ProductSizeService.Add(productSize);
            }

            foreach (var ProductImages in imageFile)
            {
                string imageFileName = ProductImages.FileName;

                var ResizeImage = Image.Load(ProductImages.OpenReadStream());
                ResizeImage.Mutate(x => x.Resize(750, 750));
                string imageUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", imageFileName);
                ResizeImage.Save(imageUploadPath);

                //imageFileName = Path.GetFileName(imageFileName);
                //string imageUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", imageFileName);
                //var Stream = new FileStream(imageUploadPath, FileMode.Create);

                //ProductImages.CopyToAsync(Stream);

                ProductImage productImage = new ProductImage();
                productImage.ProductId = Product.Id;
                productImage.ProductImagePath = imageFileName;
                _dbs.ProductImageService.Add(productImage);
            }

            return View();
        }

        [HttpGet]

        [Route("urun/guncelle/{id}")]
        public IActionResult UpdateProduct(int id)
        {
            var FindProduct = _dbs.ProductService.GetByID(id);
            return View(FindProduct);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            product.ProductDescription = "ggg";
            _dbs.ProductService.Update(product);
            return RedirectToAction("ListProduct");
        }

        [Route("urun/sil/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var FindProduct = _dbs.ProductService.GetByID(id);
            _dbs.ProductService.Delete(FindProduct);
            return RedirectToAction("ListProduct");
        }

        [HttpGet]

        [Route("kategoriler/kategori-ekle")]
        public IActionResult AddProductCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProductCategory(ProductCategory ProductCategory)
        {
            _dbs.ProductCategoryService.Add(ProductCategory);
            return RedirectToAction("ListProductCategory");
        }

        [HttpPost]
        public IActionResult AddProductReview(ProductReview ProductReview)
        {
            _dbs.ProductReviewService.Add(ProductReview);
            return View();
        }

        [Route("uyeler/uye-listesi")]
        public IActionResult ListUser()
        {
            var Users = _dbs.UserService.GetAll();
            return View(Users);
        }

        [HttpGet]

        [Route("uyeler/guncelle/{id}")]
        public IActionResult UpdateUser(int id)
        {
            var FindUser = _dbs.UserService.GetByID(id);
            return View(FindUser);
        }

        [HttpPost]
        public IActionResult UpdateUser(User UpdateUser)
        {
            _dbs.UserService.Update(UpdateUser);
            return RedirectToAction("ListUser");
        }
    }
}
