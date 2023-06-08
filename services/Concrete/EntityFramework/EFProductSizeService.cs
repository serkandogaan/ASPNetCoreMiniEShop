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
    public class EFProductSizeService : EFGenericService<ProductSize>, IProductSizeService
    {
        public EFProductSizeService(DbContext context) : base(context)
        {
        }
    }
}
