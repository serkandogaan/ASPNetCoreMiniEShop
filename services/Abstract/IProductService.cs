using entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Abstract
{
    public interface IProductService :IGenericService<Product>
    {
        IEnumerable<Product> GetProductbyFilter(int[] price, string[] color, string[] size);
    }
}
