using Data.Models;
using LOGIN.DATA.Models;
using LOGIN.SERVICES;
using LOGIN.SERVICES.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;


namespace LOGIN.APPLICATION.Controllers
{
    public class UserController : Controller
    {
        private readonly IPersonRepository<User> _userRepository;
        private readonly IUserRequestRepository _userRequestRepository;
        private readonly IFileRepository _fileRepository;

        public UserController(IPersonRepository<User> userRepository, IUserRequestRepository userRequestRepository, IFileRepository fileRepository)
        {
            _userRepository = userRepository;
            _userRequestRepository = userRequestRepository;
            _fileRepository = fileRepository;
        }
        public IActionResult Index()
        {
            string role = UserAuth();
            if (role == "Admin")
            {
                return RedirectToAction("Index", "Admin");
            }

            int UserId = int.Parse(HttpContext.Session.GetString("User"));
            ViewBag.UserInfo = _userRepository.GetPersonInfoNavBarWitById(UserId);

            return View();
        }

        [HttpGet]
        public IActionResult NewRequest()
        {
            int UserId = int.Parse(HttpContext.Session.GetString("User"));
            ViewBag.UserInfo = _userRepository.GetPersonInfoNavBarWitById(UserId);

            string role = UserAuth();
            if (role == "Admin")
            {
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewRequest(IFormFile file, UserClaim data)
        {
            int UserId = int.Parse(HttpContext.Session.GetString("User"));
            ViewBag.UserInfo = _userRepository.GetPersonInfoNavBarWitById(UserId);

            LOGAPDBContext context = new LOGAPDBContext();

            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (_fileRepository.FileExtentionControl(fileExtension))
                {
                    ViewBag.FileExtentionError = fileExtension+" is invalid file type";
                    return NewRequest();
                }

                string fileName = Path.GetFileName(file.FileName);
                data.DocumentPath = (string)(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/files/{fileName}"));
                using var stream = new FileStream(data.DocumentPath, FileMode.Create);
                await file.CopyToAsync(stream);

            }
            else
            {
               
                return NewRequest();
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
            ViewBag.UserInfo = _userRepository.GetPersonInfoNavBarWitById(UserId);
            string role = UserAuth();
            if (role == "Admin")
            {
                return RedirectToAction("Index", "Admin");
            }

            var data = _userRequestRepository.GetListUserRequestWithById(UserId);
            foreach (var item in data)
            {

                string path = Path.Combine(Directory.GetCurrentDirectory(), item.DocumentPath);
                item.UserDocument = Path.GetFileName(path);
            }

            return View(data);

        }

        [NonAction]
        public string UserAuth()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var role = identity.FindFirst(ClaimTypes.Role).Value;

            return role;
        }


    }
}
