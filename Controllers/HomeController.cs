using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CBSBahrainMVC.Models;
using Microsoft.AspNetCore.Http;

namespace CBSBahrainMVC.Controllers
{
    public class HomeController : Controller
    {

       

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //if (HttpContext.Session.GetString("Loggedin") == null) {
            //  return  RedirectToAction("Login", "Home");
            //}
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            CBSBahrainContext _context = new CBSBahrainContext();


            var usrx = _context.Cmsuser.Where(x => x.UserName == login.userid && x.Password == login.password).SingleOrDefault();
            if (usrx != null)
            {

                HttpContext.Session.SetString("Loggedin", "YES");

                return Redirect("http://www.cbs-bahrain.com/");
            }
            else
            {
                ViewBag.Message = "Invalid User ID / Password !";
                return View();
            }


        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
