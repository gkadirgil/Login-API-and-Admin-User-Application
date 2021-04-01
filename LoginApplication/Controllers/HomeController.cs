using LOGIN.DATA.Models;
using LOGIN.SERVICES;
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
        private readonly IPersonRepository<Admin> _adminRepository;
        private readonly IPersonRepository<User> _userRepository;

        public HomeController(ILogger<HomeController> logger, IPersonRepository<Admin> adminRepository, IPersonRepository<User> userRepository)
        {

            _logger = logger;
            _adminRepository = adminRepository;
            _userRepository = userRepository;
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
            
            if (HttpContext.Session.GetString("Admin") != null)
            {
                int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
                var valueAdmin = _adminRepository.GetPersonWithById(admin_id);
                ViewBag.AdminFirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(valueAdmin.FirstName);
                ViewBag.AdminLastName = valueAdmin.LastName.ToUpper();
                ViewBag.AdminID = admin_id;
            }

            else if (HttpContext.Session.GetString("User") !=null)
            {
                int user_id = int.Parse(HttpContext.Session.GetString("User"));
                var valueUser = _userRepository.GetPersonWithById(user_id);
                ViewBag.UserFirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(valueUser.FirstName);
                ViewBag.UserLastName = valueUser.LastName.ToUpper();
            }
            


            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }





}
