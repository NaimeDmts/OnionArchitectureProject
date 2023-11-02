using AutoMapper;
using KatmanliSinavProject.BLL.DTOs.AppUserDTOs;
using KatmanliSinavProject.Core.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.BLL.AutoMapper
{
    public class AppUserMapping : Profile
    {
        public AppUserMapping()
        {
            CreateMap<AppUser, RegisterDTO>().ReverseMap();
            CreateMap<AppUser, LoginDTO>().ReverseMap();
            CreateMap<AppUser, AppUserDTO>().ForMember(desc=>desc.Makales, opt=>opt.MapFrom(m=>m.Makales)).ReverseMap();
            CreateMap<AppUser, AppUserUpdateDTO>().ReverseMap();
        }
    }
}
