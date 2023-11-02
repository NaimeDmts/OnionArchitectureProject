using KatmanliSinavProject.UI.Models.ViewModels.KonuVMs;
using KatmanliSinavProject.UI.Models.ViewModels.UserVMs;

namespace KatmanliSinavProject.UI.Models.ViewModels.MakaleVMs
{
    public class MakaleCreateVM
    {
        public MakaleCreateVM()
        {
            Konus =new List<KonuVM>();
        }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime MakaleYazimTarihi { get; set; }
        public string AppUserId { get; set; }
        public int KonuId { get; set; }

        public List<KonuVM> Konus { get; set; }
        public AppUserVM AppUser { get; set; }
    }
}
