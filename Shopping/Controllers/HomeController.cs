using entity.Context;
using entity.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using services.Abstract;
using Shopping.Models;
using System.Diagnostics;
using System.Security.Claims;
using X.PagedList;

namespace Shopping.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDatabaseService _dbs;
        public DatabaseContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IDatabaseService dbs, DatabaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _dbs = dbs;
            _db = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        //[Route("urunler/")]
        [HttpGet]
        public IActionResult Product(int Sayfa = 1)
        {
            var PageSize = 6;
            var Products = _dbs.ProductService.GetAll().OrderBy(x => x.Id).ToPagedList(Sayfa, PageSize);                      
            return View(Products);
        }
        public IActionResult ProductFilter(int Sayfa = 1, int[] filterprice = null, string[] filtercolor = null, string[] filtersize = null)
        {
            var PageSize = 6;
            var Products = _dbs.ProductService.GetProductbyFilter(filterprice, filtercolor, filtersize).ToPagedList(Sayfa, PageSize);                  
            return PartialView("_ProductFilterPartial", Products);
        }

        [Route("urun/urunadi/{id}")]        
        public IActionResult ProductDetail(int id)
        {            
            var ProductDetail = _dbs.ProductService.GetAll(x => x.Id == id);
            TempData["ProductID"] = id;
            return View(ProductDetail);       
        }

        [HttpPost]
        public IActionResult AddProductReview(ProductReview ProductReview)
        {
            var a =  RouteData.Values["id"];
            var ProductID = TempData["ProductID"];
            ProductReview.ReviewerDate = DateTime.Now;
            ProductReview.ProductId = Convert.ToInt32(TempData["ProductID"]);
            _dbs.ProductReviewService.Add(ProductReview);
            return RedirectToAction("ProductDetail");
            
        }

        [HttpPost]
        public IActionResult AddProductToBasket(Basket Basket, int ProductQuantity)
        {
            var Product = _dbs.ProductService.GetByID(Basket.ProductId);
            var ass = Product.ProductName;
            var ProductID = Basket.ProductId;
                            

            return View();

        }

        public IActionResult CartPage()
        {
            string cookieName = _httpContextAccessor.HttpContext.Request.Cookies["AddBasketCookie"];
            ViewBag.Product = cookieName;
            List<Basket> cookieValue = AddBasketCookie;
            var cookielist = cookieValue.ToList();
            return View(cookielist);
        }

        public IActionResult CheckOutPage()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                var UserInfo = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var GetUserID = _dbs.UserService.GetByID(UserInfo).Id;
                var GetUserBasket = _dbs.BasketService.GetByID(GetUserID); // interface inde user id ye göre getirmeyi ekle.
                return View(GetUserBasket);
            }
            List<Basket> cookieValue = AddBasketCookie;
            var cookielist = cookieValue.ToList();
            return View(cookielist);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult InsertProductToBasket(Basket Basket, int ProductID, int ProductQuantity)
        {
            List<Basket> cookieValue = AddBasketCookie;
            var Product = _dbs.ProductService.GetByID(ProductID);
            
            var user = new User();

            //if (User.Identity.IsAuthenticated)
            //{
            //    user = _dbs.UserService.GetByID(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value));
            //    int id = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value);
            //}
            if (cookieValue.FirstOrDefault(x => x.ProductId == ProductID) == null)
            {

                //var cookieProductID = cookieValue.FirstOrDefault(p => p.ProductId == ProductID).ProductId;
                var newbasket = _dbs.ProductService.GetByID(ProductID);
                var CookieBasket = new Basket();
                CookieBasket.ProductQuantity = 1;
                CookieBasket.Product = newbasket;
                CookieBasket.ProductId = ProductID;
                cookieValue.Add(CookieBasket);

            }
            else if (cookieValue.FirstOrDefault(x => x.ProductId == ProductID).ProductId == ProductID)
            {
                var CookieProduct = cookieValue.FirstOrDefault(x => x.ProductId == ProductID);
                var NewQuantity = CookieProduct.ProductQuantity + 1;
                CookieProduct.ProductQuantity = NewQuantity;

                Basket newBasket = new Basket
                {
                    ProductId = ProductID,                    
                };

                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    newBasket.Id = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value);
                    _dbs.BasketService.Add(newBasket);
                }
               

                //cookieValue.Add(newBasket);

            }

            AddBasketCookie = cookieValue;

            return Json("Ok");
        }
        public List<Basket> AddBasketCookie
        {
            get
            {
                if (_httpContextAccessor.HttpContext.Request.Cookies["AddBasketCookie"] != null)
                {
                    string cookieName = _httpContextAccessor.HttpContext.Request.Cookies["AddBasketCookie"];
                    return JsonConvert.DeserializeObject<List<Basket>>(cookieName);
                }
                else
                {
                    return new List<Basket>();
                }
            }
            set
            {
                CookieOptions cookieOptions = new CookieOptions
                {
                    //Path = "/",
                    //HttpOnly = true,
                    //IsEssential = true,
                    //SameSite = SameSiteMode.Lax,
                    Expires = DateTime.Now.AddDays(2),
                    
                };

                string cookieValue = JsonConvert.SerializeObject(value);

                _httpContextAccessor.HttpContext.Response.Cookies.Append("AddBasketCookie", cookieValue, cookieOptions);

            }
        }

        

    }
}