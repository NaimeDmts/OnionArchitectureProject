using AutoMapper;
using KatmanliSinavProject.BLL.DTOs.KonuDTOs;
using KatmanliSinavProject.Core.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.BLL.AutoMapper
{
    public class KonuMapping : Profile
    {
        public KonuMapping()
        {
            CreateMap<Konu, KonuDTO>().ForMember(desc => desc.Makales, opt => opt.MapFrom(m => m.Makales)).ReverseMap();
            CreateMap<Konu, KonuCreateDTO>().ReverseMap();
            CreateMap<Konu, KonuUpdateDTO>().ReverseMap();
        }
    }
}
