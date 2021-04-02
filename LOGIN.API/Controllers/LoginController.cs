using AutoMapper;
using LOGIN.DATA.Models;
using LOGIN.SERVICES;
using LOGIN.SERVICES.IRepository;
using LoginApplication.Models.ViewModels;
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
        private readonly IMapper _mapper;
        public LoginController(IPersonRepository<Admin> adminRepository, IPersonRepository<User> userRepository, IMailRepository mailRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _mailRepository = mailRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Admin Login 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("LoginAdmin/{email}/{password}")]
        public ActionResult<AdminLoginDTO> LoginAdmin(string email, string password)
        {

            var data = _adminRepository.PersonLogin(email, password);
            AdminLoginDTO value = _mapper.Map<AdminLoginDTO>(data);

            return value;
        }

        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("LoginUser/{email}/{password}")]
        public ActionResult<UserLoginDTO> LoginUser(string email, string password)
        {

            var data = _userRepository.PersonLogin(email, password);
            UserLoginDTO value = _mapper.Map<UserLoginDTO>(data);

            return value;
        }

        /// <summary>
        /// User Register
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("{data}")]
        public int Register([FromBody] User data)
        {
            // TO DO: KAYIT İŞLEMLERİ YAPILIRKEN ENCRYPT İŞLEMLERİ YAPILACAK...

            LOGAPDBContext context = new LOGAPDBContext();

            data.IsActive = true;
            data.RegisterTime = DateTime.Now;
            context.Users.Add(data);
            context.SaveChanges();

            return data.UserId;

        }

    }
}
