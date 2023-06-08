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
    public class EFBasketService : EFGenericService<Basket>, IBasketService
    {
        public EFBasketService(DatabaseContext context) : base(context)
        {
        }

        public List<Basket> GetAllBasket()
        {
            return GetAll();
        }

        public Basket GetBasketByID(int id)
        {
            return GetByID(id);
        }
    }
}
