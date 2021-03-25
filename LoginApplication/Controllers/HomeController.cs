using LoginApplication.Infrustructor;
using LoginApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Globalization;

namespace LoginApplication.Controllers
{
    public class HomeController : BaseController

    {
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
           
            LOGIN.SERVICES.UserService userServices = new LOGIN.SERVICES.UserService();
            LOGIN.SERVICES.AdminServices adminServices = new LOGIN.SERVICES.AdminServices();

            if (HttpContext.Session.GetString("Admin") != null)
            {
                int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
                var valueAdmin = adminServices.GetAdminWithById(admin_id);
                ViewBag.AdminFirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(valueAdmin.FirstName);
                ViewBag.AdminLastName = valueAdmin.LastName.ToUpper();
                ViewBag.AdminID = admin_id;
            }

            else if (HttpContext.Session.GetString("User") !=null)
            {
                int user_id = int.Parse(HttpContext.Session.GetString("User"));
                var valueUser = userServices.GetUserWithById(user_id);
                ViewBag.UserFirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(valueUser.FirstName);
                ViewBag.UserLastName = valueUser.LastName.ToUpper();
            }
            


            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }





}
