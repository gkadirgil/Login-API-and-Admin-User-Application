using AutoMapper;
using LOGIN.DATA.Models;
using LoginApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApplication.AutoMappers
{
    public class UserProfil:Profile
    {
        public UserProfil()
        {
            CreateMap<User, UserRegisterDTO>();
            CreateMap<UserRegisterDTO, User>();

            CreateMap<User, PersonLoginDTO>();
            CreateMap<PersonLoginDTO, User>();

            CreateMap<User, UserLoginDTO>();
            CreateMap<UserLoginDTO, User>();

            CreateMap<UserClaim, UserRequestDTO>();
            CreateMap<UserRequestDTO, UserClaim>();

            CreateMap<UserClaim, UserMyRequestDTO>();
            CreateMap<UserMyRequestDTO, UserClaim>();

        }
    }
}
