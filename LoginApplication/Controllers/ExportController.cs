using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace LoginApplication.Controllers
{
    public class ExportController : Controller
    {
        public IActionResult Index()
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }

            ViewBag.AdminInfo = TempData["AdminInfo"];

            return View();
        }
        public IActionResult UserClaimAll()
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }
            
            LOGAPDBContext context = new LOGAPDBContext();
            var data = context.UserClaims.Where(w => w.IsActive == true).ToList();

            ViewBag.AdminInfo = TempData["AdminInfo"];
            return View(data);
        }
        public IActionResult UserClaimPos()
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }

            LOGAPDBContext context = new LOGAPDBContext();
            var data = context.UserClaims.Where(w => w.IsActive == true && w.Status=="Positive").ToList();

            ViewBag.AdminInfo = TempData["AdminInfo"];
            return View(data);
        }
        public IActionResult UserClaimNeg()
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }

            LOGAPDBContext context = new LOGAPDBContext();
            var data = context.UserClaims.Where(w => w.IsActive == true && w.Status== "Negative").ToList();

            ViewBag.AdminInfo = TempData["AdminInfo"];
            return View(data);
        }
        public IActionResult ExportPDFAll()
        {
           
            LOGAPDBContext context = new LOGAPDBContext();
            var data = context.UserClaims.Where(w => w.IsActive == true).ToList();
            return new Rotativa.AspNetCore.ViewAsPdf("UserClaimAll","Export", data);
        }
        public IActionResult ExportPDFPoz()
        {
            LOGAPDBContext context = new LOGAPDBContext();
            var data = context.UserClaims.Where(w => w.IsActive == true).ToList();
            return new Rotativa.AspNetCore.ViewAsPdf("UserClaimPos", data);
        }
        public IActionResult ExportPDFNeg()
        {
            LOGAPDBContext context = new LOGAPDBContext();
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
