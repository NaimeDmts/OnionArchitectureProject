using AutoMapper;
using KatmanliSinavProject.BLL.DTOs.MakaleDTOs;
using KatmanliSinavProject.UI.Models.ViewModels.MakaleVMs;

namespace KatmanliSinavProject.UI.AutoMapper
{
    public class MakaleMapping :Profile
    {
        public MakaleMapping()
        {
            CreateMap<MakaleCreateDTO, MakaleCreateVM>().ForMember(desc => desc.Konus, opt => opt.Ignore()).ReverseMap();
            CreateMap<MakaleUpdateDTO, MakaleUpdateVM>().ForMember(desc => desc.Konus, opt => opt.Ignore()).ReverseMap();
            CreateMap<MakaleUpdateDTO, MakaleUpdateVM>().ReverseMap();
            CreateMap<MakaleDTO, MakaleVM>().ForMember(desc => desc.AppUser, opt => opt.MapFrom(m => m.AppUser)).ForMember(desc => desc.Konu, opt => opt.MapFrom(m => m.Konu)).ReverseMap();
            CreateMap<MakaleDTO,MakaleUpdateVM>().ForMember(desc=>desc.Konus, opt=>opt.Ignore()).ReverseMap();
        }
    }
}
