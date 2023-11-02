using AutoMapper;
using KatmanliSinavProject.BLL.DTOs.KonuDTOs;
using KatmanliSinavProject.BLL.DTOs.KonuDTOs;
using KatmanliSinavProject.BLL.Utilities;
using KatmanliSinavProject.Core.Entities.Concretes;
using KatmanliSinavProject.Core.Enums;
using KatmanliSinavProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.BLL.Services.KonuService
{
    public class KonuService : IKonuService
    {
        private readonly IKonuRepository _repo;
        private readonly IMapper _mapper;

        public KonuService(IKonuRepository repo, IMapper mapping)
        {
            _repo = repo;
            _mapper = mapping;
        }

        public IList<KonuDTO> GetAll()
        {
            IList<Konu> konuList = _repo.GetAll();
            IList<KonuDTO> konuDTOs = _mapper.Map<IList<Konu>, IList<KonuDTO>>(konuList);
            return konuDTOs;
        }

        public IList<KonuDTO> GetNotPassiveAll()
        {
            IList<Konu> konuList = _repo.GetNotPassives();
            IList<KonuDTO> konuDTOs = _mapper.Map<IList<Konu>, IList<KonuDTO>>(konuList);
            return konuDTOs;
        }

        public bool KonuAdd(KonuCreateDTO konuDTO)
        {
            if (konuDTO != null)
            {
                Konu konu = _mapper.Map<Konu>(konuDTO);
                return _repo.Add(konu);
            }
            else
            {
                throw new Exception("Boş KonuDTO göderimi ekleme başarısız.");
            }
        }

        public void KonuDelete(int id)
        {
            Konu konu = _repo.KonuGetById(id);
            if (konu != null)
            {
                konu.Status = Status.Passive;
                konu.DeleteDate = DateTime.Now;
                _repo.Delete(konu);
            }
            else
            {
                throw new Exception("Id ye ait Konu Bulunmamaktadır. silme işlemi başarısız");
            }
        }

        public KonuDTO KonuGetById(int id)
        {
            Konu konu = _repo.KonuGetById(id);
            if (konu != null)
            {
                KonuDTO konuDTO = _mapper.Map<KonuDTO>(konu);
                return konuDTO;
            }
            else
            {
                throw new Exception("Id ye ait Konu Bulunmamaktadır. silme işlemi başarısız");
            }
        }

        public bool KonuUpdate(KonuUpdateDTO konuDTO)
        {
            
            if (konuDTO != null)
            {
                Konu konu = _mapper.Map<Konu>(konuDTO);
                konu.Status = Status.Modified;
                konu.ModifiedDate = DateTime.Now;
                 return _repo.Update(konu);
            }
            else
            {
                throw new Exception("Id ye ait Konu Bulunmamaktadır. silme işlemi başarısız");
            }
        }
    }
}
