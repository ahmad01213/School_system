using Microsoft.AspNetCore.Mvc;

namespace School_Management_System.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
