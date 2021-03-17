using Data.Models;
using Data.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
            UserServices userServices = new UserServices();
            Admin data = new Admin();
            Login model = new Login() { Email = email, Password = password };
            data = userServices.AdminLogin(model);
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
            UserServices userServices = new UserServices();
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
        [HttpPost]
        public Login Register([FromBody] User data)
        {
            
            Login model = new Login();
            LOGAPDBContext context = new LOGAPDBContext();
            UserServices userServices = new UserServices();
           
            if (userServices.CheckEmail(data.Email))
            {
                data.IsActive = true;
                data.RegisterTime = DateTime.Now;
                context.Users.Add(data);
                context.SaveChanges();
                model.Email = data.Email;
                model.Password = data.Password;
                return model;
            }

            else
                return null;
        }

  

    }
}
