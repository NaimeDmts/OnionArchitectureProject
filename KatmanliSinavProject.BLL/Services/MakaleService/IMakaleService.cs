using KatmanliSinavProject.BLL.DTOs.MakaleDTOs;
using KatmanliSinavProject.Core.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.BLL.Services.MakaleService
{
    public interface IMakaleService
    {
        public bool MakaleAdd(MakaleCreateDTO makaleDTO);
        public bool MakaleUpdate(MakaleUpdateDTO makaleDTO);
        public void MakaleDelete(int id);
        public MakaleDTO MakaleGetById(int id);
        public IList<MakaleDTO> GetAll();
        public IList<MakaleDTO> GetNotPassiveAll();
        public IList<MakaleDTO> GetUserMakales(string UserId);
        public IList<MakaleDTO> GetKonuMakales(int konuId);
        public IList<MakaleDTO> GetRastgeleMakale();
    }
}
