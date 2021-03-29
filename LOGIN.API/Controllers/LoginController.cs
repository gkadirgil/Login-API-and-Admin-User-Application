using Data.Models;
using LOGIN.DATA.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LOGIN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Admin Login 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("LoginAdmin/{email}/{password}")]
        public ActionResult<Admin> LoginAdmin(string email, string password)
        {
            //UserServices userServices = new UserServices();
            LOGIN.SERVICES.AdminServices adminServices = new SERVICES.AdminServices();

            Admin data = new Admin();
            Login model = new Login() { Email = email, Password = password };
            data = adminServices.AdminLogin(model);
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

            //UserServices userServices = new UserServices();
            LOGIN.SERVICES.UserService userServices = new SERVICES.UserService();

            User data = new User();
            Login model = new Login() { Email = email, Password = password };

            data = userServices.UserLogin(model);

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
            LOGIN.SERVICES.UserService userServices = new SERVICES.UserService();

            if (userServices.CheckEmail(data.Email))
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
