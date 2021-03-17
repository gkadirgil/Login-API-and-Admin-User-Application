using Data.Models;
using Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApplication.Controllers
{
    public class ExportController : Controller
    {
        public IActionResult Index()
        {
            UserServices userServices = new UserServices();

            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            var valueAdmin = userServices.GetAdminWithById(admin_id);
            ViewBag.FirstName = valueAdmin.FirstName.ToUpper();
            ViewBag.LastName = valueAdmin.LastName.ToUpper();
            return View();
        }
        public IActionResult UserClaimAll()
        {
            string Key = "Admin";
            ViewBag.AdminInfo=GetAdminWithSessinKey(Key);

            LOGAPDBContext context = new LOGAPDBContext();
            var data = context.UserClaims.Where(w => w.IsActive == true).ToList();
            return View(data);
        }
        public IActionResult UserClaimPos()
        {
            string Key = "Admin";
            ViewBag.AdminInfo = GetAdminWithSessinKey(Key);

            LOGAPDBContext context = new LOGAPDBContext();
            var data = context.UserClaims.Where(w => w.IsActive == true && w.Status=="Positive").ToList();
            return View(data);
        }
        public IActionResult UserClaimNeg()
        {
            string Key = "Admin";
            ViewBag.AdminInfo = GetAdminWithSessinKey(Key);

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

        public string GetAdminWithSessinKey(string key)
        {
            int Admin_ID = int.Parse(HttpContext.Session.GetString(key));
            Admin valueAdmin = new Admin();
            UserServices userServices = new UserServices();
            valueAdmin = userServices.GetAdminWithById(Admin_ID);
            string AdminName = valueAdmin.FirstName + " " + valueAdmin.LastName;

            return AdminName;
        }

    }
}
