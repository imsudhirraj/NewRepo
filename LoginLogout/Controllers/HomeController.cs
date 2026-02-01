using LoginLogout.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace LoginLogout.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext context;

        public HomeController(AppDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("userSession") != null)
            {
                ViewBag.session = HttpContext.Session.GetString("userSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(TBL_USER_MASTER user)
        {
            var myuser = context.TBL_USER_MASTER
                .FirstOrDefault(x =>
                    x.EMAIL == user.EMAIL &&
                    x.USER_PASSWORD == user.USER_PASSWORD);
            if (myuser != null)
            {
                HttpContext.Session.SetString("userSession", myuser.EMAIL);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Message = "Login Failed.";
            }
            return View();
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("userSession") != null)
            {
                HttpContext.Session.Remove("userSession");
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
