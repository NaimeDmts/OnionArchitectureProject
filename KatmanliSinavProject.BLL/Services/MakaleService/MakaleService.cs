using AutoMapper;
using KatmanliSinavProject.BLL.DTOs.MakaleDTOs;
using KatmanliSinavProject.BLL.Utilities;
using KatmanliSinavProject.Core.Entities.Concretes;
using KatmanliSinavProject.Core.Enums;
using KatmanliSinavProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.BLL.Services.MakaleService
{
    public class MakaleService : IMakaleService
    {
        private readonly IMakaleRepository _repo;
        private readonly IMapper _mapper;

        public MakaleService(IMakaleRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IList<MakaleDTO> GetAll()
        {
           IList<Makale> makaleList = _repo.GetAll();
            IList<MakaleDTO> makaleDTOs = _mapper.Map<IList<Makale>, IList<MakaleDTO>>(makaleList);
            return makaleDTOs;
        }

        public IList<MakaleDTO> GetKonuMakales(int konuId)
        {
            if (konuId != null)
            {
                IList<Makale> makaleList = _repo.GetKonuMakales(konuId);
                IList<MakaleDTO> makaleDTOs = _mapper.Map<IList<Makale>, IList<MakaleDTO>>(makaleList);
                return makaleDTOs;
            }
            else
            {
                throw new Exception("User Id Boş");
            }
        }

        public IList<MakaleDTO> GetNotPassiveAll()
        {
            IList<Makale> makaleList = _repo.GetNotPassives();
            IList<MakaleDTO> makaleDTOs = _mapper.Map<IList<Makale>, IList<MakaleDTO>>(makaleList);
            return makaleDTOs;
        }

        public IList<MakaleDTO> GetRastgeleMakale()
        {
            IList<Makale> makaleList = _repo.GetRastgeleMakale();
            IList<MakaleDTO> makaleDTOs = _mapper.Map<IList<Makale>, IList<MakaleDTO>>(makaleList);
            return makaleDTOs;
        }

        public IList<MakaleDTO> GetUserMakales(string UserId)
        {
            if (UserId != null)
            {
                IList<Makale> makaleList = _repo.GetUserMakales(UserId);
                IList<MakaleDTO> makaleDTOs = _mapper.Map<IList<Makale>, IList<MakaleDTO>>(makaleList);
                return makaleDTOs;
            }
            else
            {
                throw new Exception("User Id Boş");
            }
        }

        public bool MakaleAdd(MakaleCreateDTO makaleDTO)
        {
            if (makaleDTO != null)
            {
                Makale makale = _mapper.Map<Makale>(makaleDTO);
                makale.OrtalamaOkumaSuresi = MakaleIslem.HesaplaOrtalamaOkumaSuresi(makaleDTO.Icerik);
                return _repo.Add(makale);
            }
            else
            {
                throw new Exception("Boş MakaleDTO göderimi ekleme başarısız.");
            }
        }

        public void MakaleDelete(int id)
        {
            Makale makale = _repo.MakaleGetById(id);
            if (makale != null)
            {
                makale.Status =Status.Passive;
                makale.DeleteDate = DateTime.Now;
                _repo.Delete(makale);
            }
            else
            {
                throw new Exception("Id ye ait Makale Bulunmamaktadır. silme işlemi başarısız");
            }
        }

        public MakaleDTO MakaleGetById(int id)
        {
            Makale makale = _repo.MakaleGetById(id);
            if (makale != null)
            { 
                MakaleDTO makaleDTO = _mapper.Map<MakaleDTO>(makale);
                return makaleDTO;
            }
            else
            {
                throw new Exception("Id ye ait Makale Bulunmamaktadır");
            }
        }

        public bool MakaleUpdate(MakaleUpdateDTO makaleDTO)
        {
            Makale makale = _mapper.Map<Makale>(makaleDTO);
            if (makale != null)
            {
                makale.OrtalamaOkumaSuresi = MakaleIslem.HesaplaOrtalamaOkumaSuresi(makaleDTO.Icerik);
                makale.Status = Status.Modified;
                makale.ModifiedDate = DateTime.Now;
                 return _repo.Update(makale);
            }
            else
            {
                throw new Exception("Update işlemi için değişiklik bulunmamaktadır.");
            }
         
        }
    }
}
