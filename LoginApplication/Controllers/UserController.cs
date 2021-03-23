using Data.Models;
using Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;


namespace LOGIN.APPLICATION.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Index()
        {
            string role = UserAuth();
            if (role == "Admin")
            {
                return RedirectToAction("Index", "Admin");
            }

            LOGIN.SERVICES.UserService userServices = new LOGIN.SERVICES.UserService();

            int UserId = int.Parse(HttpContext.Session.GetString("User"));
            ViewBag.UserInfo = userServices.GetUserInfoNavBarWitById(UserId);

            return View();
        }

        [HttpGet]
        public IActionResult NewRequest()
        {
            string role = UserAuth();
            if (role == "Admin")
            {
                return RedirectToAction("Index", "Admin");
            }

            LOGIN.SERVICES.UserService userServices = new LOGIN.SERVICES.UserService();

            int UserId = int.Parse(HttpContext.Session.GetString("User"));
            ViewBag.UserInfo = userServices.GetUserInfoNavBarWitById(UserId);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewRequest(IFormFile file, UserClaim data)
        {


            LOGAPDBContext context = new LOGAPDBContext();



            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                string fileName = Guid.NewGuid() + fileExtension;

                data.DocumentPath = (string)(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/files/{fileName}"));
                using var stream = new FileStream(data.DocumentPath, FileMode.Create);
                await file.CopyToAsync(stream);

            }


            data.RequestDate = DateTime.Now;
            data.UserId = int.Parse(HttpContext.Session.GetString("User"));
            context.UserClaims.Add(data);
            context.SaveChanges();


            return RedirectToAction("Index");
        }

        public IActionResult MyRequests()
        {
            string role =UserAuth();
            if (role == "Admin")
            {
                return RedirectToAction("Index", "Admin");
            }

            LOGIN.SERVICES.UserService userServices = new SERVICES.UserService();
            int UserId = int.Parse(HttpContext.Session.GetString("User"));
            ViewBag.UserInfo = userServices.GetUserInfoNavBarWitById(UserId);

            var data = userServices.GetListUserRequestWithById(UserId);
            foreach (var item in data)
            {

                string path = Path.Combine(Directory.GetCurrentDirectory(), item.DocumentPath);
                item.UserDocument = Path.GetFileName(path);
            }

            return View(data);

        }

        public string UserAuth()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var role = identity.FindFirst(ClaimTypes.Role).Value;

            return role;
        }


    }
}
