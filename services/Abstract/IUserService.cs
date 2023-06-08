using entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Abstract
{
    public interface IUserService: IGenericService<User>
    {    
        //User GetUserbyMail(string mail);
    }
}
