using AutoMapper;
using KatmanliSinavProject.BLL.DTOs.MakaleDTOs;
using KatmanliSinavProject.Core.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.BLL.AutoMapper
{
    public class MakaleMapping :Profile
    {
        public MakaleMapping()
        {
            CreateMap<Makale, MakaleDTO>().ForMember(desc => desc.AppUser, opt => opt.MapFrom(m => m.AppUser)).ForMember(desc => desc.Konu, opt => opt.MapFrom(m => m.Konu)).ReverseMap();
            CreateMap<Makale, MakaleCreateDTO>().ReverseMap();
            CreateMap<Makale, MakaleUpdateDTO>().ReverseMap();
            
        }
    }
}
