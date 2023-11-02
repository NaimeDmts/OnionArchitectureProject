using KatmanliSinavProject.BLL.DTOs.AppUserDTOs;
using KatmanliSinavProject.BLL.DTOs.KonuDTOs;

namespace KatmanliSinavProject.UI.Models.ViewModels.MakaleVMs
{
    public class MakaleVM
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
