using AutoMapper;
using LOGIN.DATA.Models;
using LoginApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApplication.AutoMappers
{
    public class AdminProfil:Profile
    {
        public AdminProfil()
        {
            CreateMap<Admin, PersonLoginDTO>();
            CreateMap<PersonLoginDTO, Admin>();

            CreateMap<Admin, AdminLoginDTO>();
            CreateMap<AdminLoginDTO, Admin>();
        }
    }
}
