using entity.Models;
using Microsoft.AspNetCore.Mvc;
using services.Abstract;

namespace Shopping.Controllers
{
    public class RegisterController : Controller
    {
        public IDatabaseService _dbs;
        public RegisterController(IDatabaseService dbs)
        {
            _dbs = dbs;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User newUser)
        {
            //var User = _dbs.UserService.GetUserbyMail(newUser.UserMail);
            //if (User == null)
            //{
                //_dbs.UserService.Add(newUser);

            //}
            return Redirect("/");

        }
    }
}
