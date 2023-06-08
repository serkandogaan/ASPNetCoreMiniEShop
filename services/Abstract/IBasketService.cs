﻿using entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Abstract
{
    public interface IBasketService: IGenericService<Basket>
    {
        List<Basket> GetAllBasket();
        Basket GetBasketByID(int id);
    }
}
