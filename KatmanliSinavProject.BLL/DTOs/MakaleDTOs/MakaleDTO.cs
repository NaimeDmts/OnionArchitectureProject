using KatmanliSinavProject.BLL.DTOs.AppUserDTOs;
using KatmanliSinavProject.BLL.DTOs.KonuDTOs;
using KatmanliSinavProject.Core.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.BLL.DTOs.MakaleDTOs
{
    public class MakaleDTO
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public double OrtalamaOkumaSuresi { get; set; }
        public DateTime MakaleYazimTarihi { get; set; }
        public string AppUserId { get; set; }
        public int KonuId { get; set; }

        public AppUserDTO AppUser { get; set; }
        public KonuDTO Konu { get; set; }
    }
}
