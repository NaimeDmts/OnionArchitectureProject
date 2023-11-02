using KatmanliSinavProject.BLL.DTOs.MakaleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.BLL.DTOs.KonuDTOs
{
    public class KonuDTO
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public IList<MakaleDTO> Makales { get; set; } 
    }
}
