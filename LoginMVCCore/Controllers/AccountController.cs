using LoginMVCCore.Models;
using LoginMVCCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LoginMVCCore.Controllers
{
    public class AccountController : Controller
    {
       private readonly ILoginRepository _loginRepository;
        public AccountController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login obj)
        {
            if (ModelState.IsValid)
            {
                var user = _loginRepository.ValidateUser(obj.Username, obj.Password); 
                if (user != null )
                {
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.ErrorMessage = "Invalid Username and Passsword";
               //else
               // {
               //     ModelState.AddModelError("", "Invalid username or password.");
               //     ViewBag.ErrorMessage = "Invalid username or password.";
               // }
                //ModelState.AddModelError("", "Invalid username or password.");
                //ViewBag.ErrorMessage = "Invalid username or password.";
            }

            return View(obj);

        }

    }
}
