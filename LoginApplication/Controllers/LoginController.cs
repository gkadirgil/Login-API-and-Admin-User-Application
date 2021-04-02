using AutoMapper;
using LOGIN.DATA.Models;
using LOGIN.SERVICES.IRepository;
using LoginApplication.Infrustructor;
using LoginApplication.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace LoginApplication.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IMailRepository _mailRepository;
        private readonly IMapper _mapper;

        public LoginController(IMailRepository mailRepository, IMapper mapper)
        {
            _mailRepository = mailRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult _PRegister()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> _PRegister(UserRegisterDTO model)
        {

            bool checkValue = _mailRepository.CheckEmail(model.Email);

            if (!checkValue)
            {

                return RedirectToAction("Error", "Home");
            }

            else
            {

                User data = _mapper.Map<User>(model);
                int UserId = Post<int>("Login/Register/", data);

                var claims = new List<Claim>
                {
                   new Claim(ClaimTypes.Role,"User")

                };

                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);

                HttpContext.Session.SetString("User", UserId.ToString());
                return RedirectToAction("Index", "User");
            }

        }

        [HttpGet]
        public IActionResult LoginUser()
        {

            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUser(PersonLoginDTO model)
        {


            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }


            var dataAdmin = Get<Admin>("Login/LoginAdmin/" + model.Email + "/" + model.Password);
            var dataUser = Get<User>("Login/LoginUser/" + model.Email + "/" + model.Password);


            if (dataAdmin != null)
            {

                HttpContext.Session.SetString("Admin", dataAdmin.AdminId.ToString());
                return RedirectToAction("Error", "Home");
            }

            else if (dataUser == null)
            {
                return RedirectToAction("Index", "Home");

            }
            else if (dataUser.UserId > 0)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, dataUser.Email),
                    new Claim(ClaimTypes.Role,"User")
                };

                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                Thread.CurrentPrincipal = principal;
                await HttpContext.SignInAsync(principal);

                HttpContext.Session.SetString("User", dataUser.UserId.ToString());
                ViewBag.FirstName = dataUser.FirstName.ToUpper();
                ViewBag.LastName = dataUser.LastName.ToUpper();


                return RedirectToAction("Index", "User");
            }

            return RedirectToAction("Index", "Home");

        }


        [HttpGet]
        public IActionResult LoginAdmin()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAdmin(PersonLoginDTO model)
        {


            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            var dataAdmin = Get<Admin>("Login/LoginAdmin/" + model.Email + "/" + model.Password);
            var dataUser = Get<User>("Login/LoginUser/" + model.Email + "/" + model.Password);

            if (dataUser != null)
            {
                HttpContext.Session.SetString("User", dataUser.UserId.ToString());

                return RedirectToAction("Error", "Home");
            }

            else if (dataAdmin == null)
            {
                return RedirectToAction("Index", "Home");

            }

            else if (dataAdmin.AdminId > 0)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, dataAdmin.Email),
                    new Claim(ClaimTypes.Role,"Admin")
                };

                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                Thread.CurrentPrincipal = principal;
                await HttpContext.SignInAsync(principal);

                HttpContext.Session.SetString("Admin", dataAdmin.AdminId.ToString());
                ViewBag.FirstName = dataAdmin.FirstName.ToUpper();
                ViewBag.LastName = dataAdmin.LastName.ToUpper();
                return RedirectToAction("Index", "Admin");
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }



    }
}
