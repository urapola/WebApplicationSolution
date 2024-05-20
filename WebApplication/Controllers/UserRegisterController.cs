using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class UserRegisterController : Controller
    {
        List<UserRegisterViewModel> userRegister = new();
        public IActionResult Index()
        {
            return View(userRegister);
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(UserRegisterViewModel userRegister)
        {
            this.userRegister.Add(userRegister);
            return View("Details", userRegister);
        }
    }
}
