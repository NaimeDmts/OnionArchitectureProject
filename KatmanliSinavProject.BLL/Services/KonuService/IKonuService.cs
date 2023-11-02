using KatmanliSinavProject.BLL.DTOs.KonuDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.BLL.Services.KonuService
{
    public interface IKonuService
    {
        public bool KonuAdd(KonuCreateDTO konuDTO);
        public bool KonuUpdate(KonuUpdateDTO konuDTO);
        public void KonuDelete(int id);
        public KonuDTO KonuGetById(int id);
        public IList<KonuDTO> GetAll();
        public IList<KonuDTO> GetNotPassiveAll();
    }
}
