using LoginApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Data.Services;
using Microsoft.Extensions.DependencyInjection;
using LoginApplication.Infrustructor;
using Microsoft.AspNetCore.Authorization;
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
            UserServices userServices = new UserServices();

            if (HttpContext.Session.GetString("Admin") != null)
            {
                int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
                var valueAdmin = userServices.GetAdminWithById(admin_id);
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
