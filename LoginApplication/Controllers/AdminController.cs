using Data.Models;
using Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LOGIN.APPLICATION.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {

            UserServices userServices = new UserServices();

            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = userServices.GetAdminInfoNavBarWitById(admin_id);
            

            return View();

        }

        public IActionResult Inbox()
        {

            UserServices userServices = new UserServices();

            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = userServices.GetAdminInfoNavBarWitById(admin_id);

            var data = userServices.GetUserRequsetListFalse();

            return View(data);

        }

        public IActionResult InboxDetail(int id)
        {
            UserServices userServices = new UserServices();
            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = userServices.GetAdminInfoNavBarWitById(admin_id);

           
            var data = userServices.GetUserRequestWithById(id);
            string path = Path.Combine(Directory.GetCurrentDirectory(), data.DocumentPath);
            data.UserDocument = Path.GetFileName(path);

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
            UserServices userServices = new UserServices();

            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = userServices.GetAdminInfoNavBarWitById(admin_id);

            var valueAdmin = userServices.GetAdminWithById(admin_id);
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

            userServices.SendMail(mailing, valueAdmin.Email, valueAdmin.Password);

            

            return RedirectToAction("Index");
        }

        public IActionResult SentDetail()
        {
            UserServices userServices = new UserServices();

            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = userServices.GetAdminInfoNavBarWitById(admin_id);

            var data = userServices.GetUserRequsetListTrue();

            return View(data);
        }
    }
}
