using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YourAppNamespace.Service;

namespace YourAppNamespace.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            await _loginService.IsValid(username, password);/* 
            if (isValid)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid username or password"; */
            return View("Index");
        }
    }
}