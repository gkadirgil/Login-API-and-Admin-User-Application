﻿using Data.Models;
using LOGIN.DATA.Models;
using LOGIN.SERVICES;
using LOGIN.SERVICES.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Security.Claims;

namespace LOGIN.APPLICATION.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPersonRepository<Admin> _adminRepository;
        private readonly IPersonRepository<User> _userRepository;
        private readonly IUserRequestRepository _userRequestRepository;
        private readonly IMailRepository _mailRepository;
        public AdminController(IPersonRepository<Admin> adminRepository, IPersonRepository<User> userRepository, IUserRequestRepository userRequestRepository, IMailRepository mailRepository)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _userRequestRepository = userRequestRepository;
            _mailRepository = mailRepository;
        }
        
        public IActionResult Index()
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }

            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = _adminRepository.GetPersonInfoNavBarWitById(admin_id);

            return View();

        }

        public IActionResult Inbox()
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }

            var data = _userRequestRepository.GetUserRequsetListFalse();
            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            //ViewBag.AdminInfo = adminServices.GetAdminInfoNavBarWitById(admin_id);
            ViewBag.AdminInfo = _adminRepository.GetPersonInfoNavBarWitById(admin_id);

            return View(data);

        }

        public IActionResult InboxDetail(int id)
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }

            var data = _userRequestRepository.GetUserRequestWithById(id);

            string path = Path.Combine(Directory.GetCurrentDirectory(), data.DocumentPath);
            data.UserDocument = Path.GetFileName(path);

            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = _adminRepository.GetPersonInfoNavBarWitById(admin_id);

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
            

            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            var valueAdmin = _adminRepository.GetPersonWithById(admin_id);
            var valueUser = _userRepository.GetPersonWithById(data.UserId);


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

            _mailRepository.SendMail(mailing, valueAdmin.Email, valueAdmin.Password);
            ViewBag.AdminInfo = _adminRepository.GetPersonInfoNavBarWitById(admin_id);

            return RedirectToAction("Index");
        }

        public IActionResult SentDetail()
        {
            string role = AdminAuth();
            if (role == "User")
            {
                return RedirectToAction("Index", "User");
            }

            var data = _userRequestRepository.GetUserRequsetListTrue();

            int admin_id = int.Parse(HttpContext.Session.GetString("Admin"));
            ViewBag.AdminInfo = _adminRepository.GetPersonInfoNavBarWitById(admin_id);

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
