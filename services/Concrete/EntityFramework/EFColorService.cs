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
    public class EFColorService : EFGenericService<Color>, IColorService
    {
        public EFColorService(DbContext context) : base(context)
        {
        }
    }
}
