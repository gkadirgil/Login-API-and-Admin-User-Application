using Data.Models;
using Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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

            UserServices userServices = new UserServices();

            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = userServices.GetAdminInfoNavBarWitById(admin_id);

            return View();
        }
        public IActionResult UserClaimAll()
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }

            UserServices userServices = new UserServices();

            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = userServices.GetAdminInfoNavBarWitById(admin_id);

            LOGAPDBContext context = new LOGAPDBContext();
            var data = context.UserClaims.Where(w => w.IsActive == true).ToList();
            return View(data);
        }
        public IActionResult UserClaimPos()
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }

            UserServices userServices = new UserServices();

            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = userServices.GetAdminInfoNavBarWitById(admin_id);

            LOGAPDBContext context = new LOGAPDBContext();
            var data = context.UserClaims.Where(w => w.IsActive == true && w.Status=="Positive").ToList();
            return View(data);
        }
        public IActionResult UserClaimNeg()
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }

            UserServices userServices = new UserServices();

            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = userServices.GetAdminInfoNavBarWitById(admin_id);

            LOGAPDBContext context = new LOGAPDBContext();
            var data = context.UserClaims.Where(w => w.IsActive == true && w.Status== "Negative").ToList();
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
        public string AdminAuth()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var role = identity.FindFirst(ClaimTypes.Role).Value;

            return role;
        }



    }
}
