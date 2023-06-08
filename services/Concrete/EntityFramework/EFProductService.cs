using Microsoft.EntityFrameworkCore;
using services.Abstract;
using entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.Context;

namespace services.Concrete.EntityFramework
{
    public class EFProductService : EFGenericService<Product>, IProductService
    {
        public EFProductService(DatabaseContext _context) : base(_context)
        {
        }
        public DatabaseContext _db
        {
            get { return _context as DatabaseContext; }
        }

  
        public IEnumerable<Product> GetProductbyFilter(int[] price, string[] color, string[] size)
        {

            IQueryable<Product> filter = _db.Products;

            if (price.Length != 0)
            {
                foreach (var item in price)
                {
                   filter = filter.Where(x => item >= x.ProductPrice);
                }
            }
            if (color.Length != 0)
            {
                filter = filter.Where(x => color.Contains(x.ProductColor));
            }
            if (size.Length != 0)
            {
                filter = filter.Where(x => size.Contains(x.ProductSize));
            }
            
            
           return filter.ToList();
        }       
    }
}
