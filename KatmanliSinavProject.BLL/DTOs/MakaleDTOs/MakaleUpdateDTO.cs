using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.BLL.DTOs.MakaleDTOs
{
    public class MakaleUpdateDTO
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public int KonuId { get; set; }
        public string AppUserId { get; set; }
    }
}
