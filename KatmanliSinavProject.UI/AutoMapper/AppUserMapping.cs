using AutoMapper;
using KatmanliSinavProject.BLL.DTOs.AppUserDTOs;
using KatmanliSinavProject.Core.Entities.Concretes;
using KatmanliSinavProject.UI.Models.ViewModels.UserVMs;

namespace KatmanliSinavProject.UI.AutoMapper
{
    public class AppUserMapping :Profile
    {
        public AppUserMapping()
        {
            CreateMap<RegisterDTO, RegisterVM>().ReverseMap();
            CreateMap<LoginDTO, LoginVM>().ReverseMap();
            CreateMap<AppUserDTO, AppUserVM>().ForMember(desc=>desc.Makales, opt=>opt.MapFrom(m=>m.Makales)).ReverseMap();
            CreateMap<AppUserDTO, AppUserUpdateVM>().ReverseMap();
            CreateMap<AppUserUpdateDTO, AppUserUpdateVM>().ReverseMap();
        }
    
    }
}
