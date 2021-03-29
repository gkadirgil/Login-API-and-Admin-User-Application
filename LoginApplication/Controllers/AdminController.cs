using Data.Models;
using LOGIN.DATA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Security.Claims;

namespace LOGIN.APPLICATION.Controllers
{
    public class AdminController : Controller
    {
        LOGIN.SERVICES.AdminServices adminServices = new SERVICES.AdminServices();
        LOGIN.SERVICES.UserService userServices = new SERVICES.UserService();
        public IActionResult Index()
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }

            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = adminServices.GetAdminInfoNavBarWitById(admin_id);

            return View();

        }

        public IActionResult Inbox()
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }

            var data = userServices.GetUserRequsetListFalse();
            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = adminServices.GetAdminInfoNavBarWitById(admin_id);
            
            return View(data);

        }

        public IActionResult InboxDetail(int id)
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }

            var data = userServices.GetUserRequestWithById(id);

            string path = Path.Combine(Directory.GetCurrentDirectory(), data.DocumentPath);
            data.UserDocument = Path.GetFileName(path);

            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = adminServices.GetAdminInfoNavBarWitById(admin_id);
            return View("InboxDetail", data);
        }

        [HttpGet]
        public IActionResult Sent()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Sent(UserClaim data)
        {

            LOGAPDBContext context = new LOGAPDBContext();
            LOGIN.SERVICES.MailServices mailServices = new LOGIN.SERVICES.MailServices();

            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));

            var valueAdmin = adminServices.GetAdminWithById(admin_id);
            var valueUser = userServices.GetUserWithById(data.UserId);


            var newData = context.UserClaims.Find(data.ClaimId);
            newData.FirstName = data.FirstName;
            newData.LastName = data.LastName;
            newData.UserDescription = data.UserDescription;
            newData.DocumentPath = data.DocumentPath;
            newData.UserId = data.UserId;
            newData.RequestDate = data.RequestDate;
            newData.VerificationDate = DateTime.Now;
            newData.IsActive = true;
            newData.Status = data.Status;
            newData.AdminDescription = data.AdminDescription;
            newData.AdminDetail = valueAdmin.FirstName + " " + valueAdmin.LastName;


            MailModel mailing = new MailModel();
            mailing.AdminName = valueAdmin.FirstName + " " + valueAdmin.LastName;
            mailing.FullName = newData.FirstName + " " + newData.LastName;
            mailing.FromMail = valueAdmin.Email;
            mailing.ToMail = valueUser.Email;
            mailing.MailContent = newData.AdminDescription;
            mailing.MailSubject = "You Have A Message From Admin";

            context.MailModels.Add(mailing);
            context.SaveChanges();

            mailServices.SendMail(mailing, valueAdmin.Email, valueAdmin.Password);

            ViewBag.AdminInfo = adminServices.GetAdminInfoNavBarWitById(admin_id);

            return RedirectToAction("Index");
        }

        public IActionResult SentDetail()
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }

            var data = userServices.GetUserRequsetListTrue();

            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = adminServices.GetAdminInfoNavBarWitById(admin_id);
            return View(data);
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
