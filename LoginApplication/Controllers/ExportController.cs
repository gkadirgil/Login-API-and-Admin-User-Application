using Data.Models;
using LOGIN.DATA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace LoginApplication.Controllers
{
    public class ExportController : Controller
    {
        LOGIN.SERVICES.AdminServices adminServices = new LOGIN.SERVICES.AdminServices();
        LOGAPDBContext context = new LOGAPDBContext();
        public IActionResult Index()
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }

            int AdminId = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = adminServices.GetAdminInfoNavBarWitById(AdminId);

            return View();
        }
        public IActionResult UserClaimAll()
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }
            
            var data = context.UserClaims.Where(w => w.IsActive == true).ToList();

            int AdminId = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = adminServices.GetAdminInfoNavBarWitById(AdminId);
            return View(data);
        }
        public IActionResult UserClaimPos()
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }

            var data = context.UserClaims.Where(w => w.IsActive == true && w.Status=="Positive").ToList();

            int AdminId = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = adminServices.GetAdminInfoNavBarWitById(AdminId);
            return View(data);
        }
        public IActionResult UserClaimNeg()
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }

            var data = context.UserClaims.Where(w => w.IsActive == true && w.Status== "Negative").ToList();

            int AdminId = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = adminServices.GetAdminInfoNavBarWitById(AdminId);
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

        [NonAction]
        public string AdminAuth()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var role = identity.FindFirst(ClaimTypes.Role).Value;

            return role;
        }



    }
}
