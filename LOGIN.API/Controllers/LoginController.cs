using Data.Models;
using LOGIN.DATA.Models;
using LOGIN.SERVICES;
using LOGIN.SERVICES.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LOGIN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IPersonRepository<Admin> _adminRepository;
        private readonly IPersonRepository<User> _userRepository;
        private readonly IMailRepository _mailRepository;
        public LoginController(IPersonRepository<Admin> adminRepository, IPersonRepository<User> userRepository, IMailRepository mailRepository)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _mailRepository = mailRepository;
        }

        /// <summary>
        /// Admin Login 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("LoginAdmin/{email}/{password}")]
        public ActionResult<Admin> LoginAdmin(string email, string password)
        {
            Admin data = new Admin();
            Login model = new Login() { Email = email, Password = password };
            //data = adminServices.AdminLogin(model);
            data = _adminRepository.PersonLogin(email, password);

            return data;
        }

        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("LoginUser/{email}/{password}")]
        public ActionResult<User> LoginUser(string email, string password)
        {

            User data = new User();
            Login model = new Login() { Email = email, Password = password };

            //data = userServices.UserLogin(model);
            data = _userRepository.PersonLogin(email, password);

            return data;
        }

        /// <summary>
        /// User Register
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("{data}")]
        public User Register([FromBody] User data)
        {
            // TO DO: KAYIT İŞLEMLERİ YAPILIRKEN ENCRYPT İŞLEMLERİ YAPILACAK...


            LOGAPDBContext context = new LOGAPDBContext();

            if (_mailRepository.CheckEmail(data.Email))
            {
                data.IsActive = true;
                data.RegisterTime = DateTime.Now;
                context.Users.Add(data);
                context.SaveChanges();

                return data;
            }

            return null;
        }

    }
}
