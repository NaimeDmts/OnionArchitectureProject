using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.BLL.DTOs.MakaleDTOs
{
    public class MakaleCreateDTO
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime MakaleYazimTarihi { get; set; }
        public string AppUserId { get; set; }
        public int KonuId { get; set; }
    }
}
