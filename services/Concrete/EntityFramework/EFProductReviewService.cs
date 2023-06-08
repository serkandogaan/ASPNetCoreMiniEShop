using entity.Models;
using Microsoft.EntityFrameworkCore;
using services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Concrete.EntityFramework
{
    public class EFProductReviewService : EFGenericService<ProductReview>, IProductReviewService
    {
        public EFProductReviewService(DbContext context) : base(context)
        {
        }

        public List<ProductReview> GetProductReviews(int id)
        {
            return GetAll(x => x.ProductId == id);
        }
    }
}
