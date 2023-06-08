using entity.Context;
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
    public class EFProductCategoryService : EFGenericService<ProductCategory>, IProductCategoryService
    {
        public EFProductCategoryService(DatabaseContext context) : base(context)
        {
        }

        public List<ProductCategory> GetAllProductCategory()
        {
            return GetAll();
        }

        public ProductCategory GetProductCategorybyID(int id)
        {
            return GetByID(id);
        }
    }
}
