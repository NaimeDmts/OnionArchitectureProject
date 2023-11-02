using KatmanliSinavProject.UI.Models.ViewModels.KonuVMs;

namespace KatmanliSinavProject.UI.Models.ViewModels.MakaleVMs
{
    public class MakaleUpdateVM
    {
        public MakaleUpdateVM()
        {
            Konus = new List<KonuVM>();
        }
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public int KonuId { get; set; }
        public List<KonuVM> Konus { get; set; }
        public string AppUserId { get; set; }
    }
}
