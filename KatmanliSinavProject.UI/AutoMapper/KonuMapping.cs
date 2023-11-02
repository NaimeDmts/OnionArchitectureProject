using AutoMapper;
using KatmanliSinavProject.BLL.DTOs.KonuDTOs;
using KatmanliSinavProject.UI.Models.ViewModels.KonuVMs;

namespace KatmanliSinavProject.UI.AutoMapper
{
    public class KonuMapping :Profile
    {
        public KonuMapping()
        {
            CreateMap<KonuDTO, KonuVM>().ForMember(desc => desc.Makales, opt => opt.MapFrom(m => m.Makales)).ReverseMap();
            CreateMap<KonuUpdateDTO,KonuUpdateVM>().ReverseMap();
            CreateMap<KonuCreateDTO, KonuCreateVM>().ReverseMap();
            CreateMap<KonuDTO, KonuUpdateVM>().ReverseMap();
        }
    }
}
