using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Models.Services;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserViewModel userViewModel)
        {
            SecurityService securityService = new();

            if (securityService.IsValid(userViewModel))
            {
                return View("LoginSuccess", userViewModel);
            }
            else
            {
                return View("LoginFailure", userViewModel);
            }            
        }
    }
}
