using Data.Models;
using Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace LOGIN.APPLICATION.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            UserServices userServices = new UserServices();

            int user_id = int.Parse(HttpContext.Session.GetString("User"));
            var valueUser = userServices.GetUserWithById(user_id);
            ViewBag.FirstName = valueUser.FirstName.ToUpper();
            ViewBag.LastName = valueUser.LastName.ToUpper();
            return View();
        }
        
        [HttpGet]
        public IActionResult NewRequest()
        {
            UserServices userServices = new UserServices();
            int UserId = int.Parse(HttpContext.Session.GetString("User"));
            var valueUser = userServices.GetUserWithById(UserId);
            ViewBag.FirstName = valueUser.FirstName.ToUpper();
            ViewBag.LastName = valueUser.LastName.ToUpper();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewRequest(IFormFile file, UserClaim data)
        {
            

            LOGAPDBContext context = new LOGAPDBContext();

          

            if (file !=null)
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
            int UserId = int.Parse(HttpContext.Session.GetString("User"));
            UserServices userServices = new UserServices();
            var data = userServices.GetListUserClaimWithById(UserId);
            var valueUser = userServices.GetUserWithById(UserId);
            ViewBag.FirstName = valueUser.FirstName.ToUpper();
            ViewBag.LastName = valueUser.LastName.ToUpper();

            foreach (var item in data)
            {

                string path = Path.Combine(Directory.GetCurrentDirectory(), item.DocumentPath);
                item.UserDocument = Path.GetFileName(path);
            }

            return View(data);

        }
    }
}
