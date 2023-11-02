using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.BLL.Utilities
{
    public class MakaleIslem
    {
        public static double HesaplaOrtalamaOkumaSuresi(string Icerik)
        {

            double kelimeBasinaGecenSure = 0.3;
            int kelimeSayisi = Icerik.Split(new[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries).Length;

            double OrtalamaOkumaSuresi = kelimeSayisi * kelimeBasinaGecenSure;
            return OrtalamaOkumaSuresi;
        }
    }
}
