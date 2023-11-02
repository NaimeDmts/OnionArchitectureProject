

using KatmanliSinavProject.UI.Models.ViewModels.MakaleVMs;

namespace KatmanliSinavProject.UI.Models.ViewModels.KonuVMs
{
    public class KonuVM
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public IList<MakaleVM> Makales { get; set; }
    }
}
