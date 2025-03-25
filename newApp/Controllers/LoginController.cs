
using Microsoft.AspNetCore.Mvc;
using newApp.Service;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using newApp.Models;

namespace newApp.Controllers;
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
            var user = await _loginService.IsValid(username, password);
            if (user != null){
            // Tu peux utiliser les données utilisateur ici
            Console.WriteLine($"Token: {user.Token}");
            Console.WriteLine($"Username: {user.Username}");
            
             var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username), // Stocker le nom d'utilisateur
                new Claim(ClaimTypes.Role, user.Roles[0].Name) // Stocker le rôle
            };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                 return RedirectToAction("Index", "Home");
        }else{
            // Si l'utilisateur n'est pas authentifié, rediriger ou afficher une erreur
            ModelState.AddModelError("", "Invalid login attempt.");
            return View("Index");
        }
        }
    }
