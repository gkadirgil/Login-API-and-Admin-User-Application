using LOGIN.DATA.Models;
using LOGIN.SERVICES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace LoginApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExportController : Controller
    {
        private readonly IPersonRepository<Admin> _adminRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ExportController(IPersonRepository<Admin> adminRepository, IHostingEnvironment hostingEnvironment)
        {
            _adminRepository = adminRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        LOGAPDBContext context = new LOGAPDBContext();
        public IActionResult Index()
        {
            int AdminId = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = _adminRepository.GetPersonInfoNavBarWitById(AdminId);

            return View();
        }
        public IActionResult UserClaimAll()
        {
            var data = context.UserClaims.Where(w => w.IsActive == true).ToList();

            int AdminId = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = _adminRepository.GetPersonInfoNavBarWitById(AdminId);
            return View(data);
        }
        public IActionResult UserClaimPos()
        {
            var data = context.UserClaims.Where(w => w.IsActive == true && w.Status=="Positive").ToList();

            int AdminId = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = _adminRepository.GetPersonInfoNavBarWitById(AdminId);
            return View(data);
        }
        public IActionResult UserClaimNeg()
        {
            var data = context.UserClaims.Where(w => w.IsActive == true && w.Status== "Negative").ToList();

            int AdminId = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = _adminRepository.GetPersonInfoNavBarWitById(AdminId);
            return View(data);
        }
        public IActionResult ExportPDFAll()
        {
           
            var data = context.UserClaims.Where(w => w.IsActive == true).ToList();
            return new Rotativa.AspNetCore.ViewAsPdf("UserClaimAll","Export", data);
        }
        public IActionResult ExportPDFPoz()
        {
            var data = context.UserClaims.Where(w => w.IsActive == true).ToList();
            return new Rotativa.AspNetCore.ViewAsPdf("UserClaimPos", data);
        }
        public IActionResult ExportPDFNeg()
        {
            var data = context.UserClaims.Where(w => w.IsActive == true).ToList();
            return new Rotativa.AspNetCore.ViewAsPdf("UserClaimNeg", data);
        }


    }
}
